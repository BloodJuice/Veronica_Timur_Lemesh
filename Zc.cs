using System;


class Zc
{
    private List<int> ni;
    private int k;
    
    public Zc(List<int> ni) { this.ni = ni; k = ni.Count(); }
    private void Swap(List<Double> array, int i, int j)
    {
        Double temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    private void CocktailSort(List<Double> inArray)
    {
        int left = 0,
             right = inArray.Count - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (inArray[i] > inArray[i + 1])
                    Swap(inArray, i, i + 1);
            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (inArray[i - 1] > inArray[i])
                    Swap(inArray, i - 1, i);
            }
            left++;
        }
    }

    public List<Double> NormalGenerateX(int count)
    {
        Random rand = new Random();
        List<Double> res = new List<double>();

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
        CocktailSort(res);
        return res;
    }

    public List<Double> MainFunction(int N)
    {
        int n = 0;
        
    }
    private double FunctionZc(int n)
    {
        double result = 0.0;
        for (int i = 0; i < ni.Count(); i++) { n += ni[i]; }
        for (int i = 0; i < k; i++)
        {
            double Rij = 1.0;
            for (int j = 0; j < k; j++, Rij++)
            {
                result += Math.Log(ni[i] / ((j + 1.0) - 0.5) - 1.0) * Math.Log(n / ((Rij + 1.0) - 0.5) - 1.0);
            }
        }
        result *= 1.0 / n;
        return result;
    }


}



