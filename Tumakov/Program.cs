using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }
        static void Task1()
        {

        }
        //Упражнение 8.2
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return ReverseString(input.Substring(1)) + input[0];
        }
        static void Task2()
        {
            Console.WriteLine($"Reversed \"cat\": {ReverseString("cat")}");          // tac
            Console.WriteLine($"Reversed \"012345\": {ReverseString("012345")}");            // 543210
            Console.WriteLine($"Reversed \"\": {ReverseString("")}");                    // ""
            Console.WriteLine($"Reversed null: {ReverseString(null)}");                 // null
        }
        // Упражнение 8.3
        static void Task3()
        {
            Console.Write("Введите имя входного файла: ");
            string inputFileName = Console.ReadLine();

            Console.Write("Введите имя выходного файла: ");
            string outputFileName = Console.ReadLine();


            try
            {
                // Проверка существования входного файла
                if (!File.Exists(inputFileName))
                {
                    Console.WriteLine($"Ошибка: файл {inputFileName} не найден.");
                    return;
                }

                // Чтение содержимого входного файла
                string fileContent = File.ReadAllText(inputFileName);

                // Преобразование текста в верхний регистр
                string upperCaseContent = fileContent.ToUpper();

                // Запись в выходной файл
                File.WriteAllText(outputFileName, upperCaseContent);

                Console.WriteLine($"Содержимое файла {inputFileName} успешно записано в файл {outputFileName} заглавными буквами.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        // Упражнение 8.4
        public static bool ImplementsIFormattable(object obj)
        {
            // Используем оператор 'is'
            bool implementsIs = obj is IFormattable;

            // Используем оператор 'as'
            IFormattable formattableObj = obj as IFormattable;
            bool implementsAs = formattableObj != null;
            return implementsAs; // return implementsIs; (as эффективнее)
        }
        static void Task4()
        {
            // Тестовые примеры
            Console.WriteLine($"DateTime реализует IFormattable: {ImplementsIFormattable(DateTime.Now)}");   // True
            Console.WriteLine($"int реализует IFormattable: {ImplementsIFormattable(123)}");             // True
            Console.WriteLine($"string реализует IFormattable: {ImplementsIFormattable("Hello")}");       // True
        }


        // Домашнее задание 8.1
        public void SearchMail(ref string s)
            {
              int index = s.IndexOf('#');
              if (index != -1)
              {
                    s = s.Substring(index + 1).Trim(); // Извлекаем почту и удаляем лишние пробелы
              }
              else
              {
                    s = "";
              }

            }
        static void Task5()
        {
                
        }
        // Домашнее задание 8.2
       static void Task6()
       {
            // Создаем список из четырех песен
            List<Song> songs = new List<Song>();

            Song song1 = new Song();
            song1.SetName("Песня 1");
            song1.SetAuthor("Автор 1");
            songs.Add(song1);

            Song song2 = new Song();
            song2.SetName("Песня 2");
            song2.SetAuthor("Автор 2");
            songs.Add(song2);

            Song song3 = new Song();
            song3.SetName("Песня 3");
            song3.SetAuthor("Автор 3");
            songs.Add(song3);

            Song song4 = new Song();
            song4.SetName("Песня 4");
            song4.SetAuthor("Автор 4");
            songs.Add(song4);


            // Выводим информацию о каждой песне
            Console.WriteLine("Список песен:");
            foreach (Song song in songs)
            {
                song.PrintSongInfo();
            }

            // Сравниваем первую и вторую песни
            bool areEqual = songs[0].Equals(songs[1]);
            Console.WriteLine($"\nПервая и вторая песни одинаковы: {areEqual}");


            Console.WriteLine($"\nЗаголовок первой песни: {songs[0].Title()}");
        }
    }

}
