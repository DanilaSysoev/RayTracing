using RayTracing;
using SixLabors.ImageSharp;

Model box = Model.Build(ModelConfig.FromJson("data/cube_1.json")!);
Model floor = Model.Build(ModelConfig.FromJson("data/floor.json")!);
Model sphere = Model.Build(ModelConfig.FromJson("data/glass_sphere.json")!);
Model red_sphere = Model.Build(ModelConfig.FromJson("data/red_sphere.json")!);

var mat = MaterialLoader.LoadMaterial("data/red_sphere.mtl");
mat.Absorption = red_sphere.Material.Absorption;
mat.Color = red_sphere.Material.Color;
mat.Reflectivity = red_sphere.Material.Reflectivity;
mat.Refractivity = red_sphere.Material.Refractivity;
mat.Transparency = red_sphere.Material.Transparency;
red_sphere.Material = mat;

Scene scene = new Scene { AmbientLight = new Vector3(.6, .6, .6),
                          Camera = new Camera { Position = new Vector3(0, .75, -6), 
                                                ViewPoint = new Vector3(0, 0, 10),
                                                Up = new Vector3(0, 16, .75).Normalized,
                                                Aspect = 2 / 1.0 } };
//scene.AddModel(box);
scene.AddModel(floor);
//scene.AddModel(sphere);
scene.AddModel(red_sphere);

// scene.AddLight(new DirectionLight(new Vector3(1, 1, 1),
//                                   new Vector3(.7, .7, .7),
//                                   new Vector3(1, -1, -1)));

scene.AddLight(new PointLight(new Vector3(1, 1, 1),
                              new Vector3(.7, .7, .7),
                              new Vector3(4, 4, -4)));

floor.Mesh.Translate(new Vector3(0, -2.01, 0));
floor.Mesh.Scale(Axis.X, 200);
floor.Mesh.Scale(Axis.Z, 200);

red_sphere.Mesh.Translate(new Vector3(3, .5, 2));

box.Mesh.Translate(new Vector3(-1, 0, 4));

var image = new Tracer { Depth = 4,
                         Scene = scene }.Render();

image.SaveAsPng("output/image.png");
image.Dispose();
