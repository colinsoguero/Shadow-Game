using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    public static Webcam instance;
    public WebCamTexture webcamTexture;
    Color[] pixels;
    public GameObject spritePrefab;
    GameObject mySprite;
    public float thresh = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        //WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        // foreach(WebCamDevice device in devices)
        // {
        //     Debug.Log("Name: " + device.name);
        // }
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("pressed");
            TakeSnapshot();
        }
    }
    
    void TakeSnapshot()
    {
        if(mySprite)
            Destroy(mySprite);
        StartCoroutine(Delay());
    }

    void Threshold(Texture2D img)
    {
        Color transparent = new Color(1, 1, 1, 0);
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

    void MakeSprite()
    {
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();
        Threshold(snap);
        Sprite snapSprite = Sprite.Create(snap, new Rect(0, 0, snap.width, snap.height), new Vector2(0.5f, 0.5f), 100f);
        mySprite = Instantiate(spritePrefab);
        mySprite.GetComponent<SpriteRenderer>().sprite = snapSprite;
        mySprite.GetComponent<SpriteRenderer>().color = Color.black;
        mySprite.transform.localScale = Vector3.Scale(mySprite.transform.localScale, new Vector3(-1,1,1));
        mySprite.AddComponent<PolygonCollider2D>();
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.25f);
        MakeSprite();
    }

}
