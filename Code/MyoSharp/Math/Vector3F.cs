using System;
using System.Collections.Generic;
using System.Text;

using SysMath = System.Math;

namespace MyoSharp.Math
{
    public class Vector3F
    {
        #region Fields
        private readonly float[] _data;
        #endregion

        #region Constructors
        public Vector3F()
            : this(0, 0, 0)
        { 
        }

        public Vector3F(float x, float y, float z)
        {
            _data = new float[3];
            _data[0] = x;
            _data[1] = y;
            _data[2] = z;
        }
        #endregion

        #region Properties
        public float X { get { return _data[0]; } }

        public float Y { get { return _data[1]; } }

        public float Z { get { return _data[2]; } }

        public float this[uint index]
        {
            get
            {
                return _data[index];
            }
        }
        #endregion

        #region Methods
        public static Vector3F operator -(Vector3F vector)
        {
            return new Vector3F(-vector.X, -vector.Y, -vector.Z);
        }

        public static Vector3F operator +(Vector3F vector1, Vector3F vector2)
        {
            return new Vector3F(vector1.X + vector2.X,
                               vector1.Y + vector2.Y,
                               vector1.Z + vector2.Z);
        }

        public static Vector3F operator -(Vector3F vector1, Vector3F vector2)
        {
            return vector1 + (-vector2);
        }

        public static Vector3F operator *(Vector3F vector, float scalar)
        {
            return new Vector3F(vector.X * scalar,
                               vector.Y * scalar,
                               vector.Z * scalar);
        }

        public static Vector3F operator *(float scalar, Vector3F vector)
        {
            return vector * scalar;
        }

        public static Vector3F operator /(Vector3F vector, float scalar)
        {
            return new Vector3F(vector.X / scalar,
                               vector.Y / scalar,
                               vector.Z / scalar);
        }

        public float Magnitude()
        {
            return (float)SysMath.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override string ToString()
        {
            return string.Format("{0,6:0.00},{1,6:0.00},{2,6:0.00}", X, Y, Z);
        }
        #endregion
    }
}
