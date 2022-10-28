using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_BookStoreMenu
{
     class Progrann
    {
        enum Publisher
        {
            Buka,
            Yandex,
            YashaLoveA,
            IP_Grishin
        }

        static List<Book> Store = new List<Book>();
        struct Book
        {
            public string Name;
            public int Number;
            public string author;
            public Publisher publisher;
            public DateTime publishDate;
            public int pages;
        }

        //Добавить в список

        static void AddToList(ref int count)
        {
            Book N = new Book();
            Console.WriteLine("Введите название");
            N.Name = N.Name + count /*Console.ReadLine()*/;
            Console.WriteLine("Введите автора");
            N.author = Console.ReadLine();
            Console.WriteLine("Введите количесвто страниц");
            try { N.pages = Convert.ToInt16(Console.ReadLine()); }
            catch { N.pages = 0; }
            Console.Clear();
            bool i = true;
            while (i)
            {
                Console.WriteLine("Выберите издателя:\n 1.Бука \n 2.Яндекс \n 3.YashaLoveA \n 4. ИП Гришин \n");         //Выбор жанра игры
                int decision = Convert.ToInt16(Console.ReadKey().KeyChar);
                switch (decision)

                {
                    case 49:
                        {
                            N.publisher = Publisher.Buka;
                            i = false;
                            break;
                        }
                    case 50:
                        {
                            N.publisher = Publisher.Yandex;
                            i = false;
                            break;
                        }
                    case 51:
                        {
                            N.publisher = Publisher.YashaLoveA;
                            i = false;
                            break;
                        }
                    case 52:
                        {
                            N.publisher = Publisher.IP_Grishin;
                            i = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Неверный выбор\n");
                                         N.publisher = Publisher.IP_Grishin;
                                         i = false;
                            break;
                        }
                }
            }
            Console.Clear();

            Console.WriteLine("Введите дату публикации");
                try { N.publishDate = Convert.ToDateTime(Console.ReadLine());}
                catch {N.publishDate = DateTime.UtcNow; }

            Console.WriteLine("Инвентарный номер - {0}", count);
            N.Number = count++;
            Store.Add(N);
            Console.WriteLine("Книга занесена:\n\n");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Название: " + Store[count - 1].Name);
            Console.WriteLine("Автор: " + Store[count - 1].author);
            Console.WriteLine("Количество страниц: " + Store[count - 1].pages);
            Console.WriteLine("Издатель: " + Store[count - 1].publisher);
            Console.WriteLine("Дата публикации: " + Store[count - 1].publishDate);
            Console.WriteLine("Инвентарный номер: " + (count - 1));
            Console.WriteLine("--------------------------------------------------\n\n");
        }

        //Удалнеи записи

        static void NoteDel(int RangeStart, int RangeEnd, ref int CountM, ref bool flag)
        {
            Console.Clear();

            if (RangeEnd == 0)
            {
                Store.RemoveAt(RangeStart);
                Console.WriteLine("Книга с названием {0}, хранившееся под номером {1} успешно удалена", Store[RangeStart].Name, RangeStart);
                --CountM;
                flag = false;
                return;
            } 
 
            else
            {
                for (int i = 0; i < (RangeEnd - RangeStart) + 1; i++)
                {
                    Store.RemoveAt(RangeStart);
                    --CountM;
                    flag = false;
                }
                return;
            }
        }

        //Показать список

        static void ShowList(ref int CountM)
        {
            Console.WriteLine("Список книг:\n\n");
            for (int i = 0; i < CountM; i++ )
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Название: " + Store[i].Name);
                Console.WriteLine("Автор: " + Store[i].author);
                Console.WriteLine("Количество страниц: " + Store[i].pages);
                Console.WriteLine("Издатель: " + Store[i].publisher);
                Console.WriteLine("Дата публикации: " + Store[i].publishDate);
                Console.WriteLine("Инвентарный номер: " + i);
                Console.WriteLine("--------------------------------------------------");
                //Console.WriteLine("\n\n");

            }
            Console.WriteLine("Для удаления записи введите ее инвентарный номер. Для возвращения в главное меню, нажмите M");

            string CurrentNum = "0";
            string StartNum = "0";
            string EndNum = "0";

            bool flag = true;
            bool Trigger = true;

            while (flag)
            {
                string PressedKey = Convert.ToString(Console.ReadKey().KeyChar);

                if (Int32.TryParse(PressedKey, out var parsed))
                {
                    CurrentNum = CurrentNum + parsed;
                }
                else if (PressedKey == "\r")
                {
                    if (Trigger)
                    {
                        StartNum = CurrentNum;
                        NoteDel(Convert.ToInt32(StartNum), Convert.ToInt32(EndNum), ref CountM, ref flag);
                    }
                    else
                    { 
                        EndNum = CurrentNum;
                    NoteDel(Convert.ToInt32(StartNum), Convert.ToInt32(EndNum), ref CountM, ref flag);
                    }
                }
                else if (PressedKey == "-")
                {
                    if (Trigger)
                    {
                        StartNum = CurrentNum;
                        CurrentNum = "0";
                        Trigger = false;
                    }
                    else
                    {
                        EndNum = CurrentNum;
                        NoteDel(Convert.ToInt32(StartNum), Convert.ToInt32(EndNum), ref CountM, ref flag);
                    }
                }
                else
                {
                    Console.Clear();
                    flag = false;
                }
            }
        }

        //Поиск по издателю

        static void SearchPublisher(int Count)
        {
            Publisher des = new Publisher();
            Console.WriteLine("Выберите издателя:\n 1.Бука \n 2.Яндекс \n 3.YashaLoveA \n 4.ИП Гришин \n");          //Выбор издателя для поиска
            int decision = Convert.ToInt16(Console.ReadKey().KeyChar);
            Console.Clear();
            switch (decision)
            {
                case 49:
                    {
                        des = Publisher.Buka;
                        break;
                    }
                case 50:
                    {
                        des = Publisher.Yandex;
                        break;
                    }
                case 51:
                    {
                        des = Publisher.YashaLoveA;
                        break;
                    }
                case 52:
                    {
                        des = Publisher.IP_Grishin;
                        break;
                    }
            }
            int Flag = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Store[i].publisher == des)                //Вывод жанра 
                {
                    Console.WriteLine("Книга издаетльства {0}", des);

                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Название: " + Store[i].Name);
                    Console.WriteLine("Автор: " + Store[i].author);
                    Console.WriteLine("Количество страниц: " + Store[i].pages);
                    Console.WriteLine("Издатель: " + Store[i].publisher);
                    Console.WriteLine("Дата публикации: " + Store[i].publishDate);
                    Console.WriteLine("Инвентарный номер: " + i);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("\n\n");
                    Flag++;
                }
            }
            if (Flag == 0)
            {
                Console.WriteLine("Книг {0} в списке нет", des);
                Console.WriteLine("\n\n");
            }
        }



        static void Main(string[] args)
        {
            int decision;        //Кнопки меню
            int countM = 0;      //Счетчик инвентарного номера 

            while (true)
            {
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Удалить запись");
                Console.WriteLine("3. Поиск по издательству");
                Console.WriteLine("4. Средний возраст всех книг");

                Console.WriteLine("\nВыберите необходиму операцию");
                decision = Convert.ToInt16(Console.ReadKey().KeyChar);
                Console.Clear();
                //Console.WriteLine(Convert.ToString(decision));
                switch (decision)
                {
                    case 49:
                        {
                            Console.Clear();
                            AddToList(ref countM);
                            break;
                        }
                    case 50:
                        {
                            Console.Clear();
                            ShowList(ref countM);
                            break;
                        }
                    case 51:
                        {
                            Console.Clear();
                            SearchPublisher(countM);
                            break;
                        }
                    case 52:
                        {
                            Console.Clear();
                            AddToList(ref countM);
                            break;
                        }
                    default:
                        {
                            //Console.Clear();
                            //Console.WriteLine("Неверный выбор\n");
                            //break;
                            Console.Clear();
                            AddToList(ref countM);
                            break;
                        }
                }
            }





            Console.ReadKey();
        }
    }
}
