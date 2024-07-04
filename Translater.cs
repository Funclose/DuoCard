using System;
using System.Text;

//public  class Translater
//{
//    public static bool TranslateRandomWord(Dictionary<string, string> wordDictionary, Random random, out string randomKey, out string correctTranslation)
//    {
//        randomKey = "";
//        correctTranslation = "";

//        if (wordDictionary.Count == 0)
//        {
//            return false;
//        }

//        List<string> keys = new List<string>(wordDictionary.Keys);
//        randomKey = keys[random.Next(keys.Count)];

//        correctTranslation = wordDictionary[randomKey];
//        return true;
//    }

//    public static bool AddNewWord(Dictionary<string, string> wordDictionary, string englishWord, string russianWord)
//    {
//        if (!wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary[englishWord] = russianWord;
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public static bool EditWord(Dictionary<string, string> wordDictionary, string englishWord, string newTranslation)
//    {
//        if (wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary[englishWord] = newTranslation;
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public static bool DeleteWord(Dictionary<string, string> wordDictionary, string englishWord)
//    {
//        if (wordDictionary.ContainsKey(englishWord))
//        {
//            wordDictionary.Remove(englishWord);
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    public static void ViewAllWords(Dictionary<string, string> wordDictionary)
//    {
//        if (wordDictionary.Count == 0)
//        {
//            Console.WriteLine("Словарь пуст.");
//            return;
//        }

//        foreach (var item in wordDictionary)
//        {
//            Console.WriteLine($"{item.Key} - {item.Value}");
//        }
//    }

//    public static void SearchWord(Dictionary<string, string> wordDictionary, string searchWord)
//    {
//        var foundWords = wordDictionary.Where(pair => pair.Key.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
//                                                      pair.Value.Contains(searchWord, StringComparison.OrdinalIgnoreCase));

//        if (foundWords.Any())
//        {
//            foreach (var item in foundWords)
//            {
//                Console.WriteLine($"{item.Key} - {item.Value}");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Слово не найдено.");
//        }
//    }

//    //TODO: придумать количество символов которое выберет пользователь, вплоть до полного перевода


//    public static string GetHint(string correctTranslation)
//    {
//        if (correctTranslation.Length >= 3)
//        {
//            return correctTranslation.Substring(0, 3);
//        }
//        else
//        {
//            return correctTranslation; 
//        }
//    }

//}










public static class Translater
{
    public static bool TranslateRandomWord(Dictionary<string, string> wordDictionary, Random random, out string randomKey, out string correctTranslation)
    {
        if (wordDictionary.Count == 0)
        {
            randomKey = null;
            correctTranslation = null;
            return false;
        }

        int index = random.Next(wordDictionary.Count);
        randomKey = wordDictionary.Keys.ElementAt(index);
        correctTranslation = wordDictionary[randomKey];
        return true;
    }

    public static bool AddNewWord(Dictionary<string, string> wordDictionary, string englishWord, string russianWord)
    {
        if (wordDictionary.ContainsKey(englishWord))
        {
            return false;
        }
        wordDictionary[englishWord] = russianWord;
        return true;
    }

    public static bool EditWord(Dictionary<string, string> wordDictionary, string englishWord, string newTranslation)
    {
        if (wordDictionary.ContainsKey(englishWord))
        {
            wordDictionary[englishWord] = newTranslation;
            return true;
        }
        return false;
    }

    public static bool DeleteWord(Dictionary<string, string> wordDictionary, string englishWord)
    {
        return wordDictionary.Remove(englishWord);
    }

    public static void ViewAllWords(Dictionary<string, string> wordDictionary)
    {
        foreach (var word in wordDictionary)
        {
            Console.WriteLine($"{word.Key} - {word.Value}");
        }
    }

    public static void SearchWord(Dictionary<string, string> wordDictionary, string searchWord)
    {
        var results = wordDictionary.Where(pair => pair.Key.Contains(searchWord, StringComparison.OrdinalIgnoreCase) ||
                                                   pair.Value.Contains(searchWord, StringComparison.OrdinalIgnoreCase));

        foreach (var word in results)
        {
            Console.WriteLine($"{word.Key} - {word.Value}");
        }
    }

    public static string GetHint(string correctTranslation, int attempts)
    {
        if (attempts <= correctTranslation.Length)
        {
            return correctTranslation.Substring(0, attempts);
        }
        return correctTranslation;
    }
}



