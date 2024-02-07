namespace RayTracing;

public abstract class Light
{
    public Vector3 Diffuse { get; set; }
    public Vector3 Specular { get; set; }

    public Light(Vector3 diffuse, Vector3 specular)
    {
        Diffuse = diffuse;
        Specular = specular;
    }

    public abstract Vector3 GetDirectionFrom(Vector3 point);
    public abstract double GetDistanceFrom(Vector3 point);
}