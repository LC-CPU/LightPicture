using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Metal:Material
    {
        private Vector albedo; //漫反射率
        private double fuzz; //模糊参数
        public Metal(Vector albedo, double fuzz)
        {
            this.Albedo = albedo;
            this.fuzz = fuzz;
        }
        public double Fuzz { get => fuzz; set => fuzz = value; }
        internal Vector Albedo { get => albedo; set => albedo = value; }
        public override bool Scatter(Ray rIn, HitRecord rec, ref
       Vector attenuation, ref Ray scattered)
        {
            Vector reflected = Ray.Reflect(Vector.UnitVector(rIn.Direction), rec.Normal);
            scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), reflected + fuzz * Ray.RandomInUnitSphere());
            attenuation = albedo;
            return (Vector.DotProduct(scattered.Direction, rec.Normal) >0);
        }

    }
}
