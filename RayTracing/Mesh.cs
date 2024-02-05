namespace RayTracing;

struct ItemSet<T>
{
    public T A { get; set; }
    public T B { get; set; }
    public T C { get; set; }
}

public class Mesh : ISurface
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

    private Vector3[] vertexStorage;
    private Vector3[] normalStorage;
    private TextureUV[] texturUvsStorage;
    private Face[] faces;

    private Triangle[] triangles;
    private ItemSet<Vector3>[] normals;
    private ItemSet<TextureUV>[] textureUvs;

    private Mesh(int vertexCount, int normalsCount, int texesCount, int facesCount)
    {
        vertexStorage = new Vector3[vertexCount];
        normalStorage = new Vector3[normalsCount];
        texturUvsStorage = new TextureUV[texesCount];

        faces = new Face[facesCount];
        triangles = new Triangle[facesCount];
        normals = new ItemSet<Vector3>[facesCount];
        textureUvs = new ItemSet<TextureUV>[facesCount];
    }
}