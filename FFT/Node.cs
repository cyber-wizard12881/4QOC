using System.Numerics;

namespace FFT
{
    internal class Node
    {
        public Complex Value;
        public Node(Complex val)
        {
            Value = val;
        }
    }
}
