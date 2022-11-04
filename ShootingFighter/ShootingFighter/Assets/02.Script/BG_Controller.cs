using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Controller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        float newOffsetY = _material.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);

        _material.mainTextureOffset = newOffset;
    }
}