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

    public virtual void Translate(Vector3 on)
    {
        Position += on;
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        var matrix = Transform.GetRotation(axis, angleDegree);
        Position *= matrix;
    }
    
    public virtual void Scale(Axis axis, double scaleFactor)
    {
        Position.Scale(axis, scaleFactor);
    }

    public abstract Vector3? NormalInIntersection(Ray ray);
    public abstract Vector3? Intersection(Ray ray);

    public IntersectInfo Intersect(Ray ray)
    {
        throw new NotImplementedException();
    }
}