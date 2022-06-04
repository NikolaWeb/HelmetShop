using HelmetShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelmetShop.Api.Payment
{
    public class OrderLine
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class Order
    {
        public IEnumerable<OrderLine> Lines { get; set; }
    }

    public class OrderProcessor
    {
        private IPaymentMethod _paymentMethod;
        public bool emailSent = false;

       

        public OrderProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void ProcessOrder(Order o)
        {

            foreach (var ol in o.Lines)
            {
                Console.WriteLine(ol.Name + ": " + ol.Price);
            }

            Console.WriteLine("Total: " + o.Lines.Sum(x=> x.Price * x.Quantity));

            var result = _paymentMethod.Pay(o.Lines.Sum(x => x.Price * x.Quantity));

            if (!result)
            {
                throw new Exception("Payment error!");
            }

            emailSent = true;
        }
    }
}
