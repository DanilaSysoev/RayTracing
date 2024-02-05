namespace RayTracing;

public class RayTests
{
    [TestCase(-1, -1, -1)]
    [TestCase(-1, 0, -1)]
    [TestCase(-1, 1, -1)]
    [TestCase(-1, 2, -1)]
    [TestCase(-1, 3, -1)]
    [TestCase(0, 3, -1)]
    [TestCase(1, 3, -1)]
    [TestCase(2, 3, -1)]
    [TestCase(3, 3, -1)]
    [TestCase(3, 2, -1)]
    [TestCase(3, 1, -1)]
    [TestCase(3, 0, -1)]
    [TestCase(3, -1, -1)]
    [TestCase(2, -1, -1)]
    [TestCase(1, -1, -1)]
    [TestCase(0, -1, -1)]

    [TestCase(0, 0, -1)]
    [TestCase(0, 1, -1)]
    [TestCase(0, 2, -1)]
    [TestCase(1, 2, -1)]
    [TestCase(1, 1, -1)]
    [TestCase(1, 0, -1)]
    [TestCase(2, 0, -1)]
    [TestCase(2, 1, -1)]
    [TestCase(2, 2, -1)]

    [TestCase(-1, -1, 0)]
    [TestCase(-1, 0,  0)]
    [TestCase(-1, 1,  0)]
    [TestCase(-1, 2,  0)]
    [TestCase(-1, 3,  0)]
    [TestCase(0, 3,   0)]
    [TestCase(1, 3,   0)]
    [TestCase(2, 3,   0)]
    [TestCase(3, 3,   0)]
    [TestCase(3, 2,   0)]
    [TestCase(3, 1,   0)]
    [TestCase(3, 0,   0)]
    [TestCase(3, -1,  0)]
    [TestCase(2, -1,  0)]
    [TestCase(1, -1,  0)]
    [TestCase(0, -1,  0)]
    
    [TestCase(-1, -1, 1)]
    [TestCase(-1, 0,  1)]
    [TestCase(-1, 1,  1)]
    [TestCase(-1, 2,  1)]
    [TestCase(-1, 3,  1)]
    [TestCase(0, 3,   1)]
    [TestCase(1, 3,   1)]
    [TestCase(2, 3,   1)]
    [TestCase(3, 3,   1)]
    [TestCase(3, 2,   1)]
    [TestCase(3, 1,   1)]
    [TestCase(3, 0,   1)]
    [TestCase(3, -1,  1)]
    [TestCase(2, -1,  1)]
    [TestCase(1, -1,  1)]
    [TestCase(0, -1,  1)]

    [TestCase(-1, -1, 2)]
    [TestCase(-1, 0,  2)]
    [TestCase(-1, 1,  2)]
    [TestCase(-1, 2,  2)]
    [TestCase(-1, 3,  2)]
    [TestCase(0, 3,   2)]
    [TestCase(1, 3,   2)]
    [TestCase(2, 3,   2)]
    [TestCase(3, 3,   2)]
    [TestCase(3, 2,   2)]
    [TestCase(3, 1,   2)]
    [TestCase(3, 0,   2)]
    [TestCase(3, -1,  2)]
    [TestCase(2, -1,  2)]
    [TestCase(1, -1,  2)]
    [TestCase(0, -1,  2)]

    [TestCase(-1, -1, 3)]
    [TestCase(-1, 0,  3)]
    [TestCase(-1, 1,  3)]
    [TestCase(-1, 2,  3)]
    [TestCase(-1, 3,  3)]
    [TestCase(0, 3,   3)]
    [TestCase(1, 3,   3)]
    [TestCase(2, 3,   3)]
    [TestCase(3, 3,   3)]
    [TestCase(3, 2,   3)]
    [TestCase(3, 1,   3)]
    [TestCase(3, 0,   3)]
    [TestCase(3, -1,  3)]
    [TestCase(2, -1,  3)]
    [TestCase(1, -1,  3)]
    [TestCase(0, -1,  3)]

