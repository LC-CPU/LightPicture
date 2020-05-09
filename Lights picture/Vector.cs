using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_picture
{
    class Vector
    {
        private double x; //对应向量x的值
        private double y; //对应向量y的值
        private double z; //对应向量 z 的值
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                x = value;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        public Vector()
        {

        }
        public Vector(double x_, double y_, double z_)
        {
            this.x = x_;
            this.y = y_;
            this.z = z_;
        }
        public Vector(Vector v_)
        {
            this.x = v_.x;
            this.y = v_.y;
            this.z = v_.z;
        }
        /// <summary>
        /// 重载+运算符，向量的加法
        /// </summary>
        /// <param name="a">向量加数a</param>
        /// <param name="b">向量加数b</param>
        /// <returns>向量a和向量b相加的结果</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /// <summary>
        /// 点与向量相加左
        /// </summary>
        /// <param name="a">点a</param>
        /// <param name="b">向量b</param>
        /// <returns>结果是一个向量</returns>
        public static Vector operator +(Point3D a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /// <summary>
        /// 点与向量相加右
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">点b</param>
        /// <returns>结果是一个向量</returns>
        public static Vector operator +(Vector a, Point3D b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /// <summary>
        /// 重载-运算符，向量的减法
        /// </summary>
        /// <param name="a">向量被减数a</param>
        /// <param name="b">向量减数b</param>
        /// <returns>向量a和向量b相减的结果</returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        /// <summary>
        /// 重载-运算符，向量的取负
        /// </summary>
        /// <param name="b">要取负的向量b</param>
        /// <returns>向量b取负的结果</returns>
        public static Vector operator -(Vector b)
        {
            return new Vector(-b.X, -b.Y, -b.Z);
        }
        /// <summary>
        /// 点与向量相减左
        /// </summary>
        /// <param name="a">点a</param>
        /// <param name="b">向量b</param>
        /// <returns>结果是一个向量</returns>
        public static Vector operator -(Point3D a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        /// <summary>
        /// 点与向量相减右
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">点b</param>
        /// <returns>结果是一个向量</returns>
        public static Vector operator -(Vector a, Point3D b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        /// <summary>
        /// 重载*运算符，向量左乘以一个数
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">数b</param>
        /// <returns>向量a和数b相乘的结果</returns>
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }
        /// <summary>
        /// 重载*运算符，向量右乘以一个数
        /// </summary>
        /// <param name="a">数a</param>
        /// <param name="b">向量b</param>
        /// <returns>数a和向量b相乘的结果</returns>
        public static Vector operator *(double a, Vector b)
        {
            return new Vector(a * b.X, a * b.Y, a * b.Z);
        }
        /// <summary>
        /// 重载*运算符,向量对应的坐标相乘
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        /// <summary>
        /// 重载/运算符，向量除以一个数
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">除数b</param>
        /// <returns>向量a和数b相除的结果</returns>
        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }
        /// <summary>
        /// 得到该向量的模
        /// </summary>
        /// <returns>返回向量的模</returns>
        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        /// <summary>
        /// 向量模的平方
        /// </summary>
        /// <returns></returns>
        public double SquaredLength()
        {
            return x * x + y * y + z * z;
        }
        /// <summary>
        /// 使该向量单位化
        /// </summary>
        public void MakeUnitVector()
        {
            double k = 1 / Length();
            x *= k;
            y *= k;
            z *= k;
        }
        /// <summary>
        /// 向量的点积
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns>向量a和向量b的点积结果</returns>
        public static double DotProduct(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        /// <summary>
        /// 向量的叉积
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns>向量a和向量b的差积结果</returns>
        public static Vector CrossProduct(Vector a, Vector b)
        {
            return new Vector(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z,
           a.X * b.Y - a.Y * b.X);
        }
        /// <summary>
        /// 单位化向量
        /// </summary>
        /// <param name="v">需要进行单位化的向量v</param>
        /// <returns>单位化向量结果</returns>
        public static Vector UnitVector(Vector v)
        {
            return v / v.Length();
        }
    }
}
