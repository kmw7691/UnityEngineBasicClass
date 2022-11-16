using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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

    private int _idleStep;
    private int _moveStep;
    private int _hurtStep;
    private int _dieStep;
    private int _attackStep;

    //AI
    public enum AI
    {
        Idle,
        Think,
        TakeARest,
        MoveLeft,
        MoveRight,
        FollowTarget,
        AttackTarget
    }

    [SerializeField] private AI _ai;
    [SerializeField] private bool _aiAutoFollow = false;
    [SerializeField] private float _aiDetectRange = 2.0f;
    [SerializeField] private bool _aiAttackEnable = false;
    [SerializeField] private float _aiAttackRange = 0.5f;
    [SerializeField] private float _aiBehaviorTimeMin = 0.1f;
    [SerializeField] private float _aiBehaviorTimeMax = 2.0f;
    private float _aiBehaviorTimer;
    [SerializeField] protected LayerMask _TargetLayer;

    //Movement
    private const int DIRECTION_LEFT = -1;
    private const int DIRECTION_RIGHT = 1;
    private int _direction;

    public int Direction
    {
        get
        {
            return _direction;
        }

        set
        {
            if (value > 0)
            {
                _direction = DIRECTION_RIGHT;
                transform.eulerAngles = Vector3.zero;
            }
            else if (value < 0)
            {
                _direction = DIRECTION_LEFT;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
        }

    }
    [SerializeField] private bool _moveEnable = true;
    [SerializeField] private bool _movable = false;
    [SerializeField] private float _movespeed = 1.0f;
    protected Rigidbody2D _Rb;
    private CapsuleCollider2D _col;
    private Collider2D _target;

    //animation
    private Animator _animator;
    
    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _col = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        UpdateAI();
        ChangeState(UpdateState());
    }

    private void FixedUpdate()
    {
        if(_moveEnable && _movable)
            _Rb.MovePosition(_Rb.position + Direction * Vector2.right * _movespeed * Time.fixedDeltaTime);
    }

    private void UpdateAI()
    {
        if(Current == States.Hurt || Current ==States.Die)
           return;

        switch (_ai)
        {
            case AI.Idle:
                break;
            case AI.Think:
                {
                    _target = Physics2D.OverlapCircle(_Rb.position, _aiDetectRange, _TargetLayer);
                    if(_target != null)
                    {
                        if(_aiAttackEnable &&
                            Vector2.Distance(_Rb.position, _target.transform.position) < _aiAttackRange)
                        {
                            _ai = AI.AttackTarget;
                            ChangeState(States.Attack);
                        }

                        else
                        {
                            _ai = AI.FollowTarget;
                            ChangeState(States.Move);
                        }
                    }

                    else
                    {
                        _ai = (AI)Random.Range((int)AI.TakeARest, (int)AI.MoveRight + 1);
                        _aiBehaviorTimer = Random.Range(+_aiBehaviorTimeMin, _aiBehaviorTimeMax);
                        if (_ai == AI.TakeARest)
                            ChangeState(States.Idle);
                        else
                            ChangeState(States.Move);
                    }
                }
                break;
            case AI.TakeARest:
                {
                    if(_aiBehaviorTimer <= 0)
                    {
                        _ai = AI.Think;
                    }
                    else
                    {
                        _aiBehaviorTimer -= Time.deltaTime;
                    }
                }
                break;
            case AI.MoveLeft:
                {
                    if(_aiBehaviorTimer <= 0)
                    {
                        _ai = AI.Think;
                    }
                    else
                    {
                        Direction = DIRECTION_LEFT;
                        _aiBehaviorTimer -= Time.deltaTime;
                    }
                }
                break;
            case AI.MoveRight:
                {
                    if (_aiBehaviorTimer <= 0)
                    {
                        _ai = AI.Think;
                    }
                    else
                    {
                        Direction = DIRECTION_RIGHT;
                        _aiBehaviorTimer -= Time.deltaTime;
                    }
                }
                break;
            case AI.FollowTarget:
                {
                    //타겟이 범위를 벗어남
                    if(_target == null ||
                       Vector2.Distance(_Rb.position, _target.transform.position) > _aiDetectRange)
                    {
                        _target = null;
                        _ai = AI.Think;
                    }
                    //타겟이 공격 범위내에 들어옴
                    else if (_aiAttackEnable &&
                             Vector2.Distance(_Rb.position, _target.transform.position) < _aiAttackRange)
                    {
                        ChangeState(States.Attack);
                        _ai = AI.AttackTarget;
                    }
                    //둘다 아니면 그냥 따라감
                    else
                    {
                        if (_Rb.position.x < _target.transform.position.x - _col.size.x)
                        {
                            Direction = DIRECTION_RIGHT;
                        }
                        else if (_Rb.position.x > _target.transform.position.x + _col.size.x)
                        {
                            Direction = DIRECTION_LEFT;
                        }
                    }
                }
                break;
            case AI.AttackTarget:
                {
                    if(Current != States.Attack)
                    {
                        _ai = AI.Think;
                    }
                }
                break;
            default:
                break;
        }
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
                    _idleStep = 1;
                    _movable = false;
                    break;
                case States.Move:
                    _moveStep = 1;
                    _movable = true;
                    break;
                case States.Attack:
                    _attackStep = 1;
                    _movable = false;
                    break;
                case States.Hurt:
                    _hurtStep = 1;
                    _movable = false;
                    break;
                case States.Die:
                    _dieStep = 1;
                    _movable = false;
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
                return Idle();
            case States.Move:
                return Move();
            case States.Attack:
                return Attack();
            case States.Hurt:
                return Hurt();
            case States.Die:
                return Die();
            default:
                throw new System.Exception("Wrong State");
        }
    }

    private bool CanIdle()
    {
        return true;
    }

    private States Idle()
    {
        switch (_idleStep)
        {
            case 0:
                // nothing to do
                break;
            case 1:
                _animator.Play("Idle");
                _idleStep++;
                break;
            default:
                break;
        }

        return States.Idle;
    }

    //Move 실행 가능 조건
    private bool CanMove()
    {
        return true;
    }

    //Move상태 로직
    private States Move()
    {
        switch (_moveStep)
        {
            case 0:
                // nothing to do
                break;
            case 1:
                _animator.Play("Move");
                _moveStep++;
                break;
            case 2:
                // finished
                break;
            default:
                break;
        }

        return States.Move;
    }

    //Hurt 실행 가능 조건
    private bool CanHurt()
    {
        return true;
    }

    //Hurt상태 로직
    private States Hurt()
    {
        States next = States.Hurt;
        switch (_hurtStep)
        {
            case 0:
                // nothing to do
                break;
            case 1:
                _animator.Play("Hurt");
                _hurtStep++;
                break;
            case 2:
                // finished
                {
                    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        _hurtStep++;
                    }
                }
                break;
            default:
                {
                    next = States.Idle;
                }
                break;
        }

        return next;
    }

    //Attack 가능 조건
    private bool CanAttack()
    {
        return true;
    }

    //Attack상태 로직
    private States Attack()
    {
        States next = States.Attack;
        switch (_attackStep)
        {
            case 0:
                // nothing to do
                break;
            //공격 애니메이션 재생
            case 1:
                _animator.Play("Attack");
                _attackStep++;
                break;
            //공격 시전 시간
            //---------------------------------------------------------
            case 2:
                {
                    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
                    {
                        AttackBehavior();
                        _attackStep++;
                    }
                }
                break;
            //공격 모션 종료 대기
            //---------------------------------------------------------
            case 3:
                // finished
                {
                    if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        _attackStep++;
                    }
                }
                break;
            default:
                {
                    next = States.Idle;
                }
                break;
        }

        return next;
    }
    
    //Die 가능 조건
    private bool CanDie()
    {
        return true;
    }

    //Die상태 로직
    private States Die()
    {
        States next = States.Die;
        switch (_dieStep)
        {
            case 0:
                // nothing to do
                break;
            case 1:
                _animator.Play("die");
                _dieStep++;
                break;
            case 2:
                // finished
                {
                    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        Destroy(gameObject);
                        _dieStep++;
                    }
                }
                break;
            default:
                {
                    next = States.Idle;
                }
                break;
        }

        return next;
    }

    protected virtual void AttackBehavior()
    {

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _aiDetectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _aiAttackRange);
    }
}
