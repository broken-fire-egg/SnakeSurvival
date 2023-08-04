//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//[System.Serializable]
//public class Node
//{
//    public Node(bool _isWall, int _x, int _y) { isWall = _isWall; x = _x; y = _y; }

//    public bool isWall;
//    public Node ParentNode;

//    // G : 시작으로부터 이동했던 거리, H : |가로|+|세로| 장애물 무시하여 목표까지의 거리, F : G + H
//    public int x, y, G, H;
//    public int F { get { return G + H; } }
//}

//public class LegacyEnemy : MonoBehaviour
//{

//    public enum Direction
//    {
//        up,
//        right,
//        down,
//        left,
//        none
//    }


//    public enum Type
//    {
//        normal,
//        archer,
//        ghost,
//        explosion,
//        horseman,
//        wizard,
//        corrosion,
//        healer
//    }

//    public GameObject Player;
//    public GameObject SelfRelatedObj;

//    public float stunTime;
//    public float maxhp;
//    public float hp;
//    public float Speed;
//    public float time;
//    public float Attack;
//    public float SpeedCorrection;

//    public Vector2Int bottomLeft, topRight, startPos, targetPos;
//    public List<Node> FinalNodeList;
//    public bool allowDiagonal, dontCrossCorner;

//    public bool MoveBool;
//    int sizeX, sizeY;
//    Node[,] NodeArray;
//    Node StartNode, TargetNode, CurNode;
//    List<Node> OpenList, ClosedList;

//    Coroutine coroutine;

//    public Animator Anim;

//    public bool DeadBool;

//    Direction dir = Direction.none;

//    private int MoveNode = 1;
//    protected virtual void Start()
//    {
//        MoveBool = true;
//        Anim = GetComponent<Animator>();
//        coroutine = StartCoroutine(MyCoroutine());
//        //coroutine = StartCoroutine(Move());
//        Player = GameObject.Find("Head");
//        //TargetReload();

//        gameObject.transform.position = new Vector2((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
//        //AStarMove();

//    }

//    public void Hit(float damage, float stun = 0f, bool isCrit = false)
//    {
//        hp -= damage;
//        time -= stun;
//        stunTime += stun;
//        if (DamageTextObjectPool.instance)
//            DamageTextObjectPool.instance.SpawnText(transform.position, damage, isCrit);
//        CheckDead();
//    }


//    public void CheckDead()
//    {
//        if (hp <= 0)
//        {
//            MoveBool = false;
//            //EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
//            Anim.SetBool("Die", true);
//            Invoke("ObjectDestroy", 0.35f);
//        }
//    }

//    public void ObjectDestroy()
//    {
//        Destroy(gameObject);
//    }

//    protected virtual void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            hp = 0;
//            CheckDead();
//        }
//        if (Player != null)
//        {
//            Move();
//            //TargetReload();
//            if (stunTime > 0)
//                stunTime -= Time.deltaTime;
//        }
//        if (stunTime < 0)
//            stunTime = 0;
//    }

//    private IEnumerator MyCoroutine()
//    {
//        while (true)
//        {

//            if (Player != null)
//                SetDirection();
//            //AStarMove();

//            yield return new WaitForSeconds(0.1f); // 1초 대기
//        }
//    }
//    /*
//    IEnumerator Move()
//    {
//        while (true)
//        {
//            if (MoveBool)
//            {
//                if (FinalNodeList.Count >= 2)
//                {
//                    if (FinalNodeList[0].x == FinalNodeList[1].x)
//                    {
//                        if (FinalNodeList[0].y > FinalNodeList[1].y)
//                            transform.position = new Vector2(transform.position.x, transform.position.y - (Speed / 2000));
//                        else
//                            transform.position = new Vector2(transform.position.x, transform.position.y + (Speed / 2000));
//                    }
//                    else //if(FinalNodeList[0].y == FinalNodeList[1].y)
//                    {
//                        if (FinalNodeList[0].x > FinalNodeList[1].x)
//                            transform.position = new Vector2(transform.position.x - (Speed / 2000), transform.position.y);
//                        else
//                            transform.position = new Vector2(transform.position.x + (Speed / 2000), transform.position.y);
//                    }

//                    MoveNode++;
//                }
//            }
//            if (stunTime > 0)
//                yield return new WaitForSeconds(stunTime);
//            yield return new WaitForSeconds(0.005f); // 1초 대기
//        }
//    }*/

//    void TargetReload()
//    {
//        targetPos = new Vector2Int((int)Math.Round(Player.transform.position.x), (int)Math.Round(Player.transform.position.y));
//        startPos = new Vector2Int((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));

