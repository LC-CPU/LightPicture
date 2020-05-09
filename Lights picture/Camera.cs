using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Camera
    {
        private Point3D lowerLeftCorner;
        private Vector horizontal;
        private Vector vertical;
        private Point3D origin;
        private Vector u = new Vector();
        private Vector v = new Vector();
        private Vector w = new Vector();
        private double lensRadius;
        public Camera(Point3D lookfrom, Point3D lookat, Vector vup,
       double vfov, double aspect, double aperture, double focusDist)
        {
            lensRadius = aperture / 2;
            double theta = vfov * Math.PI / 180;
            double halfHeight = Math.Tan(theta / 2);
            double halfWidth = aspect * halfHeight;
            origin = lookfrom;
            w = Vector.UnitVector(lookfrom - lookat);
            u = Vector.UnitVector(Vector.CrossProduct(vup, w));
            v = Vector.CrossProduct(w, u);
            Vector lowerLeftCornerTemp = origin - halfWidth * focusDist * u -
           halfHeight * focusDist * v - w * focusDist;
            lowerLeftCorner = new Point3D(lowerLeftCornerTemp.X,
           lowerLeftCornerTemp.Y, lowerLeftCornerTemp.Z);
            horizontal = 2 * halfWidth * u * focusDist;
            Vertical = 2 * halfHeight * v * focusDist;
        }
        internal Point3D LowerLeftCorner
        {
            get => lowerLeftCorner; set =>
lowerLeftCorner = value;
        }
        internal Vector Horizontal
        {
            get => horizontal; set =>
horizontal = value;
        }
        internal Vector Vertical
        {
            get => vertical; set => vertical =
value;
        }
        internal Point3D Origin { get => origin; set => origin = value; }
        public Ray GetRay(double s, double t)
        {
            Vector rd = lensRadius * Ray.RandomInUnitDisk();
            Vector offset = u * rd.X + v * rd.Y; //偏移量，为了方便用
            return new Ray(new Point3D(origin.X + offset.X, origin.Y + offset.Y, origin.Z + offset.Z), lowerLeftCorner + s * horizontal + t *
    vertical - origin - offset);

        }
    }
}
