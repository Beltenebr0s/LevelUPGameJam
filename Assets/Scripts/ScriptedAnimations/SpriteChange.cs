using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite _sprite1, _sprite2;

    private SpriteRenderer _renderer;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    public void SetSprite1()
    {
        _renderer.sprite = _sprite1;
    }

    public void SetSprite2()
    {
        _renderer.sprite = _sprite2;
    }
}
