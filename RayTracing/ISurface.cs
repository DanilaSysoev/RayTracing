namespace RayTracing;

interface ISurface
{
    public Vector3? NormalInIntersection(Ray ray);
    public Vector3? Intersection(Ray ray);
    public void Translate(Vector3 on);
}