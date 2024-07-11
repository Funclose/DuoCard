using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace DuoCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            CardData cardData = new CardData { Path = mainMenu.SetDifficulty("1") };
            Dictionary<string, string> wordDictionary = cardData.Load();
            SessionStatistics allStatistics = new SessionStatistics();
            allStatistics.LoadFromFile();
            int sessionId;

            Random random = new Random();

            while (true)
            {
                mainMenu.PrintMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        sessionId = allStatistics.GetNextSessionId();
                        Statistics currentSession = new Statistics(sessionId);
                        Console.Write("\nВыход: ");
                        Decoration.WriteColoredText("exit", ConsoleColor.Red);
                        Console.Write("\nполучить полное слово: ");
                        Decoration.WriteColoredText("full\n", ConsoleColor.Green);
                        HandleTranslater.HandleTranslateRandomWord(wordDictionary, random, allStatistics);
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
                        cardData.Save(wordDictionary);
                        mainMenu.PrintDiff();
                        choice = Console.ReadLine();
                        cardData.Path = mainMenu.SetDifficulty(choice);
                        wordDictionary = cardData.Load();
                        break;
                    case "8":
                        allStatistics.ShowMyStat();
                        break;
                    case "9":
                        allStatistics.ShowAllStat();
                        break;
                    case "10":
                        allStatistics.SaveToFile();
                        cardData.Save(wordDictionary);
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }

                Console.WriteLine();
            }

        }
    }
}