    [TestCase(0, 0, 3)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 3)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(2, 0, 3)]
    [TestCase(2, 1, 3)]
    [TestCase(2, 2, 3)]
    public void Intersect_IntersectsBoundingBox_ReturnTrue(
        double rsx, double rsy, double rsz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = new Vector3(1, 1, 1) - pos;

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.True(ray.Intersect(bb));
    }

    [TestCase(-1, -1, -1)]
    [TestCase(-1, 0, -1)]
    [TestCase(-1, 1, -1)]
    [TestCase(-1, 2, -1)]
    [TestCase(-1, 3, -1)]
    [TestCase(0, 3, -1)]
    [TestCase(1, 3, -1)]
    [TestCase(2, 3, -1)]
    [TestCase(3, 3, -1)]
    [TestCase(3, 2, -1)]
    [TestCase(3, 1, -1)]
    [TestCase(3, 0, -1)]
    [TestCase(3, -1, -1)]
    [TestCase(2, -1, -1)]
    [TestCase(1, -1, -1)]
    [TestCase(0, -1, -1)]

    [TestCase(0, 0, -1)]
    [TestCase(0, 1, -1)]
    [TestCase(0, 2, -1)]
    [TestCase(1, 2, -1)]
    [TestCase(1, 1, -1)]
    [TestCase(1, 0, -1)]
    [TestCase(2, 0, -1)]
    [TestCase(2, 1, -1)]
    [TestCase(2, 2, -1)]

    [TestCase(-1, -1, 0)]
    [TestCase(-1, 0,  0)]
    [TestCase(-1, 1,  0)]
    [TestCase(-1, 2,  0)]
    [TestCase(-1, 3,  0)]
    [TestCase(0, 3,   0)]
    [TestCase(1, 3,   0)]
    [TestCase(2, 3,   0)]
    [TestCase(3, 3,   0)]
    [TestCase(3, 2,   0)]
    [TestCase(3, 1,   0)]
    [TestCase(3, 0,   0)]
    [TestCase(3, -1,  0)]
    [TestCase(2, -1,  0)]
    [TestCase(1, -1,  0)]
    [TestCase(0, -1,  0)]
    
    [TestCase(-1, -1, 1)]
    [TestCase(-1, 0,  1)]
    [TestCase(-1, 1,  1)]
    [TestCase(-1, 2,  1)]
    [TestCase(-1, 3,  1)]
    [TestCase(0, 3,   1)]
    [TestCase(1, 3,   1)]
    [TestCase(2, 3,   1)]
    [TestCase(3, 3,   1)]
    [TestCase(3, 2,   1)]
    [TestCase(3, 1,   1)]
    [TestCase(3, 0,   1)]
    [TestCase(3, -1,  1)]
    [TestCase(2, -1,  1)]
    [TestCase(1, -1,  1)]
    [TestCase(0, -1,  1)]

    [TestCase(-1, -1, 2)]
    [TestCase(-1, 0,  2)]
    [TestCase(-1, 1,  2)]
    [TestCase(-1, 2,  2)]
    [TestCase(-1, 3,  2)]
    [TestCase(0, 3,   2)]
    [TestCase(1, 3,   2)]
    [TestCase(2, 3,   2)]
    [TestCase(3, 3,   2)]
    [TestCase(3, 2,   2)]
    [TestCase(3, 1,   2)]
    [TestCase(3, 0,   2)]
    [TestCase(3, -1,  2)]
    [TestCase(2, -1,  2)]
    [TestCase(1, -1,  2)]
    [TestCase(0, -1,  2)]

    [TestCase(-1, -1, 3)]
    [TestCase(-1, 0,  3)]
    [TestCase(-1, 1,  3)]
    [TestCase(-1, 2,  3)]
    [TestCase(-1, 3,  3)]
    [TestCase(0, 3,   3)]
    [TestCase(1, 3,   3)]
    [TestCase(2, 3,   3)]
    [TestCase(3, 3,   3)]
    [TestCase(3, 2,   3)]
    [TestCase(3, 1,   3)]
    [TestCase(3, 0,   3)]
    [TestCase(3, -1,  3)]
    [TestCase(2, -1,  3)]
    [TestCase(1, -1,  3)]
    [TestCase(0, -1,  3)]

    [TestCase(0, 0, 3)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 3)]
    [TestCase(1, 2, 3)]
    [TestCase(1, 1, 3)]
    [TestCase(1, 0, 3)]
    [TestCase(2, 0, 3)]
    [TestCase(2, 1, 3)]
    [TestCase(2, 2, 3)]
    public void Intersect_NotIntersectsBoundingBox_ReturnTrue(
        double rsx, double rsy, double rsz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = pos - new Vector3(1, 1, 1);

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.False(ray.Intersect(bb));
    }

    [TestCase(-1, -1, -1, 0, 1, 0)]
    [TestCase(-1, -1, -1, 1, 0, 0)]
    [TestCase(-1, -1, -1, 0, 0, 1)]
    public void Intersect_NotIntersectsParallelBox_ReturnTrue(
        double rsx, double rsy, double rsz,
        double rdx, double rdy, double rdz
    )
    {
        BoundingBox bb = new BoundingBox();
        bb.Update(new Vector3(2, 2, 2));
        bb.Update(new Vector3(0, 0, 0));

        var pos = new Vector3(rsx, rsy, rsz);
        var dir = new Vector3(rdx, rdy, rdz);

        var ray = new Ray(
            new Vector3(rsx, rsy, rsz),
            dir.Normalize()
        );

        Assert.False(ray.Intersect(bb));
    }
}