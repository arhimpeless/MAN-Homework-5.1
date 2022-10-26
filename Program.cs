namespace Задание___5._1
{
    public enum Thresholdvalue
    {
        actual,   //0.000001
        outdated  //0.0003
    }
    public enum Calculationtype
    {
        dB_To_mV,
        mV_To_dB
    }
    public enum Physicalvalue
    {
        voltage,
        vibroacceleration
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GetCalculationtype();
                GetPhysicalvalue();
                GetThresholdvalue();
                Thresholdvalue thresholdvalue;
                Calculationtype calculationtype;
                Physicalvalue physicalvalue;
                double result = 0;

                MakeVoltage(Physicalvalue , Calculationtype , result);
                MakeVibroacceleration(Physicalvalue , Calculationtype , result);

                Console.WriteLine();
                Console.ReadLine();
            }
        }
        private static Calculationtype GetCalculationtype()
        {
            Console.WriteLine("Выбор типа расчёта. ");
            Console.WriteLine("Нажмите: 1. Пересчёт в дБ; \t 2. Пересчёт из дБ.");
            string tipe = Console.ReadLine();
            if (tipe == "1")
            {
                return Calculationtype.mV_To_dB;
            }
            if (tipe == "2")
            {
                return Calculationtype.dB_To_mV;
            }
            Console.WriteLine("Введено некорректное значение. ");
            return GetCalculationtype();
        }
        private static Physicalvalue GetPhysicalvalue()
        {
            Console.WriteLine("\nВыберите физическую величину. ");
            Console.WriteLine("Нажмите: 1. Напряжение; \t 2. Виброускорение.");
            string tipe = Console.ReadLine();
            if (tipe == "1")
            {
                return Physicalvalue.voltage;
            }
            if (tipe == "2")
            {
                return Physicalvalue.vibroacceleration;
            }
            Console.WriteLine("Введено некорректное значение. ");
            return GetPhysicalvalue();
        }
        private static Thresholdvalue GetThresholdvalue()
        {
            Console.WriteLine("Выберите пороговые значения. ");
            Console.WriteLine("Нажмите: 1. Актуальное 10(-6) м/с^2; \t 2. Устаревшее 3*10(-4) м/с^2. ");
            string tipe = Console.ReadLine();
            if (tipe == "1")
            {
                return Thresholdvalue.actual;
            }
            if (tipe == "2")
            {
                return Thresholdvalue.outdated;
            }
            Console.WriteLine("Введено некорректное значение. ");
            return GetThresholdvalue();
        }



        private static void MakeVoltage(Physicalvalue physicalvalue, Calculationtype calculationtype, double result)
        {
            if (physicalvalue == Physicalvalue.voltage && calculationtype == Calculationtype.mV_To_dB)
            {
                Console.WriteLine("Введите опорное напряжение.");
                double.TryParse(Console.ReadLine(), out double voltageReference);
                Console.WriteLine("Введите измеренное напряжение.");
                double.TryParse(Console.ReadLine(), out double voltageMeasured);
                double result_dBV = 20 * Math.Log10(voltageMeasured / voltageReference);
                Console.WriteLine("Полученное значение: " + result_dBV + "dBV");
            }
            if (physicalvalue == Physicalvalue.voltage && calculationtype == Calculationtype.dB_To_mV)
            {
                Console.WriteLine("Введите опорное напряжение.");
                double.TryParse(Console.ReadLine(), out double voltageReference);
                Console.WriteLine("Введите измеренное напряжение.");
                double.TryParse(Console.ReadLine(), out double voltageMeasuredDBV);
                double result_V = voltageReference * Math.Pow(10, (0.05 * voltageMeasuredDBV));
                Console.WriteLine("Полученное значение: " + result_V + "V");
            }
            Console.WriteLine("--------------------------------------");
        }
        private static void MakeVibroacceleration(Calculationtype calculationtype, Physicalvalue physicalvalue, Thresholdvalue thresholdvalue, double result)
        {
            double thresholdvalue_A = 0.000001;
            double thresholdvalue_O = 0.0003;
            Console.WriteLine("Введите измеренное СКЗ виброускорения.");
            double.TryParse(Console.ReadLine(), out double vibroMeasured);
            if (calculationtype == Calculationtype.mV_To_dB && thresholdvalue == Thresholdvalue.actual && physicalvalue == Physicalvalue.vibroacceleration)
            {
                result = 20 * Math.Log10(vibroMeasured / thresholdvalue_A);
                Console.WriteLine("Полученное значение: " + result + "dB");
            }
            if(calculationtype == Calculationtype.mV_To_dB && thresholdvalue == Thresholdvalue.outdated && physicalvalue == Physicalvalue.vibroacceleration)
            {
                result = 20 * Math.Log10(vibroMeasured / thresholdvalue_O);
                Console.WriteLine("Полученное значение: " + result + "dB");
            }

            if(calculationtype == Calculationtype.dB_To_mV && physicalvalue == Physicalvalue.vibroacceleration)
            {
                Console.WriteLine("Введите измеренный уровень виброускорения.");
                double.TryParse(Console.ReadLine(), out double number);
                double vibroMeasured_S = number;
                double result_VA = 0;
            if (thresholdvalue == Thresholdvalue.actual)
                {
                    result = thresholdvalue_A * Math.Pow(10, (0.05 * vibroMeasured_S));
                    Console.WriteLine("Полученное значение: " + result_VA + "м/с^2");
                }
            if (thresholdvalue == Thresholdvalue.outdated)
                {
                    result = thresholdvalue_O * Math.Pow(10, (0.05 * vibroMeasured_S));
                    Console.WriteLine("Полученное значение: " + result_VA + "м/с^2");
                }
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}