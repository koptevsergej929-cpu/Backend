using ChatBot.Dto;
using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;
using System.Collections.Concurrent;

namespace ChatBot.Repositories.Implementations
{
    public class ChatModelRepository : IChatModelRepository
    {
        private readonly ConcurrentDictionary<long, List<OpenApiResponse.Message>> _store = new();
        private readonly ILogger<ChatModelRepository> _logger;

        public ChatModelRepository(ILogger<ChatModelRepository> logger)
        {
            _logger = logger;
        }

        public Task AddMessageAsync(long chatId, OpenApiResponse.Message message)
        {
            _logger.LogInformation("Сохранение сообщения от чата {ChatId}: {Role}", chatId, message.Role);
            var list = _store.GetOrAdd(chatId, _ => new List<OpenApiResponse.Message>());
            lock (list)
            {
                list.Add(message);
            }
            return Task.CompletedTask;
        }

        public Task<List<OpenApiResponse.Message>> GetHistoryAsync(long chatId)
        {
            _logger.LogInformation("Загрузка истории для чата {ChatId}", chatId);
            _store.TryGetValue(chatId, out var list);
            return Task.FromResult(list == null ? new List<OpenApiResponse.Message>() : new List<OpenApiResponse.Message>(list));
        }

        public Task<ChatStatistics> GetChatStatisticsAsync(long chatId)
        {
            _store.TryGetValue(chatId, out var list);

            var stats = new ChatStatistics();

            foreach (var i in list)
            {
                var charsCount = i.Content.Length;
                stats.TotalTokens += charsCount / 3;
            }

            _logger.LogInformation($"Кол-во сообщений: {stats.TotalMessages}, Кол-во токенов: {stats.TotalTokens}");
            return Task.FromResult(stats);
        }

        public Task ClearHistoryAsync(long chatId)
        {
            _logger.LogInformation("Очистка истории для чата {ChatId}", chatId);
            _store.TryRemove(chatId, out _);
            return Task.CompletedTask;
        }

        public Task<bool> RemoveLastMessageAsync(long chatId)
        {
            _logger.LogInformation("Удаление последнего сообщения для чата {ChatId}", chatId);
            _store.TryGetValue(chatId, out var list);

            if (list != null && list.Count > 0)
            {
                lock (list)
                {
                    if (list.Count > 0)
                    {
                        list.RemoveAt(list.Count - 1);
                        return Task.FromResult(true);
                    }
                }
            }

            return Task.FromResult(false);
        }
    }
}
