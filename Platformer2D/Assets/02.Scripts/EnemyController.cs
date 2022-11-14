using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum States
    { 
        Idle,
        Move,
        Attack,
        Hurt,
        Die
    }

    public States Current;

    //animation
    private Animator _animator;
    private float _attackAnimTime;
    private float _hurtAnimTime;
    private float _dieAnimTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeState(UpdateState());
    }

    public bool ChangeState(States newState)
    {
        if (Current == newState)
            return false;

        bool result = false;

        switch (newState)
        {
            case States.Idle:
                result = CanIdle();
                break;
            case States.Move:
                result = CanMove();
                break;
            case States.Attack:
                result = CanAttack();
                break;
            case States.Hurt:
                result = CanHurt();
                break;
            case States.Die:
                result = CanDie(); 
                break;
            default:
                break;
        }

        if (result)
        {
            switch (newState)
            {
                case States.Idle:
                    Idle().Reset();
                    break;
                case States.Move:
                    Move().Reset();
                    break;
                case States.Attack:
                    Attack().Reset();
                    break;
                case States.Hurt:
                    Hurt().Reset(); 
                    break;
                case States.Die:
                    Die().Reset();
                    break;
                default:
                    break;
            }
            Current = newState;
        }

        return result;
    }

    private States UpdateState()
    {
        switch (Current)
        {
            case States.Idle:
                return Idle().Current;
                break;
            case States.Move:
                return Move().Current;
                break;
            case States.Attack:
                return Attack().Current;
                break;
            case States.Hurt:
                return Hurt().Current;
                break;
            case States.Die:
                return Die().Current;
                break;
            default:
                throw new System.Exception("Wrong State");
        }
    }

    private bool CanIdle()
    {
        return true;
    }

    private IEnumerator<States> Idle()
    {
        _animator.Play("Idle");
        yield return States.Idle;
    }

    //Move 실행 가능 조건
    private bool CanMove()
    {
        return true;
    }

    //Move상태 로직
    IEnumerator<States> Move()
    {
        _animator.Play("Move");
        yield return States.Idle;
    }

    private bool CanHurt()
    {
        return true;
    }

    //Attack상태 로직
    IEnumerator<States> Hurt()
    {
        _animator.Play("Hurt");
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return States.Hurt;
        }

        yield return States.Idle;
    }

    //Attack 가능 조건
    private bool CanAttack()
    {
        return true;
    }

    //Attack상태 로직
    IEnumerator<States> Attack()
    {
        _animator.Play("Attack");
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return States.Attack;
        }

        yield return States.Idle;
    }

    private bool CanDie()
    {
        return true;
    }

    //Attack상태 로직
    IEnumerator<States> Die()
    {
        _animator.Play("Die");
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return States.Die;
        }

        Destroy(gameObject);
        yield return States.Idle;
    }
}
