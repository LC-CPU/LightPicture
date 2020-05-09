using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Ray
    {
        private Point3D origin;
        private Vector direction;
        public Ray() { }
        public Ray(Point3D origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
        internal Point3D Origin { get => origin; set => origin = value; }
        internal Vector Direction
        {
            get => direction; set => direction =value;
        }
        public Vector PointAtPara(double t)
        {
            return origin + new Point3D(t * direction.X, t * direction.Y,
           t * direction.Z);
        }
       private static Random rd = new Random();
        public static Random Rd()
        {
            Random Rd = new Random();
            return Rd;
        }
        public static Vector RandomInUnitSphere()
        {
            Vector p = new Vector();
            do
            {
                p = 2.0 * new Vector(rd.NextDouble(), rd.NextDouble(),
               rd.NextDouble()) - new Point3D(1, 1, 1);
            } while (p.SquaredLength() >= 1.0);
            return p;
        }
        public static Vector Reflect(Vector v, Vector n)
        {
            return v - 2 * Vector.DotProduct(v, n) * n;
        }
        public static bool Refract(Vector v, Vector n, double niOverNt, ref Vector refracted)
        {
            Vector uv = Vector.UnitVector(v);
            double dt = Vector.DotProduct(uv, n);
            double discriminant = 1.0 - niOverNt * niOverNt * (1 - dt * dt);
            if (discriminant > 0)
            {
                refracted = niOverNt * (uv - n * dt) - n *
               Math.Sqrt(discriminant);
                return true;
            }
            else
                return false;
        }
        public static double Schlick(double cosine, double refIdx)
        {
            double r0 = (1 - refIdx) / (1 + refIdx);
            r0 = r0 * r0;
            return r0 + (1 - r0) * Math.Pow((1 - cosine), 5);
        }

        public static Color3D Color(Ray r, Hitable world, int depth)
        {
            HitRecord rec = new HitRecord();
            if (world.Hit(r, 0.001, double.MaxValue, ref rec))
            {
                Ray scattered = new Ray();
                Vector attenuation = new Vector();
                if (depth < 50 && rec.Material.Scatter(r, rec, ref attenuation, ref scattered))
                {
                    Color3D colorTemp = Color(scattered, world, depth + 1);
                    colorTemp.R *= attenuation.X;
                    colorTemp.G *= attenuation.Y;
                    colorTemp.B *= attenuation.Z;
                    return colorTemp;
                }
                else
                {
                    return new Color3D(0, 0, 0);
                }
            }
            else
            {
                Vector unitDirection = Vector.UnitVector(r.Direction);
                double t = 0.5 * (unitDirection.Y + 1.0);
                return new Color3D((1.0 - t) + t * 0.5, (1.0 - t) + t * 0.7, (1.0 - t) + t * 1);
            }
        }
    }
}
