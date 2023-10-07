using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangler
{
    public static class TriangleCalculator
    {
        public static ((float a, float b, float c) validazedValues, string triangleType, (int,int)[] pointCoordinates) CalculateTriangle(string sideA, string sideB, string sideC)
        {
            (float a, float b, float c) sides = ValidazeValues(sideA, sideB, sideC);
            string triangleType = IdentifyTriangleType(sides.a, sides.b, sides.c);
            (int, int)[] pointCoordinates = GetTrianglePointCoordinates(sides.a, sides.b, sides.c);
            Console.WriteLine(triangleType);
            foreach (var point in pointCoordinates)
            {
                Console.WriteLine(point);
            }

            return (sides, triangleType, pointCoordinates);

        }

        private static (float, float, float) ValidazeValues(string sideA, string sideB, string sideC)
        {
            float aLength = 0;
            float bLength = 0;
            float cLength = 0;
            if (float.TryParse(sideA, out float res))
            {
                aLength = float.Parse(sideA);
            }
            if (float.TryParse(sideB, out res))
            {
                bLength = float.Parse(sideB);
            }
            if (float.TryParse(sideC, out res))
            {
                cLength = float.Parse(sideC);
            }
            return (aLength, bLength, cLength);
        }

        private static string IdentifyTriangleType(float aLength, float bLength, float cLength)
        {
            if (aLength > 0 && bLength > 0 && cLength > 0)
            {
                if (aLength + bLength >= cLength && aLength + cLength >= bLength && bLength + cLength >= aLength)
                {
                    if (aLength == bLength || aLength == cLength || bLength == cLength)
                    {
                        if (aLength == bLength && bLength == cLength)
                            return "равносторонний";
                        else
                            return "равнобедренный";
                    }
                    else
                        return "разносторонний";
                }
                else
                    return "не треугольник";
            }
            else
                return "";
        }
        private static (int, int)[] GetTrianglePointCoordinates(float aLength, float bLength, float cLength)
        {
            (float x, float y) aCoordinates = (0, 0);
            (float x, float y) bCoordinates = (0, 0 + bLength);

            (float x, float y) abVector = (
                Convert.ToInt32((bCoordinates.x-aCoordinates.x) / cLength),
                Convert.ToInt32((bCoordinates.y- aCoordinates.y) / cLength)
                );
            (float x, float y) acVector = (abVector.y, -abVector.x);
            (float x, float y) cCoordinates = (acVector.x * cLength, acVector.y * cLength);

            float multiplier = 100 / bCoordinates.y;
            if (cCoordinates.x > 0 && 100 / cCoordinates.x < multiplier)
                multiplier = 100 / cCoordinates.x;
            if (cCoordinates.y > 0 && 100 / cCoordinates.y < multiplier)
                multiplier = 100 / cCoordinates.y;

            aCoordinates = (aCoordinates.x * multiplier, aCoordinates.y * multiplier);
            bCoordinates = (bCoordinates.x * multiplier, bCoordinates.y * multiplier);
            cCoordinates = (cCoordinates.x * multiplier, cCoordinates.y * multiplier);

            return new (int, int)[]{
                ((int)aCoordinates.x, (int)aCoordinates.y),
                ((int)bCoordinates.x, (int)bCoordinates.y),
                ((int)cCoordinates.x, (int)cCoordinates.y),
            };
        }
    }
}
