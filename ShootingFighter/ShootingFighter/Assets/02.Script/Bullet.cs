using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 20.0f;
    [SerializeField] private LayerMask _targetLayer;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.fixedDeltaTime);
    }

     /// <summary>
     /// 
     /// �ٸ� collider ������Ʈ�� rigid body  �� �������մ� ���ӿ�����Ʈ�� ��������
     /// �ٸ� collider �� trigger�ɼ��� true�϶� �ش� collider�� ���ڸ� �Ѱܹ޴� �̺�Ʈ �Լ�
     /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //gameobject�� layer ������Ƽ�� flag���� �ƴ� ����
        //�׷��� ����ü targetlayer�� value�� ���Ϸ���
        //flag������ �ٲ��ֱ� ���ؼ� bit-shift ������ �ؾ���
        if((1<<other.gameObject.layer & _targetLayer) > 0)
        {
            //outŰ����
            //�ΰ� �̻��� �Լ� ��ȯ���� �ʿ��Ҷ� ���
            //out���ڷ� �Ѱ��� ������ �ش� �Լ� ��ȯ�� ���������� ���ԵǾ��� ���� ��ȯ�ȴ�
            if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Hurt(100.0f);
            }

           // other.gameObject.GetComponent<Enemy>().Hurt(100.0f);
            Destroy(gameObject);
        }

        //�����ϰ� �׽�Ʈ �غ��� ���ڿ��� ���̾� �˻��ؼ� ����� �� ����
        //if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //{
            //Debug.Log(other.name);
        //}
    }

    /// <summary>
    /// �浹����� rigid body�� ������ �־���ϰ�
    /// �� ����� collider�� collision�ɼ��� true�̸� 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
