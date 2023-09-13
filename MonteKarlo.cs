using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class MonteKarlo
    {
        private List<int> ni;
        private int k, M;
        private List<double> zcDistr;

        public MonteKarlo(List<int> ni, List<double> zcDistr, int M) 
        { 
            this.ni = ni;
            this.zcDistr = zcDistr;
            this.M = M;
            k = ni.Count(); 
        }

        private void swap(List<Double> array, int i, int j)
        {
            Double temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private List<Double> cocktailSort(List<Double> inArray)
        {
            int left = 0,
                 right = inArray.Count - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (inArray[i] > inArray[i + 1])
                        swap(inArray, i, i + 1);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (inArray[i - 1] > inArray[i])
                        swap(inArray, i - 1, i);
                }
                left++;
            }
            return inArray;
        }
        public List<double> uniformDistr(int count)
        {
            Random rand = new Random();
            List<double> res = new List<double>();

            for (int i = 0; i < ni[count]; i++)
                res.Add(rand.NextDouble());
            return res;
        }
        public List<double> normalGenerateX(int count)
        {
            Random rand = new Random();
            List<double> res = new List<double>();

            for (int i = 0; i < ni[count]; i++)
            {
                double u1 = rand.NextDouble();
                double u2 = rand.NextDouble();
                if (i % 2 == 0)
                {
                    res.Add(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2));
                }
                if (i % 2 != 0)
                {
                    res.Add(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2));
                }

            }
            return res;
        }

        private double functionMonteKarlo()
        {
            List<List<double>> start_massive = new List<List<double>>();
            List<double> sort_massive = new List<double>();
            List<double> a = new List<double>();
            List<List<int>> Rij = new List<List<int>>();
            int n = 0;
            double result = 0.0;

            for (int i = 0; i < k; i++) n += ni[i];

            start_massive.Add(uniformDistr(0));
            //start_massive.Add(normalGenerateX(0));
            start_massive.Add(normalGenerateX(1));


            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < start_massive[i].Count; j++)
                    a.Add(start_massive[i][j]);
            }
            for (int i = 0; i < k; i++)
                cocktailSort(start_massive[i]);

            sort_massive.AddRange(cocktailSort(a));
            //Print(start_massive, "start_massive");
            //Print(sort_massive, "sort_massive");


            for (int i = 0; i < k; i++)
            {
                SaverCoordinatesAndValues accumulateRang = new SaverCoordinatesAndValues();
                List<int> saverTemporaryMassive = new List<int>();
                for (int j = 0; j < ni[i]; j++)
                {
                    accumulateRang.setValues(i, j, start_massive[i][j]);
                    for (int z = 0; z < n; z++)
                    {
                        if (accumulateRang.getXi == sort_massive[z])
                        {
                            saverTemporaryMassive.Add(z + 1);
                            break;
                        }
                    }

                }
                Rij.Add(saverTemporaryMassive);
            }
            //Print(Rij, "Rij");    

            for (int i = 0; i < k; i++)
            {

                for (int j = 0; j < ni[i]; j++)
                {
                    result += Math.Log(ni[i] / (j + 1.0 - 0.5) - 1.0) * Math.Log(n / (Rij[i][j] - 0.5) - 1.0);
                }
            }
            result /= n;
            return result;
        }

        private double summa(List<double> mas)
        {
            double sum = 0;
            for (int i = 0; i < mas.Count; i++)
                sum += mas[i];
            
            return sum;
        }

        public double mainFunction(int N)
        {
            double m;
            m = 0;
            
            for (int j = 0; j < M; j++)
            {
                List<double> result = new List<double>();
                for (int i = 0; i < N; i++)
                    result.Add(functionMonteKarlo());
                
                if (summa(zcDistr) > summa(result)) m++;
                Console.WriteLine(j);
            }
            
            return (1 - m / M);
        }
        private void Print(List<double> massive, string Title)
        {
            Console.WriteLine(Title);
            for (int i = 0; i < massive.Count; i++)
                Console.WriteLine(massive[i]);
        }
        private void Print(List<List<double>> massive, string Title)
        {
            Console.WriteLine(Title);
            for (int i = 0; i < massive.Count; i++)
                for (int j = 0; j < massive[i].Count; j++)
                    Console.WriteLine(massive[i][j]);
        }
        private void Print(List<List<int>> massive, string Title)
        {
            Console.WriteLine(Title);
            for (int i = 0; i < massive.Count; i++)
                for (int j = 0; j < massive[i].Count; j++)
                    Console.WriteLine(massive[i][j]);
        }
    }
}

