namespace JobLessonASPNETMVCCore02v01
{
    internal class Farmers
    {
        private char[,] _field;

        public Farmers(char[,] field) { _field = field; }

        
        //Оба фермера используют один массив field 
        public static char[,] fieldSize()
        {

            Console.Write("Укажите размер поля по оси X: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите размер поля по оси Y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            char[,] field = new char[x,y];
            return field;
        }

        //Очередность определяется  
        public static void Farmer1(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("\n");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != null)
                    {
                        continue;
                    }
                    else
                    {
                        field[i, j] = 'X';                    
                        Console.Write(field[i,j]);
                        Thread.Sleep(100);
                    }                        

                }
            }
        }
        public static void Farmer2(char[,] field)
        {
            
            for (int i = (field.GetLength(1) - 1); i >= 0; i--)
            {
                Console.Write("\n");
                for (int j = (field.GetLength(0)-1); j >=0 ; j--)
                {
                    if (field[j, i] != null)
                    {
                        continue;
                    }
                    else
                    {
                        field[j, i] = 'O';
                    }

                }
            }
        }
    }
}
