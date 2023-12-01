using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_4
    {
        public string FirstSolution(List<string> readings)
        {
            int count = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                int flag = 0;
                string[] groups = readings[i].Split(',');
                string[] group1 = groups[0].Split('-');
                string[] group2 = groups[1].Split('-');
                if (int.Parse(group1[0])<= int.Parse(group2[0])&& int.Parse(group1[1]) >= int.Parse(group2[1]))
                {
                    flag = 1;
                    count++;
                }

                if (flag!=1 && int.Parse(group1[0]) >= int.Parse(group2[0]) && int.Parse(group1[1]) <= int.Parse(group2[1]))
                {
                    count++;
                }
            }
                return (count).ToString();
        }
        public string SecondSolution(List<string> readings)
        {
            int count = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                int flag = 0;
                string[] groups = readings[i].Split(',');
                string[] group1 = groups[0].Split('-');
                string[] group2 = groups[1].Split('-');
                if (int.Parse(group1[0]) <= int.Parse(group2[0]) && int.Parse(group1[1]) >= int.Parse(group2[1]))
                {
                    flag = 1;
                    count++;
                }

                if (flag != 1 && int.Parse(group1[0]) >= int.Parse(group2[0]) && int.Parse(group1[1]) <= int.Parse(group2[1]))
                {
                    flag = 1;
                    count++;
                }
                if (flag != 1)
                {
                    int a = int.Parse(group1[0]);
                    int b = int.Parse(group1[1]);
                    int c = int.Parse(group2[0]);
                    int d = int.Parse(group2[1]);
                    List<int> first = new List<int>();
                    for (int j = a; j <= b; j++)
                    {
                        first.Add(j);
                    }
                    for (int k = c; k <= d; k++)
                    {
                        if (flag != 1 && first.Contains(k))
                        {
                            flag = 1;
                            count++;
                        }
                    }
                }
            }
            return (count).ToString();
        }
    }
}
