using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("[Test] : Awake");
    }

    private void OnEnable()
    {
        Debug.Log("[Test] : OnEnable");
    }
}
