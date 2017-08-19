using System;

public class Geometry
{
    public static float EPSILON = 0.000001f;

    public Geometry()
    {
    }

    public static Vector2 LineLineIntersection(Vector2 x1, Vector2 x2, Vector2 x3, Vector2 x4)
    {
        float denom = (x1.x - x2.x) * (x3.y - x4.y) - (x1.y - x2.y) * (x3.x - x4.x);
        if (Math.Abs(denom) < EPSILON)
        {
            throw new NotSupportedException("The lines are parallel!");
        }
        float x = (x1.x * x2.y - x1.y * x2.x) * (x3.x - x4.x) 
            - (x3.x * x4.y - x3.y * x4.x) * (x1.x - x2.x);
        float y = (x1.x * x2.y - x1.y * x2.x) * (x3.y - x4.y)
            - (x3.x * x4.y - x3.y * x4.x) * (x1.y - x2.y);
        return new Vector2(x / denom, y / denom);
    }

    public static Vector2[] LineMediator(Vector2 a, Vector2 b)
    {
        Vector2[] line = new Vector2[2];
		Vector2 ab = b - a;
		ab = Vector2.Rotate90(ab);
		line[0] = (a + b) / 2.0f;
		line[1] = ab + line[0];
		return line;
    }
}

public class Vector2
{
    public float[] components;

    public Vector2()
    {
        components = new float[2];
    }

    public Vector2(float x, float y)
    {
        components = new float[2];
        components[0] = x;
        components[1] = y;
    }

    public float this[int idx]
    {
        get { return components[idx]; }
        set { components[idx] = value; }
    }

    public float x
    {
        get { return components[0]; }
        set { components[0] = value; }
    }

    public float y
    {
        get { return components[1]; }
        set { components[1] = value; }
    }

    public float length
    {
        get { return (float)Math.Sqrt(this.x * this.x + this.y * this.y); }
    }

    public void normalize()
    {
        float l = this.length;
        this.x /= l;
        this.y /= l;
    }

    public static Vector2 Rotate90(Vector2 v)
    {
        return new Vector2(-v.y, v.x);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(b.x - a.x, b.y - a.y);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static Vector2 operator /(Vector2 a, float s)
    {
        return new Vector2(a.x / s, a.y / s);
    }
    public static Vector2 zero = new Vector2(0.0f, 0.0f);
    public static Vector2 one = new Vector2(1.0f, 1.0f);
}

#if !ONLINE_JUDGE
namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TestVector2
    {
        [Test]
        public void TestSettersGetters()
        {
            Vector2 v = new Vector2();
            v.x = 10;
            v.y = -1.1f;
            Assert.AreEqual(10, v[0]);
            Assert.AreEqual(10, v.x);
            Assert.AreEqual(-1.1f, v[1]);
            Assert.AreEqual(-1.1f, v.y);
        }

        [Test]
        public void TestRotation()
        {
            Vector2 v = new Vector2(10, 10);
            v = Vector2.Rotate90(v);
            Assert.AreEqual(-10, v.x);
            Assert.AreEqual(10, v.y);

            v.x = 1.0f;
            v.y = 0.0f;
            v = Vector2.Rotate90(v);
            Assert.AreEqual(0.0f, v.x);
            Assert.AreEqual(1.0f, v.y);

            v = Vector2.Rotate90(v);
            Assert.AreEqual(-1.0f, v.x);
            Assert.AreEqual(0.0f, v.y);
        }

        [Test]
        public void TestMagnitudeNormalization()
        {
            Vector2 v = new Vector2(0, 1);
            v.normalize();
            Assert.AreEqual(1.0f, v.length);
            v.x = 421321.1321f;
            v.y = 12332.665433f;
            v.normalize();
            Assert.AreEqual(1.0f, v.length);
        }

        [Test]
        public void TestFindCircumCenter()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(0.0f, 1.0f);
            Vector2 c = new Vector2(1.0f, 1.0f);

            var ab = Geometry.LineMediator(a, b);
            var ac = Geometry.LineMediator(a, c);

            Vector2 ip = Geometry.LineLineIntersection(ab[0], ab[1], ac[0], ac[1]);
            Assert.AreEqual(0.5f, ip.x);
            Assert.AreEqual(0.5f, ip.y);
        }
    }
}
#endif