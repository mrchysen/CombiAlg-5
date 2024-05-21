using Logic;

var g = GraphReader.ReadGraphWithWeight("g3.txt",true);

GraphAlgorithms.ReverseGraphWeight(g);

GraphAlgorithms.Floyd(g,1, 14);