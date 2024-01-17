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
        var e1 = B - A;
        var e2 = B - A;

        var pvec = ray.Direction.Cross(e2);
        var det = e1.Dot(pvec);

        if(Math.Abs(det) < double.Epsilon)
            return null;
        
        var inv_det = 1 / det;
        var tvec = ray.Start - A;
        var u = tvec.Dot(pvec) * inv_det;
        if(u < 0 || u > 1)
            return null;
        
        var qvec = tvec.Cross(e1);
        var v = ray.Direction.Dot(qvec) * inv_det;
        if(v < 0 || u + v > 1)
            return null;
        
        return ray.Start + ray.Direction * (e2.Dot(qvec) * inv_det);
    }

    public Vector3? NormalInIntersection(Ray ray)
    {
        var point = Intersection(ray);
        if(point is null)
            return null;
        return (A - B).Cross(A - C).Normalize();
    }

    public void Translate(Vector3 on)
    {
        A += on;
        B += on;
        C += on;
    }
}