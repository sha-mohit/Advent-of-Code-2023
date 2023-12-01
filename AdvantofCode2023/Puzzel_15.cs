using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantofCode2022
{
    public class Puzzel_15
    {
        //int decisionPoint = 10;
        int decisionPoint = 2000000;
        public class point
        {
            public int X;
            public int Y;
            public point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public string FirstSolution(List<string> readings)
        {
            List<point> pointRange = new List<point>();
            for (int i = 0; i < readings.Count; i++)
            {
                string[] cord = readings[i].Trim().Split(' ');
                string[] SensorX = cord[2].Replace(",", "").Split('=');
                string[] SensorY = cord[3].Replace(":", "").Split('=');
                string[] BeconX = cord[8].Replace(",", "").Split('=');
                string[] BeconY = cord[9].Split('=');
                point sensor = new point(int.Parse(SensorX[1]), int.Parse(SensorY[1]));
                point becon = new point(int.Parse(BeconX[1]), int.Parse(BeconY[1]));

                int distance = ManhattenDIstance(sensor, becon);
                point distancePoint = GetEvaluationPoints(sensor, distance);

                if (distancePoint != null)
                {
                    pointRange = GetPointRange(pointRange, distancePoint);
                }
            }
            int output = Math.Abs(pointRange[0].X) + Math.Abs(pointRange[1].X);
            return output.ToString();
        }
        public List<point> GetPointRange(List<point> pointRange, point distancePoint)
        {

            int rangeDistance =    (distancePoint.Y - decisionPoint) > 0 ? distancePoint.Y - decisionPoint : decisionPoint - distancePoint.Y;
            point leftPoint = new point(distancePoint.X - rangeDistance, distancePoint.Y);
            point rightPoint = new point(distancePoint.X + rangeDistance, distancePoint.Y);
            if (pointRange.Count == 0)
            {
                pointRange.Add(leftPoint);
                pointRange.Add(rightPoint);
            }else
            {
                if (pointRange[0].X> leftPoint.X)
                {
                    pointRange[0].X = leftPoint.X;
                }
                if (pointRange[1].X < rightPoint.X)
                {
                    pointRange[1].X = rightPoint.X;
                }
            }

            return pointRange;
        }
        public point GetEvaluationPoints(point sensor , int distance)
        {
            if (sensor.Y+ distance >= decisionPoint && sensor.Y < decisionPoint)
            {
                return new point(sensor.X,sensor.Y+distance);
            }
            if (sensor.Y - distance <= decisionPoint && sensor.Y > decisionPoint)
            {
                return new point(sensor.X, sensor.Y - distance);
            }
            return null;
        }
        public int ManhattenDIstance(point a, point b)
        {
            int x = Math.Abs(a.X - b.X);
            int y = Math.Abs(a.Y - b.Y);
            return x + y;
        }
        public string SecondSolution(List<string> readings)
        {
            List<int > positiveLine = new List<int>();
            List<int> negativeLine = new List<int>();
            for (int i = 0; i < readings.Count; i++)
            {
                string[] cord = readings[i].Trim().Split(' ');
                string[] SensorX = cord[2].Replace(",", "").Split('=');
                string[] SensorY = cord[3].Replace(":", "").Split('=');
                string[] BeconX = cord[8].Replace(",", "").Split('=');
                string[] BeconY = cord[9].Split('=');
                point sensor = new point(int.Parse(SensorX[1]), int.Parse(SensorY[1]));
                point becon = new point(int.Parse(BeconX[1]), int.Parse(BeconY[1]));

                int distance = ManhattenDIstance(sensor, becon);

                //consider x,y sensor cordinate as center
                int upPositiveLine = (sensor.X - sensor.Y) + distance;
                int downPositiveLine = (sensor.X - sensor.Y) - distance;
                int upNegativeLine = (sensor.X + sensor.Y) + distance;
                int downNegativeLine = (sensor.X + sensor.Y) - distance;

                positiveLine.Add(upPositiveLine);
                positiveLine.Add(downPositiveLine);
                negativeLine.Add(upNegativeLine);
                negativeLine.Add(downNegativeLine);
                

            }
            int positiveNotDetectedLine = 0;
            int negativeNotDetectedLine = 0;
            for (int i = 0; i < positiveLine.Count; i++)
            {
                for (int j = 0; j < positiveLine.Count; j++)
                {
                    if (Math.Abs(positiveLine[i] - positiveLine[j])==2)
                    {
                        positiveNotDetectedLine = Math.Min(positiveLine[i], positiveLine[j]) + 1;
                    }
                    if (Math.Abs(negativeLine[i] - negativeLine[j]) == 2)
                    {
                        negativeNotDetectedLine = Math.Min(negativeLine[i], negativeLine[j]) + 1;
                    }
                }

            }
            int x = (positiveNotDetectedLine + negativeNotDetectedLine) / 2;
            int y = (negativeNotDetectedLine- positiveNotDetectedLine) / 2;
            int output = x* 4000000+y;
            return output.ToString();
        }

    }
}
