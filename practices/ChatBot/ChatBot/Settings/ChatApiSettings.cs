namespace ChatBot.Settings
{
    public class ChatApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string DefaultModel { get; set; } = "gpt-3.5-turbo";
    }
}
