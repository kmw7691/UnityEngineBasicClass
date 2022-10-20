using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    private float _hp;
    
    
    //������Ƽ property
    //c#���� �ʵ��� ĸ��ȭ�� ���� ����
    // get set�����ڸ� �����ؼ� ���� �аų� ����
    //ĸ��ȭ : ĸ���˾�ó�� �߸��� ���������ų� ���ٽ� Ư���� ������ �����ϵ��� ����� �۾�
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
