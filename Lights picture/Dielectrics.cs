using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Dielectrics:Material
    {
        private double refIdx; //相对折射率
        public Dielectrics(double refIdx)
        {
            this.RefIdx = refIdx;
        }
        public double RefIdx { get => refIdx; set => refIdx = value; }
        public override bool Scatter(Ray rIn, HitRecord rec, ref Vector attenuation, ref Ray scattered)
        {
            Vector outwardNormal = new Vector();
            Vector reflected = Ray.Reflect(rIn.Direction,
           rec.Normal);
            double niOverNt;
            attenuation = new Vector(1, 1, 1); //衰减率
            Vector refracted = new Vector();
            double reflect_prob;
            double cosine;
            if (Vector.DotProduct(rIn.Direction, rec.Normal) > 0)
            {
                outwardNormal = rec.Normal * -1;
                niOverNt = refIdx;
                cosine = refIdx * Vector.DotProduct(rIn.Direction,
               rec.Normal) / rIn.Direction.Length();
            }
            else
            {
                outwardNormal = rec.Normal;
                niOverNt = 1.0 / refIdx;
                cosine = -Vector.DotProduct(rIn.Direction, rec.Normal) /
               rIn.Direction.Length();
            }
            if (Ray.Refract(rIn.Direction, outwardNormal, niOverNt, ref refracted))
            {
                reflect_prob = Ray.Schlick(cosine, refIdx);
            }
            else
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y,rec.P.Z), reflected);
                reflect_prob = 1.0;
            }
            if (Ray.Rd().NextDouble() < reflect_prob)
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), reflected);
            }
            else
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), refracted);
            }
            return true;
        }

    }

}
