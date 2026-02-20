using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace lesson_23.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct);
    }
}
