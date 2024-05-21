using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class GraphPrinter
{
    public static void Print(List<List<(int, int)>> g)
    {
        var edgeCount = 0;
        g.ForEach(l => edgeCount += l.Count);
        Console.WriteLine($"{g.Count} {edgeCount}");
        

        for (int i = 0; i< g.Count; i++)
        {
            g[i].ForEach(elem => Console.WriteLine($"{i+1} {elem.Item1+1} {elem.Item2}"));
        }
    }
}
