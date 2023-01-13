using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_Grafica.Clases
{
    public class ColaCircular<T>
    {
        public T[] cola;
        private bool[] estados;
        public int size;
        public ColaCircular(int size)
        {
            this.size = size;
            cola = new T[size];
            estados = new bool[size];
        }
        public void AddItem(int index, T item, bool estado)
        {
            cola[index] = item;
            estados[index] = estado;
        }
        public T GetItem(int index)
        {
            return cola[index];
        }
        public bool GetEstado(int index)
        {
            return estados[index];
        }
        public void SetEstado(int index, bool estado)
        {
            estados[index] = estado;
        }
        public int NextPosition(int i)
        {
            if (i == size - 1)
            {
                return 0;
            }
            return i++;
        }
    }
}
