
    public FieldForFarmers(int heightField, int lenghtField)
    {
        Field = new char[heightField, lenghtField];
        HeightField = heightField;
        LenghtField = lenghtField;


internal class Program
{
    private static void Main(string[] args)
    {

        Console.Write("Укажите размер поля по оси X: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Укажите размер поля по оси Y: ");
        int y = Convert.ToInt32(Console.ReadLine());


        AutoResetEvent[] waitFarmers = new AutoResetEvent[2];
        FieldForFarmers field = new(y, x);

        for (int i = 0; i < waitFarmers.Count(); i++)
        {
            waitFarmers[i] = new AutoResetEvent(false);
            WaitCallback waitCallback = FarmerOnField(i);
            if (waitCallback is not null)
            {
                ThreadPool.QueueUserWorkItem(waitCallback, new ThreadFieldControl(field, waitFarmers[i]));
            }
        }
        AutoResetEvent.WaitAll(waitFarmers);
        
        for (int i = 0; i < field.HeightField; i++)
        {
            for (int j = 0; j < field.LenghtField; j++)
            {
                Console.Write($"{field.Field[i, j]}");
            }
            Console.WriteLine();
        }

    }
    /// <summary>
    /// Очередь
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static WaitCallback? FarmerOnField(int index)
    {
        switch (index)
        {
            case 0:
                WaitCallback waitCallback = new(Farmer1);
                return waitCallback;
            case 1:
                return new WaitCallback(Farmer2);
            default:
                return null;
        }

    }

    /// <summary>
    /// Фермер 1
    /// </summary>
    /// <param name="field"></param>
    public static void Farmer1(object field)
    {
        if (field != null && field is ThreadFieldControl)
        {
            var threadFieldControl = (ThreadFieldControl)field;
            int heightField = threadFieldControl.Field.HeightField;
            int lenghtField = threadFieldControl.Field.LenghtField;

            for (int i = 0; i < heightField; i++)
            {
                for (int j = 0; j < lenghtField; j++)
                {
                    lock (threadFieldControl.Field)
                    {
                        if (threadFieldControl.Field.Field[i, j] == '.')
                            threadFieldControl.Field.Field[i, j] = 'Х';

                        Thread.Sleep(10);
                    }
                }
            }
            threadFieldControl.WaitHandle.Set();
        }
    }
    /// <summary>
    /// Фермер 2
    /// </summary>
    /// <param name="field"></param>
    public static void Farmer2(object field)
    {
        if (field != null && field is ThreadFieldControl)
        {
            var threadFieldControl = (ThreadFieldControl)field;
            int heightField = threadFieldControl.Field.HeightField;
            int lenghtField = threadFieldControl.Field.LenghtField;

            for (int i = heightField - 1; i > 0; i--)
            {
                for (int j = lenghtField - 1; j > 0; j--)
                {
                    lock (threadFieldControl.Field)
                    {
                        if (threadFieldControl.Field.Field[i, j] == '.')
                            threadFieldControl.Field.Field[i, j] = 'O';

    }

}
