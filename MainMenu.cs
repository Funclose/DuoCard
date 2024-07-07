using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoCards
{
    internal class MainMenu
    {
        public void PrintMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Перевести случайное слово");
            Console.WriteLine("2. Добавить новое слово");
            Console.WriteLine("3. Редактировать слово");
            Console.WriteLine("4. Удалить слово");
            Console.WriteLine("5. Просмотреть все слова");
            Console.WriteLine("6. Поиск слова");
            Console.WriteLine("7. Изменить сложность");
            Console.WriteLine("8. Выйти из приложения");
        }
        public string SetDifficulty(string var) 
        {
            if (var == "1") return @".\Light_level.bin";
            else if (var == "2") return @".\Medium_level.bin";
            else if (var == "3") return @".\Heavy_level.bin";
            else throw new Exception("Еhere is no such level of difficulty!!");
        }
        public void PrintDiff()
        {
            Console.WriteLine("1) Light");
            Console.WriteLine("2) Medium");
            Console.WriteLine("3) Heavy");
        }
    }
}
