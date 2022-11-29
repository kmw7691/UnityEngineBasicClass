using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int _hp;
    public int Hp
    {
        get { return _hp; }

        set
        {
            if (value <= 0)
            {
                value = 0;
                OnHpMin?.Invoke();
            }

            else if (value < _hp)
            {
                OnHpDecrease?.Invoke();
            }

            _hp = value;
            _hpSlider.value = (float)value / _hpMax;
        }
    }
    
    [SerializeField] private int _hpMax;
    public event Action OnHpMin;
    public event Action OnHpDecrease;



    [SerializeField] private Slider _hpSlider;

    public int ATK;

    private void Awake()
    {
        Hp = _hpMax;
    }
}
