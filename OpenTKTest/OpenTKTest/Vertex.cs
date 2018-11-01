using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace OpenTKTest
{
    public struct Vertex
    {
        public const int Size = (4 + 4) * 4; // size of struct in bytes

        private readonly Vector3 _position;
        private readonly Color4 _colour;
        private readonly Vector3 _normal;

        public Vertex(Vector3 position, Color4 colour, Vector3 normal)
        {
            _position = position;
            _colour = colour;
           _normal = normal;
        }

    }
}
