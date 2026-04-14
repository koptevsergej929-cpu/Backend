using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace lesson_21
{
    public class Book
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("publication_year")]
        public int Year { get; set; }
        
    }
}
