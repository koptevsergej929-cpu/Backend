using lesson_23.Commands;
using lesson_23.Json;
using lesson_23.Model;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace lesson_23
{
    internal class Program
    {
        private const string ScheduleJson = "schedule.json";
        static async Task Main(string[] args)
        {

            Console.WriteLine("Запуск бота");

            var token = "8459888186:AAE8PavtfcBHB4EaG0nG_9hdi59EpwkTBis";
            var botClient = new TelegramBotClient(token);

            var scheduleRepository = new JsonScheduleRepository(ScheduleJson);

            var dispatcher = new CommandDispatcher();
            dispatcher.Register("/start", new StartCommand());
            dispatcher.Register("/help", new HelpCommand());
            dispatcher.Register("/week", new WeekCommand(scheduleRepository));

            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() };

            botClient.StartReceiving(
           async (client, update, ct) => await dispatcher.DispatchAsync(update, client, ct),
           HandleErrorAsync,
           receiverOptions,
           cts.Token);

            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Бот запущен: @{me.Username}");
            Console.ReadLine();
            cts.Cancel();


        }

        static Task HandleErrorAsync(ITelegramBotClient bot, Exception ex, CancellationToken ct)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Task.CompletedTask;
        }
    }
}
