namespace RayTracingTests;


class MeshIntersectionTests
{
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalUp_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.NotNull(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalDown_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.NotNull(id.Point);
    }

    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalUp_PNIsOk(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Normal, Is.EqualTo(new Vector3(0, 1, 0)));
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckIntersectionNormalDown_PNIsOk(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.That(id.Point, Is.EqualTo(sur_pos));
        Assert.That(id.Normal, Is.EqualTo(new Vector3(0, -1, 0)));
    }
    

    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_RayDirectOutIntersectionNormalUp_Intersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = pos - sur_pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, 1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_RayDirectOutIntersectionNormalDown_Intersect (
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = pos - sur_pos;
        var ray = new Ray(pos, dir);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(new Vector3(0, -1, 0));

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }


    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(   1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    1,
                 0,    0,    0)]
    [TestCase(   1,    1,    1,
                 0,    0,    0)]
    [TestCase(   2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    2,
                 0,    0,    0)]
    [TestCase(   2,    1,    2,
                 0,    0,    0)]
    [TestCase(   4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,    4,
                 0,    0,    0)]
    [TestCase(   4,    1,    4,
                 0,    0,    0)]
    [TestCase( 100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  100,
                 0,    0,    0)]
    [TestCase( 100,    1,  100,
                 0,    0,    0)]
    [TestCase(  .5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,    1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,    1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,    1,   .1,
                 0,    0,    0)]
    [TestCase( .01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  .01,
                 0,    0,    0)]
    [TestCase( .01,    1,  .01,
                 0,    0,    0)]
    
    [TestCase(   0,    1,    0,
                 0,    0,    0)]
    [TestCase(  -1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,    1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,    1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,    1,   -4,
                 0,    0,    0)]
    [TestCase(-100,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -100,
                 0,    0,    0)]
    [TestCase(-100,    1, -100,
                 0,    0,    0)]
    [TestCase( -.5,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,    1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,    1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,    1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,    1,    0,
                 0,    0,    0)]
    [TestCase(   0,    1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,    1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckReflectionIntersectionNormalUp_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, 1, 0);
        var ray = new Ray(pos, dir).Reflect(sur_pos, normal);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(   1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    1,
                 0,    0,    0)]
    [TestCase(   1,   -1,    1,
                 0,    0,    0)]
    [TestCase(   2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    2,
                 0,    0,    0)]
    [TestCase(   2,   -1,    2,
                 0,    0,    0)]
    [TestCase(   4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,    4,
                 0,    0,    0)]
    [TestCase(   4,   -1,    4,
                 0,    0,    0)]
    [TestCase( 100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  100,
                 0,    0,    0)]
    [TestCase( 100,   -1,  100,
                 0,    0,    0)]
    [TestCase(  .5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .5,   -1,   .5,
                 0,    0,    0)]
    [TestCase(  .3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .3,   -1,   .3,
                 0,    0,    0)]
    [TestCase(  .1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   .1,
                 0,    0,    0)]
    [TestCase(  .1,   -1,   .1,
                 0,    0,    0)]
    [TestCase( .01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  .01,
                 0,    0,    0)]
    [TestCase( .01,   -1,  .01,
                 0,    0,    0)]

    [TestCase(   0,   -1,    0,
                 0,    0,    0)]
    [TestCase(  -1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -1,   -1,   -1,
                 0,    0,    0)]
    [TestCase(  -2,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -2,   -1,   -2,
                 0,    0,    0)]
    [TestCase(  -4,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,   -4,
                 0,    0,    0)]
    [TestCase(  -4,   -1,   -4,
                 0,    0,    0)]
    [TestCase(-100,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -100,
                 0,    0,    0)]
    [TestCase(-100,   -1, -100,
                 0,    0,    0)]
    [TestCase( -.5,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.5,   -1,  -.5,
                 0,    0,    0)]
    [TestCase( -.3,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.3,   -1,  -.3,
                 0,    0,    0)]
    [TestCase( -.1,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1,  -.1,
                 0,    0,    0)]
    [TestCase( -.1,   -1,  -.1,
                 0,    0,    0)]
    [TestCase(-.01,   -1,    0,
                 0,    0,    0)]
    [TestCase(   0,   -1, -.01,
                 0,    0,    0)]
    [TestCase(-.01,   -1, -.01,
                 0,    0,    0)]
    public void Intersect_CheckReflectedIntersectionNormalDown_NotIntersect(
        double rpx, double rpy, double rpz,
        double spx, double spy, double spz
    ) {
        var pos = new Vector3(rpx, rpy, rpz);
        var sur_pos = new Vector3(spx, spy, spz);
        var dir = sur_pos - pos;
        var normal = new Vector3(0, -1, 0);
        var ray = new Ray(pos, dir).Reflect(sur_pos, normal);
        var mesh = new Mesh();
        mesh.AddVertex(new Vector3(1, 0, 0));
        mesh.AddVertex(new Vector3(0, 0, 1));
        mesh.AddVertex(new Vector3(-1, 0, -1));

        mesh.AddNormal(normal);

        mesh.AddFace(new Face { Va = 0, Vb = 1, Vc = 2, Na = 0, Nb = 0, Nc = 0});

        mesh.Translate(sur_pos);
        var id = mesh.Intersect(ray);

        Assert.Null(id.Point);
    }
}