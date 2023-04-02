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


    public static SnakeHead instance;
    public List<PosHistory> posHistories;

    PosHistory lastPH;

    [SerializeField]
    SnakeBodyManager sbManager;
    const float SPEEDMULTIPLY = 0.025f;
    public enum Direction { right, down, left, up }
    public float speed;
    public float Speed { get { return speed * SPEEDMULTIPLY; } }
    public float maxHP;
    public float HP;
    protected SpriteRenderer sr;
    SpriteResolver spriteResolver;

    static public Direction GetOppositeDir(Direction dir)
    {
        if (dir == Direction.right || dir == Direction.down)
            return dir + 2;
        else
            return dir - 2;
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
        spriteResolver = GetComponent<SpriteResolver>();
        sr = GetComponent<SpriteRenderer>();
        Debug.Log("SH Init");
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
    public void ChangeDirection(Direction _dir)
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
    }
}