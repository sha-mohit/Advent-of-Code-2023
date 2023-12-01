using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_18
    {
        List<Tuple<int,int,int>> cubeCord = new List<Tuple<int, int, int>>();
        int minBoundary = 999;
        int maxBoundary = 0;
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                string[] cord = readings[i].Trim().Split(',');
                Tuple<int, int, int> cordT = new Tuple<int, int, int>(int.Parse(cord[0]), int.Parse(cord[1]), int.Parse(cord[2]));
                int min = Math.Min(Math.Min(int.Parse(cord[0]), int.Parse(cord[1])),Math.Min(int.Parse(cord[1]), int.Parse(cord[2])));
                int max = Math.Max(Math.Max(int.Parse(cord[0]), int.Parse(cord[1])), Math.Max(int.Parse(cord[1]), int.Parse(cord[2])));
                if (minBoundary > min)
                {
                    minBoundary = min;
                }
                if (maxBoundary < max)
                {
                    maxBoundary = max;
                }
                cubeCord.Add(cordT);
        }

            int totalRemainingSides = 0;
            for (int i = 0; i < cubeCord.Count; i++)
            {
                int coverdSides = 0;
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1+1, cubeCord[i].Item2, cubeCord[i].Item3)))
                {
                    coverdSides++;
                }
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1 - 1, cubeCord[i].Item2, cubeCord[i].Item3)))
                {
                    coverdSides++;
                }
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1 , cubeCord[i].Item2 + 1, cubeCord[i].Item3)))
                {
                    coverdSides++;
                }
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1 , cubeCord[i].Item2 - 1, cubeCord[i].Item3)))
                {
                    coverdSides++;
                }
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1 , cubeCord[i].Item2, cubeCord[i].Item3 + 1)))
                {
                    coverdSides++;
                }
                if (cubeCord.Contains(new Tuple<int, int, int>(cubeCord[i].Item1 , cubeCord[i].Item2, cubeCord[i].Item3 - 1)))
                {
                    coverdSides++;
                }
                totalRemainingSides = totalRemainingSides + 6 - coverdSides;//6 is no of  sides in cube
             }
            return totalRemainingSides.ToString();
        }
   
        public bool IsOusideOfBoundary(Tuple<int, int, int> cube)
        {
            if (cube.Item1< minBoundary|| cube.Item2 < minBoundary|| cube.Item3 < minBoundary)
            {
                return true;
            }
            if (cube.Item1 > maxBoundary || cube.Item2 > maxBoundary || cube.Item3 > maxBoundary)
            {
                return true;
            }
            return false;
        }
       
        public int IsReachingOutside(Tuple<int, int, int> cube)
        {
            Queue<Tuple<int, int, int>> cubeStack = new Queue<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> visited = new List<Tuple<int, int, int>>();
            if (cubeCord.Contains(cube))
            {
                return 0;
            }
            cubeStack.Enqueue(cube);
            
            while (cubeStack.Count>0)
            {
                var c = cubeStack.Dequeue();
                if (cubeCord.Contains(c))
                {
                    continue;
                }
                if (IsOusideOfBoundary(c))
                {
                    return 1;
                }
                if (visited.Contains(c))
                {
                    continue;
                }else
                {
                    visited.Add(c);
                }
                List<Tuple<int, int, int>> nList = GetNeighbours(c);
                
                for (int j = 0; j < 6; j++)
                {
                    cubeStack.Enqueue(nList[j]);
                }

            }
            return 0;
        }

        public List<Tuple<int,int,int>> GetNeighbours(Tuple<int, int, int> cube)
        {
            List<Tuple<int, int, int>> neighbours = new List<Tuple<int, int, int>>();
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 + 1, cube.Item2, cube.Item3));
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 , cube.Item2+1, cube.Item3));
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 , cube.Item2, cube.Item3+1));
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 - 1, cube.Item2, cube.Item3));
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 , cube.Item2-1, cube.Item3));
            neighbours.Add(new Tuple<int, int, int>(cube.Item1 , cube.Item2, cube.Item3-1));
            return neighbours;
        }
        Dictionary<Tuple<int, int, int>, int> cache = new Dictionary<Tuple<int, int, int>, int>();
        public string SecondSolution(List<string> readings)
        {
            int areaWithoutBubble = 0;
            for (int i = 0; i < cubeCord.Count; i++)
            {
                List<Tuple<int, int, int>> nList = GetNeighbours(cubeCord[i]);

                for (int j = 0; j < 6; j++)
                {
                    if (cache.ContainsKey(nList[j]))
                    {
                        areaWithoutBubble = areaWithoutBubble + cache[nList[j]];
                    }else
                    {
                        int output = IsReachingOutside(nList[j]);
                        cache.Add(nList[j], output);
                        areaWithoutBubble = areaWithoutBubble + output;
                    }
                  
                }
            }
            return areaWithoutBubble.ToString();
        }

    }
}
