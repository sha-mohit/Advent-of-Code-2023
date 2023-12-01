using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_3
    {
        List<char> lett = new List<char> { 'a', 'b', 'c', 'd','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
        public string FirstSolution(List<string> readings)
        {
            List<char> uniqueList = new List<char>();
            for (int i = 0; i < readings.Count; i++)
            {
                List<char> fList = readings[i].Substring(0, readings[i].Count() / 2).ToList();
                List<char> sList = readings[i].Substring(readings[i].Count() / 2 ).ToList();

                List<char> ufList = new List<char>();
                List<char> usList = new List<char>();

                for (int j = 0; j < fList.Count; j++)
                {
                    if (!ufList.Contains(fList[j]))
                    {
                        ufList.Add(fList[j]);
                    }
                    
                }
                for (int j = 0; j < sList.Count; j++)
                {
                    if (!usList.Contains(sList[j]))
                    {
                        usList.Add(sList[j]);
                    }

                }

                for (int k = 0; k < ufList.Count; k++)
                {
                    if (usList.Contains(ufList[k]))
                    {
                        uniqueList.Add(ufList[k]);
                    }
                }
            }
           
            int count = 0;
            for (int i = 0; i < uniqueList.Count; i++)
            {
                count = count + lett.IndexOf(uniqueList[i]) +1;
            }
            return count.ToString();
        }

        public string SecondSolution(List<string> readings)
        {
            List<char> uniqueList = new List<char>();
            for (int i = 0; i < readings.Count; i=i+3)
            {
                List<char> fList = readings[i].ToList();
                List<char> sList = readings[i+1].ToList();
                List<char> tList = readings[i+2].ToList();

                List<char> ufList = new List<char>();
                List<char> usList = new List<char>();
                List<char> utList = new List<char>();

                for (int j = 0; j < fList.Count; j++)
                {
                    if (!ufList.Contains(fList[j]))
                    {
                        ufList.Add(fList[j]);
                    }

                }
                for (int j = 0; j < sList.Count; j++)
                {
                    if (!usList.Contains(sList[j]))
                    {
                        usList.Add(sList[j]);
                    }

                }
                for (int j = 0; j < tList.Count; j++)
                {
                    if (!utList.Contains(tList[j]))
                    {
                        utList.Add(tList[j]);
                    }

                }

                for (int k = 0; k < ufList.Count; k++)
                {
                    if (usList.Contains(ufList[k]) && utList.Contains(ufList[k]))
                    {
                        uniqueList.Add(ufList[k]);
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < uniqueList.Count; i++)
            {
                count = count + lett.IndexOf(uniqueList[i]) + 1;
            }
            return count.ToString();
        }
    }
}
