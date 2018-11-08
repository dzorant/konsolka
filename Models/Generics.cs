using System.Collections.Generic;

namespace konsolowe.Models
{

    public class Result<T>
    {
        public T Item { get; set; }
        public bool IsValid { get; set; }
        public string Error { get; set; }
    }

    public class Pair<TFirst, TSecond>
    {
        public TFirst First {get; set;}
        public TSecond Second {get; set;}
    }

    public class Triple<TFirst, TSecond,TThird> : Pair<TFirst, TSecond>
    {
        public TThird Third {get;set;}
    }
    public class GenericOrderProcessor
    {
        public Result<Order> ProcessOrder(string email, int orderId)
        {
            Order order = new Order(1,100);

            return new Result<Order>
            {
                Item = order
            };
        }

        public void LogOrder<T>(T order)
        {

        }

    }

    public class Generics
    {
        public void Test()
        {
            GenericOrderProcessor orderProcessor = new GenericOrderProcessor();
            Result<Order> result = orderProcessor.ProcessOrder("emial@gmail.pl", 1);
            
            Pair<int, string> pair = new Pair<int, string>();
            Triple<int, string, bool> triple = new Triple<int, string, bool>();
            
            ReferenceResult<Order> intResult = new ReferenceResult<Order>();
        }
    }
    public class ReferenceResult<T> where T : class
    {
        public T Result {get; set;}
    }
}