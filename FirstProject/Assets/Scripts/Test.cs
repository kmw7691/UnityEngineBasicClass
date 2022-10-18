using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int Num;

    /// <summary>
    /// script instance�� ó�� load�ɶ� �ѹ� ȣ��
    /// (script instance : game object�� ���� script)
    /// load�Ǵ� �ñ�� �ش� script instance�� �������ִ� gameobject�� ó�� �����ɶ�
    /// script instance�� Ȱ��/��Ȱ�� ������ ������� ȣ��
    /// </summary>
    private void Awake()
    {
        Debug.Log("[Test] : Awake");
    }

    /// <summary>
    /// script instance �� Ȱ��ȭ �ɶ����� ȣ��
    /// �ش� script instance �� �������ִ� gameobject�� Ȱ��/��Ȱ��ȭ �ɶ��� ������ ����
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("[Test] : OnEnable");
    }

    /// <summary>
    /// script�� gameobject�� ���϶� ó�� ȣ���
    /// script instance �� ��� �������� �ʱ�ȭ����
    /// inspector â���� �������� ȣ���� �� ����
    /// </summary>
    private void Reset()
    {
        Debug.Log("[Test] : Reset");
    }

    /// <summary>
    /// update�Լ��� ȣ��Ǳ� ���� �ѹ� ����Ǵ� �Լ�
    /// </summary>
    private void Start()
    {
        Debug.Log("[Test] : Start");
    }

    /// <summary>
    /// ���ӷ��� �� �����Ӹ��� ȣ��Ǵ� �Լ�
    /// </summary>
    private void Update()
    {
        Debug.Log("[Test] : Update");
    }

    /// <summary>
    /// ���ӷ��� �� �����Ӹ��� �������� ȣ��Ǵ� �Լ�
    /// </summary>
    private void LateUpdate()
    {
        Debug.Log("[Test] : LateUpdate");
    }

    /// <summary>
    /// ���������� ���� �����Ӹ��� ȣ��Ǵ� �Լ�
    /// </summary>
    private void FixedUpdate()
    {
        Debug.Log("[Test] : FixedUpdate");
    }

    /// <summary>
    /// Editor���� Gizmo(�����ͻ��� �׷������� ��ҵ�) ���� �׸��� ȣ��Ǵ� �Լ�
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }

    /// <summary>
    /// ���ø����̼�
    /// </summary>
    private void OnGUI()
    {
        Event e = Event.current;
        Debug.Log(e.mousePosition);
    }

    /// <summary>
    /// ���÷����̼��� �Ͻ������ɶ� ȣ��
    /// </summary>
    private void OnApplicationPause(bool pause)
    {
        Debug.Log($"[Test] : pause = {pause}");
    }

    /// <summary>
    /// ���ø����̼��� ����ɶ� ȣ��
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("[Test] : application quit");
    }

    /// <summary>
    /// script instance�� ��Ȱ��ȭ �ɶ� ���� ȣ��
    /// </summary>
    private void OnDisable()
    {
        Debug.Log("[Test] : disabled");
    }

    /// <summary>
    /// �ı��ɶ� ȣ��
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log("[Test] : Destroyed");
    }
}
