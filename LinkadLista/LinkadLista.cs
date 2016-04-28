using System;

namespace LinkadLista
{
    class LinkadLista
    {
        Nod root;

        public LinkadLista()
        {

        }

        public void Add(int value)
        {
            if(root == null)
            {
                root = new Nod(value);
            }
            else
            {
                RecAdd(root, value);
            }
        }

        private void RecAdd(Nod nod, int value)
        {
            if(nod.Next != null)
            {
                RecAdd(nod.Next, value);
            }
            else
            {
                nod.Next = new Nod(value);
            }
        }

        public override String ToString()
        {
            String s = "";

            if(root != null)
            {
                s += String.Format( "{0} , ", root.Value);
                RecPrint(root, ref s);
            }

            return s;
        }

        private void RecPrint(Nod nod, ref String s)
        {
            if(nod.Next != null)
            {
                s += String.Format("{0} , ", nod.Next.Value);
                RecPrint(nod.Next, ref s);
            }
        }
    }

    class Nod
    {
        public int Value{ get; private set;}
        public Nod Next{get; set;}

        public Nod(int val)
        {
            Value = val;
        }

    }
}

