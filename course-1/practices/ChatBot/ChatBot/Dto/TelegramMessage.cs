using ChatBot.Dto;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace ChatBot.DTO
{
    public class TelegramMessage
    {
        [Required]
        public int MessageId { get; set; }
        public TelegramChatBot Chat { get; set; } = new TelegramChatBot();

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Text { get; set; }

        [Required]
        public int Date { get; set; }
    }
}
