using Parfumery;
using System;
using System.Collections.Generic;

namespace RegularExam
{
    public class Program
    {
        static Dictionary<string, Perfumery> perfumeries = new Dictionary<string, Perfumery>();

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "STOP")
            {
                string[] splittedInput = input.Split(' ');
                string command = splittedInput[0];

                switch (command)
                {
                    case "AddPerfume":
                        AddPerfume(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "SellPerfume":
                        SellPerfume(splittedInput[1], double.Parse(splittedInput[2]), splittedInput[3]);
                        break;
                    case "CalculateTotalPrice":
                        CalculateTotalPrice(splittedInput[1]);
                        break;
                    case "GetPerfumeWithHighestPrice":
                        GetPerfumeWithHighestPrice(splittedInput[1]);
                        break;
                    case "GetPerfumeWithLowestPrice":
                        GetPerfumeWithLowestPrice(splittedInput[1]);
                        break;
                    case "RenamePerfumery":
                        RenamePerfumery(splittedInput[1], splittedInput[2]);
                        break;
                    case "SellAllPerfumes":
                        SellAllPerfumes(splittedInput[1]);
                        break;
                    case "PerfumeryInfo":
                        PerfumeryInfo(splittedInput[1]);
                        break;
                    case "CreatePerfumery":
                        CreatePerfumery(splittedInput[1]);
                        break;
                    default:
                        Console.WriteLine("Невалидна команда!");
                        break;
                }
            }
        }

        private static void AddPerfume(string brand, double price, string name)
        {
            try
            {
                Perfume perfume = new Perfume(brand, price);
                if (!perfumeries.ContainsKey(name))
                {
                    Console.WriteLine("Не можа да се добави този парфюм към парфюмерията.");
                    return;
                }
                Perfumery perfumery = perfumeries[name];
                perfumery.AddPerfume(perfume);
                Console.WriteLine($"Добавихте парфюм {brand} към парфюмерия {perfumery.Name}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SellPerfume(string brand, double price, string name)
        {
            try
            {
                if (!perfumeries.ContainsKey(name))
                {
                    Console.WriteLine("Не можа да се продаде този парфюм от парфюмерията.");
                    return;
                }

                Perfume perfume = new Perfume(brand, price);
                Perfumery perfumery = perfumeries[name];
                if (perfumery.SellPerfume(perfume))
                {
                    Console.WriteLine($"Продадохте парфюм {brand} от парфюмерия {name}.");
                }
                else
                {
                    Console.WriteLine($"Не успяхте да продадете парфюм {brand} от парфюмерия {name}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CalculateTotalPrice(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            Perfumery perfumery = perfumeries[name];
            Console.WriteLine($"Обща цена: {perfumery.CalculateTotalPrice():F2}");
        }

        private static void GetPerfumeWithHighestPrice(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            Perfume perfume = perfumeries[name].GetPerfumeWithHighestPrice();
            Console.WriteLine($"Парфюм с най-висока цена в парфюмерия {name}: {perfume.Price:F2}");
        }

        private static void GetPerfumeWithLowestPrice(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            Perfume perfume = perfumeries[name].GetPerfumeWithLowestPrice();
            Console.WriteLine($"Парфюм с най-ниска цена в парфюмерия {name}: {perfume.Price:F2}");
        }

        private static void RenamePerfumery(string oldName, string newName)
        {
            if (!perfumeries.ContainsKey(oldName))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            perfumeries[oldName].RenamePerfumery(newName);
            perfumeries.Add(newName, perfumeries[oldName]);
            perfumeries.Remove(oldName);
            Console.WriteLine($"Преименувахте парфюмерията от {oldName} на {newName}.");
        }

        private static void SellAllPerfumes(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            perfumeries[name].SellAllPerfumes();
            Console.WriteLine($"Продадохте всички парфюми от парфюмерия {name}.");
        }

        private static void PerfumeryInfo(string name)
        {
            if (!perfumeries.ContainsKey(name))
            {
                Console.WriteLine("Парфюмерията не е намерена.");
                return;
            }
            Console.WriteLine(perfumeries[name].ToString());
        }

        private static void CreatePerfumery(string name)
        {
            try
            {
                Perfumery perfumery = new Perfumery(name);
                perfumeries.Add(name, perfumery);
                Console.WriteLine($"Създадохте парфюмерия {name}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
