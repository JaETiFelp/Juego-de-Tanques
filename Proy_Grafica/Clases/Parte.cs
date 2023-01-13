using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Proy_Grafica.Clases
{
    public class Parte
    {
        private List<Poligono> Polyg;
        private Punto PuntoRef_Part;
        private int cantParte ;
        private string nombre;

        public Parte() {
            this.Polyg = new List<Poligono>(); 
            this.PuntoRef_Part = new Punto(0,0,0);
            cantParte = 0;
                                    
        }
        public void generarPartes(){
            if (nombre != null)
            {
                Polyg.ElementAt(cantParte).InicializarPolyg();
                Console.WriteLine("canparte " + cantParte);
            }

            //for (int i = 0; i < cant;i++ ){
            //    Console.WriteLine("cant partes" + i+" canp "+cantParte);
            //    Polyg.ElementAt(i).InicializarPolyg();
                
            //}
        }
        public Parte(List<Poligono> p,Punto pr) {
            this.Polyg = p;
            this.PuntoRef_Part = pr;
        
        }


        public Parte(Parte p) {
            this.Polyg = p.Polyg;
            this.PuntoRef_Part = p.PuntoRef_Part;            
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public void setPuntoRef(Punto p) {
            this.PuntoRef_Part = p;
        }
        public Punto GetPuntoRef() {
            return PuntoRef_Part;
        }
        public void AddPolygon(string nomb, Poligono l1) {
            if (nombre != null&& !(Polyg.Contains(l1)))
            {
                
                Polyg.Add(l1);
                cantParte++;

            }
            for (int i = 0; i < cantParte;i++ )
            {
                Console.WriteLine("   dibujandoParte: " + i + "  name: " + Nombre);
                Polyg.ElementAt(i).InicializarPolyg();
                
            }

        }
        public Poligono getPoligono(int i) {
            return Polyg.ElementAt(i);
        }
        public int GetSizeParte() {
            return Polyg.Count;
        }
        public void removeParte(int index){
        
        }
       //====================


        //==========dibujar===
        public void draw2() { 
        foreach(var item in Polyg){
            item.DrawPoligono2();
        }
        }
        public void draw( ) {
            
            foreach(var item in Polyg){
                item.DrawPoligono();
            }
            
            //for (int i = 0; i <= cantParte; i++)
            //{
            //    Polyg.ElementAt(i).DrawPoligono(gw);
            
            //}
            //Polyg.ElementAt(sizeParte).DrawPoligono();
       //     Console.WriteLine("TamParte"+sizeParte+" i "+c);
            

        }




    }//end clas
}
