namespace RayTracing;

public class Triangle : ISurface
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
        var e2 = C - A;

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

    public void Rotate(Axis axis, double angleDegree)
    {
        var matrix = Transform.GetRotation(axis, angleDegree);
        A *= matrix;
        B *= matrix;
        C *= matrix;
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        A.Scale(axis, scaleFactor);
        B.Scale(axis, scaleFactor);
        C.Scale(axis, scaleFactor);
    }

    public Vector3 Interpolate(Vector3 point,
                               Vector3 aVal,
                               Vector3 bVal,
                               Vector3 cVal)
    {
        var uv = GetUV(point, aVal, bVal, cVal);
            
        var ab_d = bVal - aVal;
        var ac_d = cVal - aVal;
                
        return aVal += (ab_d * uv.Item1) + (ac_d * uv.Item2);
    }
    public TextureUV Interpolate(Vector3 point,
                                 TextureUV aVal,
                                 TextureUV bVal,
                                 TextureUV cVal)
    {
        var uv = GetUV(point, aVal, bVal, cVal);
            
        var ab_d = bVal - aVal;
        var ac_d = cVal - aVal;
                
        return aVal += (ab_d * uv.Item1) + (ac_d * uv.Item2);
    }

    private Tuple<double, double> GetUV<T>(
        Vector3 point, T aVal, T bVal, T cVal
    )
    {
        var ab = B - A;
        var ac = C - A;
        var w = point - A;
        
        double u = 0;
        double v = 0;

        var det1 = ab.X * ac.Y - ac.X * ab.Y;
        var det2 = ab.X * ac.Z - ac.X * ab.Z;
        var det3 = ab.Y * ac.Z - ac.Y * ab.Z;
        if (det1 != 0)
        {
            u = (w.X * ac.Y - w.Y * ac.X) / det1;
            v = (ab.X * w.Y - ab.Y * w.X) / det1;
        }
        else if (det2 != 0)
        {            
            u = (w.X * ac.Z - w.Z * ac.X) / det2;
            v = (ab.X * w.Z - ab.Z * w.X) / det2;
        }
        else
        {
            u = (w.Y * ac.Z - w.Z * ac.Y) / det3;
            v = (ab.Y * w.Z - ab.Z * w.Y) / det3;
        }
        
        return Tuple.Create(u, v);
    }

    public IntersectInfo Intersect(Ray ray)
    {
        var point = Intersection(ray);
        if(point is null)
            return new IntersectInfo();
        return new IntersectInfo { Point = point };
    }
}