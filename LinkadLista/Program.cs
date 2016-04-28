using System;

namespace LinkadLista
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LinkadLista list = new LinkadLista();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list.ToString());
        }
    }
}
