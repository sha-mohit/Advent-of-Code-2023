using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_2
    {
        public string FirstSolution(List<string> readings)
        {
            int Total = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                if(readings[i].Contains("A X") || readings[i].Contains("B Y") || readings[i].Contains("C Z"))
                {
                    if (readings[i].Contains("A X"))
                    {
                        Total = Total + 4;
                    }
                    if (readings[i].Contains("B Y"))
                    {
                        Total = Total + 5;
                    }
                    if (readings[i].Contains("C Z"))
                    {
                        Total = Total + 6;
                    }
                }
                if (readings[i].Contains("A Y"))
                {
                    Total = Total + 2+6;
                }
                if (readings[i].Contains("B Z"))
                {
                    Total = Total + 3 + 6;
                }
                if (readings[i].Contains("C X"))
                {
                    Total = Total + 1 + 6;
                }
                if (readings[i].Contains("A Z"))
                {
                    Total = Total + 3;
                }
                if (readings[i].Contains("B X"))
                {
                    Total = Total + 1;
                }
                if (readings[i].Contains("C Y"))
                {
                    Total = Total + 2;
                }
            }
            return (Total).ToString();
        }

        public string SecondSolution(List<string> readings)
        {
            int Total = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                if (readings[i].Contains("A X") || readings[i].Contains("B Y") || readings[i].Contains("C Z"))
                {
                    if (readings[i].Contains("A X"))
                    {
                        Total = Total + 3+0;
                    }
                    if (readings[i].Contains("B Y"))
                    {
                        Total = Total + 2+3;
                    }
                    if (readings[i].Contains("C Z"))
                    {
                        Total = Total + 1+6;
                    }
                }
                if (readings[i].Contains("A Y"))
                {
                    Total = Total + 1 + 3;
                }
                if (readings[i].Contains("B Z"))
                {
                    Total = Total + 3 + 6;
                }
                if (readings[i].Contains("C X"))
                {
                    Total = Total + 2 + 0;
                }
                if (readings[i].Contains("A Z"))
                {
                    Total = Total + 2+6;
                }
                if (readings[i].Contains("B X"))
                {
                    Total = Total + 1+0;
                }
                if (readings[i].Contains("C Y"))
                {
                    Total = Total + 3+3;
                }
            }
            return (Total).ToString();
        }
    }
}
