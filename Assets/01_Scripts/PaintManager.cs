using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public Texture2D Textura;
    public Texture2D TexturaDePrueba;
    public int pixeles;
    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            PaintSquare(TexturaDePrueba.height, TexturaDePrueba.width);
        }
    }

    public void PaintSquare(int H, int W)
    {
        Color[] color = new Color[H * W];
        pixeles = 0;
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                color[pixeles] = TexturaDePrueba.GetPixel(i, j);
                //color[pixeles] = Color.black;
                pixeles++;
            }
        }
        Textura.SetPixels(100,100,H,W,color);
        Textura.Apply();
    }
}
