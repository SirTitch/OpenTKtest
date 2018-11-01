using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKTest
{
    public class ObjectFactory
    {
        public static Vertex[] CreateSolidCube(float side, Color4 colour,float dm)
        {
            side = side / 2f; // half side - and other half
            dm = dm;
            Vertex[] vertices =
            {
   new Vertex(new Vector3(-0.25f, 0.25f, -0.25f), colour, new Vector3(0, 0, -1f)),
   new Vertex(new Vector3(-0.25f, -0.25f, -0.25f), colour,new Vector3(0, 0, -1f)),
   new Vertex(new Vector3(0.25f, -0.25f, -0.25f), colour, new Vector3(0, 0, -1f)),

   new Vertex(new Vector3(0.25f, -0.25f, -0.25f), colour, new Vector3(0, 0, -1f)),
   new Vertex(new Vector3(0.25f, 0.25f, -0.25f), colour, new Vector3(0, 0, -1f)),
   new Vertex(new Vector3(-0.25f, 0.25f, -0.25f), colour, new Vector3(0, 0, -1f)),

   new Vertex(new Vector3(0.25f, -0.25f, -0.25f), colour, new Vector3(1f, 0, 0)),
   new Vertex(new Vector3(0.25f, -0.25f, 0.25f), colour, new Vector3(1f, 0, 0)),
   new Vertex(new Vector3(0.25f, 0.25f, -0.25f), colour, new Vector3(1f, 0, 0)),

   new Vertex(new Vector3(0.25f, -0.25f, 0.25f), colour, new Vector3(1f, 0, 0)),
   new Vertex(new Vector3(0.25f, 0.25f, 0.25f), colour, new Vector3(1f, 0, 0)),
   new Vertex(new Vector3(0.25f, 0.25f, -0.25f), colour, new Vector3(1f, 0, 0)),

   new Vertex(new Vector3(0.25f, -0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),
   new Vertex(new Vector3(-0.25f, -0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),
   new Vertex(new Vector3(0.25f, 0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),

   new Vertex(new Vector3(-0.25f, -0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),
   new Vertex(new Vector3(-0.25f, 0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),
   new Vertex(new Vector3(0.25f, 0.25f, 0.25f), colour, new Vector3(0, 0, 1f)),

   new Vertex(new Vector3(-0.25f, -0.25f, 0.25f), colour, new Vector3(-1f, 0, 0)),
   new Vertex(new Vector3(-0.25f, -0.25f, -0.25f), colour, new Vector3(-1f, 0, 0)),
   new Vertex(new Vector3(-0.25f, 0.25f, 0.25f), colour, new Vector3(-1f, 0, 0)),

   new Vertex(new Vector3(-0.25f, -0.25f, -0.25f), colour, new Vector3(-1f, 0, 0)),
   new Vertex(new Vector3(-0.25f, 0.25f, -0.25f), colour, new Vector3(-1f, 0, 0)),
   new Vertex(new Vector3(-0.25f, 0.25f, 0.25f), colour, new Vector3(-1f, 0, 0)),

   new Vertex(new Vector3(-0.25f, -0.25f, 0.25f), colour, new Vector3(0, -1f, 0)),
   new Vertex(new Vector3(0.25f, -0.25f, 0.25f), colour, new Vector3(0, -1f, 0)),
   new Vertex(new Vector3(0.25f, -0.25f, -0.25f), colour, new Vector3(0, -1f, 0)),

   new Vertex(new Vector3(0.25f, -0.25f, -0.25f), colour, new Vector3(0, -1f, 0)),
   new Vertex(new Vector3(-0.25f, -0.25f, -0.25f), colour, new Vector3(0, -1f, 0)),
   new Vertex(new Vector3(-0.25f, -0.25f, 0.25f), colour, new Vector3(0, -1f, 0)),

   new Vertex(new Vector3(-0.25f, 0.25f, -0.25f), colour, new Vector3(0, 1f, 0)),
   new Vertex(new Vector3(0.25f, 0.25f, -0.25f), colour, new Vector3(0, 1f, 0)),
   new Vertex(new Vector3(0.25f, 0.25f, 0.25f), colour, new Vector3(0, 1f, 0)),

   new Vertex(new Vector3(0.25f, 0.25f, 0.25f), colour, new Vector3(0, 1f, 0)),
   new Vertex(new Vector3( -0.25f, 0.25f, 0.25f), colour, new Vector3(0, 1f, 0)),
   new Vertex(new Vector3(-0.25f, 0.25f, -0.25f), colour, new Vector3(0, 1f, 0)),
  };
            return vertices;
        }
    }
}

