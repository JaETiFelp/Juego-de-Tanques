using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using Proy_Grafica.Clases;
namespace Proy_Grafica
{
   
    class Malla
    {   
        
        private Objeto objectMalla;
        private Vector3 Cm;
        int indiceat = 0;
        float ang = 0f;
        
       // tankEnemigoGenerator t;
        public Malla()
        {
            Cm = new Vector3(0, 0, 0);
            //objload1 = new ObjLoader();
            //escenario = new EscenarioObj();
            objectMalla = new Objeto();
            inicializar();
            
        }
        
        
        public void dibujar() {
            //______  
                                GL.Color4(1,0.1,0,0);
                                //Objetos x = new Objetos();
                                //Objetos y = new Objetos();

                                ////foreach(){}
                                //x = escenario.getObjeto(0);// saca Malla 3D            
                                //y = escenario.getObjeto(1);// saca Laberinto
                                //x.Draw();          
            
                                //GL.Color4(0.5, 1, 0.2, 0);//azul0, 0.2, 1, 0.5
                                //y.Draw2();
                                //ang += 0.1f;            
            objectMalla.Draw();
            

            //___ dibujar ObjLoader _____ 
            //objload1.objectLoader_Draw();
           // objectLoader_Draw(cubeVertices,cubeColors,cubeIndices);             
            
            //____________________________________________
            //float x = 0, y = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    stars.Add(new Punto(x, y, 0));
            //}

            //GL.Color3(0.0f, 1.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //foreach (var item in stars)
            //{
            //    GL.Vertex3(item.Position.X, item.Position.Y, item.Position.Z);
            //}
            //GL.End();


            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(0f, 0f, 0);
            GL.Vertex3(1f, 0f, 0);
            GL.Vertex3(2f, 0f, 0);

            GL.Color3(0.0f, 1.0f, .0f);
            GL.Vertex3(0f, 1f, 0);
            GL.Vertex3(0f, 2f, 0);

            GL.Color3(.0f, 0.0f, 1.0f);
            GL.Vertex3(0f, 0f, 1f);
            GL.Vertex3(0f, 0f, 2);
            GL.End();
        
        }


