using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp4_MachineTest
{
    public interface IPayable
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal CheckBalance();
    }

}
