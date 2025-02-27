using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using InspiringQuotes.Models;
using InspiringQuotes.Services;
using Microsoft.UI.Xaml.Media.Imaging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InspiringQuotes
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly QuoteService _quoteService;

        public MainWindow()
        {
            this.InitializeComponent();
            _quoteService = new QuoteService();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await _quoteService.LoadQuotesAsync();
            ShowRandomQuote();
        }

        private void NextQuoteButton_Click(object sender, RoutedEventArgs e)
        {
            ShowRandomQuote();
        }

        private void ShowRandomQuote()
        {
            var quote = _quoteService.GetRandomQuote();
            
            QuoteText.Text = quote.Text;
            QuoteAuthor.Text = $"- {quote.Author}";
            TranslatedText.Text = quote.Translated;

            // Load image using relative path
            try
            {
                string imagePath = $"Assets/QuotesImage/{quote.Id}.jpg";
                var uri = new Uri($"ms-appx:///{imagePath}");
                QuoteImage.Source = new BitmapImage(uri);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
                QuoteImage.Source = null;
            }
        }
    }
}
