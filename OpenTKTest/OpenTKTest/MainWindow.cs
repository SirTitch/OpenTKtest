using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System.IO;
using OpenTK.Graphics;
using System.Diagnostics;

namespace OpenTKTest
{
    public sealed class MainWindow : GameWindow
    {
        private readonly string _title;
        private int _program;
        private double _time;
        private List<RenderObject> _renderObjects = new List<RenderObject>();
        private Color4 _backColor = new Color4(0.1f, 0.1f, 0.3f, 1.0f);
        public float rspd =  0;
        public float zcontrol = -5.0f;
        public float xcontrol = 0;
        public float ycontrol = 0;
        public float xrotate = 0;
        public float yrotate = 0;
        public float zrotate = 0;
        
        public MainWindow()
            : base(750, // initial width
                500, // initial height
                GraphicsMode.Default,
                "",  // initial title
                GameWindowFlags.Default,
                DisplayDevice.Default,
                4, // OpenGL major version
                5, // OpenGL minor version
                GraphicsContextFlags.ForwardCompatible)
        {
            _title += "OpenGL Version: " + GL.GetString(StringName.Version);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }


        protected override void OnLoad(EventArgs e)
        {
            VSync = VSyncMode.Off;
            CreateProjection();
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.HotPink,1)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.BlueViolet, 1)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.Red, 1)));
            _renderObjects.Add(new RenderObject(ObjectFactory.CreateSolidCube(0.2f, Color4.LimeGreen, 1)));
         
            CursorVisible = true;

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 4);
            GL.Enable(EnableCap.DepthTest);
            Closed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs eventArgs)
        {
            Exit();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in _renderObjects)
                obj.Dispose();
            GL.DeleteProgram(_program);
            base.Exit();
        }

        private int CreateProgram()
        {
            try
            {
                var program = GL.CreateProgram();
                var shaders = new List<int>();
                shaders.Add(CompileShader(ShaderType.VertexShader, @"Shaders\vertexShader.vert"));
                shaders.Add(CompileShader(ShaderType.FragmentShader, @"Shaders\fragmentShader.frag"));

                foreach (var shader in shaders)
                    GL.AttachShader(program, shader);
                GL.LinkProgram(program);
                var info = GL.GetProgramInfoLog(program);
                if (!string.IsNullOrWhiteSpace(info))
                    throw new Exception($"CompileShaders ProgramLinking had errors: {info}");

                foreach (var shader in shaders)
                {
                    GL.DetachShader(program, shader);
                    GL.DeleteShader(shader);
                }
                return program;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        private int CompileShader(ShaderType type, string path)
        {
            var shader = GL.CreateShader(type);
            var src = File.ReadAllText(path);
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            var info = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrWhiteSpace(info))
                throw new Exception($"CompileShader {type} had errors: {info}");
            return shader;
        }

        private Matrix4 _modelView;
        private Matrix4 _projectionMatrix;
        private uint colourmode;

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            _time += e.Time;
            var k = (float)rspd * 0.05f;
            var t1 = Matrix4.CreateTranslation(
                (float)(Math.Sin(k * 5f) * 0.5f),
                (float)(Math.Cos(k * 5f) * 0.5f),
                0f);
            var r1 = Matrix4.CreateRotationX(k * 13.0f);
            var r2 = Matrix4.CreateRotationY(k * 13.0f);
            var r3 = Matrix4.CreateRotationZ(k * 3.0f);
           _modelView = r1 * r2 * r3 * t1;

            HandleKeyboard();
        }
        private void HandleKeyboard()
        {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            if (keyState.IsKeyDown(Key.M))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Point);
            }
            if (keyState.IsKeyDown(Key.Comma))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
            if (keyState.IsKeyDown(Key.Period))
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }
            if (keyState.IsKeyDown(Key.Space))
            {
                rspd= rspd + 0.01f;
            }
            if (keyState.IsKeyDown(Key.W))
            {
                zcontrol = zcontrol + 0.01f;
            }
            if (keyState.IsKeyDown(Key.S))
            {
                zcontrol = zcontrol - 0.01f;
            }
            if (keyState.IsKeyDown(Key.A))
            {
                xcontrol = xcontrol + 0.01f;
            }
            if (keyState.IsKeyDown(Key.D))
            {
                xcontrol = xcontrol - 0.01f;
            }
            if (keyState.IsKeyDown(Key.T))
            {
                ycontrol = ycontrol - 0.01f;
            }
            if (keyState.IsKeyDown(Key.G))
            {
                ycontrol = ycontrol + 0.01f;
            }
            if (keyState.IsKeyDown(Key.L))
            {
                xrotate = xrotate + 0.1f;
            }
            if (keyState.IsKeyDown(Key.K))
            {
                xrotate = xrotate - 0.1f;
            }
            if (keyState.IsKeyDown(Key.P))
            {
                yrotate = yrotate + 0.1f;
            }
            if (keyState.IsKeyDown(Key.O))
            {
                yrotate = yrotate - 0.1f;
            }
            if (keyState.IsKeyDown(Key.Z))
            {
                zrotate = zrotate + 0.1f;
            }
            if (keyState.IsKeyDown(Key.X))
            {
                zrotate = zrotate - 0.1f;
            }
            if (keyState.IsKeyDown(Key.V))
            {
                GL.Uniform1(27, 1, ref colourmode);
                colourmode = 1;
            }
            if (keyState.IsKeyDown(Key.C))
            {
                GL.Uniform1(27, 1, ref colourmode);
                colourmode = 0;
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += e.Time;
            Title = $"{_title}: (Vsync: {VSync}) FPS: {1f / e.Time:0}";
            GL.ClearColor(_backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);
            GL.UniformMatrix4(20, false, ref _projectionMatrix);
            float c = 0f;
            foreach (var renderObject in _renderObjects)
            {
                renderObject.Bind();
                
                    var k = 1 + (float)(rspd * (0.05f + (0.1 * c)));
                    var t2 = Matrix4.CreateTranslation(
                      (float)(Math.Sin(k * 5f) * (c + 0.5f) + xcontrol),
                (float)(Math.Cos(k * 5f) * (c + 0.5f) + ycontrol),
                        zcontrol);
                    var r1 = Matrix4.CreateRotationX(k * xrotate +1);
                    var r2 = Matrix4.CreateRotationY(k * yrotate + 1);    
                    var r3 = Matrix4.CreateRotationZ(k * zrotate + 1);
                    var modelView = r1 * r2 * r3 * t2;
                    GL.UniformMatrix4(26, false, ref modelView);
                    renderObject.Render();
              
                c += 0.5f;
            }
            GL.PointSize(10);
            SwapBuffers();
        }
        private void CreateProjection()
        {

            var aspectRatio = (float)Width / Height;
            _projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                60 * ((float)Math.PI / 180f), // field of view angle, in radians
                aspectRatio,                // current window aspect ratio
                0.1f,                       // near plane
                4000f);                     // far plane
        }
    }
}
