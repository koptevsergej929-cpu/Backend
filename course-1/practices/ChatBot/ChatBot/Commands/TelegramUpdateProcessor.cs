using ChatBot.Dto;
using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;
using System.Windows.Input;
using Telegram.Bot;

namespace ChatBot.Commands
{
    public class TelegramUpdateProcessor
    {
        private readonly IEnumerable<IBotCommand> _commands;
        private readonly ITelegramBotClient _botClient;
        private readonly IChatApiClient _chatClient;
        private readonly IChatModelRepository _chatModelRepository;
        private readonly ILogger<TelegramUpdateProcessor> _logger;


        public TelegramUpdateProcessor(
            IEnumerable<IBotCommand> commands,
            ITelegramBotClient botClient,
            IChatApiClient chatClient,
            IChatModelRepository chatModelRepository,
            ILogger<TelegramUpdateProcessor> logger)
        {
            _commands = commands;
            _botClient = botClient;
            _chatClient = chatClient;
            _chatModelRepository = chatModelRepository;
            _logger = logger;
        }

        public async Task HandleAsync(TelegramUpdate update)
        {
            var message = update.Message;
            if (message == null || string.IsNullOrEmpty(message.Text)) return;
            foreach (var command in _commands)
            {
                if (message.Text.StartsWith(command.Trigger))
                {
                    await command.ExecuteAsync(update, _botClient, message.Chat.Id);
                    return;
                }
            }



            if (update.Message == null)
                return;

            var chatId = update.Message.Chat.Id;
            var text = update.Message.Text.Trim();

            _logger.LogInformation("Получено сообщение от чата {ChatId}: {Text}", chatId, text);

            if (text.StartsWith("/"))
            {
                var cmd = text.Split(' ', 2)[0];
                var command = _commands.FirstOrDefault(c => c.Trigger.Equals(cmd, StringComparison.OrdinalIgnoreCase));
                if (command != null)
                {
                    _logger.LogInformation("Выполняется команда {Command}", cmd);
                    await command.ExecuteAsync(update, _botClient, chatId);
                    return;
                }
                else
                {
                    _logger.LogWarning("Неизвестная команда: {Command}", cmd);
                    await _botClient.SendTextMessageAsync(chatId, "Неизвестная команда. Используйте /help");
                    return;
                }
            }

            
            await _chatModelRepository.AddMessageAsync(chatId, new OpenApiResponse.Message { Role = "user", Content = text });
            var history = await _chatModelRepository.GetHistoryAsync(chatId);
            try
            {
                
                _logger.LogInformation("Отправка запроса в Chat API");
                var result = await _chatClient.SendMessageAsync(text, history);

                await _chatModelRepository.AddMessageAsync(chatId, new OpenApiResponse.Message { Role = "assistant", Content = result });

                _logger.LogInformation("Ответ отправлен пользователю");
                await _botClient.SendTextMessageAsync(chatId, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при вызове Chat API");
                await _botClient.SendTextMessageAsync(chatId, "Ошибка при вызове Chat API: " + ex.Message);
            }

        }
    }
}
    

