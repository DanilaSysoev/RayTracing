namespace RayTracing;

public class Sphere : CentralSurface
{
    public double Radius { get; set; }

    public override Vector3? Intersection(Ray ray)
    {
        var tmp = ray.Start - Position;
        var a = ray.Direction.LengthSqr;
        var b = 2 * ray.Direction.Dot(tmp);
        var c = tmp.LengthSqr - Radius * Radius;
        var d = b * b - 4 * a * c;
        if(d < 0)
            return null;
        
        if(Math.Abs(d) < double.Epsilon)
            return ray.Start + (-b / (2 * a) * ray.Direction);
        
        return ray.Start + ((-b - Math.Sqrt(d)) / (2 * a) * ray.Direction);
    }

    public override Vector3? NormalInIntersection(Ray ray)
    {
        var intersect = Intersection(ray);
        return intersect is null ? null
                                 : (intersect.Value - Position).Normalize();
    }
}