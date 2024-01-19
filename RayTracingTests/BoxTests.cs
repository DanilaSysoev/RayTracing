namespace RayTracingTests;

class BoxTests
{
    [Test]
    public void Intersection_RayDontIntersectBox_ReturnsNull()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(0, 0, -100), new Vector3(0, 1, 1));

        Assert.IsNull(box.Intersection(ray));
    }
}