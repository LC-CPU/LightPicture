using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Color3D
    {
		private double r; //未放宽的r值(0~1)
		private double g; //未放宽的g值(0~1)
		private double b; //未放宽的 z 值(0~1)
		public double R
		{
			get => r; set => r = value;
		}
		public double G
		{
			get => g; set => g = value;
		}
		public double B
		{
			get => b; set => b = value;
		}
		public Color3D()
		{

		}
		public Color3D(double r, double g, double b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}
	}
}
