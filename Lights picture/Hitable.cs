using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Hitable
    {
        public virtual bool Hit(Ray r, double tMin, double tMax, ref HitRecord rec)
        {
            return false;
        }
        public static double Hit(Point3D center, double radius, Ray r)
        {
            Vector oc = r.Origin - center;
            double a = Vector.DotProduct(r.Direction, r.Direction);
            double b = 2.0 * Vector.DotProduct(oc, r.Direction);
            double c = Vector.DotProduct(oc, oc) - radius * radius;
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return -1.0;
            }
            else
            {
                return (-b - Math.Sqrt(discriminant)) / (2.0 * a);
            }
        }
        /*public static bool Hit(Point3D center, double radius, Ray r)
        {
            Vector oc = r.Direction - center;
            double a = Vector.DotProduct(r.Direction, r.Direction);
            double b = 2.0 * Vector.DotProduct(oc, r.Direction);
            double c = Vector.DotProduct(oc, oc) - radius * radius;
            double discriminant = b * b - 4 * a * c;
            return (discriminant > 0);
        }*/
    }
}
