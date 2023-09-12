using System;


namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ni = new List<int> { 10, 10 }; 
            Zc value = new Zc(ni);
            int N = 100;
            Print(value.mainFunction(N));
        }
        
        static void Print(List<Double> res)
        {
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
    }
}

