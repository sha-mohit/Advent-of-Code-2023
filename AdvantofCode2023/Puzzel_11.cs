using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_11
    {
        List<monkey> totalMonkey = new List<monkey>();
        public class monkey
        {
            public int monkeNo = 0;
            public Queue<double> Items = new Queue<double>();
            public string operation = "";
            public string operand1 = "";
            public string operand2 = "";
            public int divisible = 0;
            public int trowsTrue = 0;
            public int trowsFalse = 0;
            public int itemInspected = 0;

        }
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                if (readings[i].Contains("Monkey "))
                {
                    monkey m = new monkey();
                    m.monkeNo = int.Parse(readings[i].Split(' ')[1].Replace(":",""));
                    totalMonkey.Add(m);
                }
                if (readings[i].Contains("Starting items:"))
                {
                    var item = readings[i].Split(':');
                    var ite = item[1].Split(',');
                    for (int j = 0; j < ite.Length; j++)
                    {
                        totalMonkey[totalMonkey.Count - 1].Items.Enqueue(int.Parse(ite[j]));
                    }
                }
                if (readings[i].Contains("Operation:"))
                {
                    totalMonkey[totalMonkey.Count - 1].operand1 = readings[i].Split(' ')[5].Trim();
                    totalMonkey[totalMonkey.Count - 1].operation = readings[i].Split(' ')[6].Trim();
                    totalMonkey[totalMonkey.Count - 1].operand2 = readings[i].Split(' ')[7].Trim();
                }
                if (readings[i].Contains("Test:"))
                {
                    totalMonkey[totalMonkey.Count - 1].divisible = int.Parse(readings[i].Split(' ')[5]);
                }
                if (readings[i].Contains("true:"))
                {
                    totalMonkey[totalMonkey.Count - 1].trowsTrue = int.Parse(readings[i].Split(' ')[9]);
                }
                if (readings[i].Contains("false:"))
                {
                    totalMonkey[totalMonkey.Count - 1].trowsFalse = int.Parse(readings[i].Split(' ')[9]);
                }
            }

            int round = 20;
            for (int k = 0; k < round; k++)
            {
                int totalMnkey = totalMonkey.Count();
                for (int l = 0; l < totalMnkey; l++)
                {
                    monkey mon = totalMonkey[l];
                    int itemcount = mon.Items.Count;
                    for (int i = 0; i < itemcount; i++)
                    {
                        mon.itemInspected++;
                        double old = mon.Items.Dequeue();
                        double newItem = 0;
                        if (mon.operation.Contains("*"))
                        {
                            if (mon.operand2.Contains("old"))
                            {
                                newItem = old * old;
                            }else
                            {
                                newItem = old * int.Parse(mon.operand2);
                            }
                            
                        }
                        if (mon.operation.Contains("+"))
                        {
                            if (mon.operand2.Contains("old"))
                            {
                                newItem = old + old;
                            }
                            else
                            {
                                newItem = old + int.Parse(mon.operand2);
                            }

                        }
                        int worryLevel =(int)Math.Floor( newItem / 3);

                        if (worryLevel% mon.divisible == 0)
                        {
                            totalMonkey[mon.trowsTrue].Items.Enqueue(worryLevel);
                        }
                        else
                        {
                            totalMonkey[mon.trowsFalse].Items.Enqueue(worryLevel);
                        }
                    }
                }
            }
            var sortList = totalMonkey.OrderBy(x => x.itemInspected);
            sortList.Reverse();
            return "".ToString();
        }

        
        public string SecondSolution(List<string> readings)
        {
            totalMonkey.Clear();
            for (int i = 0; i < readings.Count; i++)
            {
                if (readings[i].Contains("Monkey "))
                {
                    monkey m = new monkey();
                    m.monkeNo = int.Parse(readings[i].Split(' ')[1].Replace(":", ""));
                    totalMonkey.Add(m);
                }
                if (readings[i].Contains("Starting items:"))
                {
                    var item = readings[i].Split(':');
                    var ite = item[1].Split(',');
                    for (int j = 0; j < ite.Length; j++)
                    {
                        totalMonkey[totalMonkey.Count - 1].Items.Enqueue(int.Parse(ite[j]));
                    }
                }
                if (readings[i].Contains("Operation:"))
                {
                    totalMonkey[totalMonkey.Count - 1].operand1 = readings[i].Split(' ')[5].Trim();
                    totalMonkey[totalMonkey.Count - 1].operation = readings[i].Split(' ')[6].Trim();
                    totalMonkey[totalMonkey.Count - 1].operand2 = readings[i].Split(' ')[7].Trim();
                }
                if (readings[i].Contains("Test:"))
                {
                    totalMonkey[totalMonkey.Count - 1].divisible = int.Parse(readings[i].Split(' ')[5]);
                }
                if (readings[i].Contains("true:"))
                {
                    totalMonkey[totalMonkey.Count - 1].trowsTrue = int.Parse(readings[i].Split(' ')[9]);
                }
                if (readings[i].Contains("false:"))
                {
                    totalMonkey[totalMonkey.Count - 1].trowsFalse = int.Parse(readings[i].Split(' ')[9]);
                }
            }

            int round = 10000;
            for (int k = 0; k < round; k++)
            {
                int totalMnkey = totalMonkey.Count();
                for (int l = 0; l < totalMnkey; l++)
                {
                    monkey mon = totalMonkey[l];
                    int itemcount = mon.Items.Count;
                    for (int i = 0; i < itemcount; i++)
                    {
                        mon.itemInspected++;
                        double old = mon.Items.Dequeue();
                        double newItem = 0;
                        if (mon.operation.Contains("*"))
                        {
                            if (mon.operand2.Contains("old"))
                            {
                                newItem = old * old;
                            }
                            else
                            {
                                newItem = old * int.Parse(mon.operand2);
                            }

                        }
                        if (mon.operation.Contains("+"))
                        {
                            if (mon.operand2.Contains("old"))
                            {
                                newItem = old + old;
                            }
                            else
                            {
                                newItem = old + int.Parse(mon.operand2);
                            }

                        }
                        double worryLevel = newItem % 9699690; //multiply all the prime divisible
                        //double worryLevel = newItem % 96577;
                        if (worryLevel % mon.divisible == 0)
                        {
                            totalMonkey[mon.trowsTrue].Items.Enqueue(worryLevel);
                        }
                        else
                        {
                            totalMonkey[mon.trowsFalse].Items.Enqueue(worryLevel);
                        }
                    }
                }
            }
            var sortList = totalMonkey.OrderBy(x => x.itemInspected);
            sortList.Reverse();
            return "".ToString();
        }
       
    }
   
}
