namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\C#\\ConsoleApp3\\ConsoleApp3\\input.txt";
            StreamReader reader = new StreamReader(path);

            int[][] mass = new int[6][];
            int[,] massEnd = new int[6, 6];
            int[,] mass_temp = new int[6, 6];

            int[] mass2 = new int[6];
            List<int> Z = new List<int>();


            int gg = int.MaxValue;

            for (int i = 0; i < 6; i++)
            {
                mass[i] = Array.ConvertAll(reader.ReadLine().Split(' ').ToArray(), int.Parse);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mass[i][j] == 0)
                    {
                        mass[i][j] = gg;

                    }
                    mass_temp[i, j] = mass[i][j];
                }
            }



            for (int k = 0; k < 6; k++)
            {


                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        int first;
                        if (mass_temp[i, k] == gg || mass_temp[k, j] == gg)
                        {
                            first = gg;
                        }
                        else
                        {
                            first = mass_temp[i, k] + mass_temp[k, j];
                        }

                        int second = mass_temp[i, j];

                        massEnd[i, j] = Math.Min(first, second);
                        if (i == j) massEnd[i, j] = 0;
                    }
                }
                mass_temp = massEnd;
            }


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (massEnd[i, j] == gg)
                        Console.Write("inf");
                    else
                        Console.Write(massEnd[i, j]);

                    Console.Write(" ");
                }
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}