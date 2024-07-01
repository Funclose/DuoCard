using System;
using System.Text;

//public static class Translater
//{
//    public static string TranslateRandomWord(Dictionary<string, string> wordDictionary, Random random)
//    {
//        if (wordDictionary.Count == 0)
//        {
//            return "Словарь пуст.";
//        }

//        List<string> keys = wordDictionary.Keys.ToList();
//        string randomKey = keys[random.Next(keys.Count)];

//        return $"Переведите слово: {randomKey}";
//    }

//    public static string CheckTranslation(Dictionary<string, string> wordDictionary, string randomKey, string userTranslation)
//    {
//        if (wordDictionary[randomKey].Equals(userTranslation, StringComparison.OrdinalIgnoreCase))
//        {
//            return "Правильно!";
//        }
//        else
//        {
//            return $"Неправильно! Подсказка: {wordDictionary[randomKey].Substring(0, Math.Min(3, wordDictionary[randomKey].Length))}...\nПравильный перевод: {wordDictionary[randomKey]}";
//        }
//    }

//    public static string AddNewWord(Dictionary<string, string> wordDictionary, string englishWord, string russianWord)
//    {
//        if (!wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary[englishWord] = russianWord;
//            return "Слово добавлено.";
//        }
//        else
//        {
//            return "Слово уже существует в словаре.";
//        }
//    }

//    public static string EditWord(Dictionary<string, string> wordDictionary, string englishWord, string newTranslation)
//    {
//        if (wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary[englishWord] = newTranslation;
//            return "Перевод обновлен.";
//        }
//        else
//        {
//            return "Слово не найдено в словаре.";
//        }
//    }

//    public static void DeleteWord(Dictionary<string, string> wordDictionary, string englishWord)
//    {
//        if (wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary.Remove(englishWord);
//            //return "Слово удалено.";
//        }
//        else
//        {
//            throw new Exception("Слово не найдено в словаре.");
//        }
//    }

//    public static string ViewAllWords(Dictionary<string, string> wordDictionary)
//    {
//        if (wordDictionary.Count == 0)
//        {
//            return "Словарь пуст.";
//        }

//        StringBuilder sb = new StringBuilder();
//        foreach (var item in wordDictionary)
//        {
//            sb.AppendLine($"{item.Key} - {item.Value}");
//        }
//        return sb.ToString();
//    }

//    public static string SearchWord(Dictionary<string, string> wordDictionary, string searchWord)
//    {
//        var foundWords = wordDictionary.Where(pair => pair.Key.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
//                                                      pair.Value.Contains(searchWord, StringComparison.OrdinalIgnoreCase));

//        if (foundWords.Any())
//        {
//            StringBuilder sb = new StringBuilder();
//            foreach (var item in foundWords)
//            {
//                sb.AppendLine($"{item.Key} - {item.Value}");
//            }
//            return sb.ToString();
//        }
//        else
//        {
//            return "Слово не найдено.";
//        }
//    }
//}







internal static class Translater
{
    public static void TranslateRandomWord(Dictionary<string, string> wordDictionary, Random random)
    {
        if (wordDictionary.Count == 0)
        {
            Console.WriteLine("Словарь пуст.");
            return;
        }

        List<string> keys = new List<string>(wordDictionary.Keys);
        string randomKey = keys[random.Next(keys.Count)];

        Console.WriteLine($"Переведите слово: {randomKey}");
        string userTranslation = Console.ReadLine();

        if (wordDictionary[randomKey].Equals(userTranslation, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Правильно!");
        }
        else
        {
            Console.WriteLine($"Неправильно! Подсказка: {wordDictionary[randomKey].Substring(0, Math.Min(3, wordDictionary[randomKey].Length))}...");
            Console.WriteLine($"Правильный перевод: {wordDictionary[randomKey]}");
        }
    }

    public static void AddNewWord(Dictionary<string, string> wordDictionary)
    {
        Console.Write("Введите английское слово: ");
        string englishWord = Console.ReadLine();
        Console.Write("Введите русский перевод: ");
        string russianWord = Console.ReadLine();

        if (!wordDictionary.ContainsKey(englishWord))
        {
            wordDictionary[englishWord] = russianWord;
            Console.WriteLine("Слово добавлено.");
        }
        else
        {
            Console.WriteLine("Слово уже существует в словаре.");
        }
    }

    public static void EditWord(Dictionary<string, string> wordDictionary)
    {
        Console.Write("Введите английское слово для редактирования: ");
        string englishWord = Console.ReadLine();

        if (wordDictionary.ContainsKey(englishWord))
        {
            Console.Write("Введите новый перевод: ");
            string newTranslation = Console.ReadLine();
            wordDictionary[englishWord] = newTranslation;
            Console.WriteLine("Перевод обновлен.");
        }
        else
        {
            Console.WriteLine("Слово не найдено в словаре.");
        }
    }

    public static void DeleteWord(Dictionary<string, string> wordDictionary)
    {
        Console.Write("Введите английское слово для удаления: ");
        string englishWord = Console.ReadLine();

        if (wordDictionary.ContainsKey(englishWord))
        {
            wordDictionary.Remove(englishWord);
            Console.WriteLine("Слово удалено.");
        }
        else
        {
            Console.WriteLine("Слово не найдено в словаре.");
        }
    }

    public static void ViewAllWords(Dictionary<string, string> wordDictionary)
    {
        if (wordDictionary.Count == 0)
        {
            Console.WriteLine("Словарь пуст.");
            return;
        }

        foreach (var item in wordDictionary)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }

    public static void SearchWord(Dictionary<string, string> wordDictionary)
    {
        Console.Write("Введите английское или русское слово для поиска: ");
        string searchWord = Console.ReadLine();

        var foundWords = wordDictionary.Where(pair => pair.Key.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                                                      pair.Value.Contains(searchWord, StringComparison.OrdinalIgnoreCase));

        if (foundWords.Any())
        {
            foreach (var item in foundWords)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("Слово не найдено.");
        }
    }
}
