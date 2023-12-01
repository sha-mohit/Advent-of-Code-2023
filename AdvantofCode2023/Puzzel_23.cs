using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_23
    {
        static int[][] matrices = new int[10000][];
        int RowCount = 0;
        int ColCount = 0;

        public class position
        {
            public int Id;
            public int CurrentX;
            public int CurrentY;
            public int ProposedX;
            public int ProposedY;
            public char moveDire ='-';
            public char ProposedDire = '-';

            public position(int X, int Y)
            {
                this.CurrentX = X;
                this.CurrentY = Y;
            }
        }
        List<char> Direction = new List<char>() { 'N', 'S', 'W', 'E' };
        public char SetDirection(char orgDir)
        {
            if (orgDir.Equals('-'))
            {
                orgDir = 'E';
            }
            int nexIndex = Direction.IndexOf(orgDir) + 1;
            if (nexIndex > 3)
            {
                nexIndex = 0;
            }
            return Direction[nexIndex];

        }
        List<position> elves = new List<position>();
        List<position> elvesCanMove = new List<position>();
        public bool canMove(position pos)
        {
            if (pos.ProposedDire.Equals('N'))
            {
                int N = pos.CurrentX - 1;
                if (N>=0)
                {
                    int NE = pos.CurrentY + 1;
                    int NW = pos.CurrentY - 1;
                    if (matrices[N][pos.CurrentY] != 1)
                    {
                        if (NW >= 0)
                        {
                            if (matrices[N][NW] == 1)
                            {
                                return false;
                            }
                        }
                        if (NE < ColCount)
                        {
                            if (matrices[N][NE] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else{
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (pos.ProposedDire.Equals('S'))
            {
                int S = pos.CurrentX + 1;
                if (S < RowCount)
                {
                    int SE = pos.CurrentY + 1;
                    int SW = pos.CurrentY - 1;
                    if (matrices[S][pos.CurrentY] != 1)
                    {
                        if (SW >= 0)
                        {
                            if (matrices[S][SW] == 1)
                            {
                                return false;
                            }
                        }
                        if (SE < ColCount)
                        {
                            if (matrices[S][SE] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (pos.ProposedDire.Equals('W'))
            {
                int W = pos.CurrentY - 1;
                if (W >= 0)
                {
                    int WN = pos.CurrentX - 1;
                    int WS = pos.CurrentX + 1;
                    if (matrices[pos.CurrentX][W] != 1)
                    {
                        if (WN >= 0)
                        {
                            if (matrices[WN][W] == 1)
                            {
                                return false;
                            }
                        }
                        if (WS < RowCount)
                        {
                            if (matrices[WS][W] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (pos.ProposedDire.Equals('E'))
            {
                int E = pos.CurrentY + 1;
                if (E < ColCount)
                {
                    int EN = pos.CurrentX - 1;
                    int ES = pos.CurrentX + 1;
                    if (matrices[pos.CurrentX][E] != 1)
                    {
                        if (EN >= 0)
                        {
                            if (matrices[EN][E] == 1)
                            {
                                return false;
                            }
                        }
                        if (ES < RowCount)
                        {
                            if (matrices[ES][E] == 1)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsThereNeighbour(position pos)
        {
            int N = pos.CurrentX - 1;
            int S = pos.CurrentX + 1;
            int W = pos.CurrentY - 1;
            int E = pos.CurrentY + 1;

            if (N>=0)
            {
                if (matrices[N][pos.CurrentY] == 1)
                {
                    return true;
                }
            }
            
            if (S<RowCount)
            {
                if (matrices[S][pos.CurrentY] == 1)
                {
                    return true;
                }
            }
            
            if (E<ColCount)
            {
                if (matrices[pos.CurrentX][E] == 1)
                {
                    return true;
                }
            }
            
            if (W>=0)
            {
                if (matrices[pos.CurrentX][W] == 1)
                {
                    return true;
                }
            }
            if (N >= 0 && E< ColCount)
            {
                if (matrices[N][E] == 1)
                {
                    return true;
                }
            }
            if (N >= 0 && W >=0)
            {
                if (matrices[N][W] == 1)
                {
                    return true;
                }
            }
            if (S < RowCount && E < ColCount)
            {
                if (matrices[S][E] == 1)
                {
                    return true;
                }
            }
            if (S < RowCount && W>=0 )
            {
                if (matrices[S][W] == 1)
                {
                    return true;
                }
            }
           
            return false;
        }
        public position setProposedPos(position pos)
        {
            if (pos.ProposedDire.Equals('N'))
            {
                int N = pos.CurrentX - 1;
                pos.ProposedX = N;
                pos.ProposedY = pos.CurrentY;
            }
            if (pos.ProposedDire.Equals('S'))
            {
                int S = pos.CurrentX + 1;
                pos.ProposedX = S;
                pos.ProposedY = pos.CurrentY;
            }
            if (pos.ProposedDire.Equals('W'))
            {
                int W = pos.CurrentY - 1;
                pos.ProposedX = pos.CurrentX;
                pos.ProposedY = W;
            }
            if (pos.ProposedDire.Equals('E'))
            {
                int E = pos.CurrentY + 1;
                pos.ProposedX = pos.CurrentX;
                pos.ProposedY = E;
            }
            return pos;
       }
        public void Spread()
        {
            for (int i = 1; i <= 1000; i++) //10 tmes for 1st
            {
                bool bMove = false;
                for (int j = 0; j < elves.Count; j++)
                {
                    elves[j].ProposedDire = elves[j].moveDire;

                    if (IsThereNeighbour(elves[j]))
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            elves[j].ProposedDire = SetDirection(elves[j].ProposedDire);

                            if (canMove(elves[j]))
                            {
                                elves[j] = setProposedPos(elves[j]);
                                elvesCanMove.Add(elves[j]);
                                bMove = true;
                                break;
                            }
                        }
                        
                    }
                    if (elves[j].moveDire.Equals('-'))
                    {
                        elves[j].moveDire = 'N';
                    }
                    else
                    {
                        elves[j].moveDire = SetDirection(elves[j].moveDire);
                    }
                }
                if (!bMove)
                {
                    NoMovement = i;
                    break;
                }
                RemoveDuplicate();
                MoveElves();
                //Console.WriteLine();
                //Console.WriteLine();
                //for (int k = 0; k < RowCount; k++)
                //{
                //    for (int l = 0; l < ColCount; l++)
                //    {
                //        Console.Write(matrices[k][l]);
                //    }
                //    Console.WriteLine();
                //}
            }
        }
        public void RemoveDuplicate()
        {
            List<int> posTobeRemoved = new List<int>();
            for (int i = 0; i < elvesCanMove.Count-1; i++)
            {
                for (int j = i+1; j < elvesCanMove.Count; j++)
                {
                    if (elvesCanMove[i].ProposedX == elvesCanMove[j].ProposedX &&
                       elvesCanMove[i].ProposedY == elvesCanMove[j].ProposedY && i!=j)
                    {
                        if (!posTobeRemoved.Contains(i))
                        {
                            posTobeRemoved.Add(i);
                        }
                        if (!posTobeRemoved.Contains(j))
                        {
                            posTobeRemoved.Add(j);
                        }
                    }
                }
            }
            posTobeRemoved.Sort();
            posTobeRemoved.Reverse();
            for (int i = 0; i < posTobeRemoved.Count; i++)
            {
                elvesCanMove.RemoveAt(posTobeRemoved[i]);
            }
        }
        public void MoveElves()
        {
            for (int i = 0; i < elvesCanMove.Count; i++)
            {
                setElvesPos(elvesCanMove[i]);
            }

            elvesCanMove.Clear();
        }
        public void setElvesPos(position pos)
        {
            matrices[pos.CurrentX][pos.CurrentY] = 0;
            elves[pos.Id].CurrentX = pos.ProposedX;
            elves[pos.Id].CurrentY = pos.ProposedY;
            elves[pos.Id].ProposedX = 0;
            elves[pos.Id].ProposedY = 0;
            matrices[elves[pos.Id].CurrentX][elves[pos.Id].CurrentY] = 1;
        }
        public int countBlankField()
        {
            int firstCol = 0;
            int lastCol = 0;
            int firstRow = 0;
            int lastRow = 0;
            for (int i = 0; i < RowCount; i++)
            {
                bool found = false;
                for (int j = 0; j < ColCount; j++)
                {
                    if (matrices[i][j]==1)
                    {
                        firstRow = i;
                        found = true;
                        break;
                    }
                   
                }
                if (found)
                {
                    break;
                }
            }
            for (int i = RowCount-1; i >= 0; i--)
            {
                bool found = false;
                for (int j = 0; j < ColCount; j++)
                {
                    if (matrices[i][j] == 1)
                    {
                        lastRow = i;
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    break;
                }
            }
            for (int i = 0; i < ColCount; i++)
            {
                bool found = false;
                for (int j = 0; j < RowCount; j++)
                {
                    if (matrices[j][i] == 1)
                    {
                        firstCol = i;
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    break;
                }
            }
            for (int i = ColCount - 1; i >= 0; i--)
            {
                bool found = false;
                for (int j = 0; j < RowCount; j++)
                {
                    if (matrices[j][i] == 1)
                    {
                        lastCol = i;
                        found = true;
                        break;
                    }

                }
                if (found)
                {
                    break;
                }
            }
            int count = 0;
            for (int i =firstRow; i <= lastRow; i++)
            {
                for (int j = firstCol; j <= lastCol; j++)
                {
                    if (matrices[i][j]==0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public string FirstSolution(List<string> readings)
        {
            RowCount = 5000;
            ColCount = 5000;
            for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new int[ColCount];
                for (int j = 0; j < ColCount; j++)
                {
                    matrices[i][j] = 0;
                }
            }

            int elvesID = 0;
            int startI = 2500;
            int startJ = 2500;

            for (int i = 0; i < readings.Count; i++)
            {
                //matrices[i] = new int[ColCount];
                string r = readings[i];

                for (int j = 0; j < r.Count(); j++)
                {
                    //if (r[j].Equals('.'))
                    //{
                    //    matrices[i][j] = 0;
                    //}
                    if (r[j].Equals('#'))
                    {
                        matrices[i+ startI][j+ startJ] = 1;
                        position pos = new position(i + startI, j + startJ);
                        pos.Id = elvesID;
                        elves.Add(pos);
                        elvesID++;
                    }
                }
            }
            Spread();
            return countBlankField().ToString();
        }
        public int NoMovement = 0;
        public string SecondSolution(List<string> readings)
        {
            while (NoMovement ==0)
            {
                Spread();
            }
            return NoMovement.ToString();
        }

    }
}
