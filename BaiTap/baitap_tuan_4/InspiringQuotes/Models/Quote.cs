using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace InspiringQuotes.Models
{
    public class Quote
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("author")]
        public string Author { get; set; } = string.Empty;

        [JsonPropertyName("translated")]
        public string Translated { get; set; } = string.Empty;
    }

    public class QuoteList
    {
        [JsonPropertyName("quotes")]
        public List<Quote> Quotes { get; set; } = new();
    }
}
