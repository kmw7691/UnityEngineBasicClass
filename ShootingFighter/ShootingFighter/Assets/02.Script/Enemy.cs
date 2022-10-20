using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private float _hp;
    
    
    //프로퍼티 property
    //c#에서 필드의 캡슐화를 위한 문법
    // get set접근자를 제공해서 값을 읽거나 쓸때
    //캡슐화 : 캡슐알약처럼 잘못된 접근을막거나 접근시 특별한 연산을 수행하도록 만드는 작업
    public float Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            if (value < 0)
                value = 0;
            Hp = value;

            if (_hp == 0)
                Destroy(gameObject);
        }
    }
    [SerializeField] private float _hpmax = 100.0f;

    public void Hurt(float damage)
    {
        Hp -= damage;
    }

    private void Awake()
    {
        Hp = _hpmax;
    }
}
