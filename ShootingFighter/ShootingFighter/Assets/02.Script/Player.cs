using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;

    private float _hp;

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

            _hp = value;
            _hpBar.value = _hp / _hpMax;

            if (_hp <= 0)
                Destroy(gameObject);
        }
    }

    [SerializeField] private float _hpMax = 50.0f;
    [SerializeField] private Slider _hpBar;

    public void Hurt(float damage)
    {
        Hp -= damage;
    }

    private void Awake()
    {
        Hp = _hpMax;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //gameobject의 layer 프로퍼티는 flag값이 아님 유의
    //    //그래서 구조체 targetlayer의 value와 비교하려면
    //    //flag값으로 바꿔주기 위해서 bit-shift 연산을 해야함
    //    if ((1 << other.gameObject.layer & _targetLayer) > 0)
    //    {
    //        if (other.gameObject.TryGetComponent<Player>(out Player player))
    //        {
    //            player.Hurt(10.0f);
    //        }

    //        Destroy(gameObject);
    //    }
    //}
}
