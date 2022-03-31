using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Commodity: IInit, IComparable<Commodity>, ICloneable //Товар //Можно было бы сделать абстрактным и эту абстаркцию бы наследовал класс продукты. В итоге создавались бы только объекты класса игрушки и молочные продукты. Но я так не сделал)
    {
        protected static Random rnd = new Random();
        protected int price; //Только в рублях, без копеек
        protected int weight; //В граммах

        public int Price
        {
            get => price;
            set
            {
                if (value >= 1) //Если 0, то товара нет в наличии (цена на данный момент неизвестна)
                {
                    price = value;
                }
                else if (value == 0)
                {
                    //Console.WriteLine("Цена на данный момент неизвестна или товара нет в наличии");
                    price = value;
                }
                else
                {
                    //Console.WriteLine("Цена не может быть меньше 1 рубля");
                    price = 0;
                }
            }
        }

        public int Weight
        {
            get => weight;
            set
            {
                if (value >= 1) //Если 0, то товара нет в наличии (вес на данный момент неизвестен)
                    weight = value;
                else if (value == 0)
                {
                    //Console.WriteLine("Вес на данный момент неизвестен или товара нет в наличии");
                    weight = value;
                }
                else
                {
                    //Console.WriteLine("Вес не может быть меньше 1 грамма");
                    weight = 0;
                }
            }
        }

        public Commodity() //Пустой конструктор
        {
            Price = 0;
            Weight = 0;
        }

        public Commodity(int price, int weight)
        {
            Price = price;
            Weight = weight;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Цена товара: {price} рублей, а его вес {weight} грамм");
        }

        public void ShowWrong() //Для проверки без виртуального метода
        {
            Console.WriteLine($"Цена товара: {price} рублей, а его вес {weight} грамм");
        }

        public virtual int QuantityOfCommodity(Commodity[] arr, string commodity)
        {
            int quantity = 0;
            return quantity;
        }

        public virtual int TotalCostOfCommodity(Commodity[] arr, string commodity)
        {
            int totalCost = 0;
            return totalCost;
        }

        public virtual string MostExpensiveMostCheap(Commodity[] arr, string shopname) //Добавить список магазинов для пользователя
        {
            string str = "";
            return  str;
        }

        public override string ToString()
        {
            return $"Цена товара: {Price}, вес товара: {Weight}";
        }

        public virtual void Init() //Случайная цена и вес
        {
            Price = rnd.Next(5, 10000);
            Weight = rnd.Next(5, 15000);
        }

        public int CompareTo(Commodity compareCom)
        {
            if (compareCom == null)
                return 1;
            else
                return this.Price.CompareTo(compareCom.Price);
        }

        public string HightLowWeight(Commodity[] arr)
        {
            string hightWeight, lowWeight, highName = "товар без названия", lowName = "товар без названия";
            Toy t = new Toy();
            MilkProduct mk= new MilkProduct();
            Commodity[] bufArr = new Commodity[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bufArr[i] = arr[i];
            }
            Array.Sort(bufArr, new SortByWeight());
            t = bufArr[0] as Toy;
            if (t != null)
                lowName = t.ToyName.ToString();
            else
            {
                mk = bufArr[0] as MilkProduct;
                if (mk != null)
                    lowName = mk.MilkProductName.ToString();
            }
            lowWeight = bufArr[0].Weight.ToString();
            t = bufArr[bufArr.Length - 1] as Toy;
            if (t != null)
                lowName = t.ToyName.ToString();
            else
            {
                mk = bufArr[bufArr.Length - 1] as MilkProduct;
                if (mk != null)
                    lowName = mk.MilkProductName.ToString();
            }
            hightWeight = bufArr[bufArr.Length - 1].Weight.ToString();
            return $"Наибольший вес в {hightWeight} грамм имеет {highName}. В то время как наименьший вес в {lowWeight} грамм имеет {lowName}";
        }

        public virtual object Clone()
        {
            return new Commodity(this.Price, this.Weight); 
        }

        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        //public IEnumerator<Commodity> GetEnumerator()
        //{
        //    foreach (Commodity item in this)
        //        yield return item;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}
    }
}
