using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace oop_laba1
{
    /// <summary>
    /// Создание новой персоны
    /// </summary>
    public static class InputPerson
    {
        /// <summary>
        /// Ввод данных в консоль
        /// </summary>
        /// <param name="data">Название вводимых данных</param>
        /// <returns>Введенные данные</returns>
        private static string DataInput(string data)
        {
            Console.WriteLine("Введите " + data);
            return Console.ReadLine();
        }

        /// <summary>
        /// Возрващает информацию о человеке
        /// </summary>
        /// <returns>Информация о человеке</returns>
        public static Person ReadFrom()
        {
            var person = new Person();
            var actionList = new List<Action>()
            {
                () =>
                {
                    person.Name = DataInput("Имя");
                },
                () =>
                {
                    person.Surname = DataInput("Фамилию");
                },
                () =>
                {
                    if (!Int32.TryParse(DataInput("Возраст"), out int age))
                    {
                        throw new ArgumentException(
                            string.Format("not integer",
                            nameof(age)));
                    }
                    person.Age = age;
                },
                () =>
                {
                    string genderStr = DataInput("Пол (Male/Female)");
                    var gender = Gender.Female;

                    //Преобразование строки для формата Gender
                    if (genderStr.ToLower() == "male")
                    {
                        gender = Gender.Male;
                    }
                    else if (genderStr.ToLower() == "female")
                    {
                        gender = Gender.Female;
                    }
                    else
                    {
                        throw new ArgumentException(
                            string.Format("***Wrong Gender***",
                            nameof(gender)));
                    }

                    person.Gender = gender;
                }
            };
            foreach (var action in actionList)
            {
                ActionCall(action);
            }

            return Person.ToCorrect(person);
        }

        /// <summary>
        /// Вызов делегатов
        /// </summary>
        /// <param name="action">Делегат</param>
        private static void ActionCall(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (ArgumentException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
