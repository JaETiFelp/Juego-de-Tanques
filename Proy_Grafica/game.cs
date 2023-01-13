using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Proy_Grafica.Clases;
namespace Proy_Grafica
{


    /*=================================================================
     * =    A L U M N O :  TICLLA FELIPE JACOB ELIUD                       =
     * =                                                            =
     ==================================================================*/






    /*_________________ ** Mover T A N K **  _________
            Con las direcccionales
       __________________________________________________*/


    /*________________ ** MOVER  CAMARA ** ______________________
     *     W = ADELANTE        A = IZQUIERDA       SPACE = ARRIBA
     *     S =  ATRAZ          D = DERECHA         SHIFT = ABAJO
     *     
     *     
     ___________________________________________________________*/

    /*_________________ ** TRASLADAR PARTE **  _________
              *     +x = "X"    ;           +y = "C"   
              *     -x = "Z"    ;           -y = "V"
       __________________________________________________*/

 public  partial   class game
    {
         GameWindow Ventana;
         Camara camara= new Camara();
         Controller con;
         int enMovimiento = 4;//1=arriba; 1=abajo; 2= Izquierda; 3=Derecha; 4= Nada
         
        //camera
         float speed = 0.01f;
         Vector3 position = new Vector3(0.5f, 1.000002f, 0.489998f);//(0.0f, 3.0f, 0.0f);
         Vector3 front = new Vector3(0.0f, -5.0f, 0.0f);//(0.0f, 0.0f, -5.0f);
         Vector3 up = new Vector3(1.0f, 3.0f, 0.0f);//(0.0f, 1.0f, 3.0f);

         float angulo = 0f;
        Mando mando;
         
         int nivel = 0;
        public game(GameWindow ve) {
            this.Ventana = ve;
            star();
        }

        private void star()
        {
            Ventana.Load += Loaded;
            Ventana.Resize += resize;
            Ventana.UpdateFrame += updateF;
            Ventana.RenderFrame += render;
            Ventana.KeyPress += keypress;
            Ventana.KeyDown += keyDown;
            Ventana.KeyUp += keyUp;
            Ventana.Run(1.0/60.0);
            

        }

   
        void resize(object o, EventArgs e)
        {
            
            GL.Viewport(0, 0, Ventana.Height , Ventana.Height);
            //GL.Viewport(0, 0, Ventana.Height-100, Ventana.Height-100);
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            
            Matrix4 matrix = Matrix4.Perspective(45.0f, Ventana.Width / Ventana.Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);

           //camara.setPespective();
        }
        
        void render(object o , EventArgs e)
        {            
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            Matrix4 view = Matrix4.LookAt(position, position + front, up);
            GL.LoadMatrix(ref view);

            
            //shader.Start();
            GL.Rotate( angulo,1f,0f,0f);
            
            con.DibujarEscena();
           // con.IniciarJuego();
            
            Ventana.SwapBuffers();
            //angulo+=1f;
        }

         

         void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f,0.1f,0.1f,0f);
            //GL.ClearColor(1.0f, 1f, 1f, 1f);
            GL.Enable(EnableCap.DepthTest);          
            
            con = new Controller();
            con.CrearObjetos(0);