        private void inicializar()
        {
            //_______________ M A L L A ______________
            Linea l1 = new Linea();
            l1.SetP1(new Punto(0.0f, 0.0f, 0.0f));
            l1.SetP2(new Punto(1.0f, 0.0f, 0.0f));
            //li.inicializar();             
            Linea l2 = new Linea();
            l2.SetP1(new Punto(1.0f, 0.0f, 0.0f));
            l2.SetP2(new Punto(1.0f, 1.0f, 0.0f));

            Linea l3 = new Linea();
            l3.SetP1(new Punto(1.0f, 1.0f, 0.0f));
            l3.SetP2(new Punto(0.0f, 1.0f, 0.0f));

            Linea l4 = new Linea();
            l4.SetP1(new Punto(0.0f, 1.0f, 0.0f));
            l4.SetP2(new Punto(0.0f, 0.0f, 0.0f));


            Poligono poli = new Poligono();
            //poli.setPuntoRef( new Punto(-0f,0f,-10f) );
            //poli.puntoRef = new Punto(-0f,0f,-10f);
            poli.AddLinea(l1);
            poli.AddLinea(l2);
            poli.AddLinea(l3);
            poli.AddLinea(l4);

            //_____________
            Parte part = new Parte();
            part.Nombre = "south";
            part.AddPolygon(part.Nombre, poli);

            //____________cabeza_______
            Linea lc1 = new Linea();
            lc1.SetP1(new Punto(0.0f, 0.0f, 0.0f));
            lc1.SetP2(new Punto(1f, 0f, 0.0f));

            Linea lc2 = new Linea();
            lc2.SetP1(new Punto(1f, 0f, 0.0f));
            lc2.SetP2(new Punto(1f, 0f, 1.0f));

            Linea lc3 = new Linea();
            lc3.SetP1(new Punto(1f, 0f, 1.0f));
            lc3.SetP2(new Punto(0f, 0f, 1.0f));

            Linea lc4 = new Linea();
            lc4.SetP1(new Punto(0f, 0f, 1.0f));
            lc4.SetP2(new Punto(0.0f, 0.0f, 0.0f));

            Poligono poli2 = new Poligono();
            //setPuntoRef(new Punto(-0f, 0f, -10f));
            poli2.AddLinea(lc1);
            poli2.AddLinea(lc2);
            poli2.AddLinea(lc3);
            poli2.AddLinea(lc4);

            Parte part2 = new Parte();
            part2.Nombre = "buttom";
            //part2.setPuntoRef(new Punto(10, 0, 0));
            part2.AddPolygon(part2.Nombre, poli2);

            //____________pierna derecho_______
            Linea li_pd1 = new Linea();
            li_pd1.SetP1(new Punto(1.0f, 0.0f, 0.0f));
            li_pd1.SetP2(new Punto(1f, 00f, 1f));

            Linea li_pd2 = new Linea();
            li_pd2.SetP1(new Punto(1f, 00f, 1f));
            li_pd2.SetP2(new Punto(1f, 1f, 1f));

            Linea li_pd3 = new Linea();
            li_pd3.SetP1(new Punto(1f, 1f, 1f));
            li_pd3.SetP2(new Punto(1.0f, 1.0f, 0f));
            Linea li_pd4 = new Linea();
            li_pd4.SetP1(new Punto(1.0f, 1.0f, 0f));
            li_pd4.SetP2(new Punto(1.0f, 0f, 0f));

            Poligono poli3 = new Poligono();
            //setPuntoRef(new Punto(-0f, 0f, -10f));
            poli3.AddLinea(li_pd1);
            poli3.AddLinea(li_pd2);
            poli3.AddLinea(li_pd3);
            poli3.AddLinea(li_pd4);


            Parte part3 = new Parte();
            part3.Nombre = "east";
            //part3.setPuntoRef(new Punto(10, 0, 0));
            part3.AddPolygon(part3.Nombre, poli3);

            //____________pierna izquierda_______
            Linea li_pIz1 = new Linea();
            li_pIz1.SetP1(new Punto(1f, 1.0f, 0.0f));
            li_pIz1.SetP2(new Punto(1f, 1f, 1f));
            Linea li_pIz2 = new Linea();
            li_pIz2.SetP1(new Punto(1f, 1f, 1f));
            li_pIz2.SetP2(new Punto(0.0f, 1.0f, 1.0f));

            Linea li_pIz3 = new Linea();
            li_pIz3.SetP1(new Punto(0.0f, 1.0f, 1.0f));
            li_pIz3.SetP2(new Punto(0f, 1.0f, 0f));
            Linea li_pIz4 = new Linea();
            li_pIz4.SetP1(new Punto(0f, 1.0f, 0f));
            li_pIz4.SetP2(new Punto(1f, 1.0f, 0f));

            Poligono poli4 = new Poligono();
            //poli4.puntoRef = new Punto(-0f, 0f, -10f);            
            poli4.AddLinea(li_pIz1);
            poli4.AddLinea(li_pIz2);
            poli4.AddLinea(li_pIz3);
            poli4.AddLinea(li_pIz4);

            Parte part4 = new Parte();
            part4.Nombre = "top";
            // part4.setPuntoRef(new Punto(10, 0, 0));
            part4.AddPolygon(part4.Nombre, poli4);


            //____________brazo izquierda_______
            Linea li_brIz1 = new Linea();
            li_brIz1.SetP1(new Punto(0f, 0.0f, 0.0f));
            li_brIz1.SetP2(new Punto(0f, 0f, 1.0f));

            Linea li_brIz2 = new Linea();
            li_brIz2.SetP1(new Punto(0f, 0f, 1.0f));
            li_brIz2.SetP2(new Punto(0f, 1f, 1.0f));

            Linea li_brIz3 = new Linea();
            li_brIz3.SetP1(new Punto(0f, 1f, 1.0f));
            li_brIz3.SetP2(new Punto(0f, 1.0f, 0.0f));

            Linea li_brIz4 = new Linea();
            li_brIz4.SetP1(new Punto(0f, 1.0f, 0.0f));
            li_brIz4.SetP2(new Punto(0f, 0.0f, 0.0f));

            Poligono poli5 = new Poligono();
            //poli5.puntoRef = new Punto(-0f, 0f, -10f);            
            poli5.AddLinea(li_brIz1);
            poli5.AddLinea(li_brIz2);
            poli5.AddLinea(li_brIz3);
            poli5.AddLinea(li_brIz4);

            Parte part5 = new Parte();
            part5.Nombre = "west";
            // part5.setPuntoRef(new Punto(10, 0, 0));
            part5.AddPolygon(part5.Nombre, poli5);

            //____________brazo Derecho_______
            Linea li_brDer1 = new Linea();
            li_brDer1.SetP1(new Punto(0f, 0.0f, 1.0f));
            li_brDer1.SetP2(new Punto(1f, 0f, 1.0f));
            Linea li_brDer2 = new Linea();
            li_brDer2.SetP1(new Punto(1f, 0f, 1.0f));
            li_brDer2.SetP2(new Punto(1f, 1f, 1.0f));

            Linea li_brDer3 = new Linea();
            li_brDer3.SetP1(new Punto(1f, 1f, 1.0f));
            li_brDer3.SetP2(new Punto(0f, 1.0f, 1.0f));
            Linea li_brDer4 = new Linea();
            li_brDer4.SetP1(new Punto(0f, 1.0f, 1.0f));
            li_brDer4.SetP2(new Punto(0f, 0.0f, 1.0f));

            Poligono poli6 = new Poligono();
            //poli6.puntoRef = new Punto(-10f, 0f, -0f);

            poli6.AddLinea(li_brDer1);
            poli6.AddLinea(li_brDer2);
            poli6.AddLinea(li_brDer3);
            poli6.AddLinea(li_brDer4);

            Parte part6 = new Parte();
            part6.Nombre = "north";
            //part6.setPuntoRef(new Punto(10, 0, 0));
            part6.AddPolygon(part6.Nombre, poli6);

            //________ ObJeto1 malla _
//            Objetos object1 = new Objetos();
            objectMalla.Nombre = "malla";
            //objec.setPuntoRef(new Punto(10,0,0));
            objectMalla.puntoreff = new Punto(10, 0, 0);

            objectMalla.AddPart(part);
            objectMalla.AddPart(part2);
            objectMalla.AddPart(part3);
            objectMalla.AddPart(part4);
            objectMalla.AddPart(part5);
            objectMalla.AddPart(part6);

            
            //escenario.CentroEscenario = new Punto(0, 0, 0);
            //escenario.addObjeto(objectMalla);


            
            
            
        }
        //public void cargar_Tank() {
        //    //________________________________

