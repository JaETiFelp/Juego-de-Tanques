using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_Grafica
{
    class Mando
    {                          //[0arriba, 1abajo, 2rotarDer, 3rotarIzq]
        public int[] valoresTeclado = { 0, 0, 0, 0, 0, 0 };
        
        public int Arriba { 
            set { valoresTeclado[0]= value ;}
            get { return valoresTeclado[0]; }
        }
        public int Abajo
        {
            set { valoresTeclado[1] = value; }
            get { return valoresTeclado[1]; }
        }        
        public void todoNull() { 
            for (int i=0;i<valoresTeclado.Count();i++){
                valoresTeclado[i] = 0;
                }
        
        }
        
    }
}
