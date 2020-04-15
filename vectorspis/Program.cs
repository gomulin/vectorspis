using System;
using System.Collections;
using System.Collections.Generic;

namespace vectorspis
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new MyListT<int>();
            int[] a = new int[10];


            Console.WriteLine();
            t.Add(2);
            t.Add(3);
            t.Add(4);
            t.Add(5);
            t.Add(6);
            t.Add(7);
            for (int i = 0; i < t.count; i++)
            {
                Console.Write(t[i] + "  ");
            }

            t.Insert(4, 1);

            Console.WriteLine(t.Pop());

            t.RemoveAt(2);

            for (int j = 0; j < t.count; j++)
            {
                Console.Write(t[j] + "  ");
            }

            Console.WriteLine("\n");

            foreach (var q in t)                            //через нумеротор //с# кастом форич
            {
                //Console.Write(i + " ");

                Console.WriteLine($"Element: {q}");


            }
            //Console.ReadKey();
        }
    }

    class MyListT<T> : IEnumerable
    {
        private T[] data;
        public int count;
        public MyListT()
        {
            data = new T[0];

        }
        public void Add(T x)                                 //Добавление элемнта в конец
        {
            Array.Resize(ref data, count + 1);
            data[count] = x;
            ++count;
        }
        public T Top()                                      //Смотрит верхний элемент
        {
            if (count > 0)
            {
                return data[count - 1];
            }
            else
            {
                return default(T);
            }
        }

        public T Pop()                                      //Извлекает первый/последний? элемент 
        {
            if (count > 0)
            {
                var t = Top();
                Array.Resize(ref data, count - 1);
                count--;
                return t;
            }
            else
            {
                throw new System.InvalidOperationException("xex");
            }
        }

        public void Insert(int index, T x)                  //Добавление элемента по индексу со сдвигом вправо 
        {
            Array.Resize(ref data, count + 1);
            if (index >= count)
            {
                Add(x);
            }
            else
            {
                for (int i = count; i > index; i--)
                {
                    data[i] = data[i - 1];
                }
                data[index] = x;
                count++;
            }
        }


        public void RemoveAt(int index)                     //Удаление элемента по индексу со сдвигом влево
        {
            if (count > 0)
            {
                for (int i = index; i < count - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                Array.Resize(ref data, --count);


            }

        }


        public T this[int key]
        {
            get
            {
                return data[key];
            }
            set
            {
                data[key] = value;
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }




        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            Array.Resize(ref data, 0);
            count = 0;
        }
    }
 }