        //    //    System.IO.StreamReader sr = new System.IO.StreamReader(@".\Model\cow.txt");
        //    //    Console.WriteLine(obj1.ToString());

        //    objload1 = objload1.LoadFromFile(@".\Model\3dtankmaterial.obj");//tank34.obj
        //    objload1.Position += new Vector3(0.07f, 0f, 0.07f);
        //    objects.Add(objload1);
        //    foreach (var item in objects)
        //    {
        //        item.cargarObjectLoader_TofloatArray();
        //    }


        //    //Console.WriteLine("count obj1 " + objload1.VertCount);
        //    //objload1.cargarObjectLoader_TofloatArray();
        //    //cargarObjectLoader_TofloatArray();
            
        //}
        

        


    }//end class


    /*
     
     
            //south
            //GL.Color3(1.0f, 0.0f, 0.0f);            
            //GL.Begin(PrimitiveType.LineLoop);
            // GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 0);
            // GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 0);
            // GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 0);                      
            // GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 0);            
            //GL.End();
            

            ////buttom
            ////GL.Color3(1.0f, 0.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 1);
            //GL.End();

            ////east
            ////GL.Color3(1.0f, 0.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 0);
            //GL.End();

            ////top
            ////GL.Color3(1.0f, 0.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 1);
            //GL.End();

            ////west
            ////GL.Color3(1.0f, 0.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 0);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 0);
            //GL.End();

            ////north
            ////GL.Color3(1.0f, 1.0f, 0.0f);
            //GL.Begin(PrimitiveType.LineLoop);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 0, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 0, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 1, Cm.Y + 1, Cm.Z + 1);
            //GL.Vertex3(Cm.X + 0, Cm.Y + 1, Cm.Z + 1);
            //GL.End();

     */



    static class tankEnemigoGenerator
    {
        static Random r = new Random();
        static List<ObjLoader> lisTankEnemigo = new List<ObjLoader>();

        public static void GeneratetankEnemigos(int cantidad, bool borrar)
        {
            if (borrar == true)
                lisTankEnemigo.Clear();
            for (int i = 0; i < cantidad; i++)
            {
                ObjLoader newobj = new ObjLoader();
                lisTankEnemigo.Add(newobj);
            }

        }

        public static bool CheckCollision(Vector3 pNtank, float radio)
        {
            foreach (var item in lisTankEnemigo)
            {
                Vector3 ptankEnemigo = item.Position;
                if (Math.Pow(Math.Pow(ptankEnemigo.X - pNtank.X, 2) + Math.Pow(ptankEnemigo.Y - pNtank.Y, 2) + Math.Pow(ptankEnemigo.Z - pNtank.Z, 2), 1 / 3f) < radio)
                {
                    if (item.chocado == false)
                    {
                        item.chocado = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void DrawtankEnemigos()
        {
            foreach (var item in lisTankEnemigo)
            {
                item.Draw();
            }
        }
    }



}
