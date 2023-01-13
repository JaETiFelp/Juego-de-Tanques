using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using Proy_Grafica.ennum;
using Proy_Grafica.Clases;


namespace Proy_Grafica
{
    /// <summary>
    /// Obtiene el TANQUE con  sus atributos
    /// </summary>
    public class ObjLoader: Objeto  
    {
        Vector3[] vertices;
        Vector3[] colors;
        Vector2[] texturecoords;
        public ColaCircular<Movimiento> acciones = new ColaCircular<Movimiento>(4);
        List<Tuple<int, int, int>> faces = new List<Tuple<int, int, int>>();      
        public  int VertCount { get { return vertices.Length; } }
        public  int IndiceCount { get { return faces.Count * 3; } }
        public  int ColorDataCount { get { return colors.Length; } }

        public Vector3 Position = Vector3.Zero;
        public Vector3 Rotation = Vector3.Zero;
        public Vector3 Scale =  new Vector3(0.2f,0.2f,0.2f);
        float angulo = 180f;

        public Matrix4 ModelMatrix = Matrix4.Identity;
        public Matrix4 ViewProjectionMatrix = Matrix4.Identity;
        public Matrix4 ModelViewProjectionMatrix = Matrix4.Identity;


        public bool choque;
        public float radio;
        public bool moviendo;
        public int vidas = 3;



        //public ObjLoader() {
        //    //objload1 = objload1.LoadFromFile(@".\Model\3dtankmaterial.obj");//tank34.obj
        //    //objload1.Position += new Vector3(0.07f, 0f, 0.07f);
        //    //objects.Add(objload1);
        //    //foreach (var item in objects)
        //    //{
        //    //    item.cargarObjectLoader_TofloatArray();
        //    //}
        //    LoadFromFile(@".\Model\3dtankmaterial.obj");//tank34.obj
        //    Position = new Vector3(0.07f, 0f, 0.07f);
        //    cargarObjectLoader_TofloatArray();

        //}
        public ObjLoader()
        {
            acciones.AddItem(0, Movimiento.Adelante, false);
            acciones.AddItem(1, Movimiento.Atras, false);
            acciones.AddItem(2, Movimiento.Derecha, false);
            acciones.AddItem(3, Movimiento.Izquierda, false);
            //crear();
        }
        #region  getter y setter
        public bool Moviendo
        {
            get { return moviendo; }
            set { moviendo = value; }
        }

        public int Vidas
        {
            get { return vidas; }
            set { vidas = value; }
        }
        public bool chocado
        {

            get { return choque; }
            set { choque = value; }
        }
        public  Vector3[] GetVerts()
        { 
            return vertices;
        }
        public int[] GetIndices(int offset=0) {
            List<int> temp = new List<int>();

            foreach (var face in faces)
            {
                temp.Add(face.Item1 + offset);
                temp.Add(face.Item2 + offset);
                temp.Add(face.Item3 + offset);
                
            }

            return temp.ToArray();
        }
        public  Vector3[] GetColorData()
        {
            return colors;
        }
        public  Vector2[] GetTextureCoords()
        {
            return texturecoords;
        }

