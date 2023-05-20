using System.Numerics;
using System.Text;

namespace FFT
{
    internal class FFT
    {
        public int N;
        public readonly List<Node> x;
        public List<Node> X;

        public FFT(int N, List<Node> x)
        {
            this.N = N;
            this.x = new List<Node>();
            X = new List<Node>();

            for (int i = 0; i < N; i++)
            {
                this.x.Add(new Node(x[i].Value));
                X.Add(new Node(new Complex(0.0, 0.0)));
            }
        }

        public List<Node> Fft(List<Node> x)
        {
            int N = x.Count; //fetch the number of samples

            if (N == 1)
            {
                return x; //base case :- one signal.
            }

            var Xe = Fft(Helper.Take(x, EvenOdd.Even)); //fetch the even terms :- the Divide phase
            var Xo = Fft(Helper.Take(x, EvenOdd.Odd));  //fetch the odd terms  :- the Divide phase

            var X = Helper.Take(x, EvenOdd.Both); //combine the odd + even terms :- the Conquer phase

            for (int k = 0; k < N / 2; k++)
            {
                Complex e = Xe[k].Value; //compute the even term
                Complex o = Helper.Exp(1, k, N) * Xo[k].Value; //compute the odd term
                X[k] = new Node(e + o); //Lower half range series is :- (even + odd) term
                X[k + N / 2] = new Node(e - o); //Upper half range series :- (even - odd) term
            }

            return X; //return the full range of signals
        }

        public string print(List<Node> cs)
        {
            var str = new StringBuilder();
            for (int j = 0; j < cs.Count; j++)
            {
                str.Append($"{cs[j].Value},");
            }
            return str.ToString().TrimEnd(',');
        }
    }
}
