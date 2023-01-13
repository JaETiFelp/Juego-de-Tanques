using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Proy_Grafica.Clases
{
    public class EscenarioObj
    {
        private List<Objeto> listaObjetos;
        private Punto centroEsc;
        public EscenarioObj() {
            listaObjetos = new List<Objeto>();
            centroEsc = new Punto(0,0,0);
        }
        public EscenarioObj(Punto pcentro) {
            listaObjetos = new List<Objeto>();
            centroEsc = pcentro;
        }
        //public void setCentroEsc(Punto p) {
        //    centroEsc = p;
        //}
        //public Punto getCentrEsc(){
        //    return centroEsc;
        //}
        public Punto CentroEscenario {
            get { return centroEsc; }
            set { centroEsc = value; }
        }
        public List<Objeto> listObjetos {
            get { return listaObjetos; }
            set { listaObjetos = value; }
        }
        public void addObjeto(Objeto ob) {
            listaObjetos.Add(ob);
        }
        public Objeto getObjeto(int index) { 
        return listaObjetos[index];
        }
        public List<Objeto> listaObjetoss {
            get { return listaObjetos; }
            set { listaObjetos = value; }
        }
        public void removeObjeto(int index) {
            listaObjetos.RemoveAt(index);
        }
        public void Draw() {
            for (int i = 0; i < listaObjetos.Count; i++)
            {
                Objeto o = listaObjetos[i];
                o.Draw();
            }
        }
        public void Draw2() {
            for (int i = 0;i<listaObjetos.Count ;i++ ) { 
            Objeto o= listaObjetos[i];
            o.Draw2();

            }
        }

        public void rotarObjetoIndex(int indice, float x, float y, float z) {
          //  listaObjetos.ElementAt(1).rotar();
        }

        public void guardarEscenario() {

           
        }
        public void recuperar() { }

    }//end Class
}
