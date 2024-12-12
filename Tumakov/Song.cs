using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    public class Song
    {
        public string name; //название песни
        public string author; //автор песни
        public Song prev; //связь с предыдущей песней в списке

        // метод для заполнения поля name
        public void SetName(string newName) { name = newName; }

        // метод для заполнения поля author
        public void SetAuthor(string newAuthor) { author = newAuthor; }

        // метод для заполнения поля prev
        public void SetPrev(Song previousSong) { prev = previousSong; }

        // метод для печати названия песни и ее исполнителя
        public void PrintSongInfo()
        {
            Console.WriteLine($"Название: {name}, Автор: {author}");
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        // метод, который сравнивает между собой два объекта-песни
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song other = (Song)obj;
            return name == other.name && author == other.author;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ author.GetHashCode(); // Простое хеширование
        }
    }
}
