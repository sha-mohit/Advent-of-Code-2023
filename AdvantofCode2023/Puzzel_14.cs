using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_14
    {
        int[][] matrices = new int[1000][];
        int RowCount = 1000;
        int ColCount = 1000;
        int downboundary = 0;
        int leftboundary = 999;
        int rightboundary = 0;
        public class point
        {
            public int X;
            public int Y;
            public point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public void drawRock(point start, point end)
        {
            if (start.X==end.X)
            {
                if (start.Y>=end.Y)
                {
                    for (int i = 0; i <= start.Y- end.Y; i++)
                    {
                        matrices[start.X][start.Y - i] = 1;
                    }
                }
                if (start.Y <= end.Y)
                {
                    for (int i = 0; i <= end.Y -start.Y ; i++)
                    {
                        matrices[start.X][start.Y+i] = 1;
                    }
                }
            }
            if (start.Y == end.Y)
            {
                if (start.X >= end.X)
                {
                    for (int i = 0; i <= start.X - end.X; i++)
                    {
                        matrices[start.X - i][start.Y] = 1;
                    }
                }
                if (start.X <= end.X)
                {
                    for (int i = 0; i <= end.X - start.X; i++)
                    {
                        matrices[start.X+i][start.Y] = 1;
                    }
                }
            }
        }

        public bool IsNextMovePossible(point p)
        {
            if (matrices[p.X + 1][p.Y] == 0)
            {
                return true;
            }
            if (matrices[p.X + 1][p.Y-1] == 0)
            {
                return true;
            }
            if (matrices[p.X + 1][p.Y + 1] == 0)
            {
                return true;
            }
            return false;
        }
        public point updatePosittion(point p)
        {
            if (matrices[p.X + 1][p.Y] == 0)
            {
                p.X = p.X + 1;
                return p;
            }
            if (matrices[p.X + 1][p.Y - 1] == 0)
            {
                p.X = p.X + 1;
                p.Y = p.Y - 1;
                return p;
            }
            if (matrices[p.X + 1][p.Y + 1] == 0)
            {
                p.X = p.X + 1;
                p.Y = p.Y + 1;
                return p;
            }
            return p;
        }
        public bool sandPath(point startPoint)
        {
            while(IsNextMovePossible(startPoint))
            {
               // Console.WriteLine("Inside While---X:" + startPoint.X+"  Y:"+ startPoint.Y);
                startPoint = updatePosittion(startPoint);
                if (downboundary <= startPoint.X || leftboundary >= startPoint.Y || rightboundary <= startPoint.Y)
                {
                    //Console.WriteLine("Inside If---X:" + startPoint.X + "  Y:" + startPoint.Y);
                    return true;
                }

            }
            matrices[startPoint.X][startPoint.Y] = 2;

            return false;
        }
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new int[ColCount];
                for (int j = 0; j < ColCount; j++)
                {
                    matrices[i][j] = 0;
                }
            }
            for (int i = 0; i < readings.Count; i++)
            {
                List<point> pList = new List<point>();
                string[] cord = readings[i].Trim().Replace(" -> ", ".").Split('.');
                for (int j = 0; j < cord.Length; j++)
                {
                    string[] point  = cord[j].Trim().Split(',');
                    point p = new point(int.Parse(point[1]), int.Parse(point[0]));
                    if (downboundary < p.X)
                    {
                        downboundary = p.X;
                    }
                    if (leftboundary > p.Y)
                    {
                        leftboundary = p.Y;
                    }
                    if (rightboundary < p.Y)
                    {
                        rightboundary = p.Y;
                    }
                    pList.Add(p);
                }
                for (int j = 0; j < pList.Count-1; j++)
                {
                    drawRock(pList[j], pList[j+1]);
                }
            }
            downboundary = downboundary + 2;
            rightboundary = rightboundary + 1;
            leftboundary = leftboundary - 1;
            bool Isoverflow = false;
            int count = 0;
            while (!Isoverflow)
            {
                count++;
                point startPoint = new point(0, 500);
                Isoverflow = sandPath(startPoint);
            }
            //for (int i = 0; i < downboundary; i++)
            //{
            //    for (int j = leftboundary; j < rightboundary; j++)
            //    {
            //        Console.Write(matrices[i][j]);
                    
            //    }
            //    Console.WriteLine();
            //}
            return (count-1).ToString() ;
        }
      
        public string SecondSolution(List<string> readings)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    if (matrices[i][j] == 2)
                    {
                        matrices[i][j] = 0;
                    }

                }
              
            }
            for (int j = 0; j < ColCount; j++)
            {
                 matrices[downboundary][j] = 1;
            }
            bool Isoverflow = false;
            int count = 0;
            while (!Isoverflow)
            {
                count++;
                point startPoint = new point(0, 500);
                Isoverflow = sandPath2(startPoint);
            }
            return (count).ToString(); ;
        }

        public bool sandPath2(point startPoint)
        {
            int dist = 0;
            while (IsNextMovePossible(startPoint))
            {
                dist++;
                startPoint = updatePosittion(startPoint);
            }
            if (dist==0)
            {
                return true;
            }
            matrices[startPoint.X][startPoint.Y] = 2;

            return false;
        }
    }
}
