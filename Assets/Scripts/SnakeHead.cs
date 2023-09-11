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
    Collider2D _collider;
    public static SnakeHead instance;
    public List<PosHistory> posHistories;
    public WeaponRange weaponRange;
    public Animator animator;

    public float slowed;
    PosHistory lastPH;

    [SerializeField]
    SnakeBodyManager sbManager;
    const float SPEEDRatio = 0.033333f; //Don't Modify!

    public MultipleMultiplierValue speedMultiplier;
    public enum Direction { right, down, left, up }

    public static Vector2 DirectionToVector2(Direction dir)
    {
        switch (dir)
        {
            case Direction.right:
                return Vector2.right;
            case Direction.down:
                return Vector2.down;
            case Direction.left:
                return Vector2.left;
            case Direction.up:
                return Vector2.up;
            default:
                return Vector2.zero;
        }
    }


    public float speed;
    public float Speed { get { return speed * SPEEDRatio * speedMultiplier * Time.deltaTime * 30 * 1.666667f; } }
    public float maxHP;
    public float HP;

    protected float attackCT;   //현재 남은 쿨타임
    public MultipleMultiplierValue attackDT;   //전체 쿨타임
    protected SpriteRenderer sr;

    public float invincibilityTime;
    public float flashtime;
    float remain_flashtime;
    float remain_invincibilityTime;

    public delegate void OnDirectionChanged(bool b);

    public OnDirectionChanged DirectionChanged;
    static public Direction GetOppositeDir(Direction dir)
    {
        if (dir == Direction.right || dir == Direction.down)
            return dir + 2;
        else
            return dir - 2;
    }


    void Hit(string tag)
    {

    }


    public Direction dir;
    Rigidbody2D rb;

    protected virtual void Awake()
    {
        if (instance == null)
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
        speedMultiplier = new MultipleMultiplierValue(1f);
        attackDT = new MultipleMultiplierValue();
        _collider = GetComponent<Collider2D>();
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

    void WallHit(Vector2 normal = default(Vector2))
    {

        print(normal);

        if (normal != default(Vector2))
        {
            if (Mathf.Abs(normal.x) > 0)
            {
                if (transform.position.y > 0f)
                    ChangeDirection(Direction.down);
                else
                    ChangeDirection(Direction.up);

            }
            else if (Mathf.Abs(normal.y) > 0)
            {
                if (transform.position.x > 0)
                    ChangeDirection(Direction.left);
                else
                    ChangeDirection(Direction.right);
            }
        }
        //switch (dir)
        //{
        //    case Direction.right:
        //    case Direction.left:
        //        if (transform.position.y > 0)
        //            ChangeDirection(Direction.down);
        //        else
        //            ChangeDirection(Direction.up);
        //        break;
        //    case Direction.down:
        //    case Direction.up:
        //        if (transform.position.x > 0)
        //            ChangeDirection(Direction.left);
        //        else
        //            ChangeDirection(Direction.right);
        //        break;
        //}
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


    protected virtual void Update()
    {
        CheckDead();
        Move();
        if (remain_invincibilityTime > 0)
        {
            remain_flashtime -= Time.deltaTime;
            remain_invincibilityTime -= Time.deltaTime;
            if(remain_flashtime < 0)
            {
                sr.enabled = !sr.enabled;
                remain_flashtime = flashtime;
            }

            if (remain_invincibilityTime < 0)
            {
                _collider.isTrigger = false;
                sr.enabled = true;
            }
        }


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

            if (HP <= 0)
                GameOver();
        }
    }

    void GameOver()
    {

        gameObject.SetActive(false);
    }


    public void Hit(float amount, Collision2D collision = null, Collider2D collider = null)
    {
        bool wall = false;

        //////*아래 수정할때 다른쪽도 수정해줄것*///
        //////*아래 수정할때 다른쪽도 수정해줄것*///
        //////*아래 수정할때 다른쪽도 수정해줄것*///
        ///
        if (collision != null)
        {
            if (collision.gameObject)
            {
                switch (collision.gameObject.tag)
                {
                    case "Wall":
                        ObserverPatternManager.instance.WallHit();
                        WallHit(collision.contacts[0].normal);
                        wall = true;
                        break;
                    case "Enemy":
                        ObserverPatternManager.instance.EnemyContact(collision.gameObject.GetComponent<Enemy>());

                        break;
                    case "EnemyBullet":

                        break;
                    case "Colleague":

                        break;
                }

            }
        }
        else if (collider != null)
            if (collider.gameObject)
            {
                switch (collider.gameObject.tag)
                {
                    case "Wall":
                        ObserverPatternManager.instance.WallHit();
                        WallHit(DirectionToVector2(dir));
                        wall = true;
                        break;
                    case "Enemy":
                        ObserverPatternManager.instance.EnemyContact(collider.gameObject.GetComponent<Enemy>());
                        break;
                    case "EnemyBullet":

                        break;
                    case "Colleague":

                        break;
                }
            }

        if(!wall)
            HPDecrease(amount);
        else
        {
            //장애물 피격 판정
            if (Airbag.instance.BlockDamage())
                return;

            HPDecrease(amount);
        }


    }
    public void HPDecrease(float amount)
    {
        if (remain_invincibilityTime > 0 && amount > 0f)
            return;
        if (amount > 0f)
        {
            remain_invincibilityTime = invincibilityTime;
            _collider.isTrigger = true;
            animator.SetTrigger("Hit");
        }
        HP -= amount;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Wall"))
        {
            Hit(collision.transform.GetComponent<Wall>().contactDamage, collision);
        }
        else if (collision.transform.CompareTag("Enemy"))
        {
            Hit(collision.transform.GetComponent<Enemy>().contactDamage, collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Wall"))
        {
            print("trwall");
            Hit(collider.transform.GetComponent<Wall>().contactDamage, collider: collider);
        }
    }
}