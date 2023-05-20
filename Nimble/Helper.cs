namespace Nimble
{
    internal class Helper
    {
        public static string[] Heaps;
        public static string[] Players;
        public static int Xors(int[] xs)
        {
            int xors = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                xors ^= xs[i];
            }
            return xors;
        }

        public static void RandomPick(Player player, List<Heap> heaps)
        {
            var nzHeap = heaps.FirstOrDefault(h => h.CurSize > 0);
            if (nzHeap != null)
            {
                var random = new Random();
                var pebbles = random.Next(1, nzHeap.CurSize);
                Console.WriteLine($"Player {player.Name} has picked {pebbles} from Heap {nzHeap.Name}!");
                nzHeap.CurSize -= pebbles;
            }
        }

        public static void OptimalPick(Player player, List<Heap> heaps, int nimSum)
        {
            if (nimSum == 0)
            {
                if (!heaps.Any(h => h.CurSize != 0))
                {
                    Console.WriteLine($"Player {player.Name} has lost the Game!");
                    return;
                }
            }
            for (int h = 0; h < heaps.Count; h++)
            {
                var heapNimSum = nimSum ^ heaps[h].CurSize;

                if (heapNimSum == 0)
                {
                    Console.WriteLine($"Player {player.Name} has picked {nimSum} from Heap {heaps[h].Name} and Lost!");
                    heaps[h].CurSize -= nimSum;
                    return;
                }

                if (heaps[h].WithinLimits(heapNimSum))
                {
                    Console.WriteLine($"Player {player.Name} has picked {heapNimSum} from Heap {heaps[h].Name}!");
                    heaps[h].CurSize -= heapNimSum;
                    break;
                }
            }
        }
    }
}
