using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitter : MonoBehaviour
{
    public KeyCode Key;
    [SerializeField] private LayerMask _noteLayer;
    private SpriteRenderer _spriteRenderer;
    private Color _colorOrigin;
    [SerializeField] private Color _colorPressed;
    [SerializeField] private GameObject _spotlightEffect;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colorOrigin = _spriteRenderer.color;
    }

    private void Update()
    {
        if(Input.GetKeyDown(Key))
        {
            SetColorPressed();
        }
        if(Input.GetKeyUp(Key))
        {
            SetColorOrigin();
        }
    }

    private void SetColorPressed()
    {
        _spriteRenderer.color = _colorPressed;
    }

    private void SetColorOrigin()
    {
        _spriteRenderer.color = _colorOrigin;
    }
}
