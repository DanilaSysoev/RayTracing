namespace RayTracing;

public class Camera
{
    public Vector3 Position { get; set; } = new Vector3();
    public Vector3 ViewPoint { get; set; } = new Vector3(0, 0, 1);
    public Vector3 Up { get; set; } = new Vector3(0, 1, 0);

    public double FieldOfView { get; set; } = 90;
    public double Aspect { get; set; } = 16.0 / 9.0;

    public Screen GetScreen(int width, int height)
    {        
        var direction = (ViewPoint - Position).Normalized;
        var up = Up.Normalized;
        var right = direction.Cross(up);
        var center = Position + direction * ScreenDistance;
        var x = ScreenDistance * Math.Tan(FieldOfView * Math.PI / 360);
        var Rc = center + right * x;
        var Lc = center - right * x;
        var y = x / Aspect;
        var Lu = Lc + up * y;
        var Ld = Lc - up * y;
        var Ru = Rc + up * y;
        
        return new Screen
        {
            Width = width,
            Height = height,
            LeftUp = Lu,
            LeftDown = Ld,
            RightUp = Ru
        };
    }

    public const double ScreenDistance = 1.0;
}
