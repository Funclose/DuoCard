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
            CardData newcard = new CardData();
            

            string lightFilePath = @".\Light_level.bin";
            string mediumFilePath = @".\Medium_level.bin";
            string hardFilePath = @".\Heavy_level.bin";

            
            Dictionary<string, string> lightWords = new Dictionary<string, string>();
            AddInitialWordsLight(lightWords);

            Dictionary<string, string> mediumWords = new Dictionary<string, string>();
            AddMediumWords(mediumWords);

            Dictionary<string, string> hardWords = new Dictionary<string, string>();
            AddHardWords(hardWords);

            
            CardData.SaveDictionaryToFile(lightWords, lightFilePath);
            CardData.SaveDictionaryToFile(mediumWords, mediumFilePath);
            CardData.SaveDictionaryToFile(hardWords, hardFilePath);

            Dictionary<string, string> wordDictionary = cardData.Load();
            SessionStatistics allStatistics = new SessionStatistics();
            //allStatistics.SaveToFile();
            allStatistics.LoadFromFile();
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
                mainMenu.PrintMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
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
                        allStatistics.ShowStat();
                        return;
                    case "9":
                        allStatistics.SaveToFile();
                        cardData.Save(wordDictionary);
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }

                Console.WriteLine();
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
                wordDictionary["food"] = "еда";
                wordDictionary["drink"] = "напиток";
                wordDictionary["chair"] = "стул";
                wordDictionary["table"] = "стол";
                wordDictionary["window"] = "окно";
                wordDictionary["door"] = "дверь";
                wordDictionary["bed"] = "кровать";
                wordDictionary["hat"] = "шляпа";
                wordDictionary["shoe"] = "туфля";
                wordDictionary["shirt"] = "рубашка";
                wordDictionary["pants"] = "штаны";
                wordDictionary["coat"] = "пальто";
                wordDictionary["road"] = "дорога";
                wordDictionary["street"] = "улица";
                wordDictionary["city"] = "город";
                wordDictionary["village"] = "деревня";
                wordDictionary["country"] = "страна";
                wordDictionary["world"] = "мир";
                wordDictionary["school"] = "школа";
                wordDictionary["student"] = "студент";
                wordDictionary["teacher"] = "учитель";
                wordDictionary["university"] = "университет";
                wordDictionary["exam"] = "экзамен";
                wordDictionary["pen"] = "ручка";
                wordDictionary["pencil"] = "карандаш";
                wordDictionary["paper"] = "бумага";
                wordDictionary["notebook"] = "тетрадь";
                wordDictionary["bookstore"] = "книжный магазин";
                wordDictionary["library"] = "библиотека";
                wordDictionary["hospital"] = "больница";
                wordDictionary["doctor"] = "доктор";
                wordDictionary["nurse"] = "медсестра";
                wordDictionary["patient"] = "пациент";
                wordDictionary["medicine"] = "лекарство";
                wordDictionary["police"] = "полиция";
                wordDictionary["officer"] = "офицер";
                wordDictionary["crime"] = "преступление";
                wordDictionary["lawyer"] = "юрист";
                wordDictionary["court"] = "суд";
                wordDictionary["judge"] = "судья";
                wordDictionary["garden"] = "сад";
                wordDictionary["plant"] = "растение";
                wordDictionary["flower"] = "цветок";
                wordDictionary["grass"] = "трава";
                wordDictionary["tree"] = "дерево";
                wordDictionary["forest"] = "лес";
                wordDictionary["river"] = "река";
                wordDictionary["mountain"] = "гора";
                wordDictionary["sea"] = "море";
                wordDictionary["ocean"] = "океан";
                wordDictionary["lake"] = "озеро";
                wordDictionary["island"] = "остров";
                wordDictionary["beach"] = "пляж";
                wordDictionary["fish"] = "рыба";
                wordDictionary["bird"] = "птица";
                wordDictionary["animal"] = "животное";
                wordDictionary["insect"] = "насекомое";
                wordDictionary["butterfly"] = "бабочка";
                wordDictionary["bee"] = "пчела";
                wordDictionary["ant"] = "муравей";
                wordDictionary["spider"] = "паук";
                wordDictionary["frog"] = "лягушка";
                wordDictionary["turtle"] = "черепаха";
                wordDictionary["snake"] = "змея";
                wordDictionary["horse"] = "лошадь";
                wordDictionary["cow"] = "корова";
                wordDictionary["pig"] = "свинья";
                wordDictionary["sheep"] = "овца";
                wordDictionary["goat"] = "коза";
                wordDictionary["chicken"] = "курица";
                wordDictionary["duck"] = "утка";
                wordDictionary["goose"] = "гусь";
                wordDictionary["turkey"] = "индюк";
                wordDictionary["rabbit"] = "кролик";
                wordDictionary["mouse"] = "мышь";
                wordDictionary["rat"] = "крыса";
                wordDictionary["elephant"] = "слон";
                wordDictionary["tiger"] = "тигр";
                wordDictionary["lion"] = "лев";
                wordDictionary["monkey"] = "обезьяна";
                wordDictionary["bear"] = "медведь";
            }

            static void AddMediumWords(Dictionary<string, string> wordDictionary)
            {
                wordDictionary["universe"] = "вселенная";
                wordDictionary["mountain"] = "гора";
                wordDictionary["river"] = "река";
                wordDictionary["music"] = "музыка";
                wordDictionary["language"] = "язык";
                wordDictionary["painting"] = "картина";
                wordDictionary["history"] = "история";
                wordDictionary["science"] = "наука";
                wordDictionary["beauty"] = "красота";
                wordDictionary["technology"] = "технология";
                wordDictionary["future"] = "будущее";
                wordDictionary["culture"] = "культура";
                wordDictionary["adventure"] = "приключение";
                wordDictionary["spirit"] = "дух";
                wordDictionary["journey"] = "путешествие";
                wordDictionary["knowledge"] = "знание";
                wordDictionary["dream"] = "мечта";
                wordDictionary["freedom"] = "свобода";
                wordDictionary["success"] = "успех";
                wordDictionary["challenge"] = "вызов";
                wordDictionary["philosophy"] = "философия";
                wordDictionary["architecture"] = "архитектура";
                wordDictionary["revolution"] = "революция";
                wordDictionary["literature"] = "литература";
                wordDictionary["medicine"] = "медицина";
                wordDictionary["astronomy"] = "астрономия";
                wordDictionary["mathematics"] = "математика";
                wordDictionary["government"] = "правительство";
                wordDictionary["environment"] = "окружающая среда";
                wordDictionary["globalization"] = "глобализация";
                wordDictionary["society"] = "общество";
                wordDictionary["communication"] = "коммуникация";
                wordDictionary["economy"] = "экономика";
                wordDictionary["development"] = "развитие";
                wordDictionary["industry"] = "индустрия";
                wordDictionary["transportation"] = "транспорт";
                wordDictionary["education"] = "образование";
                wordDictionary["experience"] = "опыт";
                wordDictionary["relationship"] = "отношения";
                wordDictionary["environment"] = "окружающая среда";
                wordDictionary["responsibility"] = "ответственность";
                wordDictionary["tradition"] = "традиция";
                wordDictionary["opportunity"] = "возможность";
                wordDictionary["imagination"] = "воображение";
                wordDictionary["curiosity"] = "любопытство";
                wordDictionary["adventure"] = "приключение";
                wordDictionary["confidence"] = "уверенность";
                wordDictionary["discovery"] = "открытие";
                wordDictionary["communication"] = "коммуникация";
                wordDictionary["creativity"] = "творчество";
                wordDictionary["intelligence"] = "интеллект";
                wordDictionary["perseverance"] = "настойчивость";
                wordDictionary["independence"] = "независимость";
                wordDictionary["achievement"] = "достижение";
                wordDictionary["innovation"] = "инновация";
                wordDictionary["vision"] = "видение";
                wordDictionary["exploration"] = "исследование";
                wordDictionary["adversity"] = "трудность";
                wordDictionary["resilience"] = "устойчивость";
                wordDictionary["integrity"] = "целостность";
                wordDictionary["leadership"] = "лидерство";
                wordDictionary["diversity"] = "разнообразие";
                wordDictionary["justice"] = "справедливость";
                wordDictionary["peace"] = "мир";
                wordDictionary["security"] = "безопасность";
                wordDictionary["prosperity"] = "благополучие";
                wordDictionary["sustainability"] = "устойчивость";
                wordDictionary["humanity"] = "человечество";
                wordDictionary["compassion"] = "сострадание";
                wordDictionary["generosity"] = "щедрость";
                wordDictionary["kindness"] = "доброта";
                wordDictionary["friendship"] = "дружба";
                wordDictionary["family"] = "семья";
                wordDictionary["love"] = "любовь";
            }

            static void AddHardWords(Dictionary<string, string> wordDictionary)
            {
                wordDictionary["philosophy"] = "философия";
                wordDictionary["architecture"] = "архитектура";
                wordDictionary["revolution"] = "революция";
                wordDictionary["literature"] = "литература";
                wordDictionary["medicine"] = "медицина";
                wordDictionary["astronomy"] = "астрономия";
                wordDictionary["mathematics"] = "математика";
                wordDictionary["government"] = "правительство";
                wordDictionary["environment"] = "окружающая среда";
                wordDictionary["globalization"] = "глобализация";
                wordDictionary["society"] = "общество";
                wordDictionary["communication"] = "коммуникация";
                wordDictionary["economy"] = "экономика";
                wordDictionary["development"] = "развитие";
                wordDictionary["industry"] = "индустрия";
                wordDictionary["architecture"] = "архитектура";
                wordDictionary["philosophy"] = "философия";
                wordDictionary["revolution"] = "революция";
                wordDictionary["literature"] = "литература";
                wordDictionary["medicine"] = "медицина";
                wordDictionary["astronomy"] = "астрономия";
                wordDictionary["mathematics"] = "математика";
                wordDictionary["government"] = "правительство";
                wordDictionary["environment"] = "окружающая среда";
                wordDictionary["globalization"] = "глобализация";
                wordDictionary["society"] = "общество";
                wordDictionary["communication"] = "коммуникация";
                wordDictionary["economy"] = "экономика";
                wordDictionary["development"] = "развитие";
                wordDictionary["industry"] = "индустрия";
                wordDictionary["philosophy"] = "философия";
                wordDictionary["revolution"] = "революция";
                wordDictionary["literature"] = "литература";
                wordDictionary["medicine"] = "медицина";
                wordDictionary["astronomy"] = "астрономия";
                wordDictionary["mathematics"] = "математика";
                wordDictionary["government"] = "правительство";
                wordDictionary["environment"] = "окружающая среда";
                wordDictionary["globalization"] = "глобализация";
                wordDictionary["society"] = "общество";
                wordDictionary["communication"] = "коммуникация";
                wordDictionary["economy"] = "экономика";
                wordDictionary["development"] = "развитие";
                wordDictionary["industry"] = "индустрия";
                wordDictionary["philosophy"] = "философия";
                wordDictionary["revolution"] = "революция";
                wordDictionary["literature"] = "литература";
                wordDictionary["medicine"] = "медицина";
            }
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
