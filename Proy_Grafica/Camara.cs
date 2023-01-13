using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Proy_Grafica
{
    class Camara
    {   private Vector3  position= new Vector3(0,0,30);
        private Vector3 direccion;
        private Vector3 up= Vector3.UnitY;
        private Matrix4 view;

        //public Camara()
        //{

        //    direccion = Vector3.Zero - position;
        //    direccion.Normalize();

            
        //}
        //public Camara(Vector3 pos,Vector3 objetiv, Vector3 arriba) { 
        //}
        //public void seleccionarCamara(int camaraInt) {
        //    GL.MatrixMode(MatrixMode.Modelview);
        //    GL.LoadIdentity();
        //    switch(camaraInt){
               
            
        //    }

        //}

        public void SeleccionarCamara(int camara) {

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            
            switch (camara) {
                case 0: {
                        position =  new Vector3(0f,2f,4f);
                        direccion = new Vector3(0f,0f,-2f);
                        up = new Vector3(0f, 1f, 0f);
                        view = Matrix4.LookAt(position,position+direccion,up);
                         break;
                }
               
                case 1:
                    {
                        position = new Vector3(0f, 3f, 5f);
                        direccion = new Vector3(0f, 1f, -4f);
                        up = new Vector3(0f, 1f, 0f);
                        view = Matrix4.LookAt(position, position + direccion, up);
                        break;
                    }
                case 2:
                    {
                        position = new Vector3(0f, 70f, 0f);
                        direccion = new Vector3(0f, 0f, -16f);
                        up = new Vector3(0f, 1f, 0f);
                        view = Matrix4.LookAt(position, position + direccion, up);
                        break;
                    }
                case 3:
                    {
                        position = new Vector3(3f, 3f, -47f);
                        direccion = new Vector3(1f, 0f, 1f);
                        up = new Vector3(0f, 1f, 0f);
                        view = Matrix4.LookAt(position, position + direccion, up);
                        break;
                    }
            
            }


        }

        public void setPespective() {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //                                    angul d visio, proporcion de ancho por alto
            Matrix4 matrix = Matrix4.Perspective(45.0f, 1, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            SeleccionarCamara(0);
        
        }


    }//end class
}
