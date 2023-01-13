using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_Grafica
{
    class Planificador
    {
        public int[] valoresTeclado = { 0, 0, 0, 0 };
        public int adelante { 
             get { return valoresTeclado[0]; } 

            set { valoresTeclado[0]=value; } 
        }
        public int atraz
        {
            get { return valoresTeclado[1]; }

            set { valoresTeclado[1] = value; }
        }
    }
}
