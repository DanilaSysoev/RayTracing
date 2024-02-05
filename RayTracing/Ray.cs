namespace RayTracing;

public class Ray
{
    public Vector3 Start { get; init; }
    public Vector3 Direction { get; init; }
    public Vector3 InvDirection { get; init; }
    
    public Ray(Vector3 start, Vector3 direction)
    {
        Start = start;
        Direction = direction.Normalized;
        InvDirection = new Vector3 {
            X = direction.X != 0 ? 1 / direction.X :
                                   direction.X * double.PositiveInfinity,
            Y = direction.Y != 0 ? 1 / direction.Y :
                                   direction.Y * double.PositiveInfinity,
            Z = direction.Z != 0 ? 1 / direction.Z :
                                   direction.Z * double.PositiveInfinity,
        };
    }

    public Ray Reflect(Vector3 point, Vector3 normal)
    {
        return new Ray(
            point,
            Direction - normal * 2 * normal.Dot(Direction)
        );
    }
    public Ray Refract(Vector3 point,
                       Vector3 normal,
                       double density_out,
                       double dencity_in)
    {
        double etha = density_out / dencity_in;
        double c_i = -Direction.Dot(normal);

        return new Ray(point,
                       etha * Direction +
                       (etha * c_i - 
                       Math.Sqrt(1 + etha * etha * (c_i * c_i - 1))) * normal);
    }

    public bool Intersect(BoundingBox boundingBox)
    {
        double lo = InvDirection.X * (boundingBox.Min.X - Start.X);
        double hi = InvDirection.X * (boundingBox.Max.X - Start.X);

        var tmin  = Math.Min(lo, hi);
        var tmax = Math.Max(lo, hi);


        double lo1 = InvDirection.Y*(boundingBox.Min.Y - Start.Y);
        double hi1 = InvDirection.Y*(boundingBox.Max.Y - Start.Y);

        tmin  = Math.Max(tmin, Math.Min(lo1, hi1));
        tmax = Math.Min(tmax, Math.Max(lo1, hi1));



        double lo2 = InvDirection.Z*(boundingBox.Min.Z - Start.Z);
        double hi2 = InvDirection.Z*(boundingBox.Max.Z - Start.Z);

        tmin  = Math.Max(tmin, Math.Min(lo2, hi2));
        tmax = Math.Min(tmax, Math.Max(lo2, hi2));


        return (tmin <= tmax) && (tmax > 0.0);
    }
}