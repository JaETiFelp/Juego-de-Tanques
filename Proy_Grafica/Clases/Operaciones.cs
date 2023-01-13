using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_Grafica.Clases
{
    class Operaciones
    {

        
        //______polygon_____
        public Punto[] sacarVerticesLinea(Poligono lis)
        {
            int Cant = lis.getSize();
            Punto[] vertices2 = new Punto[Cant * 2];

            int c = 0;

            for (int i = 0; i < Cant; i++)
            {

                vertices2[c] = lis.GetLineaOfPolygon(i).GetP1();//p11;                
                vertices2[c + 1] = lis.GetLineaOfPolygon(i).GetP2();//p22;

                //Console.WriteLine("p1[ " + vertices2[c].Position.X + "," + vertices[c].Position.Y + "," + vertices2[c].Position.Z + " ]  p2[ " +
                //                           vertices2[c + 1].Position.X + "," + vertices[c + 1].Position.Y + "," + vertices2[c + 1].Position.Z + " ]");
                c += 2;
            }
            return vertices2;

        }
        public float MayorX(Poligono pol)
        {
            int a = 0;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.X > a)
                {
                    a = (int)(puntos.ElementAt(i).Position.X);
                }
            }
            return a;
        }
        public float MenorX(Poligono pol)
        {
            int a = 10000;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.X < a)
                {
                    a = (int)(puntos.ElementAt(i).Position.X);
                }
            }
            return a;
        }
        //_________
        public float MayorY(Poligono pol)
        {
            int a = 0;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.Y > a)
                {
                    a = (int)(puntos.ElementAt(i).Position.Y);
                }
            }
            return a;
        }
        public float MenorY(Poligono pol)
        {
            int a = 10000;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.Y < a)
                {
                    a = (int)(puntos.ElementAt(i).Position.Y);
                }
            }
            return a;
        }


        //_________//____ ************____no se si se usa
        public float MayorZ(Poligono pol)
        {
            int a = 0;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.Z > a)
                {
                    a = (int)(puntos.ElementAt(i).Position.Z);
                }
            }
            return a;
        }
        public float MenorZ(Poligono pol)
        {
            int a = 10000;
            Punto[] puntos = sacarVerticesLinea(pol);
            for (int i = 0; i < puntos.Length; i++)
            {
                if (puntos.ElementAt(i).Position.Z < a)
                {
                    a = (int)(puntos.ElementAt(i).Position.Z);
                }
            }
            return a;
        }
        //_________________CENTRO POLIGONO _______________________
        public float centroPoligonoX( Poligono auxPol) {
            return ( MenorX(auxPol) + (MayorX(auxPol)-MenorX(auxPol))/2 );
        }

        public float centroPoligonoY(Poligono auxpol){
            return ( MenorY(auxpol)+ ( MayorY(auxpol)- MenorY(auxpol) )/2 );
        }


        //____ ************____no se si se usa
        public float centroPoligonoZ(Poligono auxpol)
        {
            return (MenorZ(auxpol) + (MayorZ(auxpol) - MenorZ(auxpol)) / 2);
        }






        ///=========== OBJETO ======
        ///
        public Poligono[] sacarPolig_De_Objeto(Objeto lis)
        {
            int longi =0 ;
            
            for (int c = 0; c < lis.GetSizeObjeto();c++ ) {             
                 longi += lis.GetParte(c).GetSizeParte();             
            }


            Poligono[] p = new Poligono[longi]; 
            int con=0;
            for (int i = 0; i < longi; i++)
            {
                //vertices2[c] = lis.GetLineaOfPolygon(i).GetP1();//p11;                
               Parte par=  lis.GetParte(i);
               for (int j = 0; j < par.GetSizeParte();j++ )  {
                   p[con] = par.getPoligono(i);
                   con++;
               }
                
             }
            return p;
        }

        public float centroObjeto_X(Objeto auxOb) {
            float maxX = 0;
            float menX = 10000;

            Poligono[] pol1 = sacarPolig_De_Objeto(auxOb);

            for (int i = 0; i < pol1.Count();i++ ) { 

               if( MayorX(pol1[i]) > maxX ){
                   maxX = ( MayorX( pol1[i] ) );
               }else{
                   menX = (MenorX(pol1[i]));
               }

            }
        
        return ( menX+( maxX-menX )/2 );
        }

        public float centroObjeto_Y(Objeto auxOb)
        {
            float maxY = 0;
            float menY = 10000;

            Poligono[] pol1 = sacarPolig_De_Objeto(auxOb);
                        
            for (int i = 0; i < pol1.Count(); i++)
            {

                if (MayorY(pol1[i]) > maxY)
                {
                    maxY = (MayorY(pol1[i]));
                }
                else
                {
                    menY = (MenorY(pol1[i]));
                }

            }

            return (menY + (maxY - menY) / 2);
        }


        //____ ************____no se si se usa
        public float centroObjeto_Z(Objeto auxOb)
        {
            float maxZ = 0;
            float menZ = 10000;

            Poligono[] pol1 = sacarPolig_De_Objeto(auxOb);

            for (int i = 0; i < pol1.Count(); i++)
            {

                if (MayorZ(pol1[i]) > maxZ)
                {
                    maxZ = (MayorZ(pol1[i]));
                }
                else
                {
                    menZ = (MenorZ(pol1[i]));
                }

            }

            return (menZ + (maxZ - menZ) / 2);
        }

        //________actualizar centros de poligono
        public void actualizarCentrosPoligono(Objeto O2,Objeto O, EscenarioObj E) {
            //Poligono[] p=sacarPolig_De_Objeto(O2);
            //for (int i = 0; i < p.Count();i++ )
            //{

            //    O.GetParte(i).getPoligono(i).puntoRef.Position.X = p[i].puntoRef.Position.X - O2.puntoref.Position.X;
            //}
        
        }

        /// <summary>
        /// verifica si a esta en rango  entre X1 y X2
        /// </summary>
        public Boolean estaX(float x1, float x2, float a)
        {

            Boolean sw = false;
            if (x1 > x2)
            {
                if (a > x2 && a < x1)
                    sw = true;
            }
            else
            {
                if (a > x1 && a < x2)
                    sw = true;
            }
            return sw;
        }
        public Boolean estaY(float y1, float y2, float a)
        {

            Boolean sw = false;
            if (y1 > y2)
            {
                if (a > y2 && a < y1)
                    sw = true;
            }
            else
            {
                if (a > y1 && a < y2)
                    sw = true;
            }
            return sw;
        }

    }//end class
}
