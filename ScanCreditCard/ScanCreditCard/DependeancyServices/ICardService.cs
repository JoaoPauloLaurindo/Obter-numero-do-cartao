using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScanCreditCard.DependeancyServices
{
    public interface ICardService
    {
        void StartCapture();

        string GetCardNumber();

        string GetCardholderName();
    }
}
