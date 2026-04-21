using ChatBot.Dto;
using ChatBot.Repositories.Models;

namespace ChatBot.Repositories.Interfaces
{
    public interface IChatModelRepository
    {
        Task<List<OpenApiResponse.Message>> GetHistoryAsync(long chatId);
        Task AddMessageAsync(long chatId, OpenApiResponse.Message message);
        Task<ChatStatistics> GetChatStatisticsAsync(long chatId);
        Task ClearHistoryAsync(long chatId);
        Task<bool> RemoveLastMessageAsync(long chatId);
    }
}
