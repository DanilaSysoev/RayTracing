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
    [Test]
    public void Intersection_RayIntersectBoxFrontLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 1, -100), new Vector3(0, 0, 1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, 1, -3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxFrontRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 1, -100), new Vector3(0, 0, 1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, 1, -3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxFrontLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -1, -100), new Vector3(0, 0, 1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, -1, -3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxFrontRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -1, -100), new Vector3(0, 0, 1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, -1, -3)));
    }

    [Test]
    public void Intersection_RayIntersectBoxBackLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 1, 100), new Vector3(0, 0, -1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, 1, 3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBackRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 1, 100), new Vector3(0, 0, -1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, 1, 3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBackLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -1, 100), new Vector3(0, 0, -1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, -1, 3)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBackRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -1, 100), new Vector3(0, 0, -1));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, -1, 3)));
    }

    [Test]
    public void Intersection_RayIntersectBoxLeftLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, 1, 2), new Vector3(1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-1, 1, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxLeftRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, 1, -2), new Vector3(1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-1, 1, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxLeftLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, -1, 2), new Vector3(1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-1, -1, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxLeftRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, -1, -2), new Vector3(1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-1, -1, -2)));
    }

    [Test]
    public void Intersection_RayIntersectBoxRightLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, 1, 2), new Vector3(-1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(1, 1, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxRightRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, 1, -2), new Vector3(-1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(1, 1, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxRightLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, -1, 2), new Vector3(-1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(1, -1, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxRightRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, -1, -2), new Vector3(-1, 0, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(1, -1, -2)));
    }

    [Test]
    public void Intersection_RayIntersectBoxTopLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 100, -2), new Vector3(0, -1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, 2, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxTopRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 100, -2), new Vector3(0, -1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, 2, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxTopLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 100, 2), new Vector3(0, -1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, 2, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxTopRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 100, 2), new Vector3(0, -1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, 2, 2)));
    }

    [Test]
    public void Intersection_RayIntersectBoxBottomLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -100, -2), new Vector3(0, 1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, -2, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBottomRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -100, -2), new Vector3(0, 1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, -2, -2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBottomLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -100, 2), new Vector3(0, 1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(.5, -2, 2)));
    }
    [Test]
    public void Intersection_RayIntersectBoxBottomRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -100, 2), new Vector3(0, 1, 0));

        Assert.That(box.Intersection(ray), Is.EqualTo(new Vector3(-.5, -2, 2)));
    }



    [Test]
    public void NormalInIntersection_RayDontIntersectBox_ReturnsNull()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(0, 0, -100), new Vector3(0, 1, 1));

        Assert.IsNull(box.NormalInIntersection(ray));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxFrontLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 1, -100), new Vector3(0, 0, 1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, -1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxFrontRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 1, -100), new Vector3(0, 0, 1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, -1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxFrontLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -1, -100), new Vector3(0, 0, 1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, -1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxFrontRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -1, -100), new Vector3(0, 0, 1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, -1)));
    }

    [Test]
    public void NormalInIntersection_RayIntersectBoxBackLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 1, 100), new Vector3(0, 0, -1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, 1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBackRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 1, 100), new Vector3(0, 0, -1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, 1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBackLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -1, 100), new Vector3(0, 0, -1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, 1)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBackRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -1, 100), new Vector3(0, 0, -1));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 0, 1)));
    }

    [Test]
    public void NormalInIntersection_RayIntersectBoxLeftLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, 1, 2), new Vector3(1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(-1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxLeftRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, 1, -2), new Vector3(1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(-1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxLeftLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, -1, 2), new Vector3(1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(-1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxLeftRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-100, -1, -2), new Vector3(1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(-1, 0, 0)));
    }

    [Test]
    public void NormalInIntersection_RayIntersectBoxRightLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, 1, 2), new Vector3(-1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxRightRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, 1, -2), new Vector3(-1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxRightLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, -1, 2), new Vector3(-1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(1, 0, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxRightRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(100, -1, -2), new Vector3(-1, 0, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(1, 0, 0)));
    }

    [Test]
    public void NormalInIntersection_RayIntersectBoxTopLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 100, -2), new Vector3(0, -1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxTopRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 100, -2), new Vector3(0, -1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxTopLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, 100, 2), new Vector3(0, -1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxTopRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, 100, 2), new Vector3(0, -1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, 1, 0)));
    }

    [Test]
    public void NormalInIntersection_RayIntersectBoxBottomLU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -100, -2), new Vector3(0, 1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, -1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBottomRU_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -100, -2), new Vector3(0, 1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, -1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBottomLD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(.5, -100, 2), new Vector3(0, 1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, -1, 0)));
    }
    [Test]
    public void NormalInIntersection_RayIntersectBoxBottomRD_ReturnsCorrect()
    {
        var box = new Box(Vector3.Zero, 2, 4, 6);
        var ray = new Ray(new Vector3(-.5, -100, 2), new Vector3(0, 1, 0));

        Assert.That(box.NormalInIntersection(ray), Is.EqualTo(new Vector3(0, -1, 0)));
    }
}