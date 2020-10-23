using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PersonLibrary
{
   /// <summary>
    /// Класс описывает абстракцию типа Child
    /// </summary>
    public class Child: PersonBase
    {
        /// <summary>
        /// Нижняя возрастная граница
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Верхняя возрастная граница
        /// </summary>
        private const int MaxAge = 18;

        /// <summary>
        /// Массив, содержащий родителей
        /// </summary>
        private Adult[] _family;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private int _age;

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
                    throw new ArgumentException("Ребенок находится на " +
                        "стадии планирования либо еще не родился");
                }
                else if (value >= MaxAge)
                {
                    throw new ArgumentException("Ваш ребенок уже не ребёнок");
                }
                else
                {
                    _age = value;
                }
            }
        }
       
        /// <summary>
        /// Поле "Родители"
        /// </summary>
        private Parents _parents;

        /// <summary>
        /// Информация о родителях
        /// </summary>
        public Parents Parents
        {
            get
            {
                return _parents;
            }
            set
            {
                //TODO: RSDN
                switch (value)
                {
                    case (Parents.BothParents):
                    {
                        _family = new Adult[2]

                        {
                            Adult.GetPerson(Gender.Male, Marriage.Espoused),
                            Adult.GetPerson(Gender.Female, Marriage.Espoused)
                        };

                        _parents = Parents.BothParents;
                        break;
                    }
                    case (Parents.OnlyMother):
                    {
                        _family = new Adult[1]

                        {
                           Adult.GetPerson(Gender.Female, Marriage.Espoused)
                        };

                        _parents = Parents.OnlyMother;
                        break;
                    }
                    case (Parents.Orphan):
                    {
                        _parents = Parents.Orphan;
                        break;
                    }

                }
                
            }
        }

        /// <summary>
        /// Название школы/детского сада
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Конструктор ребенка
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="parents">Информация о родителях</param>
        /// <param name="school">Детский сад/Школа</param>
        public Child(string name, string surname, int age, Gender sex,
            Parents parents, string school)
            : base(name, surname, sex)
        {
            Age = age;
            Parents = parents;
            School = school;
        }

        /// <summary>
        /// Конструктор по умолчнию
        /// </summary>
        public Child() : this("Павлик", "Морозов", 6, Gender.Male,
            Parents.Orphan, "обошли стороной") { }

        

        /// <summary>
        /// Формирует ребенка случайным образом.
        /// </summary>
        /// <returns>Возвращает ребенка</returns>
        public static Child GetRandomChild()
        {
            Child newChild = new Child();
            //TODO: RSDN
            Random random = new Random();
            
            string[] nameBaseMan = 
            {
                "Сергей", "Иван", "Алексей",
                "Михаил", "Андрей", "Федот",
                "Альберт", "Натан", "Кирилл",
                "Олег", "Матвей", "Анан"
            };
            string[] nameBaseWoman = 
            {
                "Саша", "Ира", "Алла",
                "Кира", "Алена", "Зина",
                "Алиска", "Наташа", "Екатерина",
                "Оля", "Лена", "Аня"
            };
            string[] surnameBaseMan = 
            {
                "Волков", "Сумароков", "Гвоздев",
                "Шилов","Капустин", "Петров",
                "Флажков", "Газманов"
            };
            string[] surnameBaseWoman = 
            {
                "Волкова", "Сумарокова", "Гвоздева",
                "Шилова" ,"Капустина", "Петрова",
                "Флажкова", "Газманова"
            };
            string[] schoolBase =
            {
                "Детский сад 'Буратино'", "Школа №8",
                "Детский сад 'Радуга'","Гимназия № 2",
                "Лицей № 22", "Домашнее обучение",
                "Кадетское училище №1",
                "Частная школа " +
                "им. Б.Н. Ельцина"
            };
            var childGender = random.Next(0, 2);
            Thread.Sleep(20);
            (string, string) nameSurname = ("", "");
            switch (childGender)
            {
                case 0:
                {
                    newChild.Sex = Gender.Female;
                    nameSurname = CreatingName.GetNameSurname(nameBaseWoman, surnameBaseWoman);
                    break;
                }
                case 1:
                {
                    newChild.Sex = Gender.Male;
                    nameSurname = CreatingName.GetNameSurname(nameBaseMan, surnameBaseMan);
                    break;
                }
            }
            newChild.Name = nameSurname.Item1;
            newChild.Surname = nameSurname.Item2;
            newChild.Age = random.Next(MinAge, MaxAge);
            Thread.Sleep(20);
            newChild.School = schoolBase[random.Next(0, schoolBase.Length)];
            Thread.Sleep(20);
            switch (random.Next(0, 4))
            {
                case 0:
                    newChild.Parents = Parents.Orphan;
                    break;
                case 1:
                    newChild.Parents = Parents.OnlyMother;
                    break;
                case 2:
                    newChild.Parents = Parents.OnlyFather;
                    break;
                case 3:
                    newChild.Parents = Parents.BothParents;
                    break;
            }
            return newChild;
        }


        /// <summary>
        /// Метод для вывода информации о ребенке
        /// </summary>
        /// <returns>Возвращает строку со всеми данными
        /// о ребенке</returns>
        public override string GetInfo()
        {
            string info = null;
            info = $"Имя: {Name};\n" + $"Фамилия: {Surname};\n" +
            $"Возраст: {Age};\n" + $"Пол: {GetGenderOfPerson()};\n" +
            $"Детский сад/ Школа: {School};\n" + 
            $"Родители: " + "\n" ;
            switch (Parents)
            {
                case Parents.Orphan:
                    info += "Отсутствуют\n";
                    break;
                case Parents.OnlyMother:
                    info += $"\nМать: {_family[0].GetInfo()}\n";
                    break;
                case Parents.OnlyFather:
                    info += $"\nОтец: {_family[0].GetInfo()}\n";
                    break;
                case Parents.BothParents:
                    info += $"\nОтец:\n{ _family[0].GetInfo()}\n" +
                        $"Мать:\n{ _family[1].GetInfo()}\n";
                    break;
            }
            return info += "*********************************" +
                "***********************************";
        }
    }
}
