using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_21
    {
     
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                string[] input = readings[i].Split(':');
                int val = 0;
                int.TryParse(input[1],out val);
                if (val!=0)
                {
                    valueDic.Add(input[0].Trim(), val);
                    copyDic.Add(input[0].Trim(), val);
                }
                else
                {
                    expressionDic.Add(input[0], input[1]);
                }
            }

            bool IsRoot = false;
            while (!IsRoot)
            {
                foreach (KeyValuePair<string,string> item in expressionDic)
                {
                    string[] exInput = item.Value.Trim().Split(' ');

                    switch (exInput[1].Trim())
                    {
                        case "+":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] + valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "-":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] - valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "*":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] * valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "/":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] / valueDic[exInput[2].Trim()]);
                            }
                            break;
                    }
                    if ( valueDic.ContainsKey("root"))
                    {
                        IsRoot = true;
                        break;
                    }

                }
            }
            return valueDic["root"].ToString();
        }
        Dictionary<string, double> valueDic = new Dictionary<string, double>();
        Dictionary<string, string> expressionDic = new Dictionary<string, string>();
        Dictionary<string, double> copyDic = new Dictionary<string, double>();
        public string SecondSolution(List<string> readings)
        {
            valueDic.Clear();
            copyDic.Clear();
            expressionDic.Clear();
            for (int i = 0; i < readings.Count; i++)
            {
                string[] input = readings[i].Split(':');
                int val = 0;
                int.TryParse(input[1], out val);
                if (val != 0)
                {
                    valueDic.Add(input[0].Trim(), val);
                    copyDic.Add(input[0].Trim(), val);
                }
                else
                {
                    expressionDic.Add(input[0], input[1]);
                }
            }
            bool equal = false;
            long humn = 0;
            valueDic["humn"] = humn;
            long firstRange = 0;
            long secondRange = 0;
            long incrementer = 100000000000;
            while (!equal)
            {
                foreach (KeyValuePair<string, string> item in expressionDic)
                {
                    string[] exInput = item.Value.Trim().Split(' ');

                    switch (exInput[1].Trim())
                    {
                        case "+":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] + valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "-":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] - valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "*":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] * valueDic[exInput[2].Trim()]);
                            }
                            break;
                        case "/":
                            if (valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()) && !valueDic.ContainsKey(item.Key))
                            {
                                valueDic.Add(item.Key, valueDic[exInput[0].Trim()] / valueDic[exInput[2].Trim()]);
                            }
                            break;
                    }
                    if (item.Key.Equals("root") && valueDic.ContainsKey(exInput[0].Trim()) && valueDic.ContainsKey(exInput[2].Trim()))
                    {
                        if (valueDic[exInput[0].Trim()]== valueDic[exInput[2].Trim()])
                        {
                            equal = true;
                            break;
                        }
                        else{
                            if (valueDic[exInput[0].Trim()] - valueDic[exInput[2].Trim()]>0)
                            {
                                firstRange = humn;

                            }
                            if (valueDic[exInput[0].Trim()] - valueDic[exInput[2].Trim()] < 0)
                            {
                                secondRange = humn;

                            }
                            humn = humn + incrementer;
                            if (firstRange!=0 && secondRange!=0)
                            {
                                incrementer = incrementer / 10;
                                humn = firstRange;
                                firstRange = 0;
                                secondRange = 0;
                               
                            }
                            valueDic.Clear();
                            foreach (var kv in copyDic)
                            {
                                valueDic.Add(kv.Key, kv.Value);
                            }
                            
                            valueDic["humn"] = humn;
                        }
                    }

                }
            }
            return valueDic["humn"].ToString();
        }

    }
}
