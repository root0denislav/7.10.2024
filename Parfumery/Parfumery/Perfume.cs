using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parfumery
{
        public class Perfume
        {
            public string Brand { get; private set; }
            public double Price { get; private set; }

            public Perfume(string brand, double price)
            {
                if (price > 100)
                {
                    throw new ArgumentException("Грешно име!");
                }
                Brand = brand;
                Price = price;
            }

            public override string ToString()
            {
                return $"Парфюмът {Brand} струва {Price:F2}";
            }
        }
}
