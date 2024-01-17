namespace RayTracingTests;

public class TriangleTests
{
    [Test]
    public void Intersection_RayDontIntersectTriangle_ReturnsNull()
    {
        var tr = new Triangle(new Vector3(1, 0, 0),
                              new Vector3(-1, 0, 0),
                              new Vector3(0, 1, 0));
        var ray = new Ray(new Vector3(0, 2, -5),
                          new Vector3(0, 0, 1));

        Assert.IsNull(tr.Intersection(ray));
    }
    [Test]
    public void Intersection_IntersectSphere_ReturnNearestPoint()
    {
        var tr = new Triangle(new Vector3(1, 0, 0),
                              new Vector3(-1, 0, 0),
                              new Vector3(0, 1, 0));
        var ray = new Ray(new Vector3(0, 0.5, -5),
                          new Vector3(0, 0, 1));


        Assert.That(
            tr.Intersection(ray), Is.EqualTo(new Vector3(0, 0.5, 0))
        );
    }

    
    [Test]
    public void NormalInIntersection_RayDontIntersectSphere_ReturnsNull()
    {
        var tr = new Triangle(new Vector3(1, 0, 0),
                              new Vector3(-1, 0, 0),
                              new Vector3(0, 1, 0));
        var ray = new Ray(new Vector3(0, 2, -5),
                          new Vector3(0, 0, 1));

        Assert.IsNull(tr.NormalInIntersection(ray));
    }
    [Test]
    public void NormalInIntersection_IntersectSphere_ReturnNearestPoint()
    {
        var tr = new Triangle(new Vector3(1, 4, 0),
                              new Vector3(-1, 4, 0),
                              new Vector3(0, 5, 0));
        var ray = new Ray(new Vector3(0, 4.5, -5),
                          new Vector3(0, 0, 1));


        Assert.That(
            tr.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, -1))
        );
    }
}
