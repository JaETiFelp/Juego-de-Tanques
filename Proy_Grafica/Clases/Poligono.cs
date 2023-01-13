using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using OpenTK.Graphics.OpenGL;
using OpenTK;
namespace Proy_Grafica.Clases
{
    public enum Tipo_polyg { Abierto,Cerrado}
    public class Poligono{
        private List<Linea> lineas;         
        private Punto pRef;

        public Tipo_polyg tipo;
        private int CantLines;
        
        
        
        private float AnguloRot; //para rotacion
        private float rx, ry, rz ;//pa la sgte crear un vector3

        private int vboID;
        private int ssize;

        
        Matrix4 traslacion = Matrix4.Identity;
        Matrix4 rotation = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90.0f));
        Matrix4 scale = Matrix4.CreateScale(0.5f, 0.5f, 0.5f);
       
        Matrix4 transform = Matrix4.Identity;
        public Punto[] vertices;//=new Punto[4];
        public Punto[] getvert() { return vertices; }
        public Poligono() {
            this.lineas = new List<Linea>();
            this.pRef = new Punto(0, 0, 0);
            this.tipo = Tipo_polyg.Cerrado;
            CantLines = 0;
            AnguloRot = 0.0f;
            rx = 0; ry = 0; rz = 0;
            //AnguloRot = 0.0f;// r.Next(90);
           // vertices = new Punto[0];
            
              
            
        }

        

        public void InicializarPolyg() {
            
            llenarVertices(lineas);
            vboID = GL.GenBuffer();
            ssize = vertices.Length;//size = vertices.Length;

            
          // Punto[] data_P = Linea.ProcessLinea(vertices);
            float[] data = Punto.Process(vertices);
            
            //for (int i = 0;i<data.Length ; i++){
            
            //    Console.WriteLine("___data en string -> " + data[i]);
            //}

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public Poligono(List<Linea> LLin,Punto pr,Tipo_polyg tip) {
            this.lineas = LLin;
            this.pRef = pr;
            this.tipo = tip;
            

        }

        public Poligono(Poligono p) {
            
            this.lineas = p.lineas;
            this.pRef = p.pRef;
            this.tipo = p.tipo;   
        }

        
        public Punto puntoRef
        {
            get { return pRef; }
            set { pRef = value; }
        }


        public void AddLinea(Linea l1) {
            
            lineas.Add(l1);
        }
        public int getSize() {
            return lineas.Count;
        }
        public void removee() {
        for(int i=0;i<lineas.Count;i++){
            lineas.RemoveAt(i);
        }
        }

        public Linea GetLineaOfPolygon(int indice) {
            
             return lineas.ElementAt(indice);
        }
        public List<Linea> listaLineas {
            get { return lineas; }
            set { lineas = value; }
        }
        public void trasladar(float tx, float ty, float tz)
        {
            

            float x = puntoRef.Position.X + tx;
            float y = puntoRef.Position.Y + ty;
            float z = puntoRef.Position.Z + tz;
            puntoRef.SetPxPyPz(x,y,z);
        }
        public void rotar(float _x, float _y, float _z ,float ang) {
            float x = puntoRef.Position.X + (_x-puntoRef.Position.X )  * (float)( Math.Cos(ang)) - (_y - puntoRef.Position.Y)* (float)( Math.Sin(ang));
            float y = puntoRef.Position.X + (_x - puntoRef.Position.X) * (float)(Math.Sin(ang))  + (_y - puntoRef.Position.Y) * (float)(Math.Cos(ang));
            //float z = puntoRef.Position.Z + tz;
            
            GL.PushMatrix();
            rx = x;
            ry = y;
            
            
            GL.LoadIdentity();
            transform = rotation * scale;
            GL.LoadMatrix(ref transform);

            //GL.Rotate(ang,_x,_y,_z);
            GameWindow g = new GameWindow();
            //this.DrawPoligono(g);
            ang += 1.0f;
            GL.PopMatrix();
        }
        private void llenarVertices(List<Linea> lis){
            CantLines = lis.Count;
            vertices = new Punto[CantLines * 2];
            
            int c=0;
            
            for (int i = 0; i< CantLines;i++ ){
                vertices[c]     =lis.ElementAt(i).GetP1();//p11;
                //Console.WriteLine("x" + lis.ElementAt(i).GetP1().Position.X + "y" + lis.ElementAt(i).GetP1().Position.Y + "z" + lis.ElementAt(i).GetP1().Position.Z);
                vertices[c+1] = lis.ElementAt(i).GetP2();//p22;

                Console.WriteLine(i+"___p1[ " + vertices[c].Position.X +
                                ";"      + vertices[c].Position.Y + ";"
                                         + vertices[c].Position.Z + 

                              " ]  p2[ " + vertices[c + 1].Position.X 
                                   + ";" + vertices[c + 1].Position.Y + 
                                     ";" + vertices[c + 1].Position.Z + " ]");
                c += 2;
                

            }
        
        }
        public void DrawPoligono( ) {
           GL.PushMatrix();           
          
            //GL.Translate(0.0, 0.0, -10.0);
           GL.Translate(pRef.Position.X,pRef.Position.Y,pRef.Position.Z);
          //GL.Rotate(AnguloRot, 0, 1, 0);
          //transform = rotation * scale;  
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.VertexAttribPointer(0, Punto.Size, VertexAttribPointerType.Float, false, Punto.Size * 4, 0);
            //GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, 0);
            //GL.Color3(0.0,1.0,0.0);
            GL.DrawArrays(PrimitiveType.Lines, 0, ssize);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);
           
            AnguloRot += 1.0f;
            GL.PopMatrix();
         
        }
        public void DrawPoligono2()
        {
            GL.PushMatrix();

            //GL.Translate(0.0, 0.0, -10.0);
            GL.Translate(pRef.Position.X, pRef.Position.Y, pRef.Position.Z);
            //GL.Rotate(AnguloRot, 0, 1, 0);
            //transform = rotation * scale;      



            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.VertexAttribPointer(0, Punto.Size, VertexAttribPointerType.Float, false, Punto.Size * 4, 0);
            //GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, 0);
            //GL.Color3(0.0,1.0,0.0);
            GL.DrawArrays(PrimitiveType.Polygon, 0, ssize);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);

            AnguloRot += 1.0f;
            GL.PopMatrix();

        }
        

    }//end class
}
