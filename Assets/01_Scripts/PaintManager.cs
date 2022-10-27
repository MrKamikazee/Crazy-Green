using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public Texture2D Textura;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            PaintSquare(200, 200);
        }
    }

    public void PaintSquare(int H, int W)
    {
        Color[] colores = new Color[H * W];
        for (int i = 0; i < H; i++)
        {
            colores[i] = Color.black;
        }
        Textura.SetPixels(100,100,H,W,colores);
        Textura.Apply();
    }
}
