using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SnakeHead : MonoBehaviour
{
    public class PosHistory
    {
        public Vector2 pos;
        public Direction dir;
        public PosHistory nextPH;
        public PosHistory(Vector2 _Pos, Direction _dir)
        {
            pos = _Pos;
            dir = _dir;
        }
    }

    public delegate void OnSomethingHandler();

    public OnSomethingHandler OnHitHandler;

    public static SnakeHead instance;
    public List<PosHistory> posHistories;
    public WeaponRange weaponRange;
    public Animator animator;
    PosHistory lastPH;

    [SerializeField]
    SnakeBodyManager sbManager;
    const float SPEEDMULTIPLY = 0.033333f; //Don't Modify!

    public enum Direction { right, down, left, up }
    public float speed;
    public float Speed { get { return speed * SPEEDMULTIPLY * Time.deltaTime * 30 * 1.666667f; } }
    public float maxHP;
    public float HP;

    protected float attackCT;   //현재 남은 쿨타임
    protected float attackDT;   //전체 쿨타임
    protected SpriteRenderer sr;



    public delegate void OnDirectionChanged(bool b);

    public OnDirectionChanged DirectionChanged;
    static public Direction GetOppositeDir(Direction dir)
    {
        if (dir == Direction.right || dir == Direction.down)
            return dir + 2;
        else
            return dir - 2;
    }

    public void Hit(float amount, GameObject from = null)
    {
        if(from)
        {
            //normal hit
        }
        // TODO : wall hit branch
        // TODO : enemy hit branch
        // TODO : bullet hit branch
        // TODO : colleague hit branch
    }



    public Direction dir;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    protected void Init()
    {
        posHistories = new List<PosHistory>();
        dir = Direction.right;
        ChangeDirection(Direction.up);
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }
    private void FixedUpdate()
    {
        //모바일 플랫폼 타겟 프레임 생각하면 이거 쓰면 안될듯
    }
    public virtual void ChangeDirection(Direction _dir)
    {
        if (GetOppositeDir(dir) == _dir || dir == _dir)
            return;
        dir = _dir;
        var newPH = new PosHistory(transform.position, dir);
        if (lastPH != null)
            lastPH.nextPH = newPH;
        lastPH = newPH;
        posHistories.Add(lastPH);
        ChangeAttackDirection(_dir);

        if (_dir == Direction.right)
        {
            sr.flipX = true;
        }
        else if (_dir == Direction.left)
        {
            sr.flipX = false;
        }


        SnakeBodyManager.instance.AlertNewPH(newPH);
    }
    void Move()
    {
        switch (dir)
        {
            case Direction.right:
                transform.Translate(new Vector3(1, 0) * Speed);
                break;
            case Direction.down:
                transform.Translate(new Vector3(0, -1) * Speed);
                break;
            case Direction.left:
                transform.Translate(new Vector3(-1, 0) * Speed);
                break;
            case Direction.up:
                transform.Translate(new Vector3(0, 1) * Speed);
                break;
        }
    }
    protected virtual void ChangeAttackDirection(Direction dir)
    {
        Debug.Log("parentCAD");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        if (CheckAttack())
            Attack();
        
    }
    protected virtual bool CheckAttack()
    {
        attackCT -= Time.deltaTime;
        
        return attackCT <= 0 && weaponRange.EnemySpoted;
    }
    protected virtual void Attack()
    {
        attackCT = attackDT;
    }
}