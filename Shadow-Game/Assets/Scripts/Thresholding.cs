using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresholding : MonoBehaviour
{
    Texture2D img;
    Color[] pixels;
    public float thresh = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Color transparent = new Color(1, 1, 1, 0);
        img = GetComponent<SpriteRenderer>().sprite.texture;
        pixels = img.GetPixels();
        for(int i = 0; i < pixels.Length; i++)
        {
            if(pixels[i].grayscale >= thresh)
                pixels[i] = transparent;
            else
                pixels[i] = Color.white;
        }
        img.SetPixels(pixels);
        img.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
