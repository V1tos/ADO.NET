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

            #region Linq

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

            var sortArr1 = values1.OrderByDescending(x=>x);
            var sortArr2 = values2.OrderByDescending(x=>x);

            foreach (var item in sortArr2)
            {
                Console.WriteLine(item);
            }

            foreach (var item in sortArr1)
            {
                Console.WriteLine(item);
            }

            #endregion

        }
    }
}
