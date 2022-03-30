using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Lab_11
{
    public class Menu
    {
        static Random rnd = new Random();

        public Menu() //Конструктор самого меню
        {
            var l1 = new List<Commodity>(0);
            var l2 = new List<Commodity>(0);
            var l3 = new List<Commodity>(0);
            var l4 = new List<Commodity>(0);
            var l5 = new List<Commodity>(0);
            SortedDictionary<int, Commodity> d1 = new SortedDictionary<int, Commodity>();
            SortedDictionary<int, Commodity> d2 = new SortedDictionary<int, Commodity>();
            SortedDictionary<int, Commodity> d3 = new SortedDictionary<int, Commodity>();
            SortedDictionary<int, Commodity> d4 = new SortedDictionary<int, Commodity>();
            SortedDictionary<int, Commodity> d5 = new SortedDictionary<int, Commodity>();
            var lCommoditys = new List<Commodity>();
            SortedDictionary<int, Commodity> dCommoditys = new SortedDictionary<int, Commodity>();
            string buf, search;
            int findKey = 0,  key = 0, lenght, extraL = 0, extraD = 0, n1 = 0, n2 = 0, n3 = 0, n4 = 0, remaininglength = 0, remainingNumber = 0, number, position, el;
            bool contains = false, ok, createL = false, createD = false, sort = false; //create - проверка существования объекта
            int v;
            Console.WriteLine("Приветствуем в приложении для работы с коллекциями!");
            do
            {
                do
                {
                    Console.WriteLine("\nВыберете один из предложенных вариантов:\n\nРабота со списком (List):\n\n1)Создать список (List) состоящий из объектов иерархии класса товаров \n2)Добавить объекты в список \n3)Удалить объекты из списка \n4)Вывести все элементы списка \n5)Показать товары определенного вида \n6)Показать существует ли искомый товар и если существует, то вывести информацию о нем \n7)Вывести список всех товаров/материалов \n8)Вывести список всех магазинов/кампаний производителей \n9)Показать количество товаров определенного вида \n10)Просмотреть разницу между списком созданным с помощью коструктора, клонированным и поверхностно скопированным \n11)Выполнить сортировку списка (По цене) \n12)Поиск заданного товара (по номеру) в отсортированном списке \n13)Очистить список \n14)Хранилище списков (возможность сохранения списка) \n15)Загрузить данные из списка хранящегося в хранилище \n16)Просмотреть данные списков хранящихся в хранилище \n\nРабота с отсортированным словарем (SortedDictionary):\n\n17)Создать словарь (SortedDictionary) состоящий из объектов иерархии класса товаров \n18)Добавить объекты в словарь \n19)Удалить объекты из словаря \n20)Вывести все элементы словаря \n21)Показать товары определенного вида \n22)Показать существует ли искомый товар и если существует, то вывести информацию о нем \n23)Показать количество товаров определенного вида \n24)Просмотреть разницу между словарем созданным с помощью коструктора, клонированным и поверхностно скопированным \n25)Поиск заданного товара (по номеру) \n26)Очистить словарь \n27)Хранилище словарей (возможность сохранения словаря) \n28)Загрузить данные из словаря хранящегося в хранилище \n29)Просмотреть данные словарей хранящихся в хранилище \n\nРабота с 'TestCollections' \n\n30)Создать объект TestCollections \n31)Удалить элементы из List<Toy> \n32)Удалить элементы из List<string> \n33)Удалить элементы из SortedDictionary<Commodity, Toy> \n34)Удалить элементы из SortedDictionary<string, Toy> \n35)Добавить элементы в List<Toy> \n36)Добавить элементы в List<string> \n37)Добавить элементы в SortedDictionary<Commodity, Toy> \n38)Добавить элементы в SortedDictionary<string, Toy> \n39)Показать время поиска первого, центрального, последнего и элемента, не входящего в коллекции \n40)Выход");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out v);
                    if (!ok)
                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                    if (v < 1 || v > 40)
                        Console.WriteLine("\nВыберите один из преложенных вариантов. Выбранной вами функции не существует");
                } while (!ok || (v < 1 || v > 40));

                switch (v) //Проверить интерфейс + юнит тесты + отчет
                {
                    //Создать список (List) состоящий из объектов иерархии класса товаров
                    #region case1
                    case 1:
                        extraL = 0;
                        createL = true;
                        Console.WriteLine("\nСколько элементов должно быть в новом списке?");
                        do
                        {
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out lenght);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (lenght < 0)
                                Console.WriteLine("\nКоличество элементов не может быть отрицательным");
                        } while (!ok || lenght < 0);
                        lCommoditys = new List<Commodity>(lenght);
                        do
                        {
                            Console.WriteLine("\nСколько объектов типа 'Товары'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n1);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (lenght - n1 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || lenght - n1 < 0);
                        remainingNumber = lenght - n1;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Игрушки'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n2);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n2 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n2 < 0));
                        remainingNumber -= n2;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Продукты'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n3);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n3 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n3 < 0));
                        remainingNumber -= n3;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Молочные продукты'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n4);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n4 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n4 < 0));
                        remainingNumber -= n4;
                        for (int i = 0; i < n1; i++)
                        {
                            Commodity c = new Commodity();
                            c.Init();
                            lCommoditys.Add(c);
                        }
                        for (int i = n1; i < n1 + n2; i++)
                        {
                            Toy toy = new Toy();
                            toy.Init();
                            lCommoditys.Add(toy);
                        }
                        for (int i = n1 + n2; i < n1 + n2 + n3; i++)
                        {
                            Product product = new Product();
                            product.Init();
                            lCommoditys.Add(product);
                        }
                        for (int i = n1 + n2 + n3; i < n1 + n2 + n3 + n4; i++)
                        {
                            MilkProduct mp = new MilkProduct();
                            mp.Init();
                            lCommoditys.Add(mp);
                        }
                        for (int i = n1 + n2 + n3 + n4; i < n1 + n2 + n3 + n4 + remainingNumber; i++)
                        {
                            Commodity c = new Commodity();
                            c.Init();
                            lCommoditys.Add(c);
                            extraL++;
                        }
                        if (extraL > 0) Console.WriteLine($"Было добавлено {extraL} объектов типа товары, вместо не выбраных типов объектов");
                        break;
                    #endregion
                    //Добавить объекты в список
                    #region case2
                    case 2:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            extraL = 0;
                            Console.WriteLine("Введите сколько вы хотите добавить объектов");
                            do
                            {
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out number);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (number < 0)
                                    Console.WriteLine("\nКоличество добавляемых объектов не может быть отрицательным");
                            } while (!ok || number < 0);
                            if (number == 0) break;
                            do
                            {
                                Console.WriteLine("\nСколько объектов типа 'Товары'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n1);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (number - n1 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || number - n1 < 0);
                            remainingNumber = number - n1;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Игрушки'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n2);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n2 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n2 < 0));
                            remainingNumber -= n2;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Продукты'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n3);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n3 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n3 < 0));
                            remainingNumber -= n3;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Молочные продукты'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n4);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n4 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n4 < 0));
                            remainingNumber -= n4;
                            for (int i = 0; i < n1; i++)
                            {
                                Commodity c = new Commodity();
                                c.Init();
                                lCommoditys.Add(c);
                            }
                            for (int i = n1; i < n1 + n2; i++)
                            {
                                Toy toy = new Toy();
                                toy.Init();
                                lCommoditys.Add(toy);
                            }
                            for (int i = n1 + n2; i < n1 + n2 + n3; i++)
                            {
                                Product product = new Product();
                                product.Init();
                                lCommoditys.Add(product);
                            }
                            for (int i = n1 + n2 + n3; i < n1 + n2 + n3 + n4; i++)
                            {
                                MilkProduct mp = new MilkProduct();
                                mp.Init();
                                lCommoditys.Add(mp);
                            }
                            for (int i = n1 + n2 + n3 + n4; i < n1 + n2 + n3 + n4 + remainingNumber; i++)
                            {
                                Commodity c = new Commodity();
                                c.Init();
                                lCommoditys.Add(c);
                                extraL++;
                            }
                            if (extraL > 0) Console.WriteLine($"Было добавлено {extraL} объектов типа товары, вместо не выбраных типов объектов");
                        }
                        break;
                    #endregion
                    //Удалить объекты из списка
                    #region case3
                    case 3:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            if (lCommoditys.Count == 0)
                                Console.WriteLine("Список пуст, удалять нечего");
                            else
                            {
                                Console.WriteLine("С какой позиции вы хотите удалить элементы?");
                                do
                                {
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out position);
                                    if (!ok)
                                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                    if (position < 1)
                                        Console.WriteLine("\nПозиция для удаления не может быть меньше 1");
                                    if (position > (lCommoditys.Count))
                                        Console.WriteLine("\nПозиция для удаления не может быть больше количества элементов");
                                } while (!ok || (position < 1) || (position > (lCommoditys.Count)));
                                position--;
                                Console.WriteLine("Сколько вы хотите удалить элементов?");
                                do
                                {
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out number);
                                    if (!ok)
                                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                    if (number < 0)
                                        Console.WriteLine("\nКоличество удаляемых элементов не может быть отрицательным");
                                    if (number > lCommoditys.Count - position)
                                        Console.WriteLine("\nКоличество удаляемых элементов не может быть больше количества элементов начиная с выбранной позиции");
                                } while (!ok || number < 0 || (number > lCommoditys.Count - position));
                                lCommoditys.RemoveRange(position, number);
                            }
                        }
                        break;
                    #endregion
                    //Вывести все элементы списка
                    #region case4
                    case 4:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            if (lCommoditys.Count == 0)
                                Console.WriteLine("Список пуст");
                            else
                            {
                                foreach (var c in lCommoditys)
                                    Console.WriteLine(c);
                            }
                            break;
                        }
                    #endregion
                    //Показать товары определенного вида
                    #region case5
                    case 5:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Товары (1), продукты (2), игрушки (3) или молочные продукты(4)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 4)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 4));
                            if (v == 1)
                            {
                                foreach (Commodity c in lCommoditys)
                                {
                                    if (c is Commodity)
                                    {
                                        if (c is Product)
                                        {
                                            break;
                                        }
                                        if (c is MilkProduct)
                                        {
                                            break;
                                        }
                                        if (c is Toy)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            c.Show();
                                        }
                                    }
                                }
                            }
                            if (v == 2)
                            {
                                foreach (Commodity c in lCommoditys)
                                {
                                    if (c is Product)
                                    {
                                        if (c is MilkProduct)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            c.Show();
                                        }
                                    }
                                }
                            }
                            if (v == 3)
                            {
                                foreach (Commodity c in lCommoditys)
                                {
                                    if (c is Toy)
                                    {
                                        c.Show();
                                    }
                                }
                            }
                            if (v == 4)
                            {
                                foreach (Commodity c in lCommoditys)
                                {
                                    if (c is MilkProduct)
                                    {
                                        c.Show();
                                    }
                                }
                            }
                        }
                        break;
                    #endregion
                    //Показать существует ли искомый товар и если существует, то вывести информацию о нем
                    #region case6
                    case 6:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Игрушки (1) или молочные продукты(2)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 2)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 2));
                            if (v == 1)
                            {
                                Console.WriteLine("Введите название игрушки (ассортимент можно посмотреть в главном меню)");
                                search = Console.ReadLine();
                                contains = lCommoditys.Contains(new Toy { ToyName = search }); //Поиск элемента типа игрушка с введенным именем
                                if (contains == false)
                                {
                                    Console.WriteLine("\nИгрушка не найдена");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nНайденная игрушка:");
                                    Toy t = new ();
                                    foreach (Commodity c in lCommoditys)
                                    {
                                        t = c as Toy;
                                        if (t != null)
                                        {
                                            if (search == t.ToyName)
                                            {
                                                t.Show();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (v == 2)
                            {
                                Console.WriteLine("Введите название молочного продукта (ассортимент можно посмотреть в главном меню)");
                                search = Console.ReadLine();
                                contains = lCommoditys.Contains(new MilkProduct { MilkProductName = search }); //Поиск элемента типа игрушка с введенным именем
                                if (contains == false)
                                {
                                    Console.WriteLine("\nМолочный продукт не найден");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nНайденный молочный продукт:");
                                    MilkProduct mp;
                                    foreach (var c in lCommoditys)
                                    {
                                        mp = c as MilkProduct;
                                        if (mp != null)
                                        {
                                            if (search == mp.MilkProductName)
                                            {
                                                mp.Show();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    #endregion
                    //Вывести список всех товаров/материалов
                    #region case7
                    case 7:
                        string MilkProducts = "Молоко с 0% жирности, Молоко с 3,5% жирности, Сметана с 15% жирности, Сметана с 30% жирности, Простокваша, Масло традиционное 82%, Масло крестьянское 72%";
                        string Toys = "Широкий Фредди, Бонни и кампания, Шоколадный воин, Казак Петр, Годзилла на батарейках, Матрешка, Бидон,Наездник на свине, Наездник на медведе, Горка, Морка";
                        string Materials = "Кожа, Мех, Ткань, Кожезаменитель, Синтетика, Пластик, Дерево, Железо, Стекло, Хлопок, Кость, Керамика";
                        Console.WriteLine($"Список игрушек: {Toys} \nСписок молочных продуктов: {MilkProducts} \nСписок материалов: {Materials }");
                        break;

                    #endregion
                    //Вывести список всех магазинов/кампаний производителей
                    #region case8
                    case 8:
                        string Places = "Кунгурский молочный комбинат, Молоко, Пермский хладокомбинат Созвездие, Юговский комбинат молочных продуктов, Маслозавод Нытвенский, Ленинское, Перммолоко, Экомилк";
                        string Companys = "Детский мир, Невероятные игрушки, Сюрприз, Магика, Попрыгун, Зеленый слоник, Шоколадный заец, Матрешка, КиС, МоскИгр, GehWol, Мягкий Филл";
                        string Shops = "Магого, Детский мир, Взрослый мир, Белое черное, Желтое синее, Матрешка, Букка, Ковбой Джонн, Лалаленд, Голубая лагуна, Мастерец, GameWorkshop";
                        Console.WriteLine($"Кампании производители игрушек: {Companys} \nКампании производители молочных продуктов: {Places} \nМагазины детских игрушек: {Shops}");
                        break;

                    #endregion
                    //Показать количество товаров определенного вида
                    #region case9
                    case 9:
                        number = 0;
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Товары (1), продукты (2), игрушки (3) или молочные продукты(4)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 4)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 4));
                            if (v == 1)
                            {
                                foreach (var c in lCommoditys)
                                {
                                    if (c is Commodity)
                                    {
                                        if (c is Product)
                                        {
                                            break;
                                        }
                                        else if (c is MilkProduct)
                                        {
                                            break;
                                        }
                                        else if (c is Toy)
                                        {
                                            break;
                                        }
                                        else if (c is Commodity)
                                        {
                                            number++;
                                        }
                                    }
                                }
                                number += extraL;
                            }
                            if (v == 2)
                            {
                                foreach (var c in lCommoditys)
                                {
                                    if (c is Product)
                                    {
                                        if (c is MilkProduct)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            number++;
                                        }
                                    }
                                }
                            }
                            if (v == 3)
                            {
                                foreach (var c in lCommoditys)
                                {
                                    if (c is Toy)
                                    {
                                        number++;
                                    }
                                }
                            }
                            if (v == 4)
                            {
                                foreach (var c in lCommoditys)
                                {
                                    if (c is MilkProduct)
                                    {
                                        number++;
                                    }
                                }
                            }
                            Console.WriteLine("Количество товаров выбраного типа равно:" + number);
                        }
                        break;
                    #endregion
                    //Просмотреть разницу между списком созданным с помощью коструктора, клонированным и поверхностно скопированным
                    #region case10
                    case 10:
                        var toysList = new List<Toy>(3);
                        for (int i = 0; i < 3; i++)
                        {
                            Toy toy = new Toy();
                            toy.Init();
                            toysList.Add(toy);
                        }
                        Console.WriteLine("\nКоллекция до клонирования:");
                        foreach (Toy toy in toysList)
                        {
                            Console.WriteLine(toy);
                        }

                        var tl1 = new List<Toy>(3);
                        for (int i = 0; i < 3; i++)
                        {
                            Toy toy = new Toy(toysList[i].Price, toysList[i].Weight, toysList[i].Material, toysList[i].Company, toysList[i].ToyName, toysList[i].ShopName, toysList[i].sr.series);
                            tl1.Add(toy);
                        }

                        Toy[] tm2 = new Toy[3];
                        toysList.CopyTo(tm2);
                        var tl2 = new List<Toy>(3);
                        for (int i = 0;i < 3;i++)
                        {
                            tl2.Add(tm2[i]);
                        }

                        var tl3 = new List<Toy>(3);
                        for (int i = 0; i < 3; i++)
                        {
                            Toy t = (Toy)toysList[i].Clone();
                            tl3.Add(t);
                        }

                        var tl4 = new List<Toy>(3);
                        for (int i = 0; i < 3; i++)
                        {
                            Toy t = (Toy)toysList[i].ShallowCopy();
                            tl4.Add(t);
                        }
                        toysList[2].sr.series += 100;
                        toysList[2].ToyName = toysList[2].ToyName + " CLON";
                        Console.WriteLine("\nСписок после клонирования:");
                        Console.WriteLine("\nСписок созданный с помощью конструктора:");
                        foreach (var c in tl1)
                            Console.WriteLine(c);
                        Console.WriteLine("\nСписок созданный с помощью клонирования (Clone):");
                        foreach (var c in tl3)
                            Console.WriteLine(c);
                        Console.WriteLine("\nСписок созданный с помощью поверхностного копирования (CopyTo):");
                        foreach (var c in tl2)
                            Console.WriteLine(c);
                        Console.WriteLine("\nСписок созданный с помощью поверхностного копирования (ShallowCopy):");
                        foreach (var c in tl4)
                            Console.WriteLine(c);
                        Console.WriteLine("\nИзмененный первый оригинальный cписок:");
                        foreach (var c in toysList)
                            Console.WriteLine(c);
                        break;
                    #endregion
                    //Выполнить сортировку списка (По цене)
                    #region case11
                    case 11:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            if (sort == false)
                            {
                                sort = true;
                                lCommoditys.Sort();
                                Console.WriteLine("Список отсортирован");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Список уже отсортирован");
                                break;
                            }
                        }
                    #endregion
                    //Поиск заданного товара (по номеру) в отсортированном списке
                    #region case12
                    case 12:
                        if (createL == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            if (sort == false)
                            {
                                Console.WriteLine("Список не отсортирован, для начала отсортируйте его (пункт 11)");
                                break;
                            }
                            else
                            {
                                do
                                {
                                    Console.WriteLine("Введите номер искомого элемента в отсортированном списке");
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out number);
                                    if (!ok)
                                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                    if (number < 1)
                                        Console.WriteLine("\nНельзя выбрать позицию меньше 1");
                                    if (number > lCommoditys.Count)
                                        Console.WriteLine($"\nНельзя выбрать индекс больший количества элементов списка (всего в списке {lCommoditys.Count} элементов");
                                } while (!ok || (number < 1) || (number > lCommoditys.Count));
                                number--;
                                Commodity element = lCommoditys[number];
                                Console.WriteLine(element);
                                break;
                            }
                        }
                    #endregion
                    //Очистить список
                    #region case13
                    case 13:
                        lCommoditys.Clear();
                        Console.WriteLine("Список очищен");
                        break;
                    #endregion
                    //Хранилище списков (возможность сохранения списка)
                    #region case14
                    case 14:
                        Console.WriteLine("\nЗдесь вы можете сохранить данные текущего списка, скопировав их в один из 5 слотов памяти, чтобы позже загрузить данные оттуда в текущий список");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для сохранения данных списка");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            for (int i = 0; i < lCommoditys.Count; i++)
                            {
                                l1.Add(lCommoditys[i]);
                            }
                            l1 = lCommoditys;
                        }
                        if (el == 2)
                        {
                            l2 = lCommoditys;
                        }
                        if (el == 3)
                        {
                            l3 = lCommoditys;
                        }
                        if (el == 4)
                        {
                            l4 = lCommoditys;
                        }
                        if (el == 5)
                        {
                            l5 = lCommoditys;
                        }
                        break;
                    #endregion
                    //Загрузить данные из списка хранящегося в хранилище
                    #region case15
                    case 15:
                        Console.WriteLine("\nЗдесь вы можете выгрузить данные сохраненного списка, скопировав их в текущий список");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для выгрузки данных списка");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            lCommoditys = l1;
                        }
                        if (el == 2)
                        {
                            lCommoditys = l2;
                        }
                        if (el == 3)
                        {
                            lCommoditys = l3;
                        }
                        if (el == 4)
                        {
                            lCommoditys = l4;
                        }
                        if (el == 5)
                        {
                            lCommoditys = l5;
                        }
                        break;
                    #endregion
                    //Просмотреть данные списков хранящихся в хранилище
                    #region case16
                    case 16:
                        Console.WriteLine("\nЗдесь вы можете просмотреть данные одного из 5 слотов памяти");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для просмотра данных сохраненного списка");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            foreach (var c in l1)
                            {
                                c.Show();
                            }
                        }
                        if (el == 2)
                        {
                            foreach (var c in l2)
                            {
                                c.Show();
                            }
                        }
                        if (el == 3)
                        {
                            foreach (var c in l3)
                            {
                                c.Show();
                            }
                        }
                        if (el == 4)
                        {
                            foreach (var c in l4)
                            {
                                c.Show();
                            }
                        }
                        if (el == 5)
                        {
                            foreach (var c in l5)
                            {
                                c.Show();
                            }
                        }
                        break;
                    #endregion
                    //
                    //
                    //
                    //Создать словарь (SortedDictionary) состоящий из объектов иерархии класса товаров
                    #region case17
                    case 17:
                        extraD = 0;
                        createD = true;
                        Console.WriteLine("\nСколько элементов должно быть в новом словаре?");
                        do
                        {
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out lenght);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (lenght < 0)
                                Console.WriteLine("\nКоличество элементов не может быть отрицательным");
                        } while (!ok || lenght < 0);
                        dCommoditys = new SortedDictionary<int, Commodity>(); //Ключ - шестизначный ID товара
                        do
                        {
                            Console.WriteLine("\nСколько объектов типа 'Товары'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n1);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (lenght - n1 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || lenght - n1 < 0);
                        remainingNumber = lenght - n1;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Игрушки'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n2);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n2 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n2 < 0));
                        remainingNumber -= n2;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Продукты'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n3);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n3 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n3 < 0));
                        remainingNumber -= n3;
                        do
                        {
                            if (remainingNumber == 0) break;
                            Console.WriteLine("\nСколько товаров типа 'Молочные продукты'?");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out n4);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (remainingNumber - n4 < 0)
                                Console.WriteLine("Превышено количество добавляемых объектов");
                        } while (!ok || (remainingNumber - n4 < 0));
                        remainingNumber -= n4;
                        for (int i = 0; i < n1; i++)
                        {
                            Commodity c = new Commodity();
                            c.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!dCommoditys.ContainsKey(key))
                                {
                                    dCommoditys.Add(key, c);
                                    contains = true;
                                }
                            } while (contains == false);
                        }
                        for (int i = n1; i < n1 + n2; i++)
                        {
                            Toy toy = new Toy();
                            toy.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!dCommoditys.ContainsKey(key))
                                {
                                    dCommoditys.Add(key, toy);
                                    contains = true;
                                }
                            } while (contains == false);
                        }
                        for (int i = n1 + n2; i < n1 + n2 + n3; i++)
                        {
                            Product product = new Product();
                            product.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!dCommoditys.ContainsKey(key))
                                {
                                    dCommoditys.Add(key, product);
                                    contains = true;
                                }
                            } while (contains == false);
                        }
                        for (int i = n1 + n2 + n3; i < n1 + n2 + n3 + n4; i++)
                        {
                            MilkProduct mp = new MilkProduct();
                            mp.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!dCommoditys.ContainsKey(key))
                                {
                                    dCommoditys.Add(key, mp);
                                    contains = true;
                                }
                            } while (contains == false);
                        }
                        for (int i = n1 + n2 + n3 + n4; i < n1 + n2 + n3 + n4 + remainingNumber; i++)
                        {
                            Commodity c = new Commodity();
                            c.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!dCommoditys.ContainsKey(key))
                                {
                                    dCommoditys.Add(key, c);
                                    contains = true;
                                }
                            } while (contains == false);
                            extraD++;
                        }
                        if (extraD > 0) Console.WriteLine($"Было добавлено {extraD} объектов типа товары, вместо не выбраных типов объектов");
                        break;
                    #endregion
                    //Добавить объекты в словарь
                    #region case18
                    case 18:
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            extraD = 0;
                            Console.WriteLine("Введите сколько вы хотите добавить объектов");
                            do
                            {
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out number);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (number < 0)
                                    Console.WriteLine("\nКоличество добавляемых объектов не может быть отрицательным");
                            } while (!ok || number < 0);
                            if (number == 0) break;
                            do
                            {
                                Console.WriteLine("\nСколько объектов типа 'Товары'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n1);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (number - n1 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || number - n1 < 0);
                            remainingNumber = number - n1;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Игрушки'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n2);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n2 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n2 < 0));
                            remainingNumber -= n2;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Продукты'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n3);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n3 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n3 < 0));
                            remainingNumber -= n3;
                            do
                            {
                                if (remainingNumber == 0) break;
                                Console.WriteLine("\nСколько товаров типа 'Молочные продукты'?");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out n4);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (remainingNumber - n4 < 0)
                                    Console.WriteLine("Превышено количество добавляемых объектов");
                            } while (!ok || (remainingNumber - n4 < 0));
                            remainingNumber -= n4;
                            for (int i = 0; i < n1; i++)
                            {
                                Commodity c = new Commodity();
                                c.Init();
                                do
                                {
                                    key = rnd.Next(100000, 999999);
                                    if (!dCommoditys.ContainsKey(key))
                                    {
                                        dCommoditys.Add(key, c);
                                        contains = true;
                                    }
                                } while (contains == false);
                            }
                            for (int i = n1; i < n1 + n2; i++)
                            {
                                Toy toy = new Toy();
                                toy.Init();
                                do
                                {
                                    key = rnd.Next(100000, 999999);
                                    if (!dCommoditys.ContainsKey(key))
                                    {
                                        dCommoditys.Add(key, toy);
                                        contains = true;
                                    }
                                } while (contains == false);
                            }
                            for (int i = n1 + n2; i < n1 + n2 + n3; i++)
                            {
                                Product product = new Product();
                                product.Init();
                                do
                                {
                                    key = rnd.Next(100000, 999999);
                                    if (!dCommoditys.ContainsKey(key))
                                    {
                                        dCommoditys.Add(key, product);
                                        contains = true;
                                    }
                                } while (contains == false);
                            }
                            for (int i = n1 + n2 + n3; i < n1 + n2 + n3 + n4; i++)
                            {
                                MilkProduct mp = new MilkProduct();
                                mp.Init();
                                do
                                {
                                    key = rnd.Next(100000, 999999);
                                    if (!dCommoditys.ContainsKey(key))
                                    {
                                        dCommoditys.Add(key, mp);
                                        contains = true;
                                    }
                                } while (contains == false);
                            }
                            for (int i = n1 + n2 + n3 + n4; i < n1 + n2 + n3 + n4 + remainingNumber; i++)
                            {
                                Commodity c = new Commodity();
                                c.Init();
                                do
                                {
                                    key = rnd.Next(100000, 999999);
                                    if (!dCommoditys.ContainsKey(key))
                                    {
                                        dCommoditys.Add(key, c);
                                        contains = true;
                                    }
                                } while (contains == false);
                                extraD++;
                            }
                            if (extraD > 0) Console.WriteLine($"Было добавлено {extraD} объектов типа товары, вместо не выбраных типов объектов");
                        }
                        break;
                    #endregion
                    //Удалить объекты из словаря
                    #region case19
                    case 19:
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            if (dCommoditys.Count == 0)
                                Console.WriteLine("Словарь пуст, удалять нечего");
                            else
                            {
                                Console.WriteLine("С какой позиции вы хотите удалить элементы?");
                                do
                                {
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out position);
                                    if (!ok)
                                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                    if (position < 1)
                                        Console.WriteLine("\nПозиция для удаления не может быть меньше 1");
                                    if (position > dCommoditys.Count)
                                        Console.WriteLine("\nПозиция для удаления не может быть больше количества элементов");
                                } while (!ok || (position < 1) || (position > dCommoditys.Count));
                                position--;
                                Console.WriteLine("Сколько вы хотите удалить элементов?");
                                do
                                {
                                    buf = Console.ReadLine();
                                    ok = Int32.TryParse(buf, out number);
                                    if (!ok)
                                        Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                    if (number < 0)
                                        Console.WriteLine("\nКоличество удаляемых элементов не может быть отрицательным");
                                    if (number > dCommoditys.Count - position)
                                        Console.WriteLine("\nКоличество удаляемых элементов не может быть больше количества элементов начиная с выбранной позиции");
                                } while (!ok || number < 0 || (number > dCommoditys.Count - position));
                                int removeKey = 0;
                                for (int i = 0; i < number; i++)
                                {
                                    removeKey = dCommoditys.Keys.ElementAt(position);
                                    dCommoditys.Remove(removeKey);
                                }
                            }
                        }
                        break;
                    #endregion
                    //Вывести все элементы словаря
                    #region case20
                    case 20:
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            if (dCommoditys.Count == 0)
                                Console.WriteLine("Словарь пуст");
                            else
                            {

                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                            break;
                        }
                    #endregion
                    //Показать товары определенного вида (Товары не видит)
                    #region case21
                    case 21:
                        if (createD == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Товары (1), продукты (2), игрушки (3) или молочные продукты(4)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 4)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 4));
                            if (v == 1)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys) //Присваивает pair значение ключа и значения
                                {
                                    if (pair.Value is Commodity)
                                    {
                                        if (pair.Value is Product)
                                        {
                                            break;
                                        }
                                        if (pair.Value is MilkProduct)
                                        {
                                            break;
                                        }
                                        if (pair.Value is Toy)
                                        {
                                            break;
                                        }
                                        else if (pair.Value is Commodity)
                                        {
                                            Console.WriteLine("ID товара: " + pair.Key);
                                            pair.Value.Show();
                                        }
                                    }
                                }
                            }
                            if (v == 2)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is Product)
                                    {
                                        if (pair.Value is MilkProduct)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ID продукта: " + pair.Key);
                                            pair.Value.Show();
                                        }
                                    }
                                }
                            }
                            if (v == 3)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is Toy)
                                    {
                                        Console.WriteLine("ID игрушки: " + pair.Key);
                                        pair.Value.Show();
                                    }
                                }
                            }
                            if (v == 4)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is MilkProduct)
                                    {
                                        Console.WriteLine("ID молочного продукта: " + pair.Key);
                                        pair.Value.Show();
                                    }
                                }
                            }
                        }
                        break;
                    #endregion
                    //Показать существует ли искомый товар и если существует, то вывести информацию о нем
                    #region case22
                    case 22:
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Игрушки (1) или молочные продукты(2)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 2)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 2));
                            if (v == 1)
                            {
                                Console.WriteLine("Введите название игрушки (ассортимент можно посмотреть в главном меню)");
                                search = Console.ReadLine();
                                contains = dCommoditys.ContainsValue(new Toy { ToyName = search }); //Поиск элемента типа игрушка с введенным именем
                                if (contains == false)
                                {
                                    Console.WriteLine("\nИгрушка не найдена");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nНайденная игрушка:");
                                    Toy t = new();
                                    foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                    {
                                        t = pair.Value as Toy;
                                        if (t != null)
                                        {
                                            if (search == t.ToyName)
                                            {
                                                Console.WriteLine("ID найденной игрушки: " + pair.Key);
                                                t.Show();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (v == 2)
                            {
                                Console.WriteLine("Введите название молочного продукта (ассортимент можно посмотреть в главном меню)");
                                search = Console.ReadLine();
                                contains = dCommoditys.ContainsValue(new MilkProduct { MilkProductName = search }); //Поиск элемента типа игрушка с введенным именем
                                if (contains == false)
                                {
                                    Console.WriteLine("\nМолочный продукт не найден");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nНайденный молочный продукт:");
                                    MilkProduct mp;
                                    foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                    {
                                        mp = pair.Value as MilkProduct;
                                        if (mp != null)
                                        {
                                            if (search == mp.MilkProductName)
                                            {
                                                Console.WriteLine("ID найденного молочного продукта: " + pair.Key);
                                                mp.Show();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    #endregion
                    //Показать количество товаров определенного вида (Товары не видит)
                    #region case23
                    case 23:
                        number = 0;
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Что вы хотите найти? Товары (1), продукты (2), игрушки (3) или молочные продукты(4)");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out v);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (v < 1 || v > 4)
                                    Console.WriteLine("\nВыберите один из преложенных вариантов");
                            } while (!ok || (v < 1 || v > 4));
                            if (v == 1)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is Commodity)
                                    {
                                        if (pair.Value is Product)
                                        {
                                            break;
                                        }
                                        else if (pair.Value is MilkProduct)
                                        {
                                            break;
                                        }
                                        else if (pair.Value is Toy)
                                        {
                                            break;
                                        }
                                        else if (pair.Value is Commodity)
                                        {
                                            number++;
                                        }
                                    }
                                }
                                number += extraL;
                            }
                            if (v == 2)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is Product)
                                    {
                                        if (pair.Value is MilkProduct)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            number++;
                                        }
                                    }
                                }
                            }
                            if (v == 3)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is Toy)
                                    {
                                        number++;
                                    }
                                }
                            }
                            if (v == 4)
                            {
                                foreach (KeyValuePair<int, Commodity> pair in dCommoditys)
                                {
                                    if (pair.Value is MilkProduct)
                                    {
                                        number++;
                                    }
                                }
                            }
                            Console.WriteLine("Количество товаров выбраного типа равно: " + number);
                        }
                        break;
                    #endregion
                    //Просмотреть разницу между словарем созданным с помощью коструктора, клонированным и поверхностно скопированным
                    #region case24
                    case 24:
                        SortedDictionary<int, Toy>  toysDictionary = new SortedDictionary<int, Toy>();
                        for (int i = 0; i < 3; i++)
                        {
                            Toy toy = new Toy();
                            toy.Init();
                            do
                            {
                                key = rnd.Next(100000, 999999);
                                if (!toysDictionary.ContainsKey(key))
                                {
                                    toysDictionary.Add(key, toy);
                                    contains = true;
                                }
                            } while (contains == false);
                        }
                        Console.WriteLine("\nКоллекция до клонирования:");
                        foreach (KeyValuePair<int, Toy> pair in toysDictionary) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID игрушки: {0} \nХарактеристики игрушки:\n {1}", pair.Key, pair.Value);
                        }

                        SortedDictionary<int, Toy> td1 = new SortedDictionary<int, Toy>();
                        for (int i = 0; i < 3; i++)
                        {
                            findKey = toysDictionary.Keys.ElementAt(i);
                            Toy toy = new Toy(toysDictionary[findKey].Price, toysDictionary[findKey].Weight, toysDictionary[findKey].Material, toysDictionary[findKey].Company, toysDictionary[findKey].ToyName, toysDictionary[findKey].ShopName, toysDictionary[findKey].sr.series);
                            td1.Add(findKey, toy);
                        }

                        KeyValuePair<int, Toy>[] tmd2 = new KeyValuePair<int, Toy>[3];
                        toysDictionary.CopyTo(tmd2, 0);
                        SortedDictionary<int, Toy> td2 = new SortedDictionary<int, Toy>();
                        for (int i = 0; i < 3; i++)
                        {
                            td2.Add(tmd2[i].Key, tmd2[i].Value);
                        }

                        SortedDictionary<int, Toy> td3 = new SortedDictionary<int, Toy>();
                        for (int i = 0; i < 3; i++)
                        {
                            findKey = toysDictionary.Keys.ElementAt(i);
                            Toy t = (Toy)toysDictionary[findKey].Clone();
                            td3.Add(findKey, t);
                        }

                        SortedDictionary<int, Toy> td4 = new SortedDictionary<int, Toy>();
                        for (int i = 0; i < 3; i++)
                        {
                            findKey = toysDictionary.Keys.ElementAt(i);
                            Toy t = (Toy)toysDictionary[findKey].ShallowCopy();
                            td4.Add(findKey, t);
                        }
                        findKey = toysDictionary.Keys.ElementAt(2);
                        toysDictionary[findKey].sr.series += 100;
                        toysDictionary[findKey].ToyName = toysDictionary[findKey].ToyName + " CLON";
                        Console.WriteLine("\nСловарь после клонирования:");
                        Console.WriteLine("\nСловарь созданный с помощью конструктора:");
                        foreach (KeyValuePair<int, Toy> pair in td1) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                        }
                        Console.WriteLine("\nСловарь созданный с помощью клонирования (Clone):");
                        foreach (KeyValuePair<int, Toy> pair in td3) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                        }
                        Console.WriteLine("\nСловарь созданный с помощью поверхностного копирования (CopyTo):");
                        foreach (KeyValuePair<int, Toy> pair in td2) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                        }
                        Console.WriteLine("\nСловарь созданный с помощью поверхностного копирования (ShallowCopy):");
                        foreach (KeyValuePair<int, Toy> pair in td4) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                        }
                        Console.WriteLine("\nИзмененный первый оригинальный словарь:");
                        foreach (KeyValuePair<int, Toy> pair in toysDictionary) //Присваивает pair значение ключа и значения
                        {
                            Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                        }
                        break;
                    #endregion
                    //Поиск заданного товара (по номеру)
                    #region case25
                    case 25:
                        if (createD == false)
                        {
                            Console.WriteLine("Словарь еще не создан");
                            break;
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Введите номер искомого элемента");
                                buf = Console.ReadLine();
                                ok = Int32.TryParse(buf, out number);
                                if (!ok)
                                    Console.WriteLine("\nВведено не целое число. Повторите попытку");
                                if (number < 1)
                                    Console.WriteLine("\nНельзя выбрать позицию меньше 1");
                                if (number > dCommoditys.Count)
                                    Console.WriteLine($"\nНельзя выбрать индекс больший количества элементов словаря (всего в словаре {dCommoditys.Count} элементов");
                            } while (!ok || (number < 1) || (number > dCommoditys.Count));
                            number--;
                            findKey = dCommoditys.Keys.ElementAt(number);
                            Commodity element = dCommoditys[findKey];
                            Console.WriteLine("ID товара: " + findKey);
                            Console.WriteLine(element);
                            break;
                        }
                    #endregion
                    //Очистить словарь
                    #region case26
                    case 26:
                        if (createD == false)
                        {
                            Console.WriteLine("Список еще не создан");
                            break;
                        }
                        else
                        {

                            dCommoditys.Clear();
                            Console.WriteLine("Список очищен");
                        }
                        break;
                    #endregion
                    //Хранилище словарей (возможность сохранения словаря)
                    #region case27
                    case 27:
                        Console.WriteLine("\nЗдесь вы можете сохранить данные текущего словаря, скопировав их в один из 5 слотов памяти, чтобы позже загрузить данные оттуда в текущий словарь");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для сохранения данных словаря");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            for (int i = 0; i < dCommoditys.Count; i++)
                            {
                                findKey = dCommoditys.Keys.ElementAt(i);
                                d1.Add(findKey, dCommoditys[findKey]);
                            }
                        }
                        if (el == 2)
                        {
                            for (int i = 0; i < dCommoditys.Count; i++)
                            {
                                findKey = dCommoditys.Keys.ElementAt(i);
                                d2.Add(findKey, dCommoditys[findKey]);
                            }
                        }
                        if (el == 3)
                        {
                            for (int i = 0; i < dCommoditys.Count; i++)
                            {
                                findKey = dCommoditys.Keys.ElementAt(i);
                                d3.Add(findKey, dCommoditys[findKey]);
                            }
                        }
                        if (el == 4)
                        {
                            for (int i = 0; i < dCommoditys.Count; i++)
                            {
                                findKey = dCommoditys.Keys.ElementAt(i);
                                d4.Add(findKey, dCommoditys[findKey]);
                            }
                        }
                        if (el == 5)
                        {
                            for (int i = 0; i < dCommoditys.Count; i++)
                            {
                                findKey = dCommoditys.Keys.ElementAt(i);
                                d5.Add(findKey, dCommoditys[findKey]);
                            }
                        }
                        break;
                    #endregion
                    //Загрузить данные из словаря хранящегося в хранилище
                    #region case28
                    case 28:
                        Console.WriteLine("\nЗдесь вы можете выгрузить данные сохраненного словаря, скопировав их в текущий словарь");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для выгрузки данных словаря");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            dCommoditys.Clear();
                            for (int i = 0; i < d1.Count; i++)
                            {
                                findKey = d1.Keys.ElementAt(i);
                                dCommoditys.Add(findKey, d1[findKey]);
                            }
                        }
                        if (el == 2)
                        {
                            dCommoditys.Clear();
                            for (int i = 0; i < d2.Count; i++)
                            {
                                findKey = d2.Keys.ElementAt(i);
                                dCommoditys.Add(findKey, d2[findKey]);
                            }
                        }
                        if (el == 3)
                        {
                            dCommoditys.Clear();
                            for (int i = 0; i < d3.Count; i++)
                            {
                                findKey = d3.Keys.ElementAt(i);
                                dCommoditys.Add(findKey, d3[findKey]);
                            }
                        }
                        if (el == 4)
                        {
                            dCommoditys.Clear();
                            for (int i = 0; i < d4.Count; i++)
                            {
                                findKey = d4.Keys.ElementAt(i);
                                dCommoditys.Add(findKey, d4[findKey]);
                            }
                        }
                        if (el == 5)
                        {
                            dCommoditys.Clear();
                            for (int i = 0; i < d5.Count; i++)
                            {
                                findKey = d5.Keys.ElementAt(i);
                                dCommoditys.Add(findKey, d5[findKey]);
                            }
                        }
                        break;
                    #endregion
                    //Просмотреть данные словарей хранящихся в хранилище
                    #region case29
                    case 29:
                        Console.WriteLine("\nЗдесь вы можете просмотреть данные одного из 5 слотов памяти");
                        do
                        {
                            Console.WriteLine("Выберите ячейку для просмотра данных сохраненного словаря");
                            buf = Console.ReadLine();
                            ok = Int32.TryParse(buf, out el);
                            if (!ok)
                                Console.WriteLine("\nВведено не целое число. Повторите попытку");
                            if (el < 1 || el > 5)
                                Console.WriteLine("\nВыберите одну из пяти ячеек");
                        } while (!ok || (el < 1 || el > 5));
                        if (el == 1)
                        {
                            if (d1.Count == 0) Console.WriteLine("\nЯчейка пустая");
                            else
                            {
                                foreach (KeyValuePair<int, Commodity> pair in d1) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                        }
                        if (el == 2)
                        {
                            if (d2.Count == 0) Console.WriteLine("\nЯчейка пустая");
                            else
                            {
                                foreach (KeyValuePair<int, Commodity> pair in d2) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                        }
                        if (el == 3)
                        {
                            if (d3.Count == 0) Console.WriteLine("\nЯчейка пустая");
                            else
                            {
                                foreach (KeyValuePair<int, Commodity> pair in d3) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                        }
                        if (el == 4)
                        {
                            if (d4.Count == 0) Console.WriteLine("\nЯчейка пустая");
                            else
                            {
                                foreach (KeyValuePair<int, Commodity> pair in d4) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                        }
                        if (el == 5)
                        {
                            if (d5.Count == 0) Console.WriteLine("\nЯчейка пустая");
                            else
                            {
                                foreach (KeyValuePair<int, Commodity> pair in d5) //Присваивает pair значение ключа и значения
                                {
                                    Console.WriteLine("ID товара: {0} \nХарактеристики товара:\n {1}", pair.Key, pair.Value);
                                }
                            }
                        }
                        break;
                    #endregion
                    //Создать объект TestCollections
                    #region case30 
                    case 30:
                        break;
                    #endregion
                    //Удалить элементы из List<Toy>
                    #region case31
                    case 31:
                        break;
                    #endregion
                    //Удалить элементы из List<string>
                    #region case32
                    case 32:
                        break;
                    #endregion
                    //Удалить элементы из SortedDictionary<Commodity, Toy>
                    #region case33
                    case 33:
                        break;
                    #endregion
                    //Удалить элементы из SortedDictionary<string, Toy>
                    #region case34
                    case 34:
                        break;
                    #endregion
                    //Добавить элементы в List<Toy>
                    #region case35
                    case 35:
                        break;
                    #endregion
                    //Добавить элементы в List<string>
                    #region case36
                    case 36:
                        break;
                    #endregion
                    //Добавить элементы в SortedDictionary<Commodity, Toy>
                    #region case37
                    case 37:
                        break;
                    #endregion
                    //Добавить элементы в SortedDictionary<string, Toy>
                    #region case38
                    case 38:
                        break;
                    #endregion
                    //Показать время поиска первого, центрального, последнего и элемента, не входящего в коллекции
                    #region case39
                    case 39:
                        break;
                    #endregion
                    //Выход
                    #region case40
                    case 40: Console.WriteLine("\nДо свидания!"); break;
                    #endregion
                }
            } while (v != 40);
        }
    }
}

