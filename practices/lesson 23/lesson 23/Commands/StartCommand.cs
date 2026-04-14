using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace lesson_23.Commands
{
    public class StartCommand : ICommand
    {
        public async Task ExecuteAsync(Update update, ITelegramBotClient
            botClient, CancellationToken ct)
        {
            var chatId = update.Message!.Chat.Id;
            string text = "Привет! Я бот расписания\n" +
                          "Используй /help, чтобы увидеть список команд.";

            await botClient.SendTextMessageAsync(chatId, text, cancellationToken: ct);
        }
    }
}
