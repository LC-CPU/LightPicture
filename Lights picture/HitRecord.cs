  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class HitRecord
    {
        private double t;
        private Vector p;
        private Vector normal;
        private Material material;
        public double T { get => t; set => t = value; }
        internal Vector P { get => p; set => p = value; }
        internal Vector Normal { get => normal; set => normal = value; }
        internal Material Material
        {
            get => material; set => material = value;
        }
    }
}
