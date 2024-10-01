using Parfumery;
using System;
using System.Collections.Generic;

namespace Parfumery
{
    public class Perfumery
    {
        public string Name { get; private set; }
        private List<Perfume> perfumes;

        public Perfumery(string name)
        {
            if (name.Length < 6)
            {
                throw new ArgumentException("Грешно име!");
            }
            Name = name;
            perfumes = new List<Perfume>();
        }

        public void AddPerfume(Perfume perfume)
        {
            perfumes.Add(perfume);
        }

        public bool SellPerfume(Perfume perfume)
        {
            return perfumes.Remove(perfume);
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (var perfume in perfumes)
            {
                totalPrice += perfume.Price;
            }
            return totalPrice;
        }

        public Perfume GetPerfumeWithHighestPrice()
        {
            Perfume highestPricePerfume = null;
            double highestPrice = double.MinValue;
            foreach (var perfume in perfumes)
            {
                if (perfume.Price > highestPrice)
                {
                    highestPrice = perfume.Price;
                    highestPricePerfume = perfume;
                }
            }
            return highestPricePerfume;
        }

        public Perfume GetPerfumeWithLowestPrice()
        {
            Perfume lowestPricePerfume = null;
            double lowestPrice = double.MaxValue;
            foreach (var perfume in perfumes)
            {
                if (perfume.Price < lowestPrice)
                {
                    lowestPrice = perfume.Price;
                    lowestPricePerfume = perfume;
                }
            }
            return lowestPricePerfume;
        }

        public void RenamePerfumery(string newName)
        {
            if (newName.Length < 6)
            {
                throw new ArgumentException("Грешно име!!");
            }
            Name = newName;
        }

        public void SellAllPerfumes()
        {
            perfumes.Clear();
        }

        public override string ToString()
        {
            if (perfumes.Count == 0)
            {
                return $"Парфюмерия {Name} няма налични парфюми.";
            }

            string result = $"Парфюмерия {Name} има {perfumes.Count} парфюма наличин!:";
            foreach (var perfume in perfumes)
            {
                result += $"\n{perfume.ToString()}";
            }
            return result;
        }
    }
}
