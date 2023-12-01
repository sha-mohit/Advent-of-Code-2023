using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_7
    {
        Stack<string> directoryLevel = new Stack<string>();
        Dictionary<string, int> size = new Dictionary<string, int>();
        public string FirstSolution(List<string> readings)
        {
            //Dictionary<string, int> size = new Dictionary<string, int>();
            //Stack<string> directoryLevel = new Stack<string>();
            int index = 0;
            if (readings[index].Contains("/"))
            {
                size.Add("/", 0);
                directoryLevel.Push("/");
                index++;
                findSum(readings, ref index);
            }
            int count = 0;
            foreach (var item in size)
            {
                if (item.Value <= 100000)
                {
                    count = count + item.Value;
                }
            }
            return count.ToString(); 
        }
        public int findSum(List<string> readings,ref int index)
        {
            
            while (index < readings.Count)
            {
               // int Total = 0;
                
                if (readings[index].Split(' ')[0].Contains("$") && readings[index].Split(' ')[1].Trim().Contains("ls"))
                {
                    index++;
                    //findSum(readings, ref index);
                }
                if (readings[index].Split(' ')[0].Trim().Contains("dir"))
                {
                    size.Add(directoryLevel.First()+"-"+readings[index].Split(' ')[1], 0);
                }
                int number = 0;
                int.TryParse(readings[index].Split(' ')[0], out number);
                if (number != 0)
                {
                    size[directoryLevel.First()] = size[directoryLevel.First()] + number;
                    //index++;
                    //Total = Total + number;
                }
                if (readings[index].Split(' ')[0].Contains("$") && readings[index].Split(' ')[1].Trim().Contains("cd")&& !readings[index].Split(' ')[2].Trim().Contains(".."))
                {
                    directoryLevel.Push(directoryLevel.First()+"-"+readings[index].Split(' ')[2]);
                    //index++;
                    //findSum(readings, ref index);
                }
                if (readings[index].Split(' ')[0].Contains("$") && readings[index].Split(' ')[1].Trim().Contains("cd") && readings[index].Split(' ')[2].Trim().Contains(".."))
                {
                    string abc = directoryLevel.Pop();
                    size[directoryLevel.First()] = size[directoryLevel.First()] + size[abc];
                    //index++;
                    //findSum(readings, ref index);
                }
                index++;
            }
            return 0;
        }
        public string SecondSolution(List<string> readings)
        {
            int aa = directoryLevel.Count();
            for (int i = 0; i < aa-1; i++)
            {
                string abc = directoryLevel.Pop();
                size[directoryLevel.First()] = size[directoryLevel.First()] + size[abc];
            }
            //int count = 0;
            //int index = 0;
            //foreach (var item in size)
            //{
               
            //    if (index <6)
            //    {
            //        count = count + item.Value;
            //        index++;
            //    }

            //}
            int remainingSize = 70000000 - size["/"];
            remainingSize = 30000000 - remainingSize;
            List<int> sizeGreater = new List<int>();

            foreach (var item in size)
            {
                sizeGreater.Add(item.Value);
            }
            sizeGreater.Sort();
            int total = 0;
            foreach (var item in sizeGreater)
            {
                total = total + item;
                if (total>= remainingSize)
                {
                    break;
                }
            }
            
            return total.ToString();
        }
    }
}
