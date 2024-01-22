namespace RayTracing;

public class Screen
{
    public Vector3 LeftUp { get; set; }
    public Vector3 RightUp { get; set; }
    public Vector3 LeftDown { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public Vector3[,] Points => CalculatePoints();

    private Vector3[,] CalculatePoints()
    {
        var points = new Vector3[Height, Width];
        var lrDir = RightUp - LeftUp;
        var udDir = LeftDown - LeftUp;

        double lrStep = lrDir.Length / Width;
        double udStep = udDir.Length / Height;

        lrDir.Normalize();
        udDir.Normalize();

        for(int i = 0; i < Height; ++i) {
            for(int j = 0; j < Width; ++j) {
                points[i, j] = LeftUp
                             + ((i + .5) * udStep * udDir)
                             + ((j + .5) * lrStep * lrDir);
            }
        }

        return points;
    }
}
