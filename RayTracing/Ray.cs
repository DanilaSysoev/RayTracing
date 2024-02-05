namespace RayTracing;

public class Ray
{
    public Vector3 Start { get; init; }
    public Vector3 Direction { get; init; }
    
    public Ray(Vector3 start, Vector3 direction)
    {
        Start = start;
        Direction = direction.Normalized;
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
}