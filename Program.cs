using System;
using System.IO;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ni = new List<int> { 10, 10 };
            string nameFile = "Критерий Жанга Zc (К выборок)";
            Zc value = new Zc(ni);
            int N = 16600;
            int nMonteKarlo = 1000;
            //writeFile(value.mainFunction(N), nameFile, ni[0], N);

            MonteKarlo monteKarlo = new MonteKarlo(ni, value.mainFunction(N), nMonteKarlo);
            Console.WriteLine($"Result: {monteKarlo.mainFunction(N)}");
        }
        
        static void Print(List<Double> res)
        {
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
        static void writeFile(List<double> list, string nameFile, int n, int N)
        {
            try
            {
                StreamWriter sw = new StreamWriter("E:\\Магистр_2_сем\\КТМиАД\\Timur_Veronica_C#" +
                    "\\Veronica\\ShngZc\\" + nameFile + "n_" + n.ToString() + "_" + "N_" + N.ToString() + ".dat");
                sw.WriteLine(nameFile + " " + "n = " + n.ToString() + " " + "N = " + N.ToString() + 
                    "\n" + "0" + " " + N.ToString());
                for (int i = 0; i <  list.Count; i++)
                {
                    sw.WriteLine((list[i].ToString()).Replace(",", ".") + "e+00");
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}

