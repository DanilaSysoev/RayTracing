namespace RayTracing;

public class Scene
{
    public IReadOnlyCollection<Mesh> Meshes => _meshes;

    public Scene()
    {
        _meshes = new List<Mesh>();
    }

    public void AddSurface(Mesh surface) => _meshes.Add(surface);
    public bool RemoveSurface(Mesh surface) => _meshes.Remove(surface);

    private List<Mesh> _meshes;
}