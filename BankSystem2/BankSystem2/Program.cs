using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount
            {
                FullName = "П.П.Якубович"
            };

            var reporter = new ConsoleReporter();
            account.ReportEvent += reporter.SendMessage;
            account.ReportEvent += BlahBlah;

            //анонимный метод
            account.ReportEvent += delegate (string text) {
                Console.WriteLine("asas");
                return;//можно и не писать в случае с void
            };

            //лямбда выражение - это скоращение вызова анонимного метода
            account.ReportEvent += (mess) => Console.WriteLine(mess);
            account.ReportEvent += (text) =>
            {
                Console.WriteLine(text);
            };

            var data = new List<string>
            {
                "Алматы",
                "Караганда",
                "Нур-Султан"
            };
            //без лямбда и синт. сахара
            var bufferList = new List<string>();
            foreach(var cityName in data)
            {
                if (cityName.ToLower().Contains("т"))
                {
                    bufferList.Add(cityName);
                }
            }

            //с исп. лямбда выражениями
            var result = data.Where(cityName=> cityName.ToLower().Contains("т"));

            account.AddSum(1000);
            account.WithdrowSum(100);
            Console.Read();

            void BlahBlah(string t)
            {

            }
        }
    }
}
