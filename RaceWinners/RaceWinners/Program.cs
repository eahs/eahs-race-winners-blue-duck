using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceWinners
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService ds = new DataService();
 
            // Asynchronously retrieve the group (class) data
            var data = await ds.GetGroupRanksAsync();

            int[] avg = new int[4];
            
            int Aavg = 0;
            int Bavg = 0;
            int Cavg = 0;
            int Davg = 0;

            for (int i = 0; i < data.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < data[i].Ranks.Count; j++)
                {
                    sum += data[i].Ranks[j];
                }

                avg[i] = (sum / data[i].Ranks.Count);

                if (i == 0) Aavg = sum / data[i].Ranks.Count;
                if (i == 1) Bavg = sum / data[i].Ranks.Count;
                if (i == 2) Cavg = sum / data[i].Ranks.Count;
                if (i == 3) Davg = sum / data[i].Ranks.Count;
            }

            Array.Sort(avg);
            Array.Reverse(avg);

            for (int i = 0; i < avg.Length; i++)
            {
                if (avg[i] == Aavg) Console.WriteLine($"In place {i+1} is Class A with an average rank of {Aavg}");
                if (avg[i] == Bavg) Console.WriteLine($"In place {i+1} is Class B with an average rank of {Bavg}");
                if (avg[i] == Cavg) Console.WriteLine($"In place {i+1} is Class C with an average rank of {Cavg}");
                if (avg[i] == Davg) Console.WriteLine($"In place {i+1} is Class D with an average rank of {Davg}");
            }
        }
    }
}