using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_20
    {
        List<int> Input = new List<int>();
        List<Grove> ArrangedList = new List<Grove>();

        public class Grove{
            public int position;
            public long value;
            public Grove(int position, long value)
            {
                this.position = position;
                this.value = value;
            }

        }
        public int FindPosition(int originalPos)
        {
            int pos = 0;
            for (int i = 0; i < ArrangedList.Count; i++)
            {
                if(ArrangedList[i].position == originalPos)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                Input.Add(int.Parse(readings[i]));
                Grove newGrove = new Grove(i, int.Parse(readings[i]));
                ArrangedList.Add(newGrove);
            }
           
            int moduloDivisor = Input.Count-1;
            for (int i = 0; i < Input.Count; i++)
            {
                int Number = Input[i];

                int Modulo = Number % moduloDivisor;

                int CurrentPosition = FindPosition(i);

                int steps = Modulo;
                if ((CurrentPosition+ Modulo)>= moduloDivisor || (CurrentPosition + Modulo) <= 0)
                {
                    if (Modulo>0)
                    {
                        steps = Modulo - (moduloDivisor);
                    }
                    else
                    {
                        steps = Modulo + (moduloDivisor );
                    }
                }

                if (steps>0)
                {
                    for (int j = 0; j < steps; j++)
                    {
                        var a = ArrangedList[CurrentPosition+j];
                        ArrangedList[CurrentPosition+j] = ArrangedList[CurrentPosition + j+1];
                        ArrangedList[CurrentPosition + j+1] = a;
                    }
                }
                else
                {
                    for (int j = 0; j < Math.Abs(steps); j++)
                    {
                        var a = ArrangedList[CurrentPosition - j];
                        ArrangedList[CurrentPosition - j] = ArrangedList[CurrentPosition - j - 1];
                        ArrangedList[CurrentPosition - j - 1] = a;
                    }
                }
            }
            int ZerpPos = FindPosition(Input.IndexOf(0));
            int thousand = (1000+ ZerpPos+1) % (moduloDivisor+1) ;
            int thousand2 = (2000 + ZerpPos + 1) % (moduloDivisor + 1);
            int thousand3 = (3000 + ZerpPos + 1) % (moduloDivisor + 1);

            long output = ArrangedList[ thousand-1 ].value + ArrangedList[ thousand2-1].value + ArrangedList[ thousand3-1].value;
            return output.ToString();
        }
   
        public string SecondSolution(List<string> readings)
        {
            ArrangedList.Clear();
            for (int i = 0; i < Input.Count; i++)
            {
                long inp = Input[i];
                Grove newGrove = new Grove(i, inp * 811589153);
                ArrangedList.Add(newGrove);
            }

            int moduloDivisor = Input.Count - 1;
            for (int l = 0; l < 10; l++)
            {


                for (int i = 0; i < Input.Count; i++)
                {
                    int CurrentPosition = FindPosition(i);
                    long Number = ArrangedList[CurrentPosition].value;

                    var Modulo = Number % moduloDivisor;



                    var steps = Modulo;
                    if ((CurrentPosition + Modulo) >= moduloDivisor || (CurrentPosition + Modulo) <= 0)
                    {
                        if (Modulo > 0)
                        {
                            steps = Modulo - (moduloDivisor);
                        }
                        else
                        {
                            steps = Modulo + (moduloDivisor);
                        }
                    }

                    if (steps > 0)
                    {
                        for (int j = 0; j < steps; j++)
                        {
                            var a = ArrangedList[CurrentPosition + j];
                            ArrangedList[CurrentPosition + j] = ArrangedList[CurrentPosition + j + 1];
                            ArrangedList[CurrentPosition + j + 1] = a;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < Math.Abs(steps); j++)
                        {
                            var a = ArrangedList[CurrentPosition - j];
                            ArrangedList[CurrentPosition - j] = ArrangedList[CurrentPosition - j - 1];
                            ArrangedList[CurrentPosition - j - 1] = a;
                        }
                    }
                }
            }
            int ZerpPos = FindPosition(Input.IndexOf(0));
            int thousand = (1000 + ZerpPos + 1) % (moduloDivisor + 1);
            int thousand2 = (2000 + ZerpPos + 1) % (moduloDivisor + 1);
            int thousand3 = (3000 + ZerpPos + 1) % (moduloDivisor + 1);

            long output = ArrangedList[thousand - 1].value + ArrangedList[thousand2 - 1].value + ArrangedList[thousand3 - 1].value;
            return output.ToString();
        }

    }
}
