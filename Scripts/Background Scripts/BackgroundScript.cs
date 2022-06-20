using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public MeshRenderer meshRenderer;
    private float scroll;
    void Start()
    {
        
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        scroll = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(scroll, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
