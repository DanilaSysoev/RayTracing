namespace RayTracing;

public class PointLight : Light
{
    public Vector3 Position { get; set; }

    public PointLight(Vector3 diffusion,
                      Vector3 specular,
                      Vector3 position)
        : base(diffusion, specular)
    {
        Position = position;
    }

    public override Vector3 GetDirectionFrom(Vector3 point)
    {
        return (Position - point).Normalize();
    }

    public override double GetDistanceFrom(Vector3 point)
    {
        return (Position - point).Length;
    }
}