using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Attibute
    //컴파일러에게 메타데이터를 제공해야 할때 필드/프로퍼티/클래스등의 앞에 명시해준다

    //SeriallizeField Attribute
    //유니티에디터의 인스펙터창에 해당 필드를 노출시키는 attribute
    [SerializeField]private float _moveSpeed;

    float _h, _v;
    Vector3 _dir;

    private void FixedUpdate()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _dir = new Vector3(_h, 0.0f, _v).normalized;
        transform.Translate(_dir * _moveSpeed * Time.fixedDeltaTime);
    }
}
