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
}