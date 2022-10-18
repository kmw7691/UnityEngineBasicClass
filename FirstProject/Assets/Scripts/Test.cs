using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int Num;

    /// <summary>
    /// script instance가 처음 load될때 한번 호출
    /// (script instance : game object에 붙인 script)
    /// load되는 시기는 해당 script instance를 가지고있는 gameobject가 처음 생성될때
    /// script instance의 활성/비활성 유무와 관계없이 호출
    /// </summary>
    private void Awake()
    {
        Debug.Log("[Test] : Awake");
    }

    /// <summary>
    /// script instance 가 활성화 될때마다 호출
    /// 해당 script instance 를 가지고있는 gameobject가 활성/비활성화 될때도 영향을 받음
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("[Test] : OnEnable");
    }

    /// <summary>
    /// script를 gameobject에 붙일때 처음 호출됨
    /// script instance 의 멤버 변수들을 초기화해줌
    /// inspector 창에서 수동으로 호출할 수 있음
    /// </summary>
    private void Reset()
    {
        Debug.Log("[Test] : Reset");
    }

    /// <summary>
    /// update함수가 호출되기 전에 한번 실행되는 함수
    /// </summary>
    private void Start()
    {
        Debug.Log("[Test] : Start");
    }

    /// <summary>
    /// 게임로직 매 프레임마다 호출되는 함수
    /// </summary>
    private void Update()
    {
        Debug.Log("[Test] : Update");
    }

    /// <summary>
    /// 게임로직 매 프레임마다 마지막에 호출되는 함수
    /// </summary>
    private void LateUpdate()
    {
        Debug.Log("[Test] : LateUpdate");
    }

    /// <summary>
    /// 물리연산을 위한 프레임마다 호출되는 함수
    /// </summary>
    private void FixedUpdate()
    {
        Debug.Log("[Test] : FixedUpdate");
    }

    /// <summary>
    /// Editor에서 Gizmo(에디터상의 그래픽적인 요소들) 들을 그릴때 호출되는 함수
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }

    /// <summary>
    /// 어플리케이션
    /// </summary>
    private void OnGUI()
    {
        Event e = Event.current;
        Debug.Log(e.mousePosition);
    }

    /// <summary>
    /// 어플레케이션이 일시정지될때 호출
    /// </summary>
    private void OnApplicationPause(bool pause)
    {
        Debug.Log($"[Test] : pause = {pause}");
    }

    /// <summary>
    /// 어플리케이션이 종료될때 호출
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("[Test] : application quit");
    }

    /// <summary>
    /// script instance가 비활성화 될때 마다 호출
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("[Test] : disabled");
    }

    /// <summary>
    /// 파괴될때 호출
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("[Test] : Destroyed");
    }
}
