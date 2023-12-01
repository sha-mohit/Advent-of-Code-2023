using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_13
    {
        int RowCount = 0;
        int ColCount = 0;
        List<pair> pairList = new List<pair>();

        public class pair
        {
            public string first;
            public string second;
            public pair(string a, string b)
            {
                this.first = a;
                this.second = b;
            }
        }
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; )
            {
                pairList.Add(new pair(readings[i], readings[i+1]));
                i = i + 3;
            }
            int orderCount = 0;
            for (int i = 0; i < pairList.Count;i++)
            {
                //List<string> first = getList(pairList[i].first);
                //List<string> second = getList(pairList[i].second);
                int result  = CompareRightOrder(pairList[i].first, pairList[i].second);
                if (result == 1)
                {
                    orderCount = orderCount + i + 1;
                    Console.WriteLine(i);
                }

            }
            return orderCount.ToString(); //5185
        }
        public List<string> getList(string input)
        {
            List<string> nList = new List<string>();

            string l = "";
            int forw = 0;

            string num = "";
            for (int i = 1; i < input.Count()-1; i++)
            {
                if (input[i].Equals('[') && l.Count() ==0)
                {
                    l = l+ '[';
                    forw++;
                    continue;
                }
                if (input[i].Equals(']') && l.Count() > 0)
                {
                    l = l + ']';
                    forw--;
                    if (forw ==0 )
                    {
                        string news = l;
                        nList.Add(news);
                        l = "";
                    }
                    continue;
                }
                if (forw!=0)
                {
                    if (input[i].Equals('['))
                    {
                        forw++;
                    }
                    l = l + input[i];
                }else
                {
                    if (!input[i].Equals(','))
                    {
                        num = num + input[i].ToString();
                     }else
                    {
                        string news = num;
                        if (!string.IsNullOrEmpty(news))
                        {
                            nList.Add(news);
                        }
                        num = "";
                    }
                }
            }
            string ne = num;
            if (!string.IsNullOrEmpty(ne))
            {
                nList.Add(ne);
            }
            num = "";
            return nList;
        }
        public bool IsList(string input)
        {
            if (input[0].Equals('['))
            {
                return true;
            }
            return false;
        }
        public bool IsNumber(string input)
        {
            if (input.Equals("0"))
            {
                return true;
            }
            int num = 0;
            int.TryParse(input, out num);
            if (num!=0)
            {
                return true;
            }
            return false;
        }
        public int CompareRightOrder(string first, string second)
        {
            if (IsList(first) && IsNumber(second))
            {
                second = '[' + second + ']';
            }
            if (IsList(second) && IsNumber(first))
            {
                first = '[' + first + ']';
            }
            if (IsNumber(first) && IsNumber(second))
            {
                int A = int.Parse(first);
                int B = int.Parse(second);
                if (A < B)
                {
                    return 1;
                }else if (A == B)
                {
                    return 0;
                }else
                {
                    return -1;
                }
            }
            if (IsList(first) && IsList(second))
            {
                int i = 0;
                List<string> firstInner = getList(first);
                List<string> secondInner = getList(second);
                while (i < firstInner.Count && i < secondInner.Count)
                {
                    int r = CompareRightOrder(firstInner[i], secondInner[i]);
                    if (r == 1)
                    {
                        return 1;
                    }
                    else if (r == -1)
                    {
                        return -1;
                    }
                    i++;
                }

                if (i == firstInner.Count)
                {
                    if (firstInner.Count == secondInner.Count)
                    {
                        return 0;
                    }
                    return 1;
                }

                return -1;

            }
            return -1;
        }


        public void sortMyList(List<string> nList)
        {
            bool sorting = true;
            while (sorting)
            {
                int check = 0;
                int count = nList.Count;
                for (int i = 0; i < count-1; i++)
                {
                  int r =  CompareRightOrder(nList[i], nList[i+1]);
                  if (r == -1)
                    {
                        string temp = nList[i];
                        nList[i] = nList[i + 1];
                        nList[i + 1] = temp;
                        check = -1;
                    }
                }
                if (check == 0)
                {
                    sorting = false;
                }
            }
        }
        public string SecondSolution(List<string> readings)
        {
            List<string> nList = new List<string>();
            pairList.Add(new pair("[[2]]", "[[6]]"));
            for (int i = 0; i < pairList.Count; i++)
            {
                nList.Add(pairList[i].first);
                nList.Add(pairList[i].second);
            }
            sortMyList(nList);
            return "";
        }

    }
}
