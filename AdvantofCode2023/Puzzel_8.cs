using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_8
    {
        int[][] matrices = new int[100][];
        int RowCount = 0;
        int ColCount = 0;
        int TotalVisibal = 392;
        public string FirstSolution(List<string> readings)
        {
            RowCount = readings.Count;
            if (readings.Count > 0)
            {
                ColCount = readings[0].Count();
            }
            for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new int[ColCount];
                string r = readings[i];

                for (int j = 0; j < r.Count(); j++)
                {
                    matrices[i][j] = int.Parse(r[j].ToString());
                }
            }
            int risk = 0;
            for (int i = 1; i < RowCount-1; i++)
            {
                for (int j = 1; j < ColCount-1; j++)
                {
                    int locUp = i - 1 ;
                    int locDown = i + 1 ;
                    int locBack = j - 1 ;
                    int locFor = j + 1 ;
                    bool visible = false;

                    if (visible != true)
                    {
                        bool upVissible = true;
                        for (int up = locUp; up >= 0; up--)
                        {
                            if (matrices[i][j] <= matrices[up][j])
                                {
                                    upVissible = false;
                                }
                        }
                        if (upVissible)
                        {
                            visible = true;
                        }
                    }
                    
                    if (visible!= true)
                    {
                        bool upVissible = true;
                        for (int down = locDown; down < 99; down++)
                        {
                            if (matrices[i][j] <= matrices[down][j])
                                {
                                    upVissible = false;
                                }
                        }
                        if (upVissible)
                        {
                            visible = true;
                        }
                    }
                    if (visible != true)
                    {
                        bool upVissible = true;
                        for (int left = locBack; left >= 0; left--)
                        {
                            if (matrices[i][j] <= matrices[i][left])
                                {
                                    upVissible = false;
                                }
                        }

                        if (upVissible)
                        {
                            visible = true;
                        }
                    }
                    if (visible != true)
                    {
                        bool upVissible = true;
                        for (int right = locFor; right < 99; right++)
                        {
                            if (matrices[i][j] <= matrices[i][right])
                                {
                                    upVissible = false;
                                }
                        }
                        if (upVissible)
                        {
                            visible = true;
                        }
                    }
                    if (visible)
                    {
                        TotalVisibal++;
                        //lowerePoints.Add(i + "," + j);
                    }

                }
            }
            return TotalVisibal.ToString();
        }

        public string SecondSolution(List<string> readings)
        {
            int niceview = 0;
            for (int i = 1; i < RowCount - 1; i++)
            {
                for (int j = 1; j < ColCount - 1; j++)
                {
                    int locUp = i - 1;
                    int locDown = i + 1;
                    int locBack = j - 1;
                    int locFor = j + 1;
                    bool visible = false;
                    int upCount = 0;
                    int downCount = 0;
                    int leftCount = 0;
                    int rightCount = 0;
                    if (visible != true)
                    {
                        for (int up = locUp; up >= 0; up--)
                        {
                            upCount++;
                            if (matrices[i][j] <= matrices[up][j])
                            {
                                break;
                            }
                        }
                    }

                    if (visible != true)
                    {
                        
                        for (int down = locDown; down < 99; down++)
                        {
                            downCount++;
                            if (matrices[i][j] <= matrices[down][j])
                            {
                                break;
                            }
                        }
                    }
                    if (visible != true)
                    {
                        for (int left = locBack; left >= 0; left--)
                        {
                            leftCount++;
                            if (matrices[i][j] <= matrices[i][left])
                            {
                               break;
                            }
                        }
                        
                    }
                    if (visible != true)
                    {
                        for (int right = locFor; right < 99; right++)
                        {
                            rightCount++;
                            if (matrices[i][j] <= matrices[i][right])
                            {
                                break;
                            }
                        }
                    }
                    int view = upCount * downCount * leftCount * rightCount;
                    if (niceview < view)
                    {
                        niceview = view;
                    }
                }
            }
            return niceview.ToString();
        }
    }
}
