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
    //    //gameobject�� layer ������Ƽ�� flag���� �ƴ� ����
    //    //�׷��� ����ü targetlayer�� value�� ���Ϸ���
    //    //flag������ �ٲ��ֱ� ���ؼ� bit-shift ������ �ؾ���
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
