using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Node
{
    public Node(bool _isWall, int _x, int _y) { isWall = _isWall; x = _x; y = _y; }

    public bool isWall;
    public Node ParentNode;

    // G : �������κ��� �̵��ߴ� �Ÿ�, H : |����|+|����| ��ֹ� �����Ͽ� ��ǥ������ �Ÿ�, F : G + H
    public int x, y, G, H;
    public int F { get { return G + H; } }
}
public class Enemy : MonoBehaviour
{


    

    public enum Type
    {
        normal,
        archer,
        ghost,
        explosion,
        horseman,
        wizard,
        corrosion,
        healer
    }

    public GameObject Player;
    public GameObject SelfRelatedObj;

    public float maxhp;
    public float hp;
    public float Speed;
    public float time;

    public GameObject a;
    public Vector2Int bottomLeft, topRight, startPos, targetPos;
    public List<Node> FinalNodeList;
    public bool allowDiagonal, dontCrossCorner;

    public bool MoveBool;
    int sizeX, sizeY;
    Node[,] NodeArray;
    Node StartNode, TargetNode, CurNode;
    List<Node> OpenList, ClosedList;

    Coroutine coroutine;

    public Animator Anim;

    float currentLerpTime = 0f;

    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        coroutine = StartCoroutine(MyCoroutine());
        coroutine = StartCoroutine(Move());
        Player = GameObject.Find("Head");

        gameObject.transform.position = new Vector2((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        bottomLeft = new Vector2Int(-100, -100);
        topRight = new Vector2Int(100, 100);
    }

    public void Hit(float damage)
    {
        hp -= damage;
        CheckDead();
    }


    public void CheckDead()
    {
        if (hp <= 0)
        {
            MoveBool = false;
            //EXPManager.instance.itemOP.GetRestingPoolObject().SetPositionAndActive(transform.position);
            Anim.SetBool("Die", true);
            Invoke("ObjectDestroy", 0.35f);
        }
    }

    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }

