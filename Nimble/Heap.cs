namespace Nimble
{
    internal class Heap
    {
        public int MaxSize;
        public int CurSize;
        public string Name;
        public Heap(string name, int maxSize)
        {
            Name = name;
            MaxSize = maxSize;
            CurSize = maxSize;
        }

        public bool WithinLimits(int size)
        {
            return size > 0 && size < CurSize;
        }

        public void Pick(string player, int pebbles) 
        { 
            Console.WriteLine($"Player {player} has picked {pebbles} from Heap {Name}.");
            CurSize -= pebbles;
        }
    }
}
