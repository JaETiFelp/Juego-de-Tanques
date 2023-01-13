using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Proy_Grafica.Clases;

namespace Proy_Grafica
{
   public  class Laberinto
    {
        private Parte parte;
        //private Poligono poli;
        private Objeto objetoLaberinto;
        private List<string> LisPared;//guarda 1ro el txt pa luego.insertarlo a la estructura ., _ ,  pol....
        public Laberinto() { }
        public Laberinto( int nivelMapa) {
            string path = @".\laberintos\lab_button.txt";
            parte = new Parte();
            objetoLaberinto = new Objeto();
            LisPared = new List<string>();            
            StreamReader sr = new StreamReader(path);
            Crear(sr);

            switch(nivelMapa){
                case 0: cargarLaberintoN(0);
                    break;
                case 1: cargarLaberintoN(1);
                    break;
            
            }
        }

        private void Crear( StreamReader sr)
        {
            String lineArchivo; //= sr.ReadToEnd();
            string[] VecPolygon;
            string[] vecPuntos;
            int a = 0, b = 0, c = 0;
            
            int cont = 0;
            int cont2=1;
            int cont3 =2;
            while ((lineArchivo = sr.ReadLine()) != null)
            {
                //Console.WriteLine();
                LisPared.Add("Linea" + cont);
               
                //Console.WriteLine("lineaArchivo " + cont + "-> " + lineArchivo);
                VecPolygon = lineArchivo.Split(';');//separa paredes
                
                for (int i =0; i < VecPolygon.Length; i++)
                {
                    Console.WriteLine();   
                 //   Console.WriteLine("Pared_split1_v[" + i + "]: " + VecPolygon[i] +" long "+ VecPolygon[i].Length);
                    LisPared.Insert(cont2, "Pared");
                    cont2++;                    
                    string aux = obtenerPuntos1(VecPolygon[i]);
                    //Console.WriteLine("_"+aux);
                    vecPuntos = aux.Split(':');//separa lineas
                    
                    for (int j = 0; j < vecPuntos.Length; j++)
                    {
                      //  Console.WriteLine();
                   //     Console.WriteLine("____Lineas_split2_v[" + j + "]: " + vecPuntos[j] + " long " + vecPuntos[j].Length);
                        string aux2 = obtenerPuntos2(vecPuntos[j]);
                      //  Console.Write("j "+j+"_____p____" + aux2);                  
                        
                        LisPared.Insert(cont3,aux2); cont3++; cont2++;
                        
                       c ++; //cantidad de puntos
                    }
                    b++ ;//cant de poligonos
                    cont3++;
                    
                }
                cont++; a ++;//cant de lineas
                cont2++;
                cont3 += 1;
            }
            //Console.WriteLine();
            
            
        }

        public void cargarLaberintoN(int n1){
            int li = n1 + 1;
            string cadfinlab = "Linea"+li;
            for (int x = 0; x < LisPared.Count; x++)
            {
                Console.WriteLine("vpared[ " + x + " ] " + LisPared.ElementAt(x));
            }
            //Console.WriteLine();
            int n = 0;
            for (int i = 0; i < LisPared.Count; i++)
            {
                string l = LisPared.ElementAt(i);
                string cadLinea = "Linea" + n1;         
               
                string nbre="laberinto";
                if (l == cadLinea)
                {
                    n++;                                        
                    int j=i+1;
                    
             //       Console.WriteLine(" "+cadLinea+"   "+ LisPared.ElementAt(j)+""+n);
                    if (LisPared.ElementAt(j) == "Pared")
                    {   j++;
                        Poligono po = new Poligono();
                        int f=0;
                                while (j < LisPared.Count && LisPared.ElementAt(j) != cadfinlab)//"Linea1")//para linea0 hasta donde aparece linea1
                                {
                                    if (LisPared.ElementAt(j) != "Pared")
                                    {
                                        string cad = LisPared.ElementAt(j);
                                        string cad2 = LisPared.ElementAt(j+1);
                            
                                        float x1 = float.Parse(cad.ElementAt(0).ToString() + cad.ElementAt(1).ToString() + cad.ElementAt(2).ToString() + cad.ElementAt(3).ToString())/100;
                                        float y1 = float.Parse(cad.ElementAt(5).ToString() + cad.ElementAt(6).ToString() + cad.ElementAt(7).ToString() + cad.ElementAt(8).ToString()) / 100;
                                        float z1 = float.Parse(cad.ElementAt(10).ToString() + cad.ElementAt(11).ToString() + cad.ElementAt(12).ToString() + cad.ElementAt(13).ToString()) / 100;

                                        float x2 = float.Parse(cad2.ElementAt(0).ToString() + cad2.ElementAt(1).ToString() + cad2.ElementAt(2).ToString() + cad2.ElementAt(3).ToString()) / 100;
                                        float y2 = float.Parse(cad2.ElementAt(5).ToString() + cad2.ElementAt(6).ToString() + cad2.ElementAt(7).ToString() + cad2.ElementAt(8).ToString()) / 100;
                                        float z2 = float.Parse(cad2.ElementAt(10).ToString() + cad2.ElementAt(11).ToString() + cad2.ElementAt(12).ToString() + cad2.ElementAt(13).ToString()) / 100;
                                        //Console.WriteLine("___cont2 " + j + LisPared.ElementAt(j) + "__" + x1 + "__" + y1 + "__" + z1+" j2 "+cad2);
                                        Linea l1 = new Linea();
                                        l1.SetP1(new Punto(x1, y1 * 0.6f , z1));
                                        l1.SetP2(new Punto(x2, y2 * 0.6f, z2));
                                        po.AddLinea(l1);
                                        //Console.WriteLine("Cont pol "+f);
                                        j+=2;
                                    }
                                    else
                                    {
                                        parte.Nombre = "pared"+j;
                                        parte.AddPolygon(parte.Nombre, po); f = 0;                                      
                                        
               //                         Console.WriteLine("___salto " + j + LisPared.ElementAt(j) + " long pol " + po.getSize() + " long PArte " + parte.GetSizeParte());
                                        po = new Poligono();
                                        j+=1;
                            
                                    }

                                 }//while
                                parte.Nombre = "pol" + j;
                                parte.AddPolygon(parte.Nombre, po); f = 0;
                                
                    }//2do if
                }//1r if
               
            }//for
            
           
        }
        public Parte getLaberinto() {
            return parte;
        }
        public Objeto getlaberinto() {
            
            objetoLaberinto.AddPart(parte);
            objetoLaberinto.Nombre = "ObjLaberinto1";
            return objetoLaberinto;
        }
        private string obtenerPuntos1(string cad)
        {
            string aux="";
            int i2 = 0;
            
            for (int i = 0; i < cad.Length - 1; i++) {
                aux += cad[i];
                //Console.WriteLine("___CAd : "+aux);
                if(aux=="pol["){
                    aux = "";             
                }             
            }
            return aux;
        }

        private string obtenerPuntos2(string cad)
        {
            string aux = "";
            string[] Vcad;
            Vcad = new string[cad.Length - 6];

            int i2 = 0, sw = 0;

            for (int i = 0; i < cad.Length - 1; i++)
            {
                aux += cad[i];
              //  Console.WriteLine("_________CAd : "+aux);
                if (aux == "p(")
                {
                    aux = "";
                }
            }
            //Console.WriteLine("cadena completa "+aux);

            return aux;
           
        }
    




    }//end class
}
