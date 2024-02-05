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
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Rotate(axis, angleDegree);
        for(int i = 0; i < normalStorage.Count; ++i)
            normalStorage[i].Rotate(axis, angleDegree);
                    
        RebuildTriangles();
        RebuildNormals();
    }

    public void Scale(Axis axis, double scaleFactor)
    {
        BoundingBox.Min.Scale(axis, scaleFactor);
        BoundingBox.Max.Scale(axis, scaleFactor);
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Scale(axis, scaleFactor);

        RebuildTriangles();
    }

    public void Translate(Vector3 on)
    {
        BoundingBox.Min.Translate(on);
        BoundingBox.Max.Translate(on);
        for(int i = 0; i < vertexStorage.Count; ++i)
            vertexStorage[i].Translate(on);

        RebuildTriangles();
    }

    public void AddVertex(Vector3 vertex)
    {
        vertexStorage.Add(vertex);
    }
    public void AddNormal(Vector3 normal)
    {
        normalStorage.Add(normal);
    }
    public void AddTextureUV(TextureUV textureUV)
    {
        texturUvsStorage.Add(textureUV);
    }
    public void AddFace(Face face)
    {
        faces.Add(face);
        triangles.Add(new Triangle(vertexStorage[face.Va],
                                   vertexStorage[face.Vb],
                                   vertexStorage[face.Vc]));
        if(face.Na is not null)
        {
            normals.Add(new ItemSet<Vector3>{
                A = normalStorage[face.Na!.Value],
                B = normalStorage[face.Nb!.Value],
                C = normalStorage[face.Nc!.Value]
            });
        }
        if(face.Ta is not null)
        {
            textureUvs.Add(new ItemSet<TextureUV>{
                A = texturUvsStorage[face.Ta!.Value],
                B = texturUvsStorage[face.Tb!.Value],
                C = texturUvsStorage[face.Tc!.Value]
            });
        }
    }


    private void RebuildTriangles()
    {
        for(int i = 0; i < faces.Count; ++i)
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
        for(int i = 0; i < faces.Count; ++i)
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
        for(int i = 0; i < faces.Count; ++i)
        {
            textureUvs[i] = new ItemSet<TextureUV>{
                A = texturUvsStorage[faces[i].Ta!.Value],
                B = texturUvsStorage[faces[i].Tb!.Value],
                C = texturUvsStorage[faces[i].Tc!.Value]
            };
        }        
    }

    private List<Vector3> vertexStorage;
    private List<Vector3> normalStorage;
    private List<TextureUV> texturUvsStorage;
    private List<Face> faces;

    private List<Triangle> triangles;
    private List<ItemSet<Vector3>> normals;
    private List<ItemSet<TextureUV>> textureUvs;

    public Mesh()
    {
        vertexStorage = new List<Vector3>();
        normalStorage = new List<Vector3>();
        texturUvsStorage = new List<TextureUV>();

        faces = new List<Face>();
        triangles = new List<Triangle>();
        normals = new List<ItemSet<Vector3>>();
        textureUvs = new List<ItemSet<TextureUV>>();

        BoundingBox = new BoundingBox();
    }
}