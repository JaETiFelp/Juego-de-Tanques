using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Proy_Grafica
{
    public class Punto
    {
        public const int Size = 3;

        private Vector3 pos;
        public Vector3 Position
        {
            get { return pos; }
            set { pos = value; }
        }

        public Punto(Vector3 position)
        {
            this.pos = position;
        }

        public Punto(float x, float y, float z) : 
            this(new Vector3(x, y, z)) { 
         
        }
        public void SetPxPyPz(float px, float py, float pz) {
            pos.X = px;
            pos.Y = py;
            pos.Z = pz;
        }

        public static float[] Process(Punto[] vertices)
        {
            int count = 0;

            float[] data = new float[vertices.Length * Size];
            for (int i = 0; i < vertices.Length; i++)
            {
               
                data[count] = vertices[i].Position.X;
                data[count + 1] = vertices[i].Position.Y;
                data[count + 2] = vertices[i].pos.Z;

                count += 3;
            }

            return data;
        }

    }

    //=====================================
    public class PuntoXYZ
    {
        private float X;
        private float Y;
        private float Z;

        public PuntoXYZ() { 
        }
        public PuntoXYZ(float x,float y,float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void setX(float x) {
            this.X = x;
        }
        public void setY(float y)
        {
            this.Y = y;
        }
        public void setZ(float z)
        {
            this.Z = z;
        }
        public float GetX(){
            return this.X;
        }
        public float GetY()
        {
            return this.Y;
        }
        public float GetZ()
        {
            return this.Z;
        }



    }


}


 //public Point ()
 //       {
 //           x=y=0;
 //       }
 //       public Point (int x,int y)
 //       {
 //           this.x = x;
 //           this.y = y;
 //       }
 //       internal int x,y;