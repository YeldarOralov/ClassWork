using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    public delegate void SendMessageDelegate(string message);

    public class BankAccount
    {
        public event SendMessageDelegate ReportEvent;
        public string FullName { get; set; }
        public int Sum { get; private set; } = 0;      

        public void AddSum(int sum)
        {
            Sum += sum;
            ReportEvent?.Invoke($"Вам начислено {sum}");
        }

        public int WithdrowSum(int sum)
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                ReportEvent?.Invoke($"У вас снято {sum}");
                return sum;
            }
            ReportEvent?.Invoke($"Недостаточно средств");
            return -1;
        }
    }
}
