using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
class DM02Bridge : MonoBehaviour
{
    private void Start()
    {
        Sphere sphere = new Sphere();
        sphere.Draw();
    }
}

public class Sphere
{
    public string name = "Sphere";
    public OpenGL openGL = new OpenGL();

    public void Draw()
    {
        openGL.Render(name);
    }
}

public class OpenGL
{
    public void Render(string name)
    {
        Debug.Log("OpenGL绘制出来了：" + name);
    }
}