using System;
using System.Collections.Generic;
using System.Text;

namespace ForestSim
{
    public class River
    {
        public List<Coordinate> RiverPositions;

        public struct Coordinate
        {
            public double x;
            public double y;

            public Coordinate(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public River()
        {
            this.RiverPositions = new List<Coordinate>();
        }

        public void GenerateRiver()
        {
            Coordinate initalRiverPosition = GetStartingPosition(0, 100, 0, 100);

            double riverAngle = GetStartingAngle("bottom");

            Coordinate riverPosition = initalRiverPosition;

            double increment = 1d;
            double nextRiverAngleStandardDeviation = Math.PI / 6;

            while (CheckIfInForestBounds(riverPosition, 0, 100, 0, 100))
            {
                RiverPositions.Add(riverPosition);

                riverPosition = GetNextPosition(riverAngle, riverPosition, increment);
                riverAngle = GetNextAngle(riverAngle, nextRiverAngleStandardDeviation);
            }
        }

        public Coordinate GetStartingPosition(double lowerX, double upperX, double lowerY, double upperY)
        {
            double startX, startY;

            startX = (double)GetRandomInBounds(lowerX, upperX);
            startY = 0f;

            Coordinate startingPosition = new Coordinate(startX, startY);

            return startingPosition;
        }

        public double GetStartingAngle(string side)
        {
            double angle;

            switch (side)
            {
                case "bottom":
                    angle = GetRandomInBounds(0, Math.PI);
                    break;
                default:
                    angle = 0f;
                    break;
            }

            return Math.PI / 2;
        }

        public Coordinate GetNextPosition(double angle, Coordinate riverPosition, double increment)
        {
            double changeX, changeY;

            changeX = increment * Math.Cos(angle);
            changeY = increment * Math.Sin(angle);

            Coordinate nextCoordinate = new Coordinate(riverPosition.x + changeX, riverPosition.y + changeY);

            return nextCoordinate;
        }

        public double GetNextAngle(double previousAngle, double standardDeviation)
        {
            double angleChange = SampleGaussian(0, standardDeviation);

            return previousAngle + angleChange;
        }

        public bool CheckIfInForestBounds(Coordinate riverPosition, double lowerX, double upperX, double lowerY, double upperY)
        {
            if (riverPosition.x < lowerX || riverPosition.x > upperX || riverPosition.y < lowerY || riverPosition.y > upperY)
            {
                return false;
            }

            return true;
        }

        public double GetRandomInBounds(double lowerBound, double upperBound)
        {
            Random rnd = new Random();
            return (rnd.NextDouble() * (upperBound - lowerBound) + lowerBound);
        }
        public double SampleGaussian(double mean, double stddev)
        {
            Random rnd = new Random();

            double x1 = 1 - rnd.NextDouble();
            double x2 = 1 - rnd.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return y1 * stddev + mean;
        }
    }
}
