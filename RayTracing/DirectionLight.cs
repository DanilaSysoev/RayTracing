namespace RayTracing;

public class DirectionLight : Light
{
    public Vector3 Direction { get; set; }

    public DirectionLight(Vector3 diffusion,
                          Vector3 specular,
                          Vector3 direction)
        : base(diffusion, specular)
    {
        Direction = direction.Normalized;
    }

    public override Vector3 GetDirectionFrom(Vector3 point)
    {
        return -Direction;
    }

    public override double GetDistanceFrom(Vector3 point)
    {
        return double.PositiveInfinity;
    }
}