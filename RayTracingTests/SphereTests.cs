namespace RayTracingTests;

public class SphereTests
{
    [Test]
    public void Intersection_RayDontIntersectSphere_ReturnsNull()
    {
        Sphere sphere = new Sphere { Position = Vector3.Zero, Radius = 1 };
        Ray ray = new Ray(new Vector3(-10, 0, 0), new Vector3(0, 1, 0));

        Assert.IsNull(sphere.Intersection(ray));
    }
    [Test]
    public void Intersection_IntersectSphere_ReturnNearestPoint()
    {
        Sphere sphere = new Sphere { Position = Vector3.Zero, Radius = 1 };
        Ray ray = new Ray(new Vector3(-10, 0, 0), new Vector3(1, 0, 0));

        Assert.That(
            sphere.Intersection(ray), Is.EqualTo(new Vector3(-1, 0, 0))
        );
    }    
    [Test]
    public void Intersection_TouchSphere_ReturnCorrectPoint()
    {
        Sphere sphere = new Sphere { Position = Vector3.Zero, Radius = 1 };
        Ray ray = new Ray(new Vector3(-1, -10, 0), new Vector3(0, 1, 0));

        Assert.That(
            sphere.Intersection(ray), Is.EqualTo(new Vector3(-1, 0, 0))
        );
    }

    
    [Test]
    public void NormalInIntersection_RayDontIntersectSphere_ReturnsNull()
    {
        Sphere sphere = new Sphere { Position = new Vector3(5, 6, 7)
                                   , Radius = 1 };
        Ray ray = new Ray(new Vector3(-10, 0, 0), new Vector3(0, 1, 0));

        Assert.IsNull(sphere.NormalInIntersection(ray));
    }
    [Test]
    public void NormalInIntersection_IntersectSphere_ReturnNearestPoint()
    {
        Sphere sphere = new Sphere { Position = new Vector3(5, 6, 7)
                                   , Radius = 1 };
        Ray ray = new Ray(new Vector3(-10, 6, 7), new Vector3(1, 0, 0));

        Assert.That(sphere.NormalInIntersection(ray), 
                    Is.EqualTo(new Vector3(-1, 0, 0)));
    }    
    [Test]
    public void NormalInIntersection_TouchSphere_ReturnCorrectPoint()
    {
        Sphere sphere = new Sphere { Position = new Vector3(5, 6, 7)
                                   , Radius = 1 };
        Ray ray = new Ray(new Vector3(4, -10, 7), new Vector3(0, 1, 0));

        Assert.That(sphere.NormalInIntersection(ray),
                    Is.EqualTo(new Vector3(-1, 0, 0)));
    }
}
