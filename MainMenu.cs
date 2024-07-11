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
            Console.WriteLine("8. Просмотр текущей статистики");
            Console.WriteLine("9. Просмотр всей статистики");
            Console.WriteLine("10. Выйти из приложения");
        }
        public string SetDifficulty(string var) 
        {

            switch (var)
            {
                case "1":
                    Console.WriteLine("Установлен легкий уровень");
                    return @".\Light_level.bin";
                case "2":
                    Console.WriteLine("Установлен средний уровень");
                    return @".\Medium_level.bin";
                case "3":
                    Console.WriteLine("Установлен тяжелый уровень");
                    return @".\Heavy_level.bin";
                default:
                    Console.WriteLine("Нет такого уровня сложности");
                    Console.WriteLine("Установлен легкий уровень");
                    return @".\Light_level.bin";

            }
        }
        public void PrintDiff()
        {
            Console.WriteLine("1) Легкий");
            Console.WriteLine("2) Средний");
            Console.WriteLine("3) Тяжелый");
        }
    }
}