    protected virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CheckDead();
        }
        if(Player != null)
            targetPos = new Vector2Int((int)Math.Round(Player.transform.position.x), (int)Math.Round(Player.transform.position.y));
        startPos = new Vector2Int((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        
    }

    private IEnumerator MyCoroutine()
    {
        while(true)
        {
            if(Player != null)
                AStarMove();
            yield return new WaitForSeconds(1f); // 1�� ���
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (MoveBool)
            {
                if(FinalNodeList.Count >= 2)
                    transform.position = new Vector2(FinalNodeList[1].x, FinalNodeList[1].y);
            }
            yield return new WaitForSeconds(0.1f); // 1�� ���
        }
    }


    void AStarMove()
    {
        sizeX = topRight.x - bottomLeft.x + 1;
        sizeY = topRight.y - bottomLeft.y + 1;
        NodeArray = new Node[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                bool isWall = false;
                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + bottomLeft.x, j + bottomLeft.y), 0.4f))
                    if (col.gameObject.layer == LayerMask.NameToLayer("Wall")) isWall = true;

                NodeArray[i, j] = new Node(isWall, i + bottomLeft.x, j + bottomLeft.y);
            }
        }


        // ���۰� �� ���, ��������Ʈ�� ��������Ʈ, ����������Ʈ �ʱ�ȭ
        StartNode = NodeArray[startPos.x - bottomLeft.x, startPos.y - bottomLeft.y];
        TargetNode = NodeArray[targetPos.x - bottomLeft.x, targetPos.y - bottomLeft.y];

        OpenList = new List<Node>() { StartNode };
        ClosedList = new List<Node>();
        FinalNodeList = new List<Node>();


        while (OpenList.Count > 0)
        {
            // ��������Ʈ �� ���� F�� �۰� F�� ���ٸ� H�� ���� �� ������� �ϰ� ��������Ʈ���� ��������Ʈ�� �ű��
            CurNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H) CurNode = OpenList[i];

            OpenList.Remove(CurNode);
            ClosedList.Add(CurNode);


            // ������
            if (CurNode == TargetNode)
            {
                Node TargetCurNode = TargetNode;
                while (TargetCurNode != StartNode)
                {
                    FinalNodeList.Add(TargetCurNode);
                    TargetCurNode = TargetCurNode.ParentNode;
                }
                FinalNodeList.Add(StartNode);
                FinalNodeList.Reverse();

                return;
            }

           //for(int i = 0; i < FinalNodeList.Count; i++)//���� Ȯ��
           //{
           //    if (i == 0)
           //    {
           //        if (FinalNodeList[i].x > (int)Mathf.Round(gameObject.transform.position.x))
           //            FinalNodeList[i].MoveDirection = Node.Direction.left;
           //
           //        else if (FinalNodeList[i].x < (int)Mathf.Round(gameObject.transform.position.x))
           //            FinalNodeList[i].MoveDirection = Node.Direction.left;
           //
           //        else if (FinalNodeList[i].y > (int)Mathf.Round(gameObject.transform.position.y))
           //            FinalNodeList[i].MoveDirection = Node.Direction.up;
           //
           //        else if (FinalNodeList[i].y < (int)Mathf.Round(gameObject.transform.position.y))
           //            FinalNodeList[i].MoveDirection = Node.Direction.down;
           //    }
           //    else
           //    {
           //        if (FinalNodeList[i].x > FinalNodeList[i- 1].x)
           //            FinalNodeList[i].MoveDirection = Node.Direction.right;
           //
           //        else if (FinalNodeList[i].x < FinalNodeList[i - 1].x)
           //            FinalNodeList[i].MoveDirection = Node.Direction.left;
           //
           //        else if (FinalNodeList[i].y > FinalNodeList[i - 1].y)
           //            FinalNodeList[i].MoveDirection = Node.Direction.up;
           //
           //        else if (FinalNodeList[i].y < FinalNodeList[i - 1].y)
           //            FinalNodeList[i].MoveDirection = Node.Direction.down;
           //    }
           //}


            // �֢آע�
            if (allowDiagonal)
            {
                OpenListAdd(CurNode.x + 1, CurNode.y + 1);
                OpenListAdd(CurNode.x - 1, CurNode.y + 1);
                OpenListAdd(CurNode.x - 1, CurNode.y - 1);
                OpenListAdd(CurNode.x + 1, CurNode.y - 1);
            }

            // �� �� �� ��
            OpenListAdd(CurNode.x, CurNode.y + 1);
            OpenListAdd(CurNode.x + 1, CurNode.y);
            OpenListAdd(CurNode.x, CurNode.y - 1);
            OpenListAdd(CurNode.x - 1, CurNode.y);
        }
    }
    void OpenListAdd(int checkX, int checkY)
    {
        // �����¿� ������ ����� �ʰ�, ���� �ƴϸ鼭, ��������Ʈ�� ���ٸ�
        if (checkX >= bottomLeft.x && checkX < topRight.x + 1 && checkY >= bottomLeft.y && checkY < topRight.y + 1 && !NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y].isWall && !ClosedList.Contains(NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y]))
        {
            // �밢�� ����, �� ���̷� ��� �ȵ�
            if (allowDiagonal) if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall && NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;

            // �ڳʸ� �������� ���� ������, �̵� �߿� �������� ��ֹ��� ������ �ȵ�
            if (dontCrossCorner) if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall || NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;


            // �̿���忡 �ְ�, ������ 10, �밢���� 14���
            Node NeighborNode = NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y];
            int MoveCost = CurNode.G + (CurNode.x - checkX == 0 || CurNode.y - checkY == 0 ? 10 : 14);


            // �̵������ �̿����G���� �۰ų� �Ǵ� ��������Ʈ�� �̿���尡 ���ٸ� G, H, ParentNode�� ���� �� ��������Ʈ�� �߰�
            if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
            {
                NeighborNode.G = MoveCost;
                NeighborNode.H = (Mathf.Abs(NeighborNode.x - TargetNode.x) + Mathf.Abs(NeighborNode.y - TargetNode.y)) * 10;
                NeighborNode.ParentNode = CurNode;

                OpenList.Add(NeighborNode);
            }
        }
    }

   
}
