using RayTracing;
using SixLabors.ImageSharp;

// Model box = Model.Build(ModelConfig.FromJson("data/cube_1.json")!);
// Model floor = Model.Build(ModelConfig.FromJson("data/floor.json")!);
// Model sphere = Model.Build(ModelConfig.FromJson("data/glass_sphere.json")!);
Model red_sphere = Model.Build(ModelConfig.FromJson("data/red_sphere.json")!);

var mat = MaterialLoader.LoadMaterial("data/red_sphere.mtl");
mat.Absorption = red_sphere.Material.Absorption;
mat.Color = red_sphere.Material.Color;
mat.Reflectivity = red_sphere.Material.Reflectivity;
mat.Refractivity = red_sphere.Material.Refractivity;
mat.Transparency = red_sphere.Material.Transparency;
red_sphere.Material = mat;

var camera = new Camera { Position = new Vector3(-3, 1.1, 0), 
                          ViewPoint = new Vector3(10, 0, 0),
                          Up = new Vector3(1.1, 3, 0).Normalized,
                          Aspect = 1 / 1.0 };

Scene scene = new Scene { AmbientLight = new Vector3(.6, .6, .6),
                          Camera = camera };
// scene.AddModel(box);
// scene.AddModel(floor);
//scene.AddModel(sphere);
scene.AddModel(red_sphere);

// scene.AddLight(new DirectionLight(new Vector3(1, 1, 1),
//                                   new Vector3(.7, .7, .7),
//                                   new Vector3(1, -1, -1)));

scene.AddLight(new PointLight(new Vector3(1, 1, 1),
                              new Vector3(.7, .7, .7),
                              new Vector3(4, 4, -4)));

// floor.Mesh.Translate(new Vector3(0, -2.01, 0));
// floor.Mesh.Scale(Axis.X, 200);
// floor.Mesh.Scale(Axis.Z, 200);

// red_sphere.Mesh.Translate(new Vector3(3, .5, 2));

// box.Mesh.Translate(new Vector3(3, .5, 2));

var tracer = new Tracer { Depth = 4,
                          Scene = scene,
                          Width = 400,
                          Height = 400 };

var i = tracer.Render();
i.SaveAsPng("output/i.png");
i.Dispose();

// camera.MoveForward(2);
// var i_left = tracer.Render();
// i_left.SaveAsPng("output/i_mf.png");
// i_left.Dispose();

// camera.MoveBackward(2);
// var i2 = tracer.Render();
// i2.SaveAsPng("output/i2.png");
// i2.Dispose();

// camera.MoveBackward(4);
// var i_right = tracer.Render();
// i_right.SaveAsPng("output/i_mb.png");
// i_right.Dispose();

// camera.MoveForward(4);
// var i3 = tracer.Render();
// i3.SaveAsPng("output/i3.png");
// i3.Dispose();
