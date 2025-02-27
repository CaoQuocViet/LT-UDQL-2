using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using InspiringQuotes.Models;
using System.Text.Json;

namespace InspiringQuotes.Services
{
    public class QuoteService
    {
        private readonly List<Quote> _quotes = new();
        private readonly Random _random = new();

        public async Task LoadQuotesAsync()
        {
            try
            {
                // Sử dụng đường dẫn tương đối từ thư mục thực thi
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonPath = Path.Combine(appDirectory, "Data", "InspiringQuotes.json");
                
                var jsonString = await File.ReadAllTextAsync(jsonPath);
                var quoteList = JsonSerializer.Deserialize<QuoteList>(jsonString);
                if (quoteList?.Quotes != null)
                {
                    _quotes.Clear();
                    _quotes.AddRange(quoteList.Quotes);
                }
            }
            catch (Exception ex)
            {
                // Handle error appropriately
                System.Diagnostics.Debug.WriteLine($"Error loading quotes: {ex.Message}");
            }
        }

        public Quote GetRandomQuote()
        {
            if (_quotes.Count == 0)
                return new Quote();

            int randomIndex = _random.Next(_quotes.Count);
            return _quotes[randomIndex];
        }
    }
}
