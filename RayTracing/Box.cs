namespace RayTracing;

public class Box : CentralSurface
{
    public double SizeX { get; private set; }
    public double SizeY { get; private set; }
    public double SizeZ { get; private set; }
    public Box(Vector3 position,
               double sizeX,
               double sizeY,
               double sizeZ)
        : base(position)
    {
        SizeX = sizeX;
        SizeY = sizeY;
        SizeZ = sizeZ;
        triangles = new Triangle[FacesCount * 2];
        CreateTriangles();
    }

    private void CreateTriangles()
    {
        CreateTop();
        CreateLeft();
        CreateRight();
        CreateBottom();
        CreateFront();
        CreateBack();
    }

    private void CreateTop()
    {
        triangles[0] = new Triangle(
            new Vector3(-SizeX / 2, SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2,  SizeY / 2, SizeZ / 2),
            new Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2)
        );
        triangles[1] = new Triangle(
            new Vector3(SizeX / 2,  SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2,  SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2)
        );
    }

    private void CreateLeft()
    {
        triangles[2] = new Triangle(
            new Vector3(-SizeX / 2, SizeY / 2, SizeZ / 2),
            new Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2)
        );
        triangles[3] = new Triangle(
            new Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2)
        );
    }

    private void CreateRight()
    {
        triangles[4] = new Triangle(
            new Vector3(SizeX / 2, -SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2, SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2, SizeY / 2, SizeZ / 2)
        );
        triangles[5] = new Triangle(
            new Vector3(SizeX / 2, -SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2, -SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2, SizeY / 2, -SizeZ / 2)
        );
    }

    private void CreateBottom()
    {
        triangles[6] = new Triangle(
            new Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2,  -SizeY / 2, SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2)
        );
        triangles[7] = new Triangle(
            new Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2,  -SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2,  -SizeY / 2, SizeZ / 2)
        );
    }

    private void CreateFront()
    {
        triangles[8] = new Triangle(
            new Vector3(-SizeX / 2, SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2,  SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2)
        );
        triangles[9] = new Triangle(
            new Vector3(SizeX / 2, SizeY / 2, -SizeZ / 2),
            new Vector3(SizeX / 2, -SizeY / 2, -SizeZ / 2),
            new Vector3(-SizeX / 2, -SizeY / 2, -SizeZ / 2)
        );
    }

    private void CreateBack()
    {
        triangles[10] = new Triangle(
            new Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2,  SizeY / 2, SizeZ / 2),
            new Vector3(-SizeX / 2, SizeY / 2, SizeZ / 2)
        );
        triangles[11] = new Triangle(
            new Vector3(-SizeX / 2, -SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2, -SizeY / 2, SizeZ / 2),
            new Vector3(SizeX / 2, SizeY / 2, SizeZ / 2)
        );
    }

    public override Vector3? Intersection(Ray ray)
    {
        Vector3? res = null;
        double res_len = 0;
        foreach(var triangle in triangles)
        {
            var intersect = triangle.Intersection(ray);
            if(intersect is null) continue;
            if(res is null ||
               res_len > (intersect.Value - ray.Start).LengthSqr)
            {
                res = intersect;
                res_len = (intersect.Value - ray.Start).LengthSqr;
            }
        }
        return res;
    }

    public override Vector3? NormalInIntersection(Ray ray)
    {
        Vector3? res = null;
        Vector3? normal = null;
        double res_len = 0;
        foreach(var triangle in triangles)
        {
            var intersect = triangle.Intersection(ray);
            if(intersect is null) continue;
            if(res is null ||
               res_len > (intersect.Value - ray.Start).LengthSqr)
            {
                res = intersect;
                res_len = (intersect.Value - ray.Start).LengthSqr;
                normal = triangle.NormalInIntersection(ray);
            }
        }
        return normal;        
    }

    public override void Translate(Vector3 on)
    {
        base.Translate(on);
        foreach(var triangle in triangles)
            triangle.Translate(on);
    }

    private Triangle[] triangles;
    private const int FacesCount = 6;
}