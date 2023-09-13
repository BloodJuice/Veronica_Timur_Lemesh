using System;


namespace Program 
{   
    
    class SaverCoordinatesAndValues
    {
        private int i, j;
        private double xi;
        
        public SaverCoordinatesAndValues() { }
 
        public void setValues(int i, int j, double xi)
        {
            this.i = i;
            this.j = j;
            this.xi = xi;
        }
        public int getI { get { return i;} }
        public int getJ { get { return j; } }
        public double getXi { get { return xi; } }
    }
    class Zc
    {
        private List<int> ni;
        private int k;

        public Zc(List<int> ni) { this.ni = ni; k = ni.Count(); }
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

        public List<double> normalGenerateX(int count)
        {
            Random rand = new Random();
            List<double> res = new List<double>();

            for (int i = 0; i < ni[count]; i++)
            {
                double u1 = rand.NextDouble();
                double u2 = rand.NextDouble();
                if (i % 2 == 0) {
                    res.Add(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2));
                }
                if (i % 2 != 0)
                {
                    res.Add(Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2));
                }
                
            }
            return res;
        }

        private double functionZc()
        {
            List<List<double>> start_massive = new List<List<double>>();
            List<double> sort_massive = new List<double>();
            List<double> a = new List<double>();
            List<List<int>> Rij = new List<List<int>>();
            int n = 0;
            double result = 0.0;
            
            for (int i = 0; i < k; i++) n += ni[i];

            for (int i = 0; i < k; i++)
                start_massive.Add(normalGenerateX(i));
            

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


            for (int i = 0; i < k; i++) {
                SaverCoordinatesAndValues accumulateRang = new SaverCoordinatesAndValues();
                List<int> saverTemporaryMassive = new List<int>();
                for (int j = 0; j < ni[i]; j++) {
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

        public List<double> mainFunction(int N)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < N; i++)
            {
                result.Add(functionZc());
                Console.WriteLine(i);
            }
            //Print(result, "result");
            return result;
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




    



