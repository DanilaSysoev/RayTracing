using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using RayTracing;
using SixLabors.ImageSharp;

namespace RayTracingUI;

public partial class MainWindow : Window
{
    public Scene Scene { get; private set; } = null!;
    public Tracer Tracer { get; private set; } = null!;

    public MainWindow()
    {
        InitializeComponent();
        Scene = new Scene();

        camera.MainWindow = this;
        models.MainWindow = this;
        lights.MainWindow = this;
        lights.FillAmbient();

        Setup();
        Redraw();
    }

    private void Setup()
    {
        Scene.Camera = camera.Camera;
        Tracer = new Tracer { Scene = Scene,
                              Width = 480,
                              Height = 270 };
    }

    private void RenderClick(object sender, RoutedEventArgs e)
    {
        var tracer = new Tracer { Scene = Scene,
                                  Width = GetValue(DefaultWidth, renderWidth),
                                  Height = GetValue(DefaultHeight, renderHeight),
                                  Depth = 4,
                                  SplittingHeight = 20,
                                  SplittingWidth = 40 };
        tracer.Render().SaveAsPng("output/render.png");
    }

    public void Redraw()
    {
        var img = Tracer.Render();
        img.SaveAsPng("output/.screen.png");
        ImageBrush brush = new ImageBrush(new Bitmap("output/.screen.png"));
        canvas.Background = brush;
    }

    public const int DefaultWidth = 1920;
    public const int DefaultHeight = 1080;

    private int GetValue(int defaultValue, TextBox textBox)
    {
        int val = 0;
        if (int.TryParse(textBox.Text,
                         System.Globalization.NumberStyles.Number,
                         System.Globalization.NumberFormatInfo.InvariantInfo, 
                         out val) && val > 0 && val < 10000)
            return val;
        else
            textBox.Text = defaultValue.ToString();
        return defaultValue;
    }
}