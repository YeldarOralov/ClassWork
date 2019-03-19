using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public delegate void SendMessageDelegate(string message);

    public class BankAccount
    {
        private SendMessageDelegate reporter;
        public string FullName { get; set; }
        public int Sum { get; private set; } = 0;

        public void RegisterReporter(SendMessageDelegate sendMessageDelegate)
        {
            reporter += sendMessageDelegate;
        }

        public void UnregisterDelegate(SendMessageDelegate sendMessageDelegate)
        {
            reporter -= sendMessageDelegate;
        }

        public void AddSum (int sum)
        {
            Sum += sum;
            reporter?.Invoke($"Вам начислено {sum}");
        }

        public int WithdrowSum(int sum)
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                reporter?.Invoke($"У вас снято {sum}");
                return sum;
            }
            reporter?.Invoke($"Недостаточно средств");
            return -1;
        }
    }
}
