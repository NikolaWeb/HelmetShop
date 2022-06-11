using System;

namespace HelmetShop.Api.Payment
{
    public interface IPaymentMethod
    {
        bool Pay(decimal amount);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class CCPaymentMethod : IPaymentMethod, ILogger
    {
        private string _ccNumber;
        private int _ccv;
        private string _expDate;

        public CCPaymentMethod(string ccNumber, int ccv, string expDate)
        {
            _ccNumber = ccNumber;
            _ccv = ccv;
            _expDate = expDate;
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying with credit card...");
            return true;
        } 
    }

    public class PPPaymentMethod : IPaymentMethod
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying with Paypal...");
            return true;
        }
    }

    public class WireTransfer : IPaymentMethod
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying via wire transfer...");
            return true;
        }
    }
}
