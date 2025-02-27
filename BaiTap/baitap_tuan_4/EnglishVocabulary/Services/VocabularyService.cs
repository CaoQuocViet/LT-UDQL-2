using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EnglishVocabulary.Models;

namespace EnglishVocabulary.Services
{
    public class VocabularyService
    {
        private readonly string _jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vocabulary.json");
        private List<VocabularyItem> _vocabularyItems;
        private Random _random = new Random();

        public VocabularyService()
        {
            _vocabularyItems = LoadVocabulary();
            if (!_vocabularyItems.Any())
            {
                InitializeDefaultVocabulary();
                SaveVocabulary();
            }
        }

        private List<VocabularyItem> LoadVocabulary()
        {
            if (File.Exists(_jsonPath))
            {
                var json = File.ReadAllText(_jsonPath);
                return JsonSerializer.Deserialize<List<VocabularyItem>>(json) ?? new List<VocabularyItem>();
            }
            return new List<VocabularyItem>();
        }

        private void SaveVocabulary()
        {
            var json = JsonSerializer.Serialize(_vocabularyItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonPath, json);
        }

        private void InitializeDefaultVocabulary()
        {
            var vocabFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Vocabulary");
            var imageFiles = Directory.GetFiles(vocabFolder, "*.jpg");

            var vietnameseMeanings = new Dictionary<string, string>
            {
                {"apple", "Quả táo"},
                {"beard", "Râu"},
                {"colors", "Màu sắc"},
                {"cow", "Con bò"},
                {"donkey", "Con lừa"},
                {"grapefruit", "Quả bưởi"},
                {"green", "Màu xanh lá"},
                {"hair", "Tóc"},
                {"horse", "Con ngựa"},
                {"jaw", "Hàm"},
                {"lime", "Quả chanh"},
                {"lobster", "Tôm hùm"},
                {"pig", "Con lợn"},
                {"pomegranate", "Quả lựu"},
                {"purple", "Màu tím"},
                {"red", "Màu đỏ"},
                {"reindeer", "Tuần lộc"},
                {"sea-turtle", "Rùa biển"},
                {"seal", "Hải cẩu"},
                {"snail", "Ốc sên"},
                {"tongue", "Lưỡi"}
            };

            _vocabularyItems = imageFiles.Select(file =>
            {
                var word = Path.GetFileNameWithoutExtension(file);
                return new VocabularyItem
                {
                    Word = word,
                    VietnameseMeaning = vietnameseMeanings.GetValueOrDefault(word, "Chưa có nghĩa"),
                    ImagePath = $"ms-appx:///Assets/Vocabulary/{word}.jpg"
                };
            }).ToList();
        }

        public VocabularyItem GetRandomVocabulary()
        {
            if (!_vocabularyItems.Any())
                throw new InvalidOperationException("No vocabulary items available");

            var index = _random.Next(_vocabularyItems.Count);
            return _vocabularyItems[index];
        }

        public void AddVocabulary(VocabularyItem item)
        {
            _vocabularyItems.Add(item);
            SaveVocabulary();
        }
    }
} 