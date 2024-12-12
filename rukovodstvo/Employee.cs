using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rukovodstvo
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Employee> Subordinates { get; set; } = new List<Employee>();

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public bool AcceptsTask(Employee from, string taskName, string taskType)
        {
            // Сотрудник принимает задачу только от прямого руководителя
            if (from == null) return false; // Задача не назначена


            // Проверка на соответствие типа задачи и отдела
            bool isCorrectTaskType = false;
            switch (taskType)
            {
                case "Разработчики":
                    isCorrectTaskType = Position.Contains("разработчик", StringComparison.OrdinalIgnoreCase);
                    break;
                case "Системщики":
                    isCorrectTaskType = Position.Contains("системщик", StringComparison.OrdinalIgnoreCase);
                    break;
                case "Начальство":
                    isCorrectTaskType = Position.Contains("начальник", StringComparison.OrdinalIgnoreCase) || Position.Contains("зам", StringComparison.OrdinalIgnoreCase);
                    break;
                default:
                    isCorrectTaskType = false;
                    break;
            }


            bool isDirectManager = false;
            if (Subordinates != null)
            {
                isDirectManager = this.Subordinates.Contains(from) || (from.Subordinates?.Contains(this) ?? false);
            }

            return isCorrectTaskType && isDirectManager;
        }
    }
}
