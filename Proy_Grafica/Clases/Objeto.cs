using OpenTK;
using Proy_Grafica.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Proy_Grafica
{
    public class Objeto
    {
        //private Dictionary <int ,Parte> partes;
        private List<Parte> partes;
        private Punto p_ref_Obj;
        private string nombre;

        //modelview
        Matrix4d translation = Matrix4d.Identity;
        Matrix4d rotation = Matrix4d.Identity;
        Matrix4d scale = Matrix4d.Identity;

        public Objeto(){
            //partes= new Dictionary<int,Parte>();
            partes = new List<Parte>();
            p_ref_Obj=new Punto(0,0,0);
           
        }
        public string Nombre { 
            get{return nombre;}
            set{ nombre = value;}
        }
        public int GetSizeObjeto()
        {
            return partes.Count;
        }
        //public void setPuntoRef(Punto p) {
        //    p_ref_Obj = p;
        //}
        //public Punto getPuntoRef(Punto p)
        //{
        //    return p_ref_Obj;
        //}
        public Punto puntoreff
        {
            get { return p_ref_Obj; }
            set { p_ref_Obj = value; }
        }
        //public void AddPart(int indice,Parte p) {
        //    //if (nombre!=null&&!(partes.ContainsValue(p)))
        //    //    partes.Add(indice, p);

        //}
        public void AddPart( Parte p)
        {
           
            partes.Add(p);            

        }
        
        
        //public Parte GetParte(int indice){
          
        //        return partes.ElementAt(indice).Value;
        //}
        public Parte GetParte(int indice){
          
                return partes.ElementAt(indice);
        }
        //public Dictionary<int,Parte> hasPartes {
        //    get { return partes; }
        //    set { partes = value; }
        //}
        public List<Parte> ppartes
        {
            get { return partes; }
            set { partes = value; }
        }
        public void Draw() { 
            
            foreach (var item in partes)
            {
                item.draw();
            }
            //Console.WriteLine("rotacion_rotacion____________ "+rotation.ToString());    
         
        }
        public void Draw2() { 
            foreach(var item in partes){
                item.draw2();
            }
        }
        //_____________transformaciones
        public void rotar(float angulo, Punto eje, Punto pRef)
        {

        }



    }//end class
}
