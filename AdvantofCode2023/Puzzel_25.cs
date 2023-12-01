using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_25
    {
        List<double> DecimalNoList = new List<double>();
        public string FirstSolution(List<string> readings)
        {

            for (int i = 0; i < readings.Count; i++)
            {
                string line = readings[i].Trim();

                double decimalNo = 0;
                for (int j = line.Length-1; j >= 0; j--)
                {
                    if (line[j].Equals('-'))
                    {
                        decimalNo = decimalNo - Math.Pow(5, line.Length - 1 - j);
                    } else if (line[j].Equals('='))
                    {
                        decimalNo = decimalNo - (Math.Pow(5, line.Length - 1 - j) *2) ;
                    } else {
                        decimalNo = decimalNo + (Math.Pow(5, line.Length - 1 -j) * int.Parse(line[j].ToString()));
                    }
                }
                DecimalNoList.Add(decimalNo);
            }

            long sum = 0;
            for (int i = 0; i < DecimalNoList.Count; i++)
            {
                sum = sum + (long)DecimalNoList[i];
            }
            string SNAFU = "";

            double decimalSum = sum;
            int power = 1;
            while (decimalSum > 0)
            {
                double modulo = decimalSum % Math.Pow( 5,power);

                modulo = modulo / Math.Pow(5, power-1);
                if (modulo == 3)
                {
                    modulo = -2;
                }
                if (modulo == 4)
                {
                    modulo = -1;
                }
                SNAFU = ( modulo ==-2?"=":modulo==-1?"-": modulo.ToString())+ SNAFU;
                decimalSum = decimalSum - modulo* Math.Pow(5, power - 1);
                power++;
             }

            return SNAFU;
        }
      
        public string SecondSolution(List<string> readings)
        {

            return "";

        }

    }
}
