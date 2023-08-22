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

    public float slowed;
    PosHistory lastPH;

    [SerializeField]
    SnakeBodyManager sbManager;
    const float SPEEDRatio = 0.033333f; //Don't Modify!

    public float speedMultiplier = 1;
    public enum Direction { right, down, left, up }
    public float speed;
    public float Speed { get { return speed * SPEEDRatio * speedMultiplier * Time.deltaTime * 30 * 1.666667f; } }
    public float maxHP;
    public float HP;

    protected float attackCT;   //���� ���� ��Ÿ��
    protected float attackDT;   //��ü ��Ÿ��
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
           switch(from.tag)
            {
                case "Wall":
                    ObserverPatternManager.instance.WallHit();
                    break;
                case "Enemy":
                    ObserverPatternManager.instance.EnemyContact(from.GetComponent<Enemy>());
                    break;
                case "EnemyBullet":

                    break;
                case "Colleague":

                    break;
            }
            
        }




        HP -= amount;


    }



    public Direction dir;
    Rigidbody2D rb;

    protected virtual void Awake()
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
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }
    private void FixedUpdate()
    {
        //����� �÷��� Ÿ�� ������ �����ϸ� �̰� ���� �ȵɵ�
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
        var vec = Vector3.zero;

        switch (dir)
        {
            case Direction.right:
                vec = new Vector3(1, 0);
                
                break;
            case Direction.down:
                vec = new Vector3(0, -1);
                break;
            case Direction.left:
                vec = new Vector3(-1, 0);
                break;
            case Direction.up:
                vec = new Vector3(0, 1);
                break;
        }
        vec = transform.position + vec * (Speed - Speed / 100 * slowed);
        rb.MovePosition(vec);
    }
    protected virtual void ChangeAttackDirection(Direction dir)
    {
        Debug.Log("parentCAD");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckDead();
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

    void CheckDead()
    {
        if (HP <= 0)
        {
            ObserverPatternManager.instance.ColleagueOrHeroDied(false);

            if(HP <= 0)
                GameOver();
        }
    }
    void GameOver()
    {

        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Wall"))
        {
            Hit(collision.transform.GetComponent<Wall>().contactDamage, collision.gameObject);
        }
        else if(collision.transform.CompareTag("Enemy"))
        {
            Hit(collision.transform.GetComponent<Enemy>().contactDamage, collision.gameObject);
        }
    }
}