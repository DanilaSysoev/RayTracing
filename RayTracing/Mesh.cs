namespace RayTracing;

class Mesh : ISurface
{
    public Vector3? Intersection(Ray ray)
    {
        throw new NotImplementedException();
    }

    public Vector3? NormalInIntersection(Ray ray)
    {
        throw new NotImplementedException();
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        throw new NotImplementedException();
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        throw new NotImplementedException();
    }

    public void Translate(Vector3 on)
    {
        throw new NotImplementedException();
    }

    private Triangle[] triangles;
    private Mesh(int trianglesCount)
    {
        triangles = new Triangle[trianglesCount];
    }
}