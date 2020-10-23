using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace PersonLibrary
{
    /// <summary>
    /// Абстрактный класс PersonBase
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

		/// <summary>
		/// Имя
		/// </summary>
		public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        /// <summary>
        /// Проверка символов, вводимых в поля "Имя" и "Фамилия"
        /// </summary>
        /// <param name="value">входная строка</param>
        /// <returns>Возвращает обработанную строку</returns>
        private static string Validation(string value)
        {
            string workingString = "";
            string pattern = @"[A-я ]*";
            Regex regex = new Regex($"{pattern}|{pattern}-{pattern}");
            foreach (Match match in regex.Matches(value))
            {
                workingString += match.Value;
            }

            if (workingString == string.Empty)
            {
                throw new ArgumentException("Поле осталось пустым");
            }

            string[] line = workingString.Split(' ');
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Length >= 1)
                {
                    line[i] = line[i].Substring(0, 1).ToUpper() +
                        line[i].Substring(1, line[i].Length - 1).ToLower();
                    value += line[i];
                }
                else
                {
                    value = null;
                }
            }
            value = String.Join(" ", line);
            return value;
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public abstract int Age { get; set; }
   
		/// <summary>
		/// Пол субьетка
		/// </summary>
		public Gender Sex { get; set; }
		
        //TODO: Понизить область видимости
		/// <summary>
		/// Конструктор класса <see cref="PersonBase"/>
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="surname">Фамилия</param>
		/// <param name="sex">Пол</param>
		public PersonBase(string name, string surname, Gender sex)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
        }

        /// <summary>
        /// Абстрактный метод получения информации о персоне
        /// </summary>
        public abstract string GetInfo();

        /// <summary>
        /// Для вывода наименованя пола персоны
        /// </summary>
        /// <returns>Возвращает наименование пола 
        /// на русском языке в формате string</returns>
        public string GetGenderOfPerson()
        {
            string genderInfo = null;
            switch (Sex)
            {
                case Gender.Male:
                    genderInfo = "Мужской";
                    break;
                case Gender.Female:
                    genderInfo = "Женский";
                    break;
            }
            return genderInfo;
		}
    }
}
