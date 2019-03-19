using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class BankAccount
    {
        public string FullName { get; set; }
        public int Sum { get; private set; } = 0;
        public IReporter Reporter { get; private set; }

        public BankAccount(IReporter reporterCallback)
        {
            Reporter = reporterCallback;
        }

        public void AddSum (int sum)
        {
            Sum += sum;
            if(Reporter!=null)
                Reporter.SendMessage($"Вам начислено {sum}");
        }

        public int WithdrowSum(int sum)
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                if (Reporter != null)
                    Reporter.SendMessage($"У вас снято {sum}");
                return sum;
            }
            if (Reporter != null)
                Reporter.SendMessage($"Недостаточно средств");
            return -1;
        }
    }
}
