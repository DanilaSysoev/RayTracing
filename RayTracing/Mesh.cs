namespace RayTracing;

struct ItemSet<T>
{
    public T A { get; set; }
    public T B { get; set; }
    public T C { get; set; }
}

public class Mesh : ISurface
{
    public BoundingBox BoundingBox { get; private set; }

    public Vector3? Intersection(Ray ray)
    {
        if(!ray.Intersect(BoundingBox))
            return null;        
    }

    public Vector3? NormalInIntersection(Ray ray)
    {        
        if(!ray.Intersect(BoundingBox))
            return null;
    }

    public IntersectInfo Intersect(Ray ray)
    {
        throw new NotImplementedException();
    }

    public void Rotate(Axis axis, double angleDegree)
    {
        BoundingBox.Min.Rotate(axis, angleDegree);
        BoundingBox.Max.Rotate(axis, angleDegree);
        for(int i = 0; i < vertexStorage.Length; ++i)
        {
            var normalPoint = vertexStorage[i] + normalStorage[i];
            normalPoint.Rotate(axis, angleDegree);
            vertexStorage[i].Rotate(axis, angleDegree);
            normalStorage[i] = (normalPoint - vertexStorage[i]).Normalize();
        }
        
        RebuildTriangles();
        RebuildNormals();
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        BoundingBox.Min.Scale(axis, scaleFactor);
        BoundingBox.Max.Scale(axis, scaleFactor);
        for(int i = 0; i < vertexStorage.Length; ++i)
            vertexStorage[i].Scale(axis, scaleFactor);

        RebuildTriangles();
    }

    public void Translate(Vector3 on)
    {
        BoundingBox.Min.Translate(on);
        BoundingBox.Max.Translate(on);
        for(int i = 0; i < vertexStorage.Length; ++i)
            vertexStorage[i].Translate(on);

        RebuildTriangles();
    }


    private void RebuildTriangles()
    {
        for(int i = 0; i < faces.Length; ++i)
        {
            triangles[i] = new Triangle(vertexStorage[faces[i].Va],
                                        vertexStorage[faces[i].Vb],
                                        vertexStorage[faces[i].Vc]);
        }
    }
    private void RebuildNormals()
    {
        if(!faces[0].Na.HasValue)
            return;
        for(int i = 0; i < faces.Length; ++i)
        {
            normals[i] = new ItemSet<Vector3>{
                A = normalStorage[faces[i].Na!.Value],
                B = normalStorage[faces[i].Nb!.Value],
                C = normalStorage[faces[i].Nc!.Value]
            };
        }
    }
    private void RebuildTextureUVs()
    {
        if(!faces[0].Ta.HasValue)
            return;
        for(int i = 0; i < faces.Length; ++i)
        {
            textureUvs[i] = new ItemSet<TextureUV>{
                A = texturUvsStorage[faces[i].Ta!.Value],
                B = texturUvsStorage[faces[i].Tb!.Value],
                C = texturUvsStorage[faces[i].Tc!.Value]
            };
        }        
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

        BoundingBox = new BoundingBox();
    }
}