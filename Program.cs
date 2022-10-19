namespace Задание___5._1
{
    public enum Operation     // 
    {
        calculationtype,
        physicalvalue,
        thresholdvalue,
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int y;
                bool physicalvalue = true;
                Console.WriteLine("\nВыберите физическую величину. ");
                Console.WriteLine("Нажмите: 1. Напряжение; \t 2. Виброускорение.");
                y = int.Parse(Console.ReadLine());
                if (y == 1)
                {
                    physicalvalue = true;
                }
                if (y == 2)
                {
                    physicalvalue = false;
                }
                int z;
                bool thresholdvalue = true;
                Console.WriteLine("Выберите пороговые значения. ");
                Console.WriteLine("Нажмите: 1. Актуальное 10(-6) м/с^2; \t 2. Устаревшее 3*10(-4) м/с^2. ");
                z = int.Parse(Console.ReadLine());
                if (z == 1)
                {
                    thresholdvalue = true; // 0.000001
                }
                if (z == 2)
                {
                    thresholdvalue = false; // 0.0003
                }
                int x;
                Console.WriteLine("Выбор типа расчёта. ");
                Console.WriteLine("Нажмите: 1. Пересчёт в дБ; \t 2. Пересчёт из дБ.");
                x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    if (physicalvalue == true)
                    {
                        Console.WriteLine("Введите опорное напряжение.");
                        double.TryParse(Console.ReadLine(), out double voltageReference);
                        Console.WriteLine("Введите измеренное напряжение.");
                        double.TryParse(Console.ReadLine(), out double voltageMeasured);
                        double result = 20 * Math.Log10(voltageMeasured / voltageReference);
                        Console.WriteLine("Полученное значение: " + result + "dBV");
                    }
                    else
                    {
                        Console.WriteLine("Введите опорное напряжение.");
                        double.TryParse(Console.ReadLine(), out double voltageReference);
                        Console.WriteLine("Введите измеренное напряжение.");
                        double.TryParse(Console.ReadLine(), out double voltageMeasuredDBV);
                        double result = voltageReference * Math.Pow(10, (0.05 * voltageMeasuredDBV));
                        Console.WriteLine("Полученное значение: " + result + "V");
                    }
                    Console.WriteLine("--------------------------------------");
                }
                if (x == 2)
                {
                    if (physicalvalue == false)
                    {
                        Console.WriteLine("Введите измеренное СКЗ виброускорения.");
                        double.TryParse(Console.ReadLine(), out double vibroMeasured);
                        double result = 0;
                        if (thresholdvalue == true)
                        {
                            result = 20 * Math.Log10(vibroMeasured / 0.000001);
                            Console.WriteLine("Полученное значение: " + result + "dB");
                        }
                        else
                        {
                            result = 20 * Math.Log10(vibroMeasured / 0.0003);
                            Console.WriteLine("Полученное значение: " + result + "dB");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введите измеренный уровень виброускорения.");
                        double.TryParse(Console.ReadLine(), out double number);
                        double vibroMeasured = number;
                        double result = 0;
                        if (thresholdvalue == true)
                        {
                            result = 0.000001 * Math.Pow(10, (0.05 * vibroMeasured));
                            Console.WriteLine("Полученное значение: " + result + "м/с^2");
                        }
                        else
                        {
                            result = 0.0003 * Math.Pow(10, (0.05 * vibroMeasured));
                            Console.WriteLine("Полученное значение: " + result + "м/с^2");
                        }
                    }
                    Console.WriteLine("--------------------------------------");
                }
            }
        }

    }
}