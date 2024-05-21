using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class Edge
{
    public int From;
    public int To;
    public int Wieght;

    public override string ToString() => $"{From} {To} {Wieght}"; 
}
