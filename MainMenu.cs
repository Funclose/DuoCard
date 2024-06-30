using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoCards
{
    internal class MainMenu
    {
        bool PlayGame = true;
        public void PrintMenu()
        {
            Console.WriteLine("1) Start");
            Console.WriteLine("2) Select difficulty level");
            Console.WriteLine("3) Add new word");
            Console.WriteLine("4) See the results");
            Console.WriteLine("5) Exit");
        }
        public string SetDifficulty(int var) 
        {
            if (var == 0) return @".\light_level.bin";
            else if (var == 1) return @".\Medium_level.bin";
            else if (var == 2) return @".\Heavy_level.bin";
            else throw new Exception("Еhere is no such level of difficulty!!");
        }
        public void PrintDiff()
        {
            Console.WriteLine("1) Light");
            Console.WriteLine("2) Medium");
            Console.WriteLine("3) Heavy");
        }
        public void Start ()
        {
            CardData data = new CardData();
            data.Path = SetDifficulty(1);
            while (PlayGame)
            {
                PrintMenu();
                switch (MakeChoice())
                {
                    case 1:
                        {
                            data.Load();
                            //TODO
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            PrintDiff();
                            data.Path = SetDifficulty(MakeChoice());
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            //TODO
                            //TODO data.Save();
                            break;
                        }
                    case 4:
                        {
                            //TODO
                            break;
                        }
                    case 5:
                        {
                            PlayGame = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Еhere is no such command");
                            break;
                        }

                }
            }
            
        }
        public int MakeChoice()
        {
            Console.Write("Make choice: ");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                throw new Exception("Not the right choice! try again!");
            }
        }
    }
}
