namespace RayTracing;

class Triangle : ISurface
{
    public Vector3 A { get; private set; }
    public Vector3 B { get; private set; }
    public Vector3 C { get; private set; }

    public Triangle(Vector3 a, Vector3 b, Vector3 c)
    {
        A = a;
        B = b;
        C = c;
    }

    public Vector3? Intersection(Ray ray)
    {
        var ab = B - A;
        var ac = B - A;

        var cx = ab.Y * ac.Z - ac.Y * ab.Z;
        var cy = ab.Z * ac.X - ac.Z * ab.X;
        var cz = ab.X * ac.Y - ac.X * ab.Y;
        var c = ac.X * ab.Y * A.Z + ac.Y * ab.Z * A.X + ac.Z * ab.X * A.Y -
                ab.X * ac.Y * A.Z - ab.Y * ac.Z * A.X - ab.Z * ac.X * A.Y;
                
        // TO DO
    }

    public Vector3? NormalInIntersection(Ray ray)
    {
        throw new NotImplementedException();
    }

    public void Translate(Vector3 on)
    {
        A += on;
        B += on;
        C += on;
    }
}