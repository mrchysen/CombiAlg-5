namespace Logic;

public static class GraphReader
{
    public static int[,] ReadMatrixOfEdgeWeighted(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        int[,] matrix = new int[0,0];


        try
        {

            using(StreamReader sr = new(path))
            {
                var data = sr.ReadLine().Split().Select(int.Parse).ToArray();
                int n = data[0];

                matrix = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    data = sr.ReadLine().Split().Select(int.Parse).ToArray();

                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = data[j];
                    }
                }
            }
        }
        catch
        {
            Console.WriteLine("some error in reading file");
        }

        return matrix;
    }

    /// <summary>
    /// Считывает граф с весами
    /// </summary>
    /// <param name="path"></param>
    /// <param name="IsOriented">ориентированный ли граф</param>
    /// <returns></returns>
    public static List<List<(int, int)>> ReadGraphWithWeight(string path, bool IsOriented = true)
    {
        List<List<(int, int)>> ans = new();

        if (File.Exists(path))
        {
            try
            {
                using (StreamReader sr = new(path))
                {
                    var data = sr.ReadLine().Split().Select(int.Parse).ToArray();
                    int n = data[0];
                    int m = data[1];

                    for (int i = 0; i < n; i++)
                    {
                        ans.Add(new());
                    }

                    for (int i = 0; i < m; i++)
                    {
                        data = sr.ReadLine().Split().Select(int.Parse).ToArray();

                        ans[data[0] - 1].Add((data[1] - 1, data[2]));
                        if (!IsOriented)
                            ans[data[1] - 1].Add((data[0] - 1, data[2]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error_reading: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("info: No such file");
        }

        return ans;
    }

    public static List<List<(int, int)>> ReadGraphWithWeight(string path, out List<Edge> edges, bool IsOriented = true)
    {
        List<List<(int, int)>> ans = new();
        edges = new List<Edge>();

        if (File.Exists(path))
        {
            try
            {
                using (StreamReader sr = new(path))
                {
                    var data = sr.ReadLine().Split().Select(int.Parse).ToArray();
                    int n = data[0];
                    int m = data[1];

                    for (int i = 0; i < n; i++)
                    {
                        ans.Add(new());
                    }

                    for (int i = 0; i < m; i++)
                    {
                        data = sr.ReadLine().Split().Select(int.Parse).ToArray();

                        ans[data[0] - 1].Add((data[1] - 1, data[2]));
                        edges.Add(new Edge()
                        {
                            From = data[0] - 1,
                            To = data[1] - 1,
                            Wieght = data[2]
                        });

                        if (!IsOriented)
                        {
                            ans[data[1] - 1].Add((data[0] - 1, data[2]));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error_reading: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("info: No such file");
        }

        return ans;
    }


    /// <summary>
    /// NW - неориентированный - если true то добавляется путь в обе стороны
    /// </summary>
    /// <param name="path">Path - путь к графу</param>
    /// <param name="NW">No way - граф неориентирвоанный</param>
    /// <returns></returns>
    public static List<List<int>> ReadGraph(string path, bool NW = false)
    {
        List<List<int>> ans = new();

        if(File.Exists(path))
        {
            try
            {
                using (StreamReader sr = new(path))
                {
                    var data = sr.ReadLine().Split().Select(int.Parse).ToArray();
                    int n = data[0];
                    int m = data[1];

                    for (int i = 0; i < n; i++)
                    {
                        ans.Add(new());
                    }

                    for (int i = 0; i < m; i++)
                    {
                        data = sr.ReadLine().Split().Select(int.Parse).ToArray();

                        ans[data[0] - 1].Add(data[1] - 1);
                        if(NW)
                            ans[data[1] - 1].Add(data[0] - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error_reading: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("info: No such file");
        }

        return ans;
    }
}
