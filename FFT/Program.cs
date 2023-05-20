using System.Numerics;
using System.Text;

namespace FFT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 8;
            int[] samples = { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<Node> spatialSamples = new List<Node>();
            List<Node> fftSpectralSamples = new List<Node>();
            for (int i = 0; i < N; i++)
            {
                spatialSamples.Add(new Node(new Complex(Convert.ToDouble(samples[i]), 0.0)));
                fftSpectralSamples.Add(new Node(new Complex(0.0, 0.0)));
            }
            var fft = new FFT(N, spatialSamples);
            fftSpectralSamples = fft.Fft(fft.x);

            Console.WriteLine($"-------FFT Divide N Conquer Algorithm-----------");
            Console.WriteLine($"(Spatial) x[N] = {fft.print(spatialSamples)}");
            Console.WriteLine($"(FFT) X[N] = {fft.print(fftSpectralSamples)}");

            Console.ReadKey();
        }
    }
}