using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_5
    {
        public string FirstSolution(List<string> readings)
        {

            Dictionary<int, List<char>> input = new Dictionary<int, List<char>>();
            input.Add(1, new List<char>() { 'F', 'C', 'J', 'P', 'H', 'T', 'W' });
            input.Add(2, new List<char>() { 'G', 'R', 'V', 'F', 'Z', 'J', 'B', 'H' });
            input.Add(3, new List<char>() { 'H', 'P', 'T', 'R' });
            input.Add(4, new List<char>() { 'Z', 'S', 'N', 'P', 'H', 'T' });
            input.Add(5, new List<char>() { 'N', 'V', 'F', 'Z', 'H', 'J', 'C', 'D' });
            input.Add(6, new List<char>() { 'P', 'M', 'G', 'F', 'W', 'D', 'Z' });
            input.Add(7, new List<char>() { 'M', 'V', 'Z', 'W', 'S', 'J', 'D', 'P' });
            input.Add(8, new List<char>() { 'N', 'D', 'S' });
            input.Add(9, new List<char>() { 'D', 'Z', 'S', 'F', 'M' });


            for (int i = 0; i < readings.Count; i++)
            {
                string[] row = readings[i].Split(' ');
                int move = int.Parse(row[1]);
                int from = int.Parse(row[3]);
                int to = int.Parse(row[5]);

                for (int j = 0; j < move; j++)
                {
                    char last = input[from].Last();
                    input[from].RemoveAt(input[from].Count - 1);
                    input[to].Add(last);
                }
            }
            string output = "";
            for (int i = 1; i <= input.Count; i++)
            {
                output = output + input[i].Last();
            }
            return output;
        }
        public string SecondSolution(List<string> readings)
        {
            Dictionary<int, List<char>> input = new Dictionary<int, List<char>>();
            input.Add(1, new List<char>() { 'F', 'C', 'J', 'P', 'H', 'T', 'W' });
            input.Add(2, new List<char>() { 'G', 'R', 'V', 'F', 'Z', 'J', 'B', 'H' });
            input.Add(3, new List<char>() { 'H', 'P', 'T', 'R' });
            input.Add(4, new List<char>() { 'Z', 'S', 'N', 'P', 'H', 'T' });
            input.Add(5, new List<char>() { 'N', 'V', 'F', 'Z', 'H', 'J', 'C', 'D' });
            input.Add(6, new List<char>() { 'P', 'M', 'G', 'F', 'W', 'D', 'Z' });
            input.Add(7, new List<char>() { 'M', 'V', 'Z', 'W', 'S', 'J', 'D', 'P' });
            input.Add(8, new List<char>() { 'N', 'D', 'S' });
            input.Add(9, new List<char>() { 'D', 'Z', 'S', 'F', 'M' });


            for (int i = 0; i < readings.Count; i++)
            {
                string[] row = readings[i].Split(' ');
                int move = int.Parse(row[1]);
                int from = int.Parse(row[3]);
                int to = int.Parse(row[5]);

                for (int j = move; j > 0; j--)
                {
                    char last = input[from][input[from].Count-j];
                    input[from].RemoveAt(input[from].Count - j);
                    input[to].Add(last);
                }
            }
            string output = "";
            for (int i = 1; i <= input.Count; i++)
            {
                output = output + input[i].Last();
            }
            return output;
        }
    }
}
