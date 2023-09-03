using System;


class Zc
{
    private List<Double> ni;
    private int k;
    
    public Zc(List<Double> ni, int k) { this.ni = ni; this.k = k; }

    private List<Double> NormalGenerateX(List<Double> ni, int count)
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
        return res;
    }

}



