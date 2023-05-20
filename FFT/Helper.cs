using System.Numerics;

namespace FFT
{
    internal class Helper
    {
        public static List<Node> Take(List<Node> x, EvenOdd evenOdd)
        {
            var X = new List<Node>();

            if (evenOdd == EvenOdd.Even)
            {
                for (int i = 0; i < x.Count; i += 2)
                {
                    X.Add(x[i]);
                }
            }
            else if (evenOdd == EvenOdd.Odd)
            {
                for (int i = 1; i < x.Count; i += 2)
                {
                    X.Add(x[i]);
                }
            }

            else if (evenOdd == EvenOdd.Both)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    X.Add(new Node(new Complex(0.0, 0.0)));
                }
            }

            return X;
        }

        public static Complex Exp(int n, int k, int N)
        {
            return Complex.Exp(-2.0 * Math.PI * Complex.ImaginaryOne * n * k / N);
        }
    }
}
