namespace RayTracing;

public class Scene
{
    public IReadOnlyCollection<Model> Models => _models;
    public IReadOnlyCollection<Light> Lights => _lights;

    public Camera Camera { get; private set; }
    public Vector3 AmbientLight { get; private set; }

    public Scene(Camera camera, Vector3 ambientLight)
    {
        _models = new List<Model>();
        _lights = new List<Light>();

        Camera = camera;
        AmbientLight = ambientLight;
    }

    public void AddModel(Model model) => _models.Add(model);
    public bool RemoveModel(Model model) => _models.Remove(model);

    public void AddLight(Light light) => _lights.Add(light);
    public bool RemoveLight(Light light) => _lights.Remove(light);

    private List<Model> _models;
    private List<Light> _lights;
}