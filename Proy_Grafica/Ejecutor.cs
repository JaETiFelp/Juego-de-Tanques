using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proy_Grafica.Clases;
using OpenTK; 
namespace Proy_Grafica
{
    class Ejecutor
    {
        public Ejecutor()
        {

        }

        public bool verificarColision(Vector3 ptank, Objeto o)
        {

            bool chocado = false;


            for (int i = 0; i < o.GetSizeObjeto(); i++)
            {

                Parte aux1 = o.GetParte(i);
                //Console.WriteLine("objeto tien parte " + aux1.GetSizeParte()+" nombre de parte"+ aux1.Nombre);

                for (int j = 0; j < aux1.GetSizeParte(); j++)
                {
                    Poligono aux2 = aux1.getPoligono(j);
                   // Console.WriteLine("part  tiene poligonos_ " + j);
                    Operaciones op = new Operaciones();
                    Punto[] puntoss = aux2.getvert();
                    //Console.WriteLine("____________cantidad de puntos " +puntoss.Count() );
                    float menx1 = puntoss.ElementAt(0).Position.X;//op.MenorX(aux2);
                    float mayx2 = puntoss.ElementAt(0).Position.X;// op.MayorX(aux2);

                    float menz1 = puntoss.ElementAt(0).Position.Z;// op.MenorZ(aux2);
                    float mayz2 = puntoss.ElementAt(0).Position.Z; //op.MayorZ(aux2);

                    for (int p = 0; p < puntoss.Count(); p++)
                    {

                        if (puntoss.ElementAt(p).Position.X < menx1)
                        {
                            menx1 = (float)(puntoss.ElementAt(p).Position.X);
                        }
                        if (puntoss.ElementAt(p).Position.X > mayx2)
                        {
                            mayx2 = (float)(puntoss.ElementAt(p).Position.X);
                        }


                        if (puntoss.ElementAt(p).Position.Z < menz1)
                        {
                            menz1 = (float)(puntoss.ElementAt(p).Position.Z);
                        }
                        if (puntoss.ElementAt(p).Position.Z > mayz2)
                        {
                            mayz2 = (float)(puntoss.ElementAt(p).Position.Z);
                        }
                        //Console.WriteLine(puntoss);
                        //if (op.estaX(x1, x2, ptank.X) || op.estaY(z1, z2, ptank.Z))
                        //{

                        //}
                       // Console.WriteLine("cant  " + puntoss.ElementAt(p).Position.X + "cant  " + puntoss.ElementAt(p).Position.Y + "cant  " + puntoss.ElementAt(p).Position.Z);
                        //Operaciones op = new Operaciones();
                        //op.sacarVerticesLinea();


                    }
             //       Console.WriteLine("men x1 " + menx1 + " x2 " + mayx2 + ":: men  z1 " + menz1 + " z2 " + mayz2);

                    if (op.estaX(menx1, mayx2, ptank.X) && op.estaY(menz1, mayz2, ptank.Z)) {
                        return true;
                    }

                    //for (int p = 0; p < puntoss.count(); p++)
                    //{   //if (op.estax(x1, x2, ptank.x) || op.estay(z1, z2, ptank.z))
                    //    console.writeline("cant  " + puntoss.elementat(p).position.x + "cant  " + puntoss.elementat(p).position.y + "cant  " + puntoss.elementat(p).position.z);
                    //}

                }

            }

            return false;


        }
        
        public void trasladarObj(ObjLoader objeto, float x1, float y1, float z1)
        {
           // double currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
           // if(tiempoVariacion<30){}
            objeto.trasladar(x1, y1, z1);
            


        }
        public void rotarObj(ObjLoader objeto, float x1, float y1, float z1, float ang)
        {

            objeto.rotar(x1, y1, z1, ang);
        }


        /// <summary>
        /// enviar posicion del tank y objeto laberinto
        /// </summary>
        
          //foreach (var item in o.ppartes )
          //{
          //    Vector3 ptankEnemigo = item.Position;
          //    if (Math.Pow(Math.Pow(ptankEnemigo.X - pNtank.X, 2) + Math.Pow(ptankEnemigo.Y - pNtank.Y, 2) + Math.Pow(ptankEnemigo.Z - pNtank.Z, 2), 1 / 3f) < radio)
          //    {
          //        if (item.chocado == false)
          //        {
          //            item.chocado = true;
          //            return true;
          //        }
          //    }
          //}
         

    }
}
