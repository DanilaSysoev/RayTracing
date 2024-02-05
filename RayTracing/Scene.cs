namespace RayTracing;

public class Scene
{
    public IReadOnlyCollection<ISurface> Surfaces => _surfaces;

    public Scene()
    {
        _surfaces = new List<ISurface>();
    }

    public void AddSurface(ISurface surface) => _surfaces.Add(surface);
    public bool RemoveSurface(ISurface surface) => _surfaces.Remove(surface);   


    private List<ISurface> _surfaces;
}