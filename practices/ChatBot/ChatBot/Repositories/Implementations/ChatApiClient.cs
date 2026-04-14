using ChatBot.Repositories.Interfaces;
using ChatBot.Repositories.Models;
using ChatBot.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ChatBot.Repositories.Implementations
{
    public class ChatApiClient : IChatApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ChatApiSettings _chatApiSettings;

        public ChatApiClient(HttpClient httpClient, IOptions<ChatApiSettings> chatApiSettings)
        {
            _httpClient = httpClient;
            _chatApiSettings = chatApiSettings.Value;

            _httpClient.BaseAddress = new Uri(_chatApiSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _chatApiSettings.ApiKey);
        }

        public async Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history)
        {
            var playload = new OpenApiRequest()
            {
                Model = _chatApiSettings.DefaultModel,
                Messages =history.ToList(),
                MaxTokens = 1000
            };

            var response = await _httpClient.PostAsJsonAsync("", playload);

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<OpenApiResponse?>();

            if (body?.Choices != null && body.Choices.Length > 0)
            {
                return body.Choices[0].Message.Content;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