            enMovimiento = 4;
            mando = new Mando();
        }
         void updateF(object o, EventArgs e)
         {
             con.isRunning = true;
             
             KeyboardState input = Keyboard.GetState();
             //________trasladar__

             //_Mover Tanke   tank
             //if (input.IsKeyDown(Key.Up))
             //{
             //      con.moverObj(0.005f, 0, 0);
             //    //Console.WriteLine("tecla  1"); 
             //    //con.valoresTeclado[0] = 1;
             //    mando.Arriba = 1;
             //}
             //if (input.IsKeyDown(Key.Down))
             //{
             //    con.moverObj(-0.005f, 0, 0);
             //    //Console.WriteLine("tecla  0" ); 
             //    //con.valoresTeclado[1] = 1;
             //    mando.Abajo = 2;
             //}


             //if (input.IsKeyDown(Key.Right))
             //{
             //    con.moverObj(0, 0, 0.005f);
             //    //con.valoresTeclado[2] = 1;
             //    //mando.r = 1;
             //}
             //if (input.IsKeyDown(Key.Left))
             //{
             //    con.moverObj(0, 0, -0.005f);
             //    //con.valoresTeclado[3] = 1;
             //    //mando.Izquierda = 1;
             //}
             

             
             ////________Rotar
             //if (input.IsKeyDown(Key.T))
             //{
             //    con.rotarObj(0, 1, 0, 90f);
             //}
             //if (input.IsKeyDown(Key.G))
             //{
             //    con.rotarObj(0, 1, 0, -90f);
             //}
             //if (input.IsKeyDown(Key.N))
             //{
             //    //con.valorTeclado[2]=1;
             //    con.CrearObjetos(Nivel2());
             //}

             
             //if (input.IsKeyUp(Key.N))
             //{
             //    //con.valorTeclado[2]=0;
             //    con.CrearObjetos(Nivel2());
             //}
              //con.realizarAcciones();
             
             //for (int i = 0;i<mando.valoresTeclado.Count() ;i++ ) {
             //    Console.Write("," +mando.valoresTeclado.ElementAt(i));
             //}
             //Console.WriteLine();
             //camara
             if (input.IsKeyDown(Key.W))
             {
                 position += front * speed; //Forward adelante
                 //Console.WriteLine("poscion W y S   x: "+position.X +" y:  "+position.Y+" z:  "+position.Z);
             }

             if (input.IsKeyDown(Key.S))
             {
                 position -= front * speed; //Backwards  atraz
                 // Console.WriteLine("poscion W y S   x: " + position.X + " y:  " + position.Y + " z:  " + position.Z);
             }


             if (input.IsKeyDown(Key.A))
             {
                 position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed; //Left
             }

             if (input.IsKeyDown(Key.D))
             {
                 position += Vector3.Normalize(Vector3.Cross(front, up)) * speed; //Right
             }

             if (input.IsKeyDown(Key.Space))
             {
                 position += up * speed; //Up 
                 //   Console.WriteLine("POS spac y shift    x: " + position.X + " y:  " + position.Y + " z:  " + position.Z);
             }

             if (input.IsKeyDown(Key.LShift))
             {
                 position -= up * speed; //Down
                 // Console.WriteLine("POS spac y shift    x: " + position.X + " y:  " + position.Y + " z:  " + position.Z);
             }


            // con.IniciarJuego();

         }
         public int Nivel2() {
             return nivel + 1;
         }

         void keypress(object o, KeyPressEventArgs e) {
            // Console.WriteLine("keypress"+e.KeyChar);
             if(e.KeyChar=='r'){
                 Console.WriteLine("r");
             }
             
         }
         void keyDown(object o, KeyboardKeyEventArgs e)
         { //keydown y keyup no distinguen en may y min

             


             //if (e.Key == Key.R)
             //{
             //    Console.WriteLine("r");
             //}


             if (e.Key == Key.Up)
             {
                 con.obj3ds.acciones.SetEstado(0, true);
                 //enMovimiento = 0;
                 //con.moverObj(0.005f, 0, 0);
                 //con.valoresTeclado[0] = 1;
                 
             }
             if (e.Key == Key.Down)
             {
                 con.obj3ds.acciones.SetEstado(1, true);
                 //con.moverObj(-0.005f, 0, 0);
                 //enMovimiento = 1;
                 //con.valoresTeclado[1] = 1;
             }
             if (e.Key == Key.Left)
             {
                 con.obj3ds.acciones.SetEstado(3, true);
                 //con.moverObj(0, 0, -0.005f);
                 //enMovimiento = 2;
                 //con.valoresTeclado[1] = 1;
             }
             if (e.Key == Key.Right)
             {
                 con.obj3ds.acciones.SetEstado(2, true);
             //    con.moverObj(0, 0, 0.005f);
             //    enMovimiento = 3;
             //    con.valoresTeclado[1] = 1;
             }
             Console.WriteLine("KD" + con.obj3ds.acciones.GetEstado(2));
             if (e.Key==Key.N)
             {
                 //con.valorTeclado[2]=0;
                 con.CrearObjetos(Nivel2());
             }
         }
         void keyUp(object o, KeyboardKeyEventArgs e)
         {
             //ObjLoader obj = new ObjLoader();
             if (e.Key == Key.Up)
             {
                 con.obj3ds.acciones.SetEstado(0, false);
               //  obj.acciones.SetEstado(0,false);
             }
             if (e.Key == Key.Down)
             {
                 con.obj3ds.acciones.SetEstado(1, false);
                 
             }
             if (e.Key == Key.Left)
             {
                 con.obj3ds.acciones.SetEstado(3, false);
             }
             if (e.Key == Key.Right)
             {
                 con.obj3ds.acciones.SetEstado(2, false);
             }
             Console.WriteLine("KU"+con.obj3ds.acciones.GetEstado(2));
             //if (e.Key == Key.R)
             //{
             //    Console.WriteLine("r");
             //}
           //  con.valoresTeclado =new int[] { 0, 0, 0, 0, 0, 0 };

             //if (e.Key == Key.Up)
             //{

             //    enMovimiento = 0;
             //    con.moverObj(0.005f, 0, 0);
             //    con.valoresTeclado[0] = 0;
             //     
             //}
             //if (e.Key == Key.Down)
             //{
             //    con.moverObj(-0.005f, 0, 0);
             //    enMovimiento = 1;
             //    con.valoresTeclado[1] = 0;
             //}
             //if (e.Key == Key.Left)
             //{
             //    con.moverObj(0, 0, -0.005f);
             //    enMovimiento = 2;
             //    con.valoresTeclado[1] = 0;
             //}
             //if (e.Key == Key.Right)
             //{
             //    con.moverObj(0, 0, 0.005f);
             //    enMovimiento = 3;
             //    con.valoresTeclado[1] = 0;
             //}
             
         }

    }//end class


//    #version 330 core

//out vec4 FragColor;
//uniform vec4 uniformColour;
//void main()
//{
//    FragColor = uniformColour;
//}

//    #version 330 core
//layout (location = 0) in vec3 aPosition;

//void main()
//{

//    gl_Position = vec4(0.3*aPosition, 1.0);
//}


}