using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace lesson_21
{
    public class Library
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("books")]
        public List<Book> Books { get; set; }
    }
}
