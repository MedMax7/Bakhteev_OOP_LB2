using System;
using static System.Console;
using PersonLibrary;

namespace LAB2
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Работа программы
        /// </summary>
        static void Main(string[] args)
        {
            #region Для тестирования
            /* PersonBase potsan = Child.GetChild();
             WriteLine(potsan.GetInfo());
             while (true)
             {
                 try
                 {
                     int age = GetCorrectInt("Введите возраст");
                     Adult human = new Adult("Володя", "Головин", age,
                     Gender.Male, "1234 567890", Marriage.married, "Морг");
                     Console.WriteLine(human.GetInfo());
                     break;
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                 }
             }


             while (true)
             {
                 try
                 {
                     int age = GetCorrectInt("Введите возраст");
                     Child kid = new Child("Павлик", "Морозов", age, Gender.Male,
             Parents.orphan, "обошли стороной");
                     Console.WriteLine(kid.GetInfo());
                     break;
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                 }
             }
             */
            #endregion

            Random random = new Random();
            PersonBase[] personList = new PersonBase[7];
            for (int i = 0; i < 7; i++)
            {
                WriteLine($"Номер элемента в списке: {i}");
                WriteLine();
                if (random.Next(0, 100) < 50)
                {
                    personList[i] = Adult.GetRandomPerson();
                }
                else
                {
                    personList[i] = Child.GetRandomChild();
                }
                WriteLine(personList[i].GetInfo());
            }

			const int personIndex = 4;
            WriteLine();
            WriteLine(personList[personIndex].GetType().Name);
            WriteLine();			

			if (personList[personIndex] is Adult adult)
            {
				WriteLine(adult.Passport);
            }
            else if (personList[personIndex] is Child child)
            {
                WriteLine(child.School);
            }
            ReadLine();
        }
    }
}
