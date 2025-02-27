using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using EnglishVocabulary.Services;
using EnglishVocabulary.Models;

namespace EnglishVocabulary
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly VocabularyService _vocabularyService;

        public MainWindow()
        {
            this.InitializeComponent();
            _vocabularyService = new VocabularyService();
            ShowRandomWord();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ShowRandomWord();
        }

        private void ShowRandomWord()
        {
            var vocabulary = _vocabularyService.GetRandomVocabulary();
            wordTextBlock.Text = vocabulary.Word;
            vietnameseTextBlock.Text = vocabulary.VietnameseMeaning;
            vocabularyImage.Source = new BitmapImage(new Uri(vocabulary.ImagePath));
        }
    }
}
