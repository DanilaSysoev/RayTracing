namespace RayTracing;

public interface ISurface : ITransformable
{
    Vector3? NormalInIntersection(Ray ray);
    Vector3? Intersection(Ray ray);
}
