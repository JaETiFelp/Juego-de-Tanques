using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Proy_Grafica.Clases;
namespace Proy_Grafica
{
    class Program
    {
        
        static void Main(string[] args)

        {
        //    Linea lin = new Linea();

        //    Console.WriteLine("vector " +lin.punto1[1].Position.X);
            
            //Vector3 v;
            //v.X = 1;
            //v.Y = 2;
            //v.Z = 5;
            //Console.WriteLine(v.X);
            //Console.WriteLine("long "+v.LengthFast);
    
            GameWindow Ventana = new GameWindow(500, 500);
            
           game ga = new game(Ventana);



        }
    }
}
