using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace lesson_23.Commands
{
    public class HelpCommand : ICommand
    {
        public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
        {
            var chatId = update.Message!.Chat.Id;
            string text = "Доступные команды:\n" +
                          "/start - приветствие\n" +
                          "/help - помощь\n" +
                          "/week - расписание\n";


            await botClient.SendTextMessageAsync(chatId, text, cancellationToken: ct);
        }

    }
}