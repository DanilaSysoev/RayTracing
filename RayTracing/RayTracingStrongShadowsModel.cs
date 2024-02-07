namespace RayTracing;

public class RayTracingStrongShadowsModel : ILightModel
{
    public Vector3 CalculateColor(
        Vector3 point,
        Vector3 normal,
        Material material,
        Scene scene
    ) {
        Vector3 color = new Vector3();
        foreach (var light in scene.Lights)
        {
            if (PointIsIlluminated(point, light, scene))
            {
                var rayToLight = new Ray(point, light.GetDirectionFrom(point));
                var cameraDirection = (scene.Camera.Position - point).Normalize();
                var reflDir = -rayToLight.Reflect(point, normal).Direction;
                color += material.Diffuse * light.Diffuse *
                         normal.Dot(rayToLight.Direction);
                color += material.Specular * light.Specular *
                         Math.Pow(cameraDirection.Dot(reflDir), material.Shininess);
            }
        }
        return new Vector3();
    }

    private bool PointIsIlluminated(Vector3 point, Light light, Scene scene)
    {
        var rayToLight = new Ray(point, light.GetDirectionFrom(point));
        var intersectInfo = scene.GetNearestIntersection(rayToLight);
        return intersectInfo.IsMiss ||
               intersectInfo.Distance > light.GetDistanceFrom(point);
    }
}