using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_12
    {
        static string[][] matrices = new string[41][];
        int[][] visited = new int[41][];
        static int ColCount = 0;
        static int RowCount = 0;
        int pathCount =1;
        static string[] signal = { "a","b","c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q"
            , "r", "s", "t", "u", "v", "w", "x", "y","z"};

        static public point target = new point(0,0,0);
        static public point current = new point(0,0,0);
        public int currentLetter = 0;
        static public List<int> path = new List<int>();
        public class point
        {
            public int x;
            public int y;
            public int patcount;
            public point(int x,int y,int patcount)
            {
                this.x = x;
                this.y = y;
                this.patcount = patcount;
            }
        }
        public string FirstSolution(List<string> readings)
        {
            RowCount = readings.Count;
            if (readings.Count > 0)
            {
                ColCount = readings[0].Count();
            }

            for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new string[ColCount];
                visited[i] = new int[ColCount];
                string r = readings[i];

                for (int j = 0; j < r.Count(); j++)
                {
                    matrices[i][j] = r[j].ToString();
                    if (r[j].ToString().Equals("E"))
                    {
                        target.x = i;
                        target.y = j;
                        matrices[i][j] = "z";
                    }
                    if (r[j].ToString().Equals("S"))
                    {
                        current.x = i;
                        current.y = j;
                        matrices[i][j] = "a";
                    }
                   
                    visited[i][j] = 0;
                }
            }
            bool[,] vis = new bool[RowCount, ColCount];
            BFS(matrices, vis, current.x, current.y);
            //bool result = MoveNext(current);
            path.Sort();
             return path[0].ToString();
        }
        static int[] dRow = { 1, -1, 0, 0 };
        static int[] dCol = { 0, 0, 1, -1 };

        
        static void BFS(string[][] grid, bool[,] vis,
                int row, int col)
        {

            Queue<point> q = new Queue<point>();

            q.Enqueue(new point(row, col,0));
            vis[row, col] = true;

            while (q.Count != 0)
            {
                point cell = q.Peek();
                int x = cell.x;
                int y = cell.y;

                
                cell.patcount++;
                q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int adjx = x + dRow[i];
                    int adjy = y + dCol[i];

                    if (adjx < 0 || adjy < 0 || adjx >= RowCount || adjy >= ColCount)
                        continue;

                    if (vis[adjx, adjy])
                        continue;

                    if (signal.ToList().IndexOf(matrices[adjx][adjy]) - signal.ToList().IndexOf(matrices[x][y]) > 1)
                        continue;


                    if (adjx == target.x && adjy == target.y)
                    {
                        path.Add(cell.patcount);
                        Console.WriteLine();
                    }  
                    q.Enqueue(new point(adjx, adjy, cell.patcount));
                    vis[adjx, adjy] = true;

                }
            }
        }
        
      
        public string SecondSolution(List<string> readings)
        {
            List<point> pList = new List<point>();
            for (int i = 0; i < RowCount; i++)
            {
               for (int j = 0; j < ColCount; j++)
                {
                    if (matrices[i][j].Equals("a"))
                    {
                        pList.Add(new point(i,j,0));
                    }
                }
            }
            path.Clear();

            foreach (point p in pList)
            {
                bool[,] vis = new bool[RowCount, ColCount];
                BFS(matrices, vis, p.x, p.y);
            }
            
            path.Sort();
            return path[0].ToString();
        }
       
    }

   
}
