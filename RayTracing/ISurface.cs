namespace RayTracing;

public interface ISurface
{
    public Vector3? NormalInIntersection(Ray ray);
    public Vector3? Intersection(Ray ray);
    public void Translate(Vector3 on);
    public void Rotate(Axis axis, double angleDegree);
    public void Scale(Axis axis, double scaleFactor);
}
