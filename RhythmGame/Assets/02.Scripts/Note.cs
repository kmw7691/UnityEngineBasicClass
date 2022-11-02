using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum HitType
{
    None,
    Bad,
    Miss,
    Good,
    Great,
    Cool
}


public class Note : MonoBehaviour
{
    public void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.None:
                break;
            case HitType.Bad:
                break;
            case HitType.Miss:
                break;
            case HitType.Good:
                break;
            case HitType.Great:
                break;
            case HitType.Cool:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    { 
        transform.position += Vector3.down * Time.fixedDeltaTime;
    }
}
