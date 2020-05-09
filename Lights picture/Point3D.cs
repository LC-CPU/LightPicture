using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Point3D
    {
		private double x; //对应点x的值
		private double y; //对应点y的值
		private double z; //对应点 z 的值
		public double X
		{
			get => x; set => x = value;
		}
		public double Y
		{
			get => y; set => y = value;
		}
		public double Z
		{
			get => z; set => z = value;
		}
		public Point3D()
		{

		}
		public Point3D(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		/// <summary>
		/// 两个点相减得到这两个点构成的向量
		/// </summary>
		/// <param name="a">末尾的点a</param>
		/// <param name="b">开始的点b</param>
		/// <returns>两个点组成的向量</returns>
		public static Vector operator -(Point3D a, Point3D b)
		{
			return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		/// <summary>
		/// 两个点相加得到向量
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Vector operator +(Point3D a, Point3D b)
		{
			return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
		}
	}
}
