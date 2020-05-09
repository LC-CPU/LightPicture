using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Lambertian:Material
    {
        private Vector albedo; //漫反射系数
        public Lambertian(Vector albedo)
        {
            this.Albedo = albedo;
        }
        internal Vector Albedo { get => albedo; set => albedo = value; }

        public override bool Scatter(Ray rIn, HitRecord rec, ref Vector attenuation, ref Ray scattered)
        {
            Vector target = rec.P + rec.Normal + Ray.RandomInUnitSphere();
            scattered = new Ray(new Point3D(rec.P.X,rec.P.Y, rec.P.Z), target - rec.P);
            attenuation = albedo;
            return true;
        }

    }
}
