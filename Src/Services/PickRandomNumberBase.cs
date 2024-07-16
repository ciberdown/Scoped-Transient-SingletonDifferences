using WebApi_Test.Src.Interfaces;

namespace WebApi_Test.Src.Services
{
    public class PickRandomNumberBase : IPickRandomNumberBase
    {
        public int rnd {get; set;}
        public int rnd2 {get; set;}
        protected PickRandomNumberBase()
        {
            rnd = random().Next();
            rnd2 = random().Next();
        }
        private Random random(){
            return new Random();
        }
        public void LogRandom(){
            Console.WriteLine("Hii--------=============");
            Console.WriteLine($"first picked number is: {rnd}");
            Console.WriteLine($"second picked number is: {rnd2}");
        }
    }
}