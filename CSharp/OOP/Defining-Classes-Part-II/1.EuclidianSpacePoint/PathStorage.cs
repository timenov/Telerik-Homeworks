﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianSpacePoint
{
    public class PathStorage
    {
        public static void SavePathToFile(Path points)
        {
            using (StreamWriter writer = new StreamWriter(@"../../SavedPath.txt",false))
            {
                int pointCounter = 0;
                writer.WriteLine("---------====== Last Path ======---------");
                if (points.SequenceOfPoints.Count > 0)
                {
                    foreach (var point in points.SequenceOfPoints)
                    {
                        pointCounter++;
                        writer.WriteLine("{0}. {1} {2} {3}", pointCounter, point.coordX, point.coordY, point.coordZ);
                    }
                }
                else
                {
                    writer.WriteLine("No point in sequence!");
                    throw new NullReferenceException("Point Sequence is empty!");
                }
            }
        }

        public static Path LoadLastPathFromFile()
        {
            Path newSequence = new Path();
            using (StreamReader reader = new StreamReader(@"../../SavedPath.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if ((char.IsDigit(line[0])))
                        {
                            string[] components = line.Split();
                            Point3D newPoint = new Point3D(int.Parse(components[1]), int.Parse(components[2]), int.Parse(components[3]));
                            newSequence.AddPointToSequnce(newPoint);
                        }
                    }
                    line = reader.ReadLine(); 
                }
            }

            if (newSequence.SequenceOfPoints.Count == 0)
            {
                throw new FileLoadException("The file you are trying to load is empty!");
            }

            return newSequence;
        }
    }
}
