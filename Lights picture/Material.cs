using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Material
    {
        public virtual bool Scatter(Ray rIn, HitRecord rec, ref Vector attenuation, ref Ray scattered)
        {
            return false;
        }

    }
}
