using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PersonLibrary
{
    /// <summary>
    /// Класс описывает метод CreatingName
    /// </summary>
    public class CreatingName
    {
        //TODO: Вынести, RSDN
        // Метод возвращает значение типа (string, string),
        // в котором содержится имя и фамилия
        /// <returns>Возвращает Имя и Фамилию персоны</returns>
        internal static (string, string) GetNameSurname(string[] nameBase, string[] surnameBase)
        {
            Random random = new Random();
            (string Name, string LastName) namePerson;
            namePerson.Name = nameBase[random.Next(0, nameBase.Length)];
            Thread.Sleep(20);
            namePerson.LastName = surnameBase[random.Next(0, surnameBase.Length)];
            return namePerson;
        }
    }
}
