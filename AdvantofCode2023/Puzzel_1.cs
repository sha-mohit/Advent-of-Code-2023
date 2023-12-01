using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_1
    {
        public string FirstSolution(List<string> readings)
        {
            Char first = '-';
            Char last = '-';
            int total = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                for (int j = 0; j < readings[i].Count(); j++)
                {
                  if(Char.IsNumber(readings[i][j])&& first== '-')
                  {
                        first = readings[i][j];
                    }
                    else if (Char.IsNumber(readings[i][j]))
                    {
                        last = readings[i][j];
                    }
                }
                if (first!= '-' && last != '-')
                {
                    int val = int.Parse(first + "" + last);

                    first = '-';
                    last = '-';
                    total = total + val;
                }
                if (first != '-' && last == '-')
                {
                    int val = int.Parse(first + "" + first);

                    first = '-';
                    last = '-';
                    total = total + val;
                }
            }
           return total.ToString();
        }
       
        public string SecondSolution(List<string> readings)
        {
            Dictionary<string, int> digit = new Dictionary<string, int>();
            digit.Add("one", 1);
            digit.Add("two", 2);
            digit.Add("three", 3);
            digit.Add("four", 4);
            digit.Add("five", 5);
            digit.Add("six", 6);
            digit.Add("seven", 7);
            digit.Add("eight", 8);
            digit.Add("nine", 9);
            Char first = '-';
            Char last = '-';
            int total = 0;
            for (int i = 0; i < readings.Count; i++)
            {
                string firstStr = "";
                for (int k = 0; k < readings[i].Count(); k++)
                {
                    if (Char.IsNumber(readings[i][k]))
                    {
                        firstStr = readings[i][k].ToString();
                        break;
                    }
                    firstStr = firstStr + readings[i][k];
                    foreach (KeyValuePair<string, int> item in digit)
                    {
                        if (firstStr.Contains(item.Key))
                        {
                            firstStr = item.Value.ToString();
                            break;
                        }
                    }
                    if (Char.IsNumber(firstStr[0]))
                    {
                       break;
                    }
                }
                string lastStr = "";
                for (int k = readings[i].Count()-1; k >= 0; k--)
                {
                    if (Char.IsNumber(readings[i][k]))
                    {
                        lastStr = readings[i][k].ToString();
                        break;
                    }
                    lastStr =  readings[i][k] + lastStr;
                    foreach (KeyValuePair<string, int> item in digit)
                    {
                        if (lastStr.Contains(item.Key))
                        {
                            lastStr = item.Value.ToString();
                            break;
                        }
                    }
                    if (Char.IsNumber(lastStr[0]))
                    {
                        break;
                    }
                }
                if (firstStr!="")
                {
                    first = firstStr[0];
                }
                if (lastStr != "")
                {
                    last = lastStr[0];
                }
               
                if (first != '-' && last != '-')
                {
                    int val = int.Parse(first + "" + last);

                    first = '-';
                    last = '-';
                    total = total + val;
                }
                if (first != '-' && last == '-')
                {
                    int val = int.Parse(first + "" + first);

                    first = '-';
                    last = '-';
                    total = total + val;
                }
            }
            return total.ToString();
        }
    }
}
