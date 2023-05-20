namespace Nimble
{
    internal class Nim
    {
        public List<Player> Players { get; set; }
        public List<Heap> Heaps { get; set; }

        public Nim(string[] nHeaps, string[] nPlayers)
        {
            Players = new List<Player>(nPlayers.Length);
            Heaps = new List<Heap>(nHeaps.Length);

            for (int h = 0; h < nHeaps.Length; h++)
            {
                Heaps.Add(new Heap(nHeaps[h], 0));
            }
            for (int p = 0; p < nPlayers.Length; p++)
            {
                Players.Add(new Player(nPlayers[p]));
            }
        }

        public void Init(int[] heapSizes)
        {
            for (int i = 0; i < Heaps.Count; i++)
            {
                Heaps[i].MaxSize = heapSizes[i];
                Heaps[i].CurSize = heapSizes[i];
            }
        }

        public Player WhoWillWin(List<Player> players, List<Heap> heaps)
        {
            int turn = 0;
            int nimSum = -1;
            do
            {
                nimSum = Helper.Xors(heaps.Select(h => h.CurSize).ToArray());
                for (int h = 0; h < heaps.Count; h++)
                {
                    int heapNimSum = nimSum ^ heaps[h].CurSize;
                    if (heapNimSum == 0)
                        return players[turn % players.Count];
                    else
                    {
                        if (heaps[h].WithinLimits(heapNimSum))
                        {
                            heaps[h].CurSize -= heapNimSum;
                            turn++;
                            break;
                        }
                    }
                }

            }
            while (nimSum != 0);

            return players[turn % players.Count];
        }

        public void Play(List<Player> players)
        {
            int turn = 0;
            do
            {
                var nimSum = Helper.Xors(Heaps.Select(h => h.CurSize).ToArray());
                if (nimSum == 0)
                {
                    Helper.RandomPick(Players[turn % Players.Count], Heaps);
                    turn++;
                    continue;
                }
                for (int h = 0; h < Heaps.Count; h++)
                {
                    var heapNimSum = nimSum ^ Heaps[h].CurSize;
                    if (heapNimSum == 0)
                    {
                        Helper.RandomPick(Players[turn % Players.Count], Heaps);
                        turn++;
                        break;
                    }
                    else
                    {
                        Helper.OptimalPick(Players[turn % Players.Count], Heaps, heapNimSum);
                        turn++;
                        break;
                    }
                }
            } while (Heaps.Any(h => h.CurSize != 0));
        }
    }
}
