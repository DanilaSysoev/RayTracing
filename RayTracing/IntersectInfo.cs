namespace RayTracing;

public class IntersectInfo
{
    public Triangle? Triangle { get; set; }
    public Vector3? Point { get; set; }
    public Vector3? Normal { get; set; }
    public TextureUV? TextureUV { get; set; }
}