//        topRight = new Vector2Int(startPos.x + Mathf.RoundToInt(Vector2.Distance(gameObject.transform.position, Player.transform.position)) + 1, startPos.y + Mathf.RoundToInt(Vector2.Distance(gameObject.transform.position, Player.transform.position)) + 1);

//        bottomLeft = new Vector2Int(startPos.x - Mathf.RoundToInt(Vector2.Distance(gameObject.transform.position, Player.transform.position)) - 1, startPos.y - Mathf.RoundToInt(Vector2.Distance(gameObject.transform.position, Player.transform.position)) - 1);

//        if ((targetPos.x > topRight.x || targetPos.y > topRight.y))
//        {
//        }
//        else if (targetPos.x < topRight.x || targetPos.y < topRight.y)
//        {
//            //bottomLeft = new Vector2Int(startPos.x - (int)Math.Abs(Vector2.Distance(gameObject.transform.position, Player.transform.position)), startPos.y - (int)Math.Abs(Vector2.Distance(gameObject.transform.position, Player.transform.position)));
//            //topRight = new Vector2Int(startPos.x + (int)Math.Abs(Vector2.Distance(gameObject.transform.position, Player.transform.position)), startPos.y + (int)Math.Abs(Vector2.Distance(gameObject.transform.position, Player.transform.position)));
//        }
//    }

//    void AStarMove()
//    {
//        TargetReload();
//        MoveNode = 1;
//        sizeX = (topRight.x > bottomLeft.x ? topRight.x - bottomLeft.x + 1 : bottomLeft.x - topRight.x + 1);
//        sizeY = (topRight.y > bottomLeft.y ? topRight.y - bottomLeft.y + 1 : bottomLeft.y - topRight.y + 1);
//        NodeArray = new Node[sizeX, sizeY];

//        for (int i = 0; i < sizeX; i++)
//        {
//            for (int j = 0; j < sizeY; j++)
//            {
//                bool isWall = false;
//                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + bottomLeft.x, j + bottomLeft.y), 0.4f))
//                    if (col.gameObject.layer == LayerMask.NameToLayer("Wall")) isWall = true;

//                NodeArray[i, j] = new Node(isWall, i + bottomLeft.x, j + bottomLeft.y);
//            }
//        }


//        // 시작과 끝 노드, 열린리스트와 닫힌리스트, 마지막리스트 초기화
//        try
//        {
//            //StartNode = NodeArray[(startPos.x > bottomLeft.x ? startPos.x - bottomLeft.x : bottomLeft.x - startPos.x), (startPos.y > bottomLeft.y ? startPos.y - bottomLeft.y : bottomLeft.y - startPos.y)];
//            //TargetNode = NodeArray[(targetPos.x > bottomLeft.x ? targetPos.x - bottomLeft.x : bottomLeft.x - targetPos.x), (targetPos.y > bottomLeft.y ? targetPos.y - bottomLeft.y : bottomLeft.y - targetPos.y)];
//            StartNode = NodeArray[startPos.x - bottomLeft.x, startPos.y - bottomLeft.y];
//            TargetNode = NodeArray[targetPos.x - bottomLeft.x, targetPos.y - bottomLeft.y];
//        }
//        catch (Exception e)
//        {
//            Debug.Log(gameObject.transform.name);
//            Debug.Log(targetPos.x - bottomLeft.x + " : " + targetPos.x + ", " + bottomLeft.x);
//            Debug.Log(targetPos.y - bottomLeft.y + " : " + targetPos.y + ", " + bottomLeft.y);
//        }
//        OpenList = new List<Node>() { StartNode };
//        ClosedList = new List<Node>();
//        FinalNodeList = new List<Node>();


//        while (OpenList.Count > 0)
//        {
//            // 열린리스트 중 가장 F가 작고 F가 같다면 H가 작은 걸 현재노드로 하고 열린리스트에서 닫힌리스트로 옮기기
//            CurNode = OpenList[0];
//            for (int i = 1; i < OpenList.Count; i++)
//                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H) CurNode = OpenList[i];

//            OpenList.Remove(CurNode);
//            ClosedList.Add(CurNode);


//            // 마지막
//            if (CurNode == TargetNode)
//            {
//                Node TargetCurNode = TargetNode;
//                while (TargetCurNode != StartNode)
//                {
//                    FinalNodeList.Add(TargetCurNode);
//                    TargetCurNode = TargetCurNode.ParentNode;
//                }
//                FinalNodeList.Add(StartNode);
//                FinalNodeList.Reverse();

//                return;
//            }


//            // ↗↖↙↘
//            if (allowDiagonal)
//            {
//                OpenListAdd(CurNode.x + 1, CurNode.y + 1);
//                OpenListAdd(CurNode.x - 1, CurNode.y + 1);
//                OpenListAdd(CurNode.x - 1, CurNode.y - 1);
//                OpenListAdd(CurNode.x + 1, CurNode.y - 1);
//            }

//            // ↑ → ↓ ←
//            OpenListAdd(CurNode.x, CurNode.y + 1);
//            OpenListAdd(CurNode.x + 1, CurNode.y);
//            OpenListAdd(CurNode.x, CurNode.y - 1);
//            OpenListAdd(CurNode.x - 1, CurNode.y);
//        }

//    }
//    void OpenListAdd(int checkX, int checkY)
//    {
//        // 상하좌우 범위를 벗어나지 않고, 벽이 아니면서, 닫힌리스트에 없다면
//        if (checkX >= bottomLeft.x && checkX < topRight.x + 1 && checkY >= bottomLeft.y && checkY < topRight.y + 1 && !NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y].isWall && !ClosedList.Contains(NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y]))
//        {
//            // 대각선 허용시, 벽 사이로 통과 안됨
//            if (allowDiagonal) if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall && NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;

//            // 코너를 가로질러 가지 않을시, 이동 중에 수직수평 장애물이 있으면 안됨
//            if (dontCrossCorner) if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall || NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;


//            // 이웃노드에 넣고, 직선은 10, 대각선은 14비용
//            Node NeighborNode = NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y];
//            int MoveCost = CurNode.G + (CurNode.x - checkX == 0 || CurNode.y - checkY == 0 ? 10 : 14);


//            // 이동비용이 이웃노드G보다 작거나 또는 열린리스트에 이웃노드가 없다면 G, H, ParentNode를 설정 후 열린리스트에 추가
//            if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
//            {
//                NeighborNode.G = MoveCost;
//                NeighborNode.H = (Mathf.Abs(NeighborNode.x - TargetNode.x) + Mathf.Abs(NeighborNode.y - TargetNode.y)) * 10;
//                NeighborNode.ParentNode = CurNode;

//                OpenList.Add(NeighborNode);
//            }
//        }
//    }

//    void SetDirection()
//    {

//        Vector3 vec3 = Player.transform.position - transform.position;

//        if (MathF.Abs(vec3.x) > MathF.Abs(vec3.y))
//        {
//            if (vec3.x > 0)
//            {
//                Debug.Log("right1");
//                dir = Direction.right;
//                //right
//            }
//            else
//            {
//                Debug.Log("left1");
//                dir = Direction.left;
//                //left
//            }
//        }
//        else
//        {
//            if (vec3.y > 0)
//            {
//                Debug.Log("up");
//                dir = Direction.up;
//                //up
//            }
//            else
//            {
//                Debug.Log("down");
//                dir = Direction.down;
//                //down
//            }
//        }
//    }

//    void Move()
//    {


//        //if (gameObject.transform.position.y < Player.transform.position.y)
//        //{
//        //    if (MathF.Abs(MathF.Abs(gameObject.transform.position.x) - MathF.Abs(Player.transform.position.x)) > MathF.Abs(MathF.Abs(gameObject.transform.position.y) - MathF.Abs(Player.transform.position.y)))
//        //    {
//        //        if (gameObject.transform.position.x < Player.transform.position.x)
//        //        {

//        //        }
//        //        else
//        //        {

//        //        }
//        //    }
//        //    else
//        //    {

//        //    }
//        //}
//        //else
//        //{
//        //    if (MathF.Abs(MathF.Abs(gameObject.transform.position.x) - MathF.Abs(Player.transform.position.x)) > MathF.Abs(MathF.Abs(gameObject.transform.position.y) - MathF.Abs(Player.transform.position.y)))
//        //    {
//        //        if (gameObject.transform.position.x < Player.transform.position.x)
//        //        {
//        //            Debug.Log("right2");
//        //            dir = Direction.right;
//        //        }
//        //        else
//        //        {

//        //            Debug.Log("left2");
//        //            dir = Direction.left;
//        //        }
//        //    }
//        //    else
//        //    {

//        //    }
//        //}
//        // Debug.Log(MathF.Abs(gameObject.transform.position.x) - MathF.Abs(Player.transform.position.x));
//        switch (dir)
//        {
//            case Direction.right:
//                transform.Translate(new Vector3(1, 0) * Speed * SpeedCorrection);
//                break;
//            case Direction.down:
//                transform.Translate(new Vector3(0, -1) * Speed * SpeedCorrection);
//                break;
//            case Direction.left:
//                transform.Translate(new Vector3(-1, 0) * Speed * SpeedCorrection);
//                break;
//            case Direction.up:
//                transform.Translate(new Vector3(0, 1) * Speed * SpeedCorrection);
//                break;
//        }
//    }
//}