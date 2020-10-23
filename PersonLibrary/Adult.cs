using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;


namespace PersonLibrary
{
    
    /// <summary>
    /// Класс описывает абстракцию типа Adult
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Нижняя возрастная граница
        /// </summary>
		private const int MinAge = 18;

        /// <summary>
        /// Верхняя возрастная граница
        /// </summary>
		private const int MaxAge = 110;

        

        /// <summary>
        /// Создание супру(-га/-ги)
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private int _age;

        /// <summary>
        /// Паспортные данные
        /// </summary>
        private string _passport;

        /// <summary>
        /// Cемейное положение
        /// </summary>
        private Marriage _marriage;

        /// <summary>
        /// Паспортные данные
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public Marriage Marriage
        {
            get
            {
                return _marriage;
            }
            set
            {
                //TODO: RSDN
                switch (value)
                {
                    case (Marriage.Married):
                    {
                        _partner = GetPerson(Sex == Gender.Female ? 
                          Gender.Male : Gender.Female, 
                          Marriage.Espoused);
                        _marriage = Marriage.Married;
                        break;
                    }
                    case (Marriage.Unmarried):
                    {
                        _marriage = Marriage.Unmarried;
                        break;
                    }
                    case (Marriage.Espoused):
                    {
                        _marriage = Marriage.Espoused;
                        break;
                    }
                
                
                }
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Свойство "Возраст"
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException("Персоны категории 'Adult' " +
                        "должны быть старше 18 лет");
                }
                if (value > MaxAge)
                {
                    throw new ArgumentException("Этой персоне больше подойдет " +
                        "категория 'Ancient'");
                }
                else
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// Конструктор взрослого
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="passport">Паспортные данные</param>
        /// <param name="marriage">Семейное положение</param>
        public Adult(string name, string surname, int age, Gender sex,
            string passport, Marriage marriage, string job)
            : base (name, surname, sex)
        {
            Age = age;
            Passport = passport;
            Marriage = marriage;
            Job = job;
        }
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Adult() : this("Дерил", "Диксон", 32, Gender.Male, "0100 001100", 
            Marriage.Unmarried, "Безработный") { }
            
        /// <summary>
        /// Формирует персону типа "Взрослый" 
        /// </summary>
        /// <returns>возвращает персону класса Adult</returns>
        public static Adult GetPerson(Gender gender, Marriage maritalStatus)
        {
            Adult newAdult = new Adult();
            string[] nameBaseMan = 
			{
				"Сергей", "Иван", "Алексей",
				"Михаил", "Андрей", "Федот",
				"Аркадий", "Натан", "Мстислав",
				"Олег", "Епифан", "Абрам",
			};
            string[] nameBaseWoman =
            {
                "Сара", "Марина", "Алена",
                "Надежда", "Анна", "Фаина",
                "Алиса", "Наталья", "Екатерина",
                "Ольга", "Елена", "Юлия",
            };
            string[] surnameBaseMan = 
            { "Волков", "Сумароков", "Гвоздев",
              "Шилов","Капустин", "Петров",
              "Флажков", "Газманов"
            };
            string[] surnameBaseWoman = 
            {
                "Волкова", "Сумарокова", "Гвоздева",
                "Шилова" ,"Капустина", "Петрова",
                "Флажкова", "Газманова"
            };
            string[] jobBase = 
            {
                "Безработн(-ый/-ая)", "Школа №8","Областная клиническая больница",
                "АО СО ЕЭС", "ИП Пирогова",
                "ФГУП 'ПО'Заря'", "Автодор Томск",
                "Продуктовый магазин 'Близкий'"
            };

            (string, string) nameSurname = ("", "");
            switch (gender)
            {
                case Gender.Female:
                {
                    nameSurname = CreatingName.GetNameSurname(nameBaseWoman, surnameBaseWoman);
                    break;
                }
                case Gender.Male:
                {
                    nameSurname = CreatingName.GetNameSurname(nameBaseMan, surnameBaseMan);
                    break;
                }
            }
            //TODO: RSDN
            Random random = new Random();
            newAdult.Name = nameSurname.Item1;
            newAdult.Surname = nameSurname.Item2;
            newAdult.Sex = gender;
			newAdult.Age = random.Next(MinAge, MaxAge);
            Thread.Sleep(20);
            newAdult.Passport = $"{random.Next(1000, 10000)} " +
                $"{random.Next(100000, 1000000)}";
            Thread.Sleep(20);
            newAdult.Job = jobBase[random.Next(0, jobBase.Length)];
            Thread.Sleep(20);
            newAdult.Marriage = maritalStatus;

            return newAdult;
        }


        /// <summary>
        /// Рандомное создание персоны
        /// </summary>
        /// <returns>Возвращает персону типа Adult</returns>
        public static Adult GetRandomPerson()
        {
            //TODO: RSDN
            Random random = new Random();
            Thread.Sleep(20);
            Gender gender = new Gender();
            Marriage maritalStatus = new Marriage();
            if (random.Next(0, 10) < 5)
            {
                gender = Gender.Male;
                Thread.Sleep(20);
            }
            if (random.Next(0, 10) < 7)
            {
                maritalStatus = Marriage.Married;
                Thread.Sleep(20);
            }
            else if (random.Next(0, 10) >= 7)
            {
                maritalStatus = Marriage.Unmarried;
                Thread.Sleep(20);
            }
            return GetPerson(gender, maritalStatus);
        }
        
        /// <summary>
        /// Метод получения информации о персоне
        /// </summary>
        /// <returns>Возвращает строку данных о персоне</returns>
        public override string GetInfo()
        {
            string maritalStatus = null;
            //TODO: перечисление
            switch (Marriage)
            {
                case Marriage.Unmarried:
                    maritalStatus = "В браке не состоит";
                    break;
                default:
                    maritalStatus = "Cостоит в браке";
                    break;
            }
            string info = $"Имя: {Name};\n" + $"Фамилия: {Surname};\n" +
                $"Возраст: {Age};\n" + $"Пол: {GetGenderOfPerson()};\n" +
                $"Паспортные данные: {Passport};\n" +
                $"Место работы: {Job};\n" +
                $"Семейное положение: {maritalStatus}.\n";
            if (_marriage == Marriage.Married)
            {
                info += "\n" + $"Информация о супруге: \n{_partner.GetInfo()}\n" +
                    "********************************************************************";
            }         
            return info;
        }

    }
}
