using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lights_picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nx = 400; //宽度
            int ny = 400; //高度
            int ns = 100;
            Bitmap bitmap = new Bitmap(nx, ny);
            Random rd = new Random();
            List<Hitable> list = new List<Hitable>();
            double R = Math.Cos(Math.PI / 4);
            list.Add(new Sphere(new Point3D(-R, 0, -1), R, new Lambertian(new Vector(0, 0, 1))));
            list.Add(new Sphere(new Point3D(R, 0, -1), R, new Lambertian(new Vector(1, 0, 0))));
            HitableList world = new HitableList(list, list.Count); 
            Camera cam = new Camera(new Point3D(-2, 2, 1), new Point3D(0, 0, -1), new Vector(0, 1, 0), 90, (double)(nx) / (double)(ny));
            list.Add(new Sphere(new Point3D(0, 0, -1), 0.5, new Lambertian(new Vector(0.1, 0.2, 0.5))));
            list.Add(new Sphere(new Point3D(0, -100.5, -1), 100, new Lambertian(new Vector(0.8, 0.8, 0.0))));
            list.Add(new Sphere(new Point3D(1, 0, -1), 0.5, new Metal(new Vector(0.8, 0.6, 0.2), 0.0)));
            list.Add(new Sphere(new Point3D(-1, 0, -1), 0.5, new Dielectrics(1.5)));
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    Color3D col = new Color3D();
                    for (int s = 0; s < ns; s++)
                    {
                        double u = (double)(i + rd.NextDouble()) / (double)nx;
                        double v = (double)(j + rd.NextDouble()) / (double)ny;
                        Ray r = cam.GetRay(u, v);
                        Color3D colTemp = Ray.Color(r, world, 0);
                        col.R += colTemp.R;
                        col.G += colTemp.G;
                        col.B += colTemp.B;
                    }
                    col.R /= ns;
                    col.G /= ns;
                    col.B /= ns;
                    col = new Color3D(Math.Sqrt(col.R), Math.Sqrt(col.G), Math.Sqrt(col.B));
                    int ir = (int)(255.99 * col.R);
                    int ig = (int)(255.99 * col.G);
                    int ib = (int)(255.99 * col.B);
                    bitmap.SetPixel(i, ny - j - 1, Color.FromArgb(ir, ig, ib));
                }
            }
            pictureBox1.Image = bitmap;
        }
     }
            
 }
