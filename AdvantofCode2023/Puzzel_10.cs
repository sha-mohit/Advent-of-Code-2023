using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_10
    {
        int X = 1;
        int cycle = 0;
        int signalStrength =0;
        int look = 20;
        int signalCount = 0;
        public string FirstSolution(List<string> readings)
        {
            int count = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                if (readings[i].Equals("noop"))
                {
                    cycle++;
                    if (cycle == look && signalCount <= 6)
                    {
                        signalStrength = signalStrength + X * look;
                        look = look + 40;
                        signalCount++;
                    }

                }else
                {
                    string[] groups = readings[i].Split(' ');
                    cycle = cycle + 1;
                    if (cycle == look && signalCount <= 6)
                    {
                        signalStrength = signalStrength + X * look;
                        look = look + 40;
                        signalCount++;
                    }
                    cycle = cycle + 1;
                    if (cycle == look && signalCount <= 6)
                    {
                        signalStrength = signalStrength + X * look;
                        look = look + 40;
                        signalCount++;
                    }
                    X = X + int.Parse(groups[1]);
                    
                }
                
            }
                return signalStrength.ToString();
        }
        string[][] matrices = new string[6][];
        int RowCount = 6;
        int ColCount = 40;
        int curser = 1;
        List<string> crt = new List<string>();
        public string SecondSolution(List<string> readings)
        {
            cycle = 0;


            for (int i = 0; i < readings.Count; i++)
            {
                if (readings[i].Equals("noop"))
                {
                    cycle++;
                  
                    if (cycle == curser || cycle == curser + 1 || cycle == curser + 2)
                    {
                        crt.Add("#");
                    }else
                    {
                        crt.Add(".");
                    }
                    if (cycle ==40)
                    {
                        cycle = 0;
                    }
                }
                else
                {
                    string[] groups = readings[i].Split(' ');
                    cycle = cycle + 1;
                    if (cycle == curser || cycle == curser + 1 || cycle == curser + 2)
                    {
                        crt.Add("#");
                    }
                    else
                    {
                        crt.Add(".");
                    }
                    if (cycle == 40)
                    {
                        cycle = 0;
                    }
                    cycle = cycle + 1;
                    if (cycle == curser || cycle == curser + 1 || cycle == curser + 2)
                    {
                        crt.Add("#");
                    }
                    else
                    {
                        crt.Add(".");
                    }
                    if (cycle == 40)
                    {
                        cycle = 0;
                    }
                    curser = curser + int.Parse(groups[1]);

                }

            }
            int count = 0;
            for (int i = 0; i < RowCount; i++)
            {
                matrices[i] = new string[ColCount];

                for (int j = 0; j < ColCount; j++)
                {

                    matrices[i][j] = crt[count];
                    Console.Write(matrices[i][j]);
                    count++;
                }
                Console.WriteLine();
            }
            
            return signalStrength.ToString();
        }
    }
}
