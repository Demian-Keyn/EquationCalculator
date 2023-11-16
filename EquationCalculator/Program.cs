using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение квадратных уравнений");
            bool isWorks = true;

            while (isWorks)
            {
                Console.WriteLine("\n1. Ввод данных с клавитуры \n2. Ввод данных из файла\n3. Выход из программы\n");
                Console.Write("Выберите режим по номеру из предложенных выше: ");

                var optionNumber = Console.ReadLine();

                switch (optionNumber)
                {
                    case "1":
                        {
                            try
                            {
                                Console.Write("\nВведите число a = ");
                                var a = double.Parse(Console.ReadLine());
                                Console.Write("Введите число b = ");
                                var b = double.Parse(Console.ReadLine());
                                Console.Write("Введите число c = ");
                                var c = double.Parse(Console.ReadLine());

                                Tuple<double, double> result = Equation.QuadraticEquation(a, b, c);
                                if(result != null)
                                {
                                    Console.WriteLine($"Корни уравнения: x1 = {result.Item1}, x2 = {result.Item2}");
                                }
                                else
                                {
                                    Console.WriteLine("Квадратное уравнение не имеет корней");
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Exception: {ex.Message}");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Укажите путь к файлу: ");
                            string path = Console.ReadLine();
                            try
                            {
                                using (StreamReader reader = new StreamReader(path))
                                {
                                    string line;
                                    Console.WriteLine();
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        try
                                        {
                                            Console.WriteLine("----------------------------------");
                                            string[] simb = line.Split(' ');
                                            Console.WriteLine($"a = {simb[0]}, b = {simb[1]}, c = {simb[2]}");
                                            Tuple<double, double> result = Equation.QuadraticEquation(double.Parse(simb[0]), double.Parse(simb[1]), double.Parse(simb[2]));
                                            if (result != null)
                                            {
                                                Console.WriteLine($"Корни уравнения: x1 = {result.Item1}, x2 = {result.Item2}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Квадратное уравнение не имеет корней");
                                            }
                                            Console.WriteLine("----------------------------------");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Exception: {ex.Message}");
                                            Console.WriteLine("----------------------------------");
                                        }
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Exception: {ex.Message}");
                            }
                            break;
                        }
                    case "3":
                        {
                            isWorks = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Некорректный режим");
                            break;
                        }
                }
            }
        }
    }
}
