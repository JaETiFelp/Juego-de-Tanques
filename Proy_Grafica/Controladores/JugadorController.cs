using Proy_Grafica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Proy_Grafica.ennum;
using OpenTK;

namespace Proy_Grafica.Controladores
{
    public class JugadorController
    {
        // crear la cola de jugadores
        private ColaCircular< ObjLoader> jugadores = new ColaCircular<ObjLoader>(2);
        //public int[] valoresTeclado = { 0, 0, 0, 0, 0, 8 };
        public bool corriendo = true;
        float angulo = 0.00003f;
        Ejecutor eje = new Ejecutor();

        public void AddJugador(ObjLoader jugador)
        {
            //agregar a la cola
            jugadores.AddItem(0, jugador, true);
            jugadores.AddItem(1, jugador, true);
        }
        public void IniciarJuego(Objeto lab)
        {
            int i = 0;
            Thread HiloEjecutor = new Thread(()                                                                                         =>
                {
                
                while (corriendo)
                {
                    ObjLoader jugador = jugadores.GetItem(i);
                    for (int j = 0; j < jugador.acciones.size; j++)

                    {
                                float x = 0.00000005f, y=0, z=0;
                                bool estado = jugador.acciones.GetEstado(j);
                                if (estado)
                                {
                                    Movimiento movimiento = jugador.acciones.GetItem(j);
                                //
                                    if (movimiento == Movimiento.Adelante)
                                    {
                                
                                        //eje.trasladarObj(jugador, x, y, z);
                                        //if (!eje.verificarColision(new Vector3(x, y, z), lab))
                                        //{

                                            eje.trasladarObj(jugador, x, y, z);
                                          //  Console.WriteLine("chocado");
                                        //}
                                       // Console.WriteLine("adelante");
                                    }
                                    if (movimiento == Movimiento.Atras)
                                    {
                                        eje.trasladarObj(jugador, -x, y, z);
                                            //if (!eje.verificarColision(new Vector3(-x, y, z), lab))
                                            //{
                                
                                            //    eje.trasladarObj(jugador, -x, y, z);
                                            //    Console.WriteLine("chocado");
                                        
                                            // }
                                
                                       // Console.WriteLine("atraz");
                                    }
                                    if (movimiento == Movimiento.Derecha)
                                    {
                                
                                        eje.rotarObj(jugador,0,1,0, -angulo);
                           
                                        //Console.WriteLine("rot-");
                                    }
                                    if (movimiento == Movimiento.Izquierda)
                                    {
                                        eje.rotarObj(jugador, 0, 1, 0, angulo);
                           
                                        //Console.WriteLine("rot+");
                                    }
                            

                                    //if (!eje.verificarColision(paredes, posicionAux, objeto.radius, true))
                                    //{
                                    //    objeto.posicion.x += dx;
                                    //    objeto.posicion.y = 0;
                                    //    objeto.posicion.z += dz;
                                    //}
                                    //objeto.rotY += giro * 0.08f;
                                    jugador.Rotation.Y += 0.08f;
                                                          
                                }

                        
                            }          
                            i = jugadores.NextPosition(i);
                            //jugador.acciones = jugador.acciones.GetEstado(j);
                            //objeto.currentAction = objeto.acciones.nextPosition(objeto.currentAction);
                        }
            });
            HiloEjecutor.Start();
        }
    }
}
