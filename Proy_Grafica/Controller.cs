using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proy_Grafica.Clases;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Threading;
using Proy_Grafica.Controladores;




namespace Proy_Grafica
{
    class Controller
    {
        
        public  Malla mall;
        public Laberinto lab { set; get; }
        Shader shader;
        public ObjLoader obj3ds = new ObjLoader();
        Camara camara = new Camara();
        Mando mand = new Mando();
        Ejecutor ejecutor = new Ejecutor();
        JugadorController jugadorController = new JugadorController();
       public int[] valoresTeclado = { 0, 0, 0, 0, 0, 8 };
       List<ObjLoader> objects;
       ObjLoader obj4 = new ObjLoader();
       public bool isRunning { set; get; }
        public Camara camera {
            get { return camara; }
        }
        /// <summary>
        /// se envia nivel
        /// </summary>
        public void CrearObjetos(int nivel)
        {
            shader = new Shader("resourse/shader/vertex.shader",
                               "resourse/shader/fragment.shader");
            mall = new Malla();
           
            lab = new Laberinto(nivel);

            obj3ds = obj3ds.LoadFromFile(@".\Model\3dtankmaterial.obj");//tank34.obj
            obj3ds.Position = new Vector3(0.07f, 0f, 0.07f);//(0.07f, 0f, 0.07f);
            obj3ds.cargarObjectLoader_TofloatArray();
            //obj4 = obj4.LoadFromFile(@".\Model\tank34.obj");//tank34.obj
            //obj4.Position= new Vector3(0.07f, 0f, 0.57f);
            //obj4.Scale = new Vector3(0.02f, 0.02f, 0.02f);
            //obj4.cargarObjectLoader_TofloatArray();
            jugadorController.AddJugador(obj3ds);
           // jugadorController.AddJugador(obj4);
            jugadorController.IniciarJuego(lab.getlaberinto());
            


        }
    
        public void IniciarJueg() { 
        // //ejecutor empezar a mover
        //   // Console.WriteLine("hola arrbiba" + mand.Arriba);
        //    //ejecutor.trasladarObj(obj3ds, 0.005f, 0, 0);
        //    int i = 0;
        //    //double currentTime = DateTimeOffset.UtcNow.AddMilliseconds(3000);
        //    Thread hilo= new Thread(()=>{
                
                
        //        while (isRunning){
        //  //      while(i<mand.valoresTeclado.Count()){
                    
        //           int estado = mand.valoresTeclado[i];
        //           if (estado != 1)
        //                {
        //                    Console.WriteLine("hola arrbiba" + mand.Arriba.ToString());
        //                    ejecutor.trasladarObj(obj3ds, 0.005f, 0, 0);
        //                   //mand.valoresTeclado[0] = 0;
        //                }
        //           if (estado != 2)
        //                {
        //                    Console.WriteLine("hola abajo" + mand.Abajo.ToString());
        //                    ejecutor.trasladarObj(obj3ds, -0.005f, 0, 0);
        //                    //mand.valoresTeclado[1] = 0;
        //                }
                
        //           //if (i == valoresTeclado.Count()) {
        //           //    i = 0;
        //           //}
        //           //i++;
        //        }
        //    });
        //    hilo.Start();

        }
        public void ReiniciarJuego(){
        //reiniciar
        }

        public void realizarAcciones()

        {
            /*
            if(valoresTeclado[0]==1){
                ejecutor.trasladarObj(tanque,1.0f,0.0f,0.0f)
            }
             * 
             * if(valoresTeclado[0]==1){
             * ;
                ejecutor.trasladarObj(tanque,planificador.setDireccion())
            }
            if(valoresTeclado[0]==1{
             * planificador.add(new ObjLoader())
             * ejecutor.disparar(planificador.objetos[0], direccion);
             
             }
             * 
             */
                     }


        public void DibujarEscena() {
            //shader.Start();            
            mall.dibujar();
            lab.getlaberinto().Draw2();
            obj3ds.Draw();
            //ejecutor.verificarColision(obj3ds.Position, lab.getlaberinto());
           // obj4.Draw();
            
           // shader.Stop();
        }
        
        public void moverObj(float x1,float y1,float z1){
            //es.trasladarObj(x1,y1,z1);
            ejecutor.trasladarObj(obj3ds,x1,y1,z1);
            
        }
        public void rotarObj(float x1, float y1, float z1, float ang)
        {

           ejecutor.rotarObj(obj3ds, x1, y1, z1,ang);
        }



    }//end class
}
