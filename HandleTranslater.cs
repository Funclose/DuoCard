using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class HandleTranslater
    {
        public static void HandleTranslateRandomWord(Dictionary<string, string> wordDictionary, Random random)
        {
            string randomKey;
            string correctTranslation;

            bool result = Translater.TranslateRandomWord(wordDictionary, random, out randomKey, out correctTranslation);

            if (result)
            {
                Console.WriteLine($"Переведите слово: {randomKey}");
                string userTranslation = Console.ReadLine();

                if (correctTranslation.Equals(userTranslation, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine($"Неправильно! Подсказка: {correctTranslation.Substring(0, Math.Min(3, correctTranslation.Length))}...");
                    Console.WriteLine($"Правильный перевод: {correctTranslation}");
                }
            }
            else
            {
                Console.WriteLine("Словарь пуст.");
            }
        }

        public static void HandleAddNewWord(Dictionary<string, string> wordDictionary)
        {
            Console.Write("Введите английское слово: ");
            string englishWord = Console.ReadLine();
            Console.Write("Введите русский перевод: ");
            string russianWord = Console.ReadLine();

            bool result = Translater.AddNewWord(wordDictionary, englishWord, russianWord);

            if (result)
            {
                Console.WriteLine("Слово добавлено.");
            }
            else
            {
                Console.WriteLine("Слово уже существует в словаре.");
            }
        }

        public static void HandleEditWord(Dictionary<string, string> wordDictionary)
        {
            Console.Write("Введите английское слово для редактирования: ");
            string englishWord = Console.ReadLine();

            if (wordDictionary.ContainsKey(englishWord))
            {
                Console.Write("Введите новый перевод: ");
                string newTranslation = Console.ReadLine();
                bool result = Translater.EditWord(wordDictionary, englishWord, newTranslation);

                if (result)
                {
                    Console.WriteLine("Перевод обновлен.");
                }
                else
                {
                    Console.WriteLine("Ошибка при обновлении перевода.");
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре.");
            }
        }

        public static void HandleDeleteWord(Dictionary<string, string> wordDictionary)
        {
            Console.Write("Введите английское слово для удаления: ");
            string englishWord = Console.ReadLine();

            bool result = Translater.DeleteWord(wordDictionary, englishWord);

            if (result)
            {
                Console.WriteLine("Слово удалено.");
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре.");
            }
        }

        public static void HandleViewAllWords(Dictionary<string, string> wordDictionary)
        {
            Translater.ViewAllWords(wordDictionary);
        }

        public static void HandleSearchWord(Dictionary<string, string> wordDictionary)
        {
            Console.Write("Введите английское или русское слово для поиска: ");
            string searchWord = Console.ReadLine();

            Translater.SearchWord(wordDictionary, searchWord);
        }
    }