        public Vector3 GetPosicion()
        {
            return Position;
        }
        #endregion
        //_________
        public ObjLoader LoadFromFile( string filename) {
            ObjLoader obj = new ObjLoader();
            //Console.WriteLine("hola1");
            try {
                using (StreamReader reader= new StreamReader(new FileStream( filename,FileMode.Open,FileAccess.Read)) ){
               // Console.WriteLine("la linea streamReader es : \n" + reader.ReadToEnd());        
                    obj= LoadFromString(reader.ReadToEnd());
                    

                    //Console.WriteLine("hola1");        
                 
                }
            }
            catch(FileNotFoundException e){
                Console.WriteLine("File not found:{0}",filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Loading File:{0}", filename);
            }

            return obj;
        }
        /// <summary>
        /// saca datos(vertices,color,face) de .obj
        /// </summary>

        public ObjLoader LoadFromString(String obj) {
        
            //separe lines from the file
            List<string> lines = new List<string>(obj.Split('\n'));
            //lists to hold model data
            
            List<Vector3> verts = new List<Vector3>();
            List<Vector3> colors = new List<Vector3>();
            List<Vector2> texs = new List<Vector2>();
            List<Tuple<int, int , int>> faces= new List<Tuple<int,int,int>>();
        //read file line by line
            
            foreach(String line in lines){
                if(line.StartsWith("v ")){//vertex definition
                    //cut off beginning of line
                    String temp = line.Substring(2);
                    
                    Vector3 vec = new Vector3();
                   
                   // Console.WriteLine("temp "+temp);
                  //
                    if (temp.Count((char c) => c == ' ') == 2)
                    {// Check if there's enough element for a  vertex

                        String[] vertparts = temp.Split(' ');

                        //intenta analizar cada parte del vertice                        
                        bool success = float.TryParse(vertparts[0], out vec.X); vec.X = vec.X / 10000000;
                        success &= float.TryParse(vertparts[1], out vec.Y); vec.Y = vec.Y / 10000000;
                        success &= float.TryParse(vertparts[2], out vec.Z); vec.Z = vec.Z / 10000000;
                        //Console.WriteLine("__________________ vecx "+float.Parse(vec.X.ToString())+" vecy "+vec.Y+" vecz "+vec.Z);

                        // coordenadas ficticias de  color/texture coordinates por ahora
                        //colors.Add(new Vector3((float)Math.Cos(vec.X), (float)Math.Sin(vec.Z), (float)Math.Sin(vec.Z)));
                        //var random = new Random(seed);
                        //var value = random.Next(0, 5);
                        float randomNumber = new Random().Next(0, 1);
                        colors.Add(new Vector3((float)Math.Cos(vec.Z), (float)Math.Sin(vec.Z), (float)Math.Sin(randomNumber)));
                        //var random = new Random(seed);
                        //var value = random.Next(0, 5);
                        //colors.Add(new Vector3(1f,1f, (float)Math.Sin(vec.Z)));

                        texs.Add(new Vector2((float)Math.Sin(vec.Z), (float)Math.Sin(vec.Z)));

                        // If any of the parses failed, report the error
                        if (!success)//parsing = analisis
                        {
                            Console.WriteLine("Error parsing vertex: {0}", line);
                        }
                    }
                    verts.Add(vec);
                }  //en if"v"
                else if (line.StartsWith("f ")) // Face definition
                {
                    // Cut off beginning of line
                    String temp = line.Substring(2);

                    Tuple<int, int, int> face = new Tuple<int, int, int>(0, 0, 0);

                    if (temp.Count((char c) => c == ' ') == 2) // Check if there's enough elements for a face
                    {
                        String[] faceparts = temp.Split(' ');

                        int i1, i2, i3;

                        // Attempt to parse each part of the face
                        bool success = int.TryParse(faceparts[0], out i1);
                        success &= int.TryParse(faceparts[1], out i2);
                        success &= int.TryParse(faceparts[2], out i3);

                        // If any of the parses failed, report the error
                        if (!success)
                        {
                            Console.WriteLine("Error parsing face: {0}", line);
                        }
                        else
                        {
                            // Decrement to get zero-based vertex numbers
                            //Console.WriteLine("i1_ " +i1+ "i2 " +i2+ "i3 "+i3);
                            face = new Tuple<int, int, int>(i1 - 1, i2 - 1, i3 - 1);
                            faces.Add(face);
                        }
                    }
                }
            
            }//end forEach
            

            //create the objloader
            ObjLoader vol = new ObjLoader();
            vol.vertices = verts.ToArray();
            vol.faces = new List<Tuple<int, int, int>>(faces);            
            vol.colors = colors.ToArray();
            vol.texturecoords = texs.ToArray();

            
            
            //Console.WriteLine("tamn  de color " + vol.colors.Count());
            //for (int i = 0; i < vol.colors.Count(); i++)
            //{
            //    Console.WriteLine("i-> " + i + " " + vol.colors.ElementAt(i));
            //}
            //for (int i = 0; i < vol.vertices.Count(); i++)
            //{
            //    Console.WriteLine("vert " + i + " " + vol.vertices.ElementAt(i));
            //}
            //for (int i = 0; i < vol.faces.Count; i++)
            //{
            //    Console.WriteLine("faces-> " + i + "| " + vol.faces.ElementAt(i).Item1 + "| " + vol.faces.ElementAt(i).Item2 + "| " + vol.faces.ElementAt(i).Item3);
            //}
            return vol;
        }
        /// <summary>
        /// Calculates the model matrix from transforms
        /// </summary>
        public void CalculateModelMatrix()
        {
            ModelMatrix = Matrix4.Scale(Scale) * Matrix4.CreateRotationX(Rotation.X) * Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z) * Matrix4.CreateTranslation(Position);
        }



        float[] cubeVertices;
        float[] cubeColors;
        int[] cubeIndices;

        #region datos en float[]

