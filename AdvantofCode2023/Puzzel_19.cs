using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2023
{
    public class Puzzel_19
    {
        public class Robot
        {
            public string RobotType;
            public int BuildOrecost;
            public int Collection;
            public int RobotCount;

            public Robot(string type, int cost, int collection,int robotCount)
            {
                this.RobotType = type;
                this.BuildOrecost = cost;
                this.Collection = collection;
                this.RobotCount = robotCount;
            }

        }
        public class ObsRobot :Robot
        {
            public int BuildClaycost;
            public ObsRobot(string type, int Orecost, int ClayCost, int collection ,int count) : base(type, Orecost, collection,count)
            {
                this.BuildClaycost = ClayCost;
            }

        }
        public class GeoRobot : ObsRobot
        {
            public int BuildObscost;
            public GeoRobot(string type, int Orecost, int ClayCost, int ObsCost, int collection,int count):base(type,Orecost,ClayCost, collection,count)
            {
                this.BuildObscost = ObsCost;
            }

        }
        Dictionary<int, List<GeoRobot>> BlueprintList = new Dictionary<int, List<GeoRobot>>();
        Dictionary<int, List<GeoRobot>> BlueprintListCopy = new Dictionary<int, List<GeoRobot>>();
        public string FirstSolution(List<string> readings)
        {
            for (int i = 0; i < readings.Count; i++)
            {
                string[] input = readings[i].Split(' ');
                int bIdc = int.Parse(input[1].Replace(":", "").Trim());
                int oreCost = int.Parse(input[6].Trim());
                int clayOreCost = int.Parse(input[12].Trim());
                int obsOreCost = int.Parse(input[18].Trim());
                int ObsCalyCost = int.Parse(input[21].Trim());
                int GeoOreCost = int.Parse(input[27].Trim());
                int GeoobsCost = int.Parse(input[30].Trim());

                GeoRobot oreRobot = new GeoRobot("OreRobot", oreCost, 0, 0, 0, 1);
                GeoRobot clayRobot = new GeoRobot("ClayRobot", clayOreCost, 0, 0, 0, 0);
                GeoRobot ObsRobot = new GeoRobot("ObsRobot", obsOreCost, ObsCalyCost, 0, 0, 0);
                GeoRobot GeoRobot = new GeoRobot("GeoRobot", GeoOreCost, 0, GeoobsCost, 0, 0);

                BlueprintListCopy.Add(bIdc, new List<GeoRobot>() { oreRobot, clayRobot, ObsRobot, GeoRobot });


            }
            for (int i = 1; i <= BlueprintListCopy.Count; i++)
            {
                BlueprintList.Add(i, CopyList(BlueprintListCopy[i]));
            }
            int totalQualityLevel = 0;
            Parallel.For(1, BlueprintList.Count+1, i => { GetMaxGeode(BlueprintList[i],i,24); });
          
            for (int i = 1; i <= BlueprintList.Count; i++)
            {
                totalQualityLevel = totalQualityLevel + i * BlueprintList[i][3].Collection;
            }
            return totalQualityLevel.ToString();
        }

        public void GetMaxGeode(List<GeoRobot> Robots,int index ,int time)
        {
            BlueprintList[index] = DFS(CopyList(Robots), time);
        }
        public List<GeoRobot> CopyList(List<GeoRobot> Robots)
        {
            List<GeoRobot> Robot = new List<GeoRobot>();

            for (int i = 0; i < Robots.Count; i++)
            {
                GeoRobot newRobo = new GeoRobot(Robots[i].RobotType, Robots[i].BuildOrecost, Robots[i].BuildClaycost, Robots[i].BuildObscost, Robots[i].Collection, Robots[i].RobotCount);
                Robot.Add(newRobo);
            }
            return Robot;
        }

        public List<GeoRobot> DFS(List<GeoRobot> Robots, int time)
        {
           if (time <= 0)
            {
                return Robots;
            }

            List<List<GeoRobot>> hList = new List<List<GeoRobot>>();
            bool roboCreated = false;
            if (CanCreateRobot(Robots,3, time))
            {
                List<GeoRobot> Robots3 = new List<GeoRobot>();// create geo robo
                Robots3.AddRange(CopyList(Robots));
                roboCreated = CreateRobot(Robots3, 3);
                hList.Add(DFS(Robots3, time - 1));
            }
            if (CanCreateRobot(Robots,2, time) && !roboCreated)
            {
                List<GeoRobot> Robots2 = new List<GeoRobot>(); // create obse robo
                Robots2.AddRange(CopyList(Robots));
                roboCreated = CreateRobot(Robots2, 2);
                hList.Add(DFS(Robots2, time - 1));
            }
            if (CanCreateRobot(Robots, 1, time) && !roboCreated)
            {
                List<GeoRobot> Robots1 = new List<GeoRobot>();// create clay robo
                Robots1.AddRange(CopyList(Robots));
                roboCreated = CreateRobot(Robots1, 1);
                hList.Add(DFS(Robots1, time - 1));
            }
            if (CanCreateRobot(Robots, 0, time))
            {
                List<GeoRobot> Robots0 = new List<GeoRobot>(); // create ore robo
                Robots0.AddRange(CopyList(Robots));
                roboCreated = CreateRobot(Robots0, 0);
                hList.Add(DFS(Robots0, time - 1));
            }
            if (CanCreateRobot(Robots, 4, time))
            {
                List<GeoRobot> Robots4 = new List<GeoRobot>();// no robo
                Robots4.AddRange(CopyList(Robots));
                CreateRobot(Robots4, 4);
                hList.Add(DFS(Robots4, time - 1));
            }


            var R = Robots;
            
            for (int i = 0; i < hList.Count; i++)
            {
                R = R[3].Collection > hList[i][3].Collection ? R : hList[i];
            }

            return R;
        }

        public bool CanCreateRobot(List<GeoRobot> Robots, int type,int time )
        {
            if (type == 3)
            {
                if (Robots[0].Collection >= Robots[3].BuildOrecost && Robots[2].Collection >= Robots[3].BuildObscost)
                {
                    return true;
                }
            }
            if (type == 2)
            {
                if (Robots[0].Collection >= Robots[2].BuildOrecost && Robots[1].Collection >= Robots[2].BuildClaycost && Robots[2].Collection < Robots[3].BuildObscost * time
                    && Robots[2].RobotCount < Robots[3].BuildObscost)
                {
                    return true;
                }
            }
            if (type == 1)
            {
                if (Robots[0].Collection >= Robots[1].BuildOrecost && Robots[1].Collection < Robots[2].BuildClaycost * time && Robots[1].RobotCount < Robots[2].BuildClaycost)
                {
                    return true;
                }
            }
            if (type == 0)
            {
                var H1 = Robots[3].BuildOrecost > Robots[2].BuildOrecost ? Robots[3].BuildOrecost : Robots[2].BuildOrecost;
                var H2 = Robots[1].BuildOrecost > Robots[0].BuildOrecost ? Robots[1].BuildOrecost : Robots[1].BuildOrecost;

                H1 = H1 > H2 ? H1 : H2;
                if (Robots[0].Collection >= Robots[0].BuildOrecost && Robots[0].Collection < H1* time && Robots[0].RobotCount< H1)
                {
                    return true;
                }
            }
            if (type == 4)
            {
                var H1 = Robots[3].BuildOrecost > Robots[2].BuildOrecost ? Robots[3].BuildOrecost : Robots[2].BuildOrecost;
                var H2 = Robots[1].BuildOrecost > Robots[0].BuildOrecost ? Robots[1].BuildOrecost : Robots[1].BuildOrecost;

                H1 = H1 > H2 ? H1 : H2;
                if (Robots[2].Collection < Robots[3].BuildObscost * time && Robots[1].Collection < Robots[2].BuildClaycost * time && Robots[0].Collection < H1 * time && Robots[0].RobotCount < H1
                    && Robots[1].RobotCount < Robots[2].BuildClaycost && Robots[2].RobotCount < Robots[3].BuildObscost)
                {
                    return true;
                }
            }
            return false;
        } 
        public bool CreateRobot(List<GeoRobot> Robots ,int type)
        {
            bool roboCreated = false;
            Robots[3].Collection = Robots[3].Collection + Robots[3].RobotCount;
            if (type ==3)
            {
                if (Robots[0].Collection >= Robots[3].BuildOrecost && Robots[2].Collection >= Robots[3].BuildObscost)
                {
                    Robots[3].RobotCount++;
                    Robots[0].Collection = Robots[0].Collection - Robots[3].BuildOrecost;
                    Robots[2].Collection = Robots[2].Collection - Robots[3].BuildObscost;
                    roboCreated = true;
                }
            }
            
            Robots[2].Collection = Robots[2].Collection + Robots[2].RobotCount;
            if (type == 2)
            {
                if (Robots[0].Collection >= Robots[2].BuildOrecost && Robots[1].Collection >= Robots[2].BuildClaycost)
                {
                    Robots[2].RobotCount++;
                    Robots[0].Collection = Robots[0].Collection - Robots[2].BuildOrecost;
                    Robots[1].Collection = Robots[1].Collection - Robots[2].BuildClaycost;
                    roboCreated = true;
                }
            }
            Robots[1].Collection = Robots[1].Collection + Robots[1].RobotCount;
            if (type == 1)
            {
                if (Robots[0].Collection >= Robots[1].BuildOrecost)
                {
                    Robots[1].RobotCount++;
                    Robots[0].Collection = Robots[0].Collection - Robots[1].BuildOrecost;
                    roboCreated = true;
                }
            }
            Robots[0].Collection = Robots[0].Collection + Robots[0].RobotCount;
            if (type == 0)
            {
                if (Robots[0].Collection >= Robots[0].BuildOrecost)
                {
                    Robots[0].RobotCount++;
                    Robots[0].Collection = Robots[0].Collection - Robots[0].BuildOrecost;
                    roboCreated = true;
                }
            }
            return roboCreated;
        }
        public string SecondSolution(List<string> readings)
        {
            BlueprintList.Clear();
            for (int i = 1; i <= BlueprintListCopy.Count; i++)
            {
                BlueprintList.Add(i, CopyList(BlueprintListCopy[i]));
            }
            int totalQualityLevel = 1;
            Parallel.For(1, 4, i => { GetMaxGeode(BlueprintList[i], i,32); });

            for (int i = 1; i <= 3; i++)
            {
                totalQualityLevel = totalQualityLevel * BlueprintList[i][3].Collection;
            }
            return totalQualityLevel.ToString();
        }

    }
}
