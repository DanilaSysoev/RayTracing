using System.Drawing;
using RayTracing.Exceptions;

namespace RayTracing;

public class Material
{
    public string Name { get; set; } = "";
    public Vector3 Diffuse { get; set; } = new Vector3();
    public Vector3 Specular { get; set; } = new Vector3();
    public double Shininess { get; set; } = 0.0;
    public double Reflectivity { get; set; } = 0.0;
    public double Refractivity { get; set; } = 0.0;
    public double Transparency => 1.0 - Reflectivity;
    public Vector3? Ambient { get; set; } = null;
    public Texture? Texture { get; set; } = null;

    public Vector3 GetColor(TextureUV uv) => GetColor(uv.U, uv.V);
    public Vector3 GetColor(double u, double v)
    {
        if (Texture is not null)
           return Texture.GetColor(u, v);
        else if (Ambient is not null)
           return Ambient;
        throw new MaterialException(
            $"Material {Name} has no texture or ambient color"
        );
    }
}