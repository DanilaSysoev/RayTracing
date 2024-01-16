namespace RayTracing;

public abstract class CentralSurface : ISurface
{
    public Vector3 Position { get; set; }

    public CentralSurface()
    {
        Position = Vector3.Zero;
    }
    public CentralSurface(Vector3 position)
    {
        Position = position;
    }

    public void Translate(Vector3 on)
    {
        Position += on;
    }

    public abstract Vector3? NormalInIntersection(Ray ray);
    public abstract Vector3? Intersection(Ray ray);
}