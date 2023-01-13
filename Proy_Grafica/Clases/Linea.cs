using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OpenTK;
//using System.Windows.Shapes;

using OpenTK.Graphics.OpenGL;

namespace Proy_Grafica.Clases
{
    public class Linea
    {
        private Punto p1;
        private Punto p2;



       private Punto[] puntosV = new Punto[2];      
        private int VboId;
        private int Ssize;
        public Linea() {
            p1 = new Punto(0,0,0);
            p2 = new Punto(0,0,0);
        }
        public  void inicializar(){
            cargarPuntos(p1, p2);
            VboId = GL.GenBuffer();
            Ssize = puntosV.Length;
            float[] data = Punto.Process(puntosV);


            GL.BindBuffer(BufferTarget.ArrayBuffer, VboId);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        public Linea(Punto a, Punto b) {
            this.p1 = a;
            this.p2 = b;          

        }
        public void SetP1(Punto a){
            p1 = a;
        }
        public void SetP2(Punto b)
        {
            p2 = b;
        }
        public Punto GetP1()
        { 
            return p1;
        }
        public Punto GetP2()
        {
            return p2;
        }
        public void cargarPuntos(Punto a, Punto b) {
            puntosV[0] = a;
            puntosV[1] = b;           
            
        }
        public void Draw() {

            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VboId);
            GL.VertexAttribPointer(0, Punto.Size, VertexAttribPointerType.Float, false, Punto.Size * 4, 0);
            GL.DrawArrays(PrimitiveType.Lines, 0, Ssize);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DisableVertexAttribArray(0);     


        }

        public static Punto[] ProcessLinea(Linea[] vertices)
        {
            int count = 0;

            Punto[] data = new Punto[vertices.Length * 2];
            for (int i = 0; i < vertices.Length; i++)
            {

                data[count] = vertices[i].GetP1();
                data[count + 1] = vertices[i].GetP2();
                //data[count]   = vertices[i].p1.Position.X;
                //data[count+1] = vertices[i].p1.Position.Y;
                //data[count+2] = vertices[i].p1.Position.Z;

                //data[count+3] = vertices[i].p2.Position.X;
                //data[count+4] = vertices[i].p2.Position.Y;
                //data[count+5] = vertices[i].p2.Position.Z;
                count += 2;
            }

            return data;
        }
    }//end class
}
