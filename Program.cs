﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace DuoCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardData cardData = new CardData { Path = "wordDictionary.dat" };
            Dictionary<string, string> wordDictionary = cardData.Load();
            SessionStatistics allStatistics = SessionStatistics.LoadFromFile();
            int sessionId = allStatistics.GetNextSessionId();
            Statistics currentSession = new Statistics(sessionId);


            if (wordDictionary.Count == 0)
            {
                AddInitialWordsLight(wordDictionary);
                cardData.Save(wordDictionary);
            }

            Random random = new Random();

            while (true)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nВыход: ");
                        Decoration.WriteColoredText("exit", ConsoleColor.Red);
                        Console.Write("\nполучить полное слово: ");
                        Decoration.WriteColoredText("full\n", ConsoleColor.Green);
                        HandleTranslater.HandleTranslateRandomWord(wordDictionary, random);
                        break;
                    case "2":
                        HandleTranslater.HandleAddNewWord(wordDictionary);
                        cardData.Save(wordDictionary); 
                        break;
                    case "3":
                        HandleTranslater.HandleEditWord(wordDictionary);
                        cardData.Save(wordDictionary); 
                        break;
                    case "4":
                        HandleTranslater.HandleDeleteWord(wordDictionary);
                        cardData.Save(wordDictionary); 
                        break;
                    case "5":
                        HandleTranslater.HandleViewAllWords(wordDictionary);
                        break;
                    case "6":
                        HandleTranslater.HandleSearchWord(wordDictionary);
                        break;
                    case "7":
                        allStatistics.AddSession(currentSession);
                        allStatistics.SaveToFile();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }

                Console.WriteLine(); 
            }
        }

          
        static void DisplayMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Перевести случайное слово");
            Console.WriteLine("2. Добавить новое слово");
            Console.WriteLine("3. Редактировать слово");
            Console.WriteLine("4. Удалить слово");
            Console.WriteLine("5. Просмотреть все слова");
            Console.WriteLine("6. Поиск слова");
            Console.WriteLine("7. сохранить в файл");
            Console.WriteLine("8. Выйти из приложения");
        }

        static void AddInitialWordsLight(Dictionary<string, string> wordDictionary)
        {
            
            wordDictionary["apple"] = "яблоко";
            wordDictionary["house"] = "дом";
            wordDictionary["car"] = "машина";
            wordDictionary["book"] = "книга";
            wordDictionary["computer"] = "компьютер";
            wordDictionary["dog"] = "собака";
            wordDictionary["cat"] = "кошка";
            wordDictionary["tree"] = "дерево";
            wordDictionary["sun"] = "солнце";
            wordDictionary["moon"] = "луна";
            wordDictionary["water"] = "вода";
            wordDictionary["fire"] = "огонь";
            wordDictionary["earth"] = "земля";
            wordDictionary["sky"] = "небо";
            wordDictionary["flower"] = "цветок";
            wordDictionary["friend"] = "друг";
            wordDictionary["family"] = "семья";
            wordDictionary["love"] = "любовь";
            wordDictionary["time"] = "время";
            wordDictionary["money"] = "деньги";
        }
    }
}















//namespace DuoCards
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //MainMenu menu = new MainMenu();
//            //menu.Start();
//            CardData cardData = new CardData { Path = "wordDictionary.dat" };
//            Dictionary<string, string> wordDictionary = cardData.Load();
//            Random random = new Random();

//            while (true)
//            {
//                Console.WriteLine("Выберите действие:");
//                Console.WriteLine("1. Перевести случайное слово");
//                Console.WriteLine("2. Добавить новое слово");
//                Console.WriteLine("3. Редактировать слово");
//                Console.WriteLine("4. Удалить слово");
//                Console.WriteLine("5. Просмотреть все слова");
//                Console.WriteLine("6. Поиск слова");
//                Console.WriteLine("7. Выйти из приложения");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        Translater.TranslateRandomWord(wordDictionary, random);
//                        break;
//                    case "2":
//                        Translater.AddNewWord(wordDictionary);
//                        cardData.Save(wordDictionary);
//                        break;
//                    case "3":
//                        Translater.EditWord(wordDictionary);
//                        cardData.Save(wordDictionary);
//                        break;
//                    case "4":
//                        Translater.DeleteWord(wordDictionary);
//                        cardData.Save(wordDictionary);
//                        break;
//                    case "5":
//                        Translater.ViewAllWords(wordDictionary);
//                        break;
//                    case "6":
//                        Translater.SearchWord(wordDictionary);
//                        break;
//                    case "7":
//                        return;
//                    default:
//                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
//                        break;
//                }
//            }
//        }
//    }

//}
