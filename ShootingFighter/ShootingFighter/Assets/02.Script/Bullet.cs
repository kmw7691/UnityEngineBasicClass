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
     /// 다른 collider 컴포넌트와 rigid body  를 가지고잇는 게임오브젝트와 만났을때
     /// 다른 collider 의 trigger옵션이 true일때 해당 collider의 인자를 넘겨받는 이벤트 함수
     /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //gameobject의 layer 프로퍼티는 flag값이 아님 유의
        //그래서 구조체 targetlayer의 value와 비교하려면
        //flag값으로 바꿔주기 위해서 bit-shift 연산을 해야함
        if((1<<other.gameObject.layer & _targetLayer) > 0)
        {
            //out키워드
            //두개 이상의 함수 반환값이 필요할때 사용
            //out인자로 넘겨진 변수에 해당 함수 반환시 마지막으로 대입되었던 값이 반환된다
            if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Hurt(100.0f);
            }

           // other.gameObject.GetComponent<Enemy>().Hurt(100.0f);
            Destroy(gameObject);
        }

        //간단하게 테스트 해볼때 문자열로 레이어 검색해서 사용할 수 있음
        //if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        //{
            //Debug.Log(other.name);
        //}
    }

    /// <summary>
    /// 충돌대상이 rigid body를 가지고 있어야하고
    /// 그 대상의 collider의 collision옵션이 true이면 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
