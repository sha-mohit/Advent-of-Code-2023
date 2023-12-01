using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_16
    {
        Dictionary<string, List<string>> tunnelsList = new Dictionary<string, List<string>>();
        Dictionary<string, int> rateList = new Dictionary<string, int>();
       
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                string[] line = readings[i].Trim().Split(';');
                string[] firstHalf = line[0].Trim().Split(' ');
                string valve = firstHalf[1].Trim();
                string rate = firstHalf[4].Replace(";", "").Split('=')[1];
                string secondhalf = line[1].Trim().Replace("tunnels lead to valves", "").Replace("tunnel leads to valve","").Trim();
                string[] tunnelsValves = secondhalf.Split(',');

                List<string> tValves = new List<string>();
                for (int j = 0; j < tunnelsValves.Length; j++)
                {
                    tValves.Add(tunnelsValves[j].Trim());
                }
                tunnelsList.Add(valve, tValves);
                if (int.Parse(rate)!=0)
                {
                    rateList.Add(valve, int.Parse(rate));
                }
                
            }
            
            Node startNode = new Node("AA");
            Node final = DFS(startNode,30);
            return final.pressure.ToString(); ;
        }
        public class Node
        {
            public string valve ="";
            public bool HasMoved = false;
            public List<string> opendValve = new List<string>();
            public int pressure = 0;
            public Node() { }
            public Node(string volve)
            {
                this.valve = volve;
            }
        }
        public List<string> CopyList(List<string> valves)
        {
            List<string> newvalves = new List<string>();
            for (int i = 0; i < valves.Count; i++)
            {
                newvalves.Add(valves[i]);
            }
            return newvalves;
        }
        public Node DFS(Node node , int time)
        {
            if (time == 0) return node;

            foreach (var item in node.opendValve)
            {
                node.pressure = node.pressure + rateList[item];
            }
            List<Node> compareList = new List<Node>();
            if (!rateList.ContainsKey(node.valve))
            {
                for (int i = 0; i < tunnelsList[node.valve].Count; i++)
                {
                    string valve = tunnelsList[node.valve][i];
                    Node newNode = new Node(valve);
                    newNode.opendValve.AddRange(CopyList(node.opendValve));
                    newNode.pressure = node.pressure;
                    newNode.HasMoved = false;
                    if (newNode.opendValve.Contains(valve))
                    {
                        compareList.Add( DFS(newNode, time - 1));
                    }
                    else
                    {
                        newNode.HasMoved = true;
                        compareList.Add(DFS(newNode, time - 1));
                    }

                   
                }
            }
            else
            {
                if (!node.opendValve.Contains(node.valve))
                {
                    Node newNode = new Node(node.valve);
                    newNode.opendValve.AddRange(CopyList(node.opendValve));
                    newNode.pressure = node.pressure;
                    newNode.HasMoved = node.HasMoved;
                    if (newNode.HasMoved == true)
                    {
                        newNode.opendValve.Add(newNode.valve);
                        compareList.Add(DFS(newNode, time - 1));
                    }
                    else
                    {
                        newNode.HasMoved = true;
                        compareList.Add(DFS(newNode, time - 1));
                    }
                }


                for (int i = 0; i < tunnelsList[node.valve].Count; i++)
                {
                    string valve = tunnelsList[node.valve][i];
                    Node newNode = new Node(valve);
                    newNode.opendValve.AddRange(CopyList(node.opendValve));
                    newNode.pressure = node.pressure;
                    newNode.HasMoved = false;
                    if (newNode.opendValve.Contains(valve))
                    {
                        compareList.Add(DFS(newNode, time - 1));
                    }
                    else
                    {
                        newNode.HasMoved = true;
                        compareList.Add(DFS(newNode, time - 1));
                    }
                    
                }


            }
            Node re = new Node();
            foreach (Node n in compareList)
            {
                if (re.pressure<n.pressure)
                {
                    re = n;
                }
            }
            return re;

        }

        public string SecondSolution(List<string> readings)
        {
            return "";
        }

    }
}