        public void cargarObjectLoader_TofloatArray()
        {
            cubeVertices = new float[VertCount * 3];
            cubeColors = new float[ColorDataCount * 3];

            cubeIndices = GetIndices();
            int ii2 = 0;
            for (int ii = 0; ii < VertCount; ii++)
            {

                cubeVertices[ii2] = GetVerts().ElementAt(ii).X;
                cubeVertices[ii2 + 1] = GetVerts().ElementAt(ii).Y;
                cubeVertices[ii2 + 2] = GetVerts().ElementAt(ii).Z;

                cubeColors[ii2] = GetColorData().ElementAt(ii).X ;
                cubeColors[ii2 + 1] = GetColorData().ElementAt(ii).Y;
                cubeColors[ii2 + 2] = GetColorData().ElementAt(ii).Z;
                //if(ii<10){
                //   Console.WriteLine("Cubevert [ " + ii2 + " ] : " + cubeVertices[ii2] + "  " + cubeVertices[ii2 + 1] + "  " + cubeVertices[ii2 + 2] + "  " + objload1.VertCount);
                //    Console.WriteLine("   face[ " + ii2 + " ] :" + cubeIndices[ii2] + "  " + cubeIndices[ii2 + 1] + "  " + cubeIndices[ii2 + 2] + "    " + objload1.IndiceCount);
                ii2 += 3;

            //cubeVertices = new float[objload1.VertCount * 3];
            //cubeColors = new float[objload1.ColorDataCount * 3];

            //cubeIndices = objload1.GetIndices();
            //int ii2 = 0;
            //for (int ii = 0; ii < objload1.VertCount; ii++)
            //{

            //    cubeVertices[ii2] = objload1.GetVerts().ElementAt(ii).X;
            //    cubeVertices[ii2 + 1] = objload1.GetVerts().ElementAt(ii).Y;
            //    cubeVertices[ii2 + 2] = objload1.GetVerts().ElementAt(ii).Z;

            //    cubeColors[ii2] = objload1.GetColorData().ElementAt(ii).X;
            //    cubeColors[ii2 + 1] = objload1.GetColorData().ElementAt(ii).Y;
            //    cubeColors[ii2 + 2] = objload1.GetColorData().ElementAt(ii).Z;
            //    //if(ii<10){
            //    //   Console.WriteLine("Cubevert [ " + ii2 + " ] : " + cubeVertices[ii2] + "  " + cubeVertices[ii2 + 1] + "  " + cubeVertices[ii2 + 2] + "  " + objload1.VertCount);
            //    //    Console.WriteLine("   face[ " + ii2 + " ] :" + cubeIndices[ii2] + "  " + cubeIndices[ii2 + 1] + "  " + cubeIndices[ii2 + 2] + "    " + objload1.IndiceCount);
            //    ii2 += 3;
            }

        }

        //public void objectLoader_Draw(float[] cubevertices, float[] cubecolor, int[] cubeindices)
        public new void Draw()
        {
            GL.PushMatrix();
            GL.Translate(Position.X, Position.Y, Position.Z);

            //GL.Translate(Position.X, Position.Y, Position.Z);
            //GL.Rotate(-45, 0, 1, 0);
            //GL.Translate(-Position.X, -Position.Y, -Position.Z);

            GL.Rotate(-angulo, 0, 1, 0);
            GL.Scale(Scale.X, Scale.Y, Scale.Z );
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.VertexPointer(3, VertexPointerType.Float, 0, cubeVertices);
            GL.ColorPointer(3, ColorPointerType.Float, 0, cubeColors);

            GL.DrawElements(PrimitiveType.Triangles, cubeIndices.Length, DrawElementsType.UnsignedInt, cubeIndices);

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.ColorArray);
            GL.PopMatrix();
        }
        #endregion

        #region {Mover,trasladar,escalar}
        public void trasladar(float tx, float ty, float tz)
        {
            float dx = (float)(tx * Math.Sin((angulo * 0.017453292519943295f)));
            float dz = (float)(tx * Math.Cos((angulo * 0.017453292519943295f)));
            Position.X += dz;//dz
            Position.Y += ty;
            Position.Z += dx;//dx

        }
        public void rotar(float _x, float _y, float _z, float ang)
        {

            //float x = Rotation.X + (_x - Rotation.X) * (float)(Math.Cos(ang)) - (_y - Rotation.Y) * (float)(Math.Sin(ang));
            //float y = Rotation.X + (_x - Rotation.X) * (float)(Math.Sin(ang)) + (_y - Rotation.Y) * (float)(Math.Cos(ang));
            //float z = Rotation.X + (_x - Rotation.X) * (float)(Math.Sin(ang)) + (_z - Rotation.Z) * (float)(Math.Cos(ang));
            //float z = puntoRef.Position.Z + tz;
            /*float rx = (float)Math.Cos(MathHelper.DegreesToRadians(ang));
            float rz = (float)Math.Sin(MathHelper.DegreesToRadians(ang));
            Rotation.X = x;
            Rotation.Y = _y;
            Rotation.Z = z;
            angulo = ang;
            */
            //float x3 = (float)( _z * Math.Cos( Rotation.Y * (float)(180 / Math.PI)));
            //float z3 = (float)(_z * Math.Sin( Rotation.Y*(float)(180/Math.PI ) ));
            //Rotation += new Vector3(x3, 0, z3);
            //Rotation.X = x;
            //Rotation.Y = y;
            //Rotation.Z = z;
            angulo += ang;
            //Console.WriteLine("x "+Rotation.X + " y " + Rotation.Y + " z " + Rotation.Z+" a "+angulo);
           
        }
        #endregion

        //public void moverAdelante()
        //{
        //    acciones.Add(EMovimiento.Adelante);
         
        //}
        //public void moverAtras()
        //{
        //    acciones.Add(EMovimiento.Atras);

        //}
        //public void moverIzquierda()
        //{
        //    acciones.Add(EMovimiento.Izquierda);
         
        //}
        //public void moverDerecha()
        //{
        //    acciones.Add(EMovimiento.Derecha);
         
        //}
        


    }//end class
}
