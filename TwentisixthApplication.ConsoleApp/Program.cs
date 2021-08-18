using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TwentisixthApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstName firstName = new FirstName();
            firstName.NameEvent += ShowName;
            while(true)
            {
                try
                {
                    firstName.Read();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }
            
        }
        static void ShowName(int num)
        {
            switch(num)
            {
                case 1: Console.WriteLine("Введено значение 1"); break;
                case 2: Console.WriteLine("Введено значение 2"); break;
            }
        }

    }
    class FirstName
    {
        public delegate void NameDelegate(int num);
        public event NameDelegate NameEvent;
        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Необходимо ввести значение либо 1, либо 2");
            int num = Convert.ToInt32(Console.ReadLine());
 
            if (num != 1 && num != 2) throw new FormatException();
            Name(num);
            AdvertName(num);
        }
        protected virtual void Name(int num)
        {
            NameEvent.Invoke(num);

        }
        public void AdvertName(int num)
        {
            List<string> allName = new List<string>();
            allName.Add("Иванов");
            allName.Add("Лесков");
            allName.Add("Петров");
            allName.Add("Меньшиков");
            allName.Add("Новиков");
            List<string> sortedList = null;
            if (num == 1)
            {
                sortedList = allName.OrderBy(n => n).ToList();
            }
            else if (num == 2)
            {
                sortedList = allName.OrderByDescending(n => n).ToList();
            }
            
            foreach (string str in sortedList)
                Console.WriteLine(str);
            Console.ReadLine();
        }
        
    }
}
