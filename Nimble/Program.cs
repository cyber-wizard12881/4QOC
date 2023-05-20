namespace Nimble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Heaps = { "A", "B", "C" };
            string[] Players = { "Computer", "Man" };
            int[] heaps = { 3, 4, 5 };
            var localHeaps = new Heap[heaps.Length];
            for (int i = 0; i < localHeaps.Length; i++)
            {
                localHeaps[i] = new Heap(Heaps[i], heaps[i]);
                localHeaps[i].CurSize = heaps[i];
            }
            Console.WriteLine("The Game of Nim - Misere Play.");
            Nim nim = new Nim(Heaps, Players);
            nim.Init(heapSizes: heaps);
            var winner = nim.WhoWillWin(nim.Players, localHeaps.ToList());
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"The Winner of the game of Nim will be {winner.Name}!");
            Console.WriteLine("-------------------------------------------------------");
            nim.Play(nim.Players);
            Console.ReadKey();
        }
    }
}