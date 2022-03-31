using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MilkProduct: Product, IEquatable<MilkProduct>
    {
        protected int highTemperature;
        protected int lowTemperature;

        public string MilkProductName { get; set; }

        public string PlaceOfProduction { get; set; }

        static string[] MilkProducts = {"Молоко с 0% жирности", "Молоко с 3,5% жирности", "Молоко с 5% жирности", "Сметана с 15% жирности", "Сметана с 30% жирности", "Простокваша", "Масло традиционное 82%", "Масло крестьянское 72%" };

        static string[] Places = { "Кунгурский молочный комбинат", "Молоко", "Пермский хладокомбинат Созвездие", "Юговский комбинат молочных продуктов", "Маслозавод Нытвенский", "Ленинское", "Перммолоко", "Экомилк" };

        public int HighTemperature
        {
            get => highTemperature;
            set
            {
                if (value >= 0 && value <= 10)
                {
                    highTemperature = value;
                }
                else
                {
                    //Console.WriteLine("Неподходящая температура хранения");
                    highTemperature = 0;
                }
            }
        }

        public int LowTemperature
        {
            get => lowTemperature;
            set
            {
                if (value >= -10 && value <= 0)
                {
                    lowTemperature = value;
                }
                else
                {
                    //Console.WriteLine("Неподходящая температура хранения");
                    lowTemperature = 0;
                }
            }
        }


        public MilkProduct() : base()
        {
            HighTemperature = 0;
            LowTemperature = 0;
            PlaceOfProduction = "Неизвестное место изготовления";
            MilkProductName = "Неизвестное наименование продукта";
        }
        public MilkProduct(int price, int weight, int Date, bool GMO, int high, int low, string milkproductname, string place):base(price, weight, Date, GMO)
        {
            HighTemperature = high;
            LowTemperature = low;
            PlaceOfProduction = place;
            MilkProductName = milkproductname;
            PlaceOfProduction = place;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Наименование продукта: {MilkProductName}. Хранить при температуре от {LowTemperature} до {HighTemperature} градусов. Компания производитель: {PlaceOfProduction}");
        }

        public new void ShowWrong() //Для проверки без виртуального метода
        {
            base.ShowWrong();
            Console.WriteLine($"Наименование продукта: {MilkProductName}. Хранить при температуре от {LowTemperature} до {HighTemperature} градусов. Компания производитель: {PlaceOfProduction}");
        }

        public override int QuantityOfCommodity(Commodity[] arr, string commodity)
        {
            int quantity = 0;
            MilkProduct m;
            foreach (Commodity c in arr)
            {
                m = c as MilkProduct;
                if (m != null)
                {
                    if (commodity == m.MilkProductName)
                        quantity++;
                }
            }
            return quantity;
        }

        public override int TotalCostOfCommodity(Commodity[] arr, string commodity)
        {
            int totalCost = 0;
            MilkProduct m;
            foreach (Commodity c in arr)
            {
                m = c as MilkProduct;
                if (m != null)
                {
                    if (commodity == m.MilkProductName)
                        totalCost += m.price;
                }
            }
            return totalCost;
        }

        public override string ToString()
        {
            return base.ToString() + $", наименование молочного продукта: {MilkProductName}, кампания производитель: {PlaceOfProduction}, условия хранения: от {LowTemperature} до {HighTemperature} градусов";
        }


        public override void Init()
        {
            base.Init();
            HighTemperature = rnd.Next(0, 10);
            LowTemperature = rnd.Next(-10, 0);
            MilkProductName = MilkProducts[rnd.Next(MilkProducts.Length)];
            PlaceOfProduction = Places[rnd.Next(Places.Length)];
        }

        public override object Clone()
        {
            return new MilkProduct(this.Price, this.Weight, this.ExpirationDate, this.NoGMO, this.HighTemperature, this.LowTemperature, this.MilkProductName, this.PlaceOfProduction);
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            MilkProduct objAsMilkProduct = obj as MilkProduct;
            if (objAsMilkProduct == null) return false;
            else return Equals(objAsMilkProduct);
        }

        public bool Equals(MilkProduct other)
        {
            if (other == null) return false;
            return (this.MilkProductName.Equals(other.MilkProductName));
        }
    }
}
