namespace RayTracing;

public class Camera
{
    public Vector3 Position { get; set; } = new Vector3();
    public Vector3 ViewPoint { get; set; } = new Vector3(0, 0, 1);
    public Vector3 Up { get; set; } = new Vector3(0, 1, 0);

    public double FieldOfView { get; set; } = 90;
    public double Aspect { get; set; } = 16.0 / 9.0;
}
