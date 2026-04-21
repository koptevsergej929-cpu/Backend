using ChatBot.Dto;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBot.Commands
{
    public class HistoryCommand : IBotCommand
    {
        private static List<string> messageLog = new List<string>();
        private int maxHistory = 6;
        private string filePath = "data.json";

        public string Trigger => "/history";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient botClient, long chatId)
        {
            LoadHistory();
            if (messageLog.Count == 0)
            {
                await botClient.SendTextMessageAsync(chatId, "История сообщений пуста");
                return;
            }

            string historyText = "Последние сообщения: \n" + string.Join("\n", messageLog);
            await botClient.SendTextMessageAsync(chatId,historyText);
        }

        public void AddToHistory(string sender, string text)
        {
            LoadHistory();
            messageLog.Add($"{sender}: {text}");
            if (messageLog.Count > maxHistory)
                messageLog.RemoveAt(0);
            SaveHistory();
        }

        private void SaveHistory()
        {
            var json = JsonSerializer.Serialize(messageLog);
            System.IO.File.WriteAllText(filePath, json);
        }

        private void LoadHistory()
        {
            if (System.IO.File.Exists(filePath))
            {
                var json = System.IO.File.ReadAllText(filePath);
                messageLog = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
        }
        
    }
}
