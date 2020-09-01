using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1___LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LinqToSql


          
            
            
            
            //            5. Вибрати всі книги, ім'я в яких складається менше ніж з 10-ти символів
            //            6. Вибрати книгу з максимальною кількістю сторінок не американського автор
            //            7. Вибрати автора, який має найменше книг в базі даних
            //            8. Вибрати імена всіх авторів, крім американських, розташованих в алфавітном порядку
            //            9. Вибрати країну, авторів якої є найбільше в базі

            Console.OutputEncoding = Encoding.UTF8;

            //string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            BooksDBClassesDataContext context = new BooksDBClassesDataContext();

            //            1.Вибрати всі книги, кількість сторінок в яких більше 100
            //var books = context.Books.Where(x => x.Pages > 100);

            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //            2. Вибрати всі книги, ім'я яких починається на літеру 'А' або 'а

            //var books = context.Books.Where(x => x.Name.StartsWith("C") || x.Name.StartsWith("c"));

            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //            3. Вибрати всі книги автора William Shakespeare

            //var books = context.Books.Where(x => x.Author.Name == "R.S.Martin");

            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //            4. Вибрати всі книги українських авторів

            //var books = context.Books.Where(x => x.Author. == "R.S.Martin");

            //foreach (var item in books)
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion

            #region LinqArrays

            int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
            int[] values2 = new int[5] { 19, 1, 4, 9, 8 };

            //1) Посчитать среднее значение четных элементов, которые больше 10.

            //var avgEvenElements1 = (from obj in values1
            //                       where obj > 1 && obj %2 == 0
            //                       select obj).Average();

            //var avgEvenElements2 = (from obj in values2
            //                        where obj > 1 && obj % 2 == 0
            //                        select obj).Average();

            //Console.WriteLine(avgEvenElements1);
            //Console.WriteLine(avgEvenElements2);


            //2) Выбрать только уникальные элементы из массивов values1 и values2.

            //var uniqueElements1 = values1.Except(values2);
            //var uniqueElements2 = values2.Except(values1);

            //foreach (var item in uniqueElements1)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in uniqueElements2)
            //{
            //    Console.WriteLine(item);
            //}


            //3) Найти максимальный элемент массива values2, который есть в массиве values1.

            //var maxElement = (from obj in values1
            //                  join obj2 in values2 on obj equals obj2
            //                  select obj).Max();

            //Console.WriteLine(maxElement);

            //4) Посчитать сумму элементов массивов values1 и values2, которые попадают
            //    в диапазон от 5 до 15.

            //var sumElements1 = (from obj in values1
            //                    where obj > 5 && obj < 15
            //                    select obj).Sum();

            //var sumElements2 = (from obj in values2
            //                    where obj > 5 && obj < 15
            //                    select obj).Sum();

            //Console.WriteLine(sumElements1 + sumElements2);

            //5) Отсортировать элементы массивов values1 и values2 по убыванию.

            //var sortArr1 = values1.OrderByDescending(x=>x);
            //var sortArr2 = values2.OrderByDescending(x=>x);

            //foreach (var item in sortArr2)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in sortArr1)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region LinqGoodsList
            List<Good> goods1 = new List<Good>()
            {
            new Good()
            { Id = 1, Title = "Nokia 1100", Price = 700, Category = "Mobile" },
            new Good()
            { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good()
            { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good()
            { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good()
            { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            };

            List<Good> goods2 = new List<Good>()
            {
            new Good()
            { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good()
            { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good()
            { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good()
            { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good()
            { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };

            //1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.

            //var goodsMobile = goods1.Concat(goods2).Where(x => x.Category == "Mobile" && x.Price > 1000);

            //ShowGoods(goods1);


            //2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen,
            //    цена которых превышает 1000 грн.

            //var goodsNotMobile = goods1.Concat(goods2).Where(x => x.Category != "Mobile" && x.Price > 1000);

            //ShowGoods(goodsNotMobile);

            //3) Вывести название товара и его категорию, который имеет максимальную цену.

            //var maxPriceGood = goods1.Concat(goods2).Where(x => x.Price == goods1.Max(y => y.Price));

            //ShowGoods(maxPriceGood);

            //4) Вычислить среднее значение всех цен товаров.

            //var avgPrice = goods1.Concat(goods2).Average(x => x.Price);

            //Console.WriteLine($"Average price of all goods - {avgPrice}");

            //5) Вывести список категорий без повторений.

            //var distinctCategory = goods1.Concat(goods2).Select(x => x.Category).Distinct();

            //foreach (var item in distinctCategory)
            //{
            //    Console.WriteLine(item);
            //}

            //6) Вывести названия тех товаров, цены которых совпадают.

            //var samePrices = goods1.Select(x => x.Price).Intersect(goods2.Select(x => x.Price));

            //foreach (var item in samePrices)
            //{
            //    Console.WriteLine(item);
            //}

            //var samePriceGoods = goods1.Where(x=>x.Price == samePrices.FirstOrDefault(y=>y==x.Price)).Distinct().
            //                     Concat(goods2.Where(x=>x.Price == samePrices.FirstOrDefault(y => y == x.Price)).Distinct()).Where(x=>x.Price>0);


            //ShowGoods(samePriceGoods);

            //7) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по
            //    названию.

            //var SortGoods = goods1.Concat(goods2).OrderBy(x => x.Title);

            //ShowGoods(SortGoods);

            //8) Проверить, содержит ли категория Car товары, с ценой от 1000 до 2000 грн.

            //var hasProduct = goods1.Concat(goods2).Where(x => x.Category == "Car" && x.Price >1000 & x.Price<2000);

            //ShowGoods(hasProduct);

            //9) Посчитать суммарное количество товаров категорий Сar и Mobile.

            //var productCount = goods1.Concat(goods2).Where(x => x.Category == "Car" || x.Category == "Mobile").Count();

            //Console.WriteLine(productCount);

            //10) Вывести список категорий и количество товаров каждой категории.

            //var groupProduct = goods1.Concat(goods2).GroupBy(x => x.Category);

            //foreach (var item in groupProduct)
            //{
            //    Console.WriteLine($"{item.Key} - {item.Count()} ");
            //}


            #endregion

        }

        private static void ShowGoods(IEnumerable<Good> goods)
        {
            foreach (var item in goods)
            {
                Console.WriteLine($"{item.Title} - {item.Price} - {item.Category}");
            }
        }

        public class Good
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            public string Category { get; set; }
        }
    }
}
