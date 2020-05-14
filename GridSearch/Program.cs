using System;
namespace GridSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            float e = 0.0001f,
                h, m, d;

            float a1, a2, a3,
                b1, b2, b3;

            float min, x, y, z, temp, 
                xmin = 0, ymin = 0, zmin = 0;

            a1 = a2 = a3 = -5f;
            b1 = b2 = b3 = 5f;

            min = f(a1, a2, a3);

            d = b1 - a1;
            m = 5f;
            h = d / m;

            while (h > e)
            {
                for (int i = 0; i <= m; i++)
                {
                    x = a1 + (i * h);
                    for (int j = 0; j <= m; j++)
                    {
                        y = a2 + (j * h);
                        for (int k = 0; k <= m; k++)
                        {
                            z = a3 + (k * h);

                            temp = f(x, y, z);
                            if (temp < min)
                            {
                                min = temp;
                                xmin = x;
                                ymin = y;
                                zmin = z;
                            }
                        }
                    }
                }
                a1 = xmin - h;
                b1 = xmin + h;

                a2 = ymin - h;
                b2 = ymin + h;

                a3 = zmin - h;
                b3 = zmin + h;

                d = b1 - a1;
                h = d / m;
            }

            Console.WriteLine($"Точка экстремума ф-ии: {min} в точках \n" +
                $"[{b1 - h}]\n[{b2 - h}]\n[{b3 - h}]");
            Console.ReadKey();
        }

        static float f(float x, float y, float z) =>
            (x * x) - (2 * x) + (y * y) + (6 * y) + (z * z) + (2 * z) + 11;
    }
}
