using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Sphere : Hitable
    {
        private double radius;
        private Point3D center;
        private Material material;
        public double Radius { get => radius; set => radius = value; }
        internal Point3D Center { get => center; set => center = value; }
        internal Material Material
        {
            get => material; set => material = value;
        }
        public Sphere() { }
        public Sphere(Point3D center, double radius, Material material)
        {
            this.radius = radius;
            this.center = center;
            this.material = material;
        }
        public override bool Hit(Ray r, double tMin, double tMax, ref HitRecord rec)
        {
            Vector oc = r.Origin - center;
            double a = Vector.DotProduct(r.Direction, r.Direction);
            double b = Vector.DotProduct(oc, r.Direction);
            double c = Vector.DotProduct(oc, oc) - radius * radius;
            double discriminant = b * b - a * c;
            if (discriminant > 0)
            {
                double temp = (-b - Math.Sqrt(b * b - a * c)) / a;
                if (temp < tMax && temp > tMin)
                {
                    rec.T = temp;
                    rec.P = r.PointAtPara(rec.T);
                    rec.Normal = (rec.P - center) / radius;
                    rec.Material = material;
                    return true;
                }
                temp = temp = (-b + Math.Sqrt(b * b - a * c)) / a;
                if (temp < tMax && temp > tMin)
                {
                    rec.T = temp;
                    rec.P = r.PointAtPara(rec.T);
                    rec.Normal = (rec.P - center) / radius;
                    rec.Material = material;
                    return true;
                }
            }
            return false;
        }
    }
}
