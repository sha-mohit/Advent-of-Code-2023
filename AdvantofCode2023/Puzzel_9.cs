using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_9
    {
        int[][] matrices = new int[1000][];
        int RowCount = 1000;
        int ColCount = 1000;
        int HeadX = 500;
        int HeadY = 500;
        int TailX = 500;
        int TailY = 500;
        List<point> NinePoint = new List<point>();

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
        public bool checkAdjuscent(int TailX, int TailY, int HeadX, int HeadY)
        {
            if ((TailX+1 == HeadX && HeadY == TailY )|| (TailX - 1 == HeadX && HeadY == TailY) || (TailX == HeadX && HeadY == TailY))
            {
                return true;
            }
            if ((TailY + 1 == HeadY && HeadX == TailX) || (TailY - 1 == HeadY && HeadX == TailX) || (TailX == HeadX && HeadY == TailY))
            {
                return true;
            }
            if ((TailY + 1 == HeadY && HeadX == TailX +1) || (TailY - 1 == HeadY && HeadX == TailX-1) || (TailY + 1 == HeadY && HeadX == TailX - 1) || (TailY - 1 == HeadY && HeadX == TailX + 1))
            {
                return true;
            }
            return false;
        }
        public point MoveTail(int TailX, int TailY, int HeadX, int HeadY)
        {
            if (HeadY == TailY && HeadX > TailX)
            {
                TailX++;
            }
            if (HeadY == TailY && HeadX < TailX)
            {
                TailX--;
            }
            if (HeadX == TailX && HeadY > TailY)
            {
                TailY++;
            }
            if (HeadX == TailX && HeadY < TailY)
            {
                TailY--;
            }
            if (HeadX > TailX && HeadY > TailY)
            {
                TailX++;
                TailY++;
            }
            if (HeadX < TailX && HeadY < TailY)
            {
                TailX--;
                TailY--;
            }
            if (HeadX > TailX && HeadY < TailY)
            {
                TailX++;
                TailY--;
            }
            if (HeadX < TailX && HeadY > TailY)
            {
                TailX--;
                TailY++;
            }
            return new point(TailX, TailY);
        }
        public string FirstSolution(List<string> readings)
        {
           
           for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new int[ColCount];
                for (int j = 0;j < ColCount; j++)
                {
                    matrices[i][j] = 0;
                }
            }
            matrices[TailX][TailY] = 1;
            for (int i = 0; i < readings.Count; i++)
            {
                var moveDire= readings[i].Split(' ');

                if (moveDire[0].Equals("L"))
                {
                    for (int left = 0; left < int.Parse(moveDire[1]); left++)
                    {
                        HeadY--;
                        if (!checkAdjuscent(TailX, TailY, HeadX, HeadY))
                        {
                            point p = MoveTail(TailX, TailY, HeadX, HeadY);
                            TailX = p.X;
                            TailY = p.Y;
                            matrices[TailX][TailY] = 1;
                        }
                    }
                }
                if (moveDire[0].Equals("D"))
                {
                    for (int down = 0; down < int.Parse(moveDire[1]); down++)
                    {
                        HeadX++;
                        if (!checkAdjuscent(TailX, TailY, HeadX, HeadY))
                        {
                            point p = MoveTail(TailX, TailY, HeadX, HeadY);
                            TailX = p.X;
                            TailY = p.Y;
                            matrices[TailX][TailY] = 1;
                        }
                    }
                }
                if (moveDire[0].Equals("U"))
                {
                    for (int up = 0; up < int.Parse(moveDire[1]); up++)
                    {
                        HeadX--;
                        if (!checkAdjuscent(TailX, TailY, HeadX, HeadY))
                        {
                            point p = MoveTail(TailX, TailY, HeadX, HeadY);
                            TailX = p.X;
                            TailY = p.Y;
                            matrices[TailX][TailY] = 1;
                        }
                    }

                }
                if (moveDire[0].Equals("R"))
                {
                    for (int right = 0; right < int.Parse(moveDire[1]); right++)
                    {
                        HeadY++;
                        if (!checkAdjuscent(TailX,TailY,HeadX,HeadY))
                        {
                           point p= MoveTail(TailX, TailY, HeadX, HeadY);
                            TailX = p.X;
                            TailY = p.Y;
                            matrices[TailX][TailY] = 1;
                        }
                    }
                }

            }
            int count = 0;
            for(int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {

                    if (matrices[i][j] == 1)
                    {
                        count++;
                    }
                }
            }
           return count.ToString();
        }

        
        public string SecondSolution(List<string> readings)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    matrices[i][j] = 0;
                }
            }
            HeadX = 500;
            HeadY = 500;
            for (int j = 0; j < 9; j++)
            {
                NinePoint.Add(new point(500, 500));
            }
            matrices[HeadX][HeadY] = 1;
            for (int i = 0; i < readings.Count; i++)
            {
                var moveDire = readings[i].Split(' ');

                if (moveDire[0].Equals("L"))
                {
                    for (int left = 0; left < int.Parse(moveDire[1]); left++)
                    {
                        HeadY--;
                        if (!checkAdjuscent(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY))
                        {
                            point p = MoveTail(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY);
                            NinePoint[0].X = p.X;
                            NinePoint[0].Y = p.Y;
                            
                        }
                        for (int k = 1; k < NinePoint.Count; k++)
                        {
                            if (!checkAdjuscent(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y))
                            {
                                point p = MoveTail(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y);
                                NinePoint[k].X = p.X;
                                NinePoint[k].Y = p.Y;
                            }
                            
                        }
                        matrices[NinePoint.Last().X][NinePoint.Last().Y] = 1;
                    }
                }
                if (moveDire[0].Equals("D"))
                {
                    for (int down = 0; down < int.Parse(moveDire[1]); down++)
                    {
                        HeadX++;
                        if (!checkAdjuscent(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY))
                        {
                            point p = MoveTail(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY);
                            NinePoint[0].X = p.X;
                            NinePoint[0].Y = p.Y;

                        }
                        for (int k = 1; k < NinePoint.Count; k++)
                        {
                            if (!checkAdjuscent(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y))
                            {
                                point p = MoveTail(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y);
                                NinePoint[k].X = p.X;
                                NinePoint[k].Y = p.Y;
                            }

                        }
                        matrices[NinePoint.Last().X][NinePoint.Last().Y] = 1;
                    }
                }
                if (moveDire[0].Equals("U"))
                {
                    for (int up = 0; up < int.Parse(moveDire[1]); up++)
                    {
                        HeadX--;
                        if (!checkAdjuscent(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY))
                        {
                            point p = MoveTail(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY);
                            NinePoint[0].X = p.X;
                            NinePoint[0].Y = p.Y;

                        }
                        for (int k = 1; k < NinePoint.Count; k++)
                        {
                            if (!checkAdjuscent(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y))
                            {
                                point p = MoveTail(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y);
                                NinePoint[k].X = p.X;
                                NinePoint[k].Y = p.Y;
                            }

                        }
                        matrices[NinePoint.Last().X][NinePoint.Last().Y] = 1;
                    }

                }
                if (moveDire[0].Equals("R"))
                {
                    for (int right = 0; right < int.Parse(moveDire[1]); right++)
                    {
                        HeadY++;
                        if (!checkAdjuscent(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY))
                        {
                            point p = MoveTail(NinePoint[0].X, NinePoint[0].Y, HeadX, HeadY);
                            NinePoint[0].X = p.X;
                            NinePoint[0].Y = p.Y;

                        }
                        for (int k = 1; k < NinePoint.Count; k++)
                        {
                            if (!checkAdjuscent(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y))
                            {
                                point p = MoveTail(NinePoint[k].X, NinePoint[k].Y, NinePoint[k - 1].X, NinePoint[k - 1].Y);
                                NinePoint[k].X = p.X;
                                NinePoint[k].Y = p.Y;
                            }

                        }
                        matrices[NinePoint.Last().X][NinePoint.Last().Y] = 1;
                    }
                }

            }
            int count = 0;
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {

                    if (matrices[i][j] == 1)
                    {
                        count++;
                    }
                }
            }
            return count.ToString();
        }
       
    }
   
}
