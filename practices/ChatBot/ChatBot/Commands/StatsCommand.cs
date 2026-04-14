using ChatBot.Dto;
using ChatBot.Repositories.Interfaces;
using Telegram.Bot;

namespace ChatBot.Commands
{
    public class StatsCommand : IBotCommand
    {
        private readonly IChatModelRepository _chatModelRepository;
        public StatsCommand(IChatModelRepository chatModelRepository)
        {
            _chatModelRepository = chatModelRepository;
        }
        public string Trigger => "/stats";
        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient botClient, long chatId)
        {
            var statistics = await _chatModelRepository.GetChatStatisticsAsync(chatId);

            await botClient.SendTextMessageAsync(chatId, $"{statistics.TotalTokens}, {statistics.TotalMessages}");
        }
    }
}
