using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_24
    {
        //static string[][] matrices = new string[41][];
        int[][] visited = new int[41][];
        static int ColCount = 0;
        static int RowCount = 0;

        public class point
        {
            public int X;
            public int Y;
            public int direction;
            public int time;
            public point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public point(int x, int y,int direction)
            {
                this.X = x;
                this.Y = y;
                this.direction = direction;
            }
        }
        point startPoint = new point(0,1);
        point endPoint = new point(0, 0);

        List<char> blizzardDirections = new List<char>() { '>','v','<','^' };
        List<point> blizzardMove = new List<point>() { new point(0, 1), new point(1, 0), new point(0, -1), new point(-1, 0) };
        List<point> yourMove = new List<point>() { new point(0, 1), new point(1, 0), new point(0, -1), new point(-1, 0), new point(0, 0) };
        Dictionary<int, List<point>> blizzardStates = new Dictionary<int, List<point>>();
        public string FirstSolution(List<string> readings)
        {
            RowCount = readings.Count;
            if (readings.Count > 0)
            {
                ColCount = readings[0].Count();
            }
            List<point> blizzardState = new List<point>();
            for (int i = 0; i < RowCount; i++)
            {
                string r = readings[i];
                for (int j = 0; j < r.Count(); j++)
                {
                    if (blizzardDirections.Contains(r[j]))
                    {
                        point blizzard = new point(i, j, blizzardDirections.IndexOf(r[j]));
                        blizzardState.Add(blizzard);
                    }
                }
            }
            blizzardStates.Add(0, blizzardState);
            endPoint.X = RowCount - 1;
            endPoint.Y = ColCount - 2;

            InitializeBlizzardsState();
            MoveFor();

            return reachTime.ToString();
        }
        int reachTime = 0;
       
        
        public void MoveFor() {

            List<string> wasHereBefore = new List<string>();
            Queue<point> blizzardQueue = new Queue<point>();
            startPoint.time = reachTime;
            blizzardQueue.Enqueue(startPoint);
           
            while (blizzardQueue.Count > 0)
            {
                point blizzard = blizzardQueue.Dequeue();
                string blz = blizzard.X + "" + blizzard.Y + "" + blizzard.time;
                if (wasHereBefore.Contains(blz))
                {
                    continue;
                }
                else
                {
                    wasHereBefore.Add(blz);
                }

                if (blizzard.X == endPoint.X && blizzard.Y == endPoint.Y)
                {
                    reachTime= blizzard.time;
                    break;
                }

                for (int i = 0; i < yourMove.Count; i++)
                {
                    int newX = blizzard.X + yourMove[i].X;
                    int newY = blizzard.Y + yourMove[i].Y;

                    if (!(newX==startPoint.X&&newY==startPoint.Y || newX == endPoint.X && newY == endPoint.Y)&&
                        (newX<1 || newY<1 || newX>RowCount-2|| newY >ColCount-2))
                    {
                        continue;
                    }
                    point newZBizzard = new point(newX, newY);
                    newZBizzard.time = blizzard.time + 1;
                    if (!ISBlizzardInPath(newZBizzard))
                    {
                        blizzardQueue.Enqueue(newZBizzard);
                    }
                 }
            }

        }
        public void MoveBack()
        {
            List<string> wasHereBefore = new List<string>();
            Queue<point> blizzardQueue = new Queue<point>();
            endPoint.time = reachTime;
            blizzardQueue.Enqueue(endPoint);

            while (blizzardQueue.Count > 0)
            {
                point blizzard = blizzardQueue.Dequeue();
                string blz = blizzard.X + "" + blizzard.Y + "" + blizzard.time;
                if (wasHereBefore.Contains(blz))
                {
                    continue;
                }
                else
                {
                    wasHereBefore.Add(blz);
                }

                if (blizzard.X == startPoint.X && blizzard.Y == startPoint.Y)
                {
                    reachTime =  blizzard.time;
                    break;
                }

                for (int i = 0; i < yourMove.Count; i++)
                {
                    int newX = blizzard.X + yourMove[i].X;
                    int newY = blizzard.Y + yourMove[i].Y;

                    if (!(newX == startPoint.X && newY == startPoint.Y || newX == endPoint.X && newY == endPoint.Y) &&
                        (newX < 1 || newY < 1 || newX > RowCount - 2 || newY > ColCount - 2))
                    {
                        continue;
                    }
                    point newZBizzard = new point(newX, newY);
                    newZBizzard.time = blizzard.time + 1;
                    if (!ISBlizzardInPath(newZBizzard))
                    {
                        blizzardQueue.Enqueue(newZBizzard);
                    }
                }
            }

        }
        public bool ISBlizzardInPath(point blizzard)
        {
            var stateList = blizzardStates[blizzard.time % blizzardCycle];

            for (int i = 0; i < stateList.Count; i++)
            {
                if (stateList[i].X== blizzard.X && stateList[i].Y == blizzard.Y)
                {
                    return true;
                }
            }
            return false;
        }
        int blizzardCycle = 0;
        public void InitializeBlizzardsState()
        {
            blizzardCycle = lcm(RowCount - 2, ColCount - 2);
            for (int i = 1; i < blizzardCycle; i++)
            {
                List<point> blizzardState = new List<point>();
                for (int j = 0; j < blizzardStates[(i-1)].Count; j++)
                {
                    var oldBlizzard = blizzardStates[(i - 1)][j];
                    int newX = oldBlizzard.X + blizzardMove[oldBlizzard.direction].X;
                    int newY = oldBlizzard.Y + blizzardMove[oldBlizzard.direction].Y;
                    if (newX==0 && oldBlizzard.direction ==3)
                    {
                        newX = RowCount - 2;
                    }else if (newX == RowCount-1 && oldBlizzard.direction == 1)
                    {
                        newX = 1;
                    }

                    if (newY == 0 && oldBlizzard.direction == 2)
                    {
                        newY = ColCount - 2;
                    }
                    else if (newY == ColCount - 1 && oldBlizzard.direction == 0)
                    {
                        newY = 1;
                    }
                    blizzardState.Add( new point(newX, newY, oldBlizzard.direction));
                }
                blizzardStates.Add(i, blizzardState);
            }
        }
        public int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }
        public int lcm(int a, int b)
        {
            return (a / gcd(a, b)) * b;
        }
        public string SecondSolution(List<string> readings)
        {

            MoveBack();
            MoveFor();
            return reachTime.ToString();
        }

    }
}
