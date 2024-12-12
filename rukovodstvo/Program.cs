using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rukovodstvo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем сотрудников
            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор");
            Employee ilham = new Employee("Ильхам", "Директор по автоматизации");
            Employee lukas = new Employee("Лукас", "Главный бухгалтер");
            Employee orkadiy = new Employee("Оркадий", "Начальник инф систем");
            Employee volodia = new Employee("Володя", "Зам.начальника");
            Employee ilshat = new Employee("Ильшат", "Главный системщик");
            Employee ivanych = new Employee("Иваныч", "Зам.системщик");
            Employee ilya = new Employee("Илья", "Системщик");
            Employee vitya = new Employee("Витя", "Системщик");
            Employee zhenya = new Employee("Женя", "Системщик");
            Employee sergey = new Employee("Сергей", "Главный разработчик");
            Employee lyaysan = new Employee("Ляйсан", "Зам.разработчик");
            Employee marat = new Employee("Марат", "Разработчик");
            Employee dina = new Employee("Дина", "Разработчик");
            Employee ildar = new Employee("Ильдар", "Разработчик");
            Employee anton = new Employee("Антон", "Разработчик");


            // Строим иерархию
            timur.Subordinates.AddRange(new[] { rashid, ilham });
            rashid.Subordinates.Add(lukas);
            ilham.Subordinates.AddRange(new[] { orkadiy, volodia });
            orkadiy.Subordinates.AddRange(new[] { ilshat, ivanych });
            ilshat.Subordinates.AddRange(new[] { ilya, vitya, zhenya });
            volodia.Subordinates.Add(sergey);
            sergey.Subordinates.Add(lyaysan);
            lyaysan.Subordinates.AddRange(new[] { marat, dina, ildar, anton });


            // Создаем задачи
            List<Tuple<Employee, string, string, Employee>> tasks = new List<Tuple<Employee, string, string, Employee>>()
        {
            new Tuple<Employee, string, string, Employee>(orkadiy, "Настроить сеть", "Системщики", ilya),
            new Tuple<Employee, string, string, Employee>(lyaysan, "Исправить баг", "Разработчики", dina),
            new Tuple<Employee, string, string, Employee>(timur, "Подготовить отчет", "Начальство", rashid),
            new Tuple<Employee, string, string, Employee>(rashid, "Сделать автоматизацию", "Начальство", lukas), //Бухгалтерия хочет автоматизацию (не получит)
            new Tuple<Employee, string, string, Employee>(sergey, "Добавить функционал", "Разработчики", ildar),

        };

            // Распределяем задачи и выводим результаты
            Console.WriteLine("Распределение задач:");
            foreach (var task in tasks)
            {
                bool accepted = task.Item4.AcceptsTask(task.Item1, task.Item2, task.Item3);
                Console.WriteLine($"От {task.Item1.Name} дается задача «{task.Item2}» ({task.Item3}) {task.Item4.Name}. Берет задачу: {accepted}");
            }
        }
    }
}
