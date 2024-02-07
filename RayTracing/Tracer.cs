namespace RayTracing;

public class Tracer
{
    public Scene Scene { get; set; } = new Scene();
    public ILightModel LightModel { get; set; }
         = new RayTracingStrongShadowsModel();
    public int Depth { get; set; } = 1;

    public int Width { get; set; } = 600;
    public int Height { get; set; } = 400;

    public void Render()
    {
    }
}