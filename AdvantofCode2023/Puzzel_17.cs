using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_17
    {
        public class shape
        {
            public int[][] tiles;
            public int rows = 0;
            public int cols = 0;

            public int StartRowIndex;
            
            public int StartColIndex ;


        }
        public void AddShapes()
        {
            shape HLine = new shape();
            HLine.tiles = new int[1][];
            for (int i = 0; i < HLine.tiles.Length; i++)
            {
                HLine.tiles[i] = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    HLine.tiles[i][j] = 1;
                }
            }
            HLine.rows = 1;
            HLine.cols = 4;

            shape Plus = new shape();
            Plus.tiles = new int[3][];
            for (int i = 0; i < Plus.tiles.Length; i++)
            {
                Plus.tiles[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 || j == 1)
                    {
                        Plus.tiles[i][j] = 1;
                    }
                    else
                    {
                        Plus.tiles[i][j] = 0;
                    }

                }
            }
            Plus.rows = 3;
            Plus.cols = 3;

            shape LShape = new shape();
            LShape.tiles = new int[3][];
            for (int i = 0; i < LShape.tiles.Length; i++)
            {
                LShape.tiles[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    if (i == 2 || j == 2)
                    {
                        LShape.tiles[i][j] = 1;
                    }
                    else
                    {
                        LShape.tiles[i][j] = 0;
                    }

                }
            }
            LShape.rows = 3;
            LShape.cols = 3;

            shape VLine = new shape();
            VLine.tiles = new int[4][];
            for (int i = 0; i < VLine.tiles.Length; i++)
            {
                VLine.tiles[i] = new int[1];
                for (int j = 0; j < 1; j++)
                {
                    VLine.tiles[i][j] = 1;
                }
            }
            VLine.rows = 4;
            VLine.cols = 1;

            shape Square = new shape();
            Square.tiles = new int[2][];
            for (int i = 0; i < Square.tiles.Length; i++)
            {
                Square.tiles[i] = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    Square.tiles[i][j] = 1;
                }
            }
            Square.rows = 2;
            Square.cols =2;

            shapes.Add(HLine);
            shapes.Add(Plus);
            shapes.Add(LShape);
            shapes.Add(VLine);
            shapes.Add(Square);
        }
        public List<shape> shapes = new List<shape>();
        shape currentShape = new shape();
        public List<char> windMoves = new List<char>();
        static int roomHeight = 50000;
        int[][] matrices = new int[roomHeight][];
        int initialCycle = 0;
        int initialHeight = 0;
        int rocks = 20022;//increase the rock for 2nd solution 20000
        public string FirstSolution(List<string> readings)
        {
            windMoves = readings[0].ToList();
            for (int i = 0; i < roomHeight; i++)
            {
                matrices[i] = new int[7];
                for (int j = 0; j < 7; j++)
                {
                    matrices[i][j] = 0;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                matrices[roomHeight-1][i] = 1;
            }
            AddShapes();
            int towerTop = GetHeight();
            int fallBase = towerTop - 3;
            int sahpeCounter = 0;
            int windMoveCounter = 0;
            for (int i = 0; i < rocks; i++)
            {
                currentShape.tiles = shapes[sahpeCounter].tiles;
                currentShape.rows = shapes[sahpeCounter].rows;
                currentShape.cols = shapes[sahpeCounter].cols;
                currentShape.StartRowIndex = fallBase- currentShape.rows;
                currentShape.StartColIndex = 2;
                bool canMove = true;
                while (canMove)
                {
                    WindMove(windMoves[windMoveCounter]);
                    windMoveCounter++;
                    if (windMoveCounter >= windMoves.Count)
                    {
                        windMoveCounter = 0;
                    }
                    canMove = Move();
                }
                Draw();
                towerTop = GetHeight();
                cycleTImeMap.Add(i, towerTop);
                

                fallBase = towerTop - 3;
                sahpeCounter++;
                if (sahpeCounter >= shapes.Count)
                {
                    sahpeCounter = 0;
                    if (windMoveCounter==0)
                    {
                        Console.WriteLine();
                    }
                }
                
            }
            //for (int i = 0; i < 5000; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.Write(matrices[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            
            return (roomHeight-1 - GetHeight()).ToString() ;
        }
        public int GetHeight()
        {
            int h = 0;
            for (int i = 0; i < roomHeight; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                   if( matrices[i][j] == 1)
                    {
                        h = i;
                        break;
                    }
                }
                if (h!=0)
                {
                    break;
                }
            }
            return h;
        }
        public void Draw()
        {
            for (int i = currentShape.StartRowIndex; i < currentShape.StartRowIndex+currentShape.rows; i++)
            {
                for (int j = currentShape.StartColIndex; j < currentShape.StartColIndex+currentShape.cols; j++)
                {
                    if (currentShape.tiles[ i- currentShape.StartRowIndex][j- currentShape.StartColIndex] == 1)
                    {
                        matrices[i][j] = 1;
                    }
                }
            }
        }
        public bool Move()
        {
            bool canMove = true;
            for (int i = currentShape.StartRowIndex; i < currentShape.StartRowIndex+currentShape.rows; i++)
            {
                for (int j = currentShape.StartColIndex; j < currentShape.StartColIndex+currentShape.cols; j++)
                {
                    if (currentShape.tiles[i - currentShape.StartRowIndex][j - currentShape.StartColIndex] == 1 && matrices[i+1][j] == 1)
                    {
                        canMove = false;
                    }
                }
            }
            if (canMove)
            {
                currentShape.StartRowIndex++;
            }
            return canMove;
        }
        public void WindMove(char windDirection)
        {
            switch (windDirection)
            {
                case '>':
                    if (currentShape.StartColIndex+ currentShape.cols <= 6)
                    {
                        bool canMove = true;
                        for (int i = currentShape.StartRowIndex; i < currentShape.StartRowIndex+currentShape.rows; i++)
                        {
                            for (int j = currentShape.StartColIndex; j < currentShape.StartColIndex+currentShape.cols; j++)
                            {
                                if (currentShape.tiles[i- currentShape.StartRowIndex][j- currentShape.StartColIndex] ==1 && matrices[i][j+1] ==1)
                                {
                                    canMove = false;
                                }
                            }
                        }
                        if (canMove)
                        {
                            currentShape.StartColIndex++;
                        }
                    }
                    break;
                case '<':
                    if (currentShape.StartColIndex - 1 >= 0)
                    {
                        bool canMove = true;
                        for (int i = currentShape.StartRowIndex; i < currentShape.StartRowIndex+currentShape.rows; i++)
                        {
                            for (int j = currentShape.StartColIndex; j < currentShape.StartColIndex+currentShape.cols; j++)
                            {
                                if (currentShape.tiles[i - currentShape.StartRowIndex][j - currentShape.StartColIndex] == 1 && matrices[i][j - 1] == 1)
                                {
                                    canMove = false;
                                }
                            }
                        }
                        if (canMove)
                        {
                            currentShape.StartColIndex--;
                        }
                    }
                    break;
            }
        }
        public string GetRow(int row)
        {
            string r = "";
            for (int j = 0; j < 7; j++)
            {
                r = r + matrices[row][j];
            }
            return r;
        }
        Dictionary<int, int> cycleTImeMap = new Dictionary<int, int>();
        public string SecondSolution(List<string> readings)
        {
            //cycleTImeMap.Reverse();
            //foreach (KeyValuePair<int, int> item in cycleTImeMap)
            //{
            //    Console.WriteLine("brick-> " + item.Key + "  height-> " + item.Value );
            //}
            //foreach (KeyValuePair<int, int> item in cycleTImeMap)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.Write(matrices[item.Value][j]);
            //    }
            //    Console.WriteLine();
            //}
            int l = 1;
            int m = 2;
            bool found = false;
            for (int i = 10; i < cycleTImeMap.Count; i++)
            {
                if (!found)
                {
                    for (int j = i + 15; j < cycleTImeMap.Count-15; j++)
                    {

                        if (GetRow(cycleTImeMap[i]).Equals(GetRow(cycleTImeMap[j])))
                        {
                           
                            bool match = true;
                            for (int k = 1; k <= 15; k++)
                            {
                                if (!GetRow(cycleTImeMap[i + k]).Equals( GetRow(cycleTImeMap[j + k])))
                                {
                                    match = false;
                                    break;
                                }
                              
                            }
                            if (match)
                            {
                                l = i;
                                m = j;
                                found = true;
                                break;
                            }
                           
                        }
                    }
                }
            }

            //initialCycle = 15;
            //initialHeight = 4998 - 4974;

            //int cycDuration = 35;
            //int cycHeight = 4974 - 4921;
            initialCycle = l;
            initialHeight = (roomHeight - 1) - cycleTImeMap[l-1];

            int cycDuration = m-l;
            int cycHeight = cycleTImeMap[l-1] - cycleTImeMap[m-1];
            long remainingCycle = (1000000000000 - initialCycle) % cycDuration;

            int remainingHeight = ((roomHeight - 1) - cycleTImeMap[((int)remainingCycle+ initialCycle) - 1])- initialHeight;

            long product = (1000000000000 - initialCycle- remainingCycle) / cycDuration;

            long totalHeight = cycHeight * product + initialHeight + remainingHeight ;

            return totalHeight.ToString();
        }

    }
}
