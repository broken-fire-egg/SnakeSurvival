using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_Enemy : Enemy
{
    public GameObject SplitObject;
    public int SplitCount;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        if(hp <= 0 && !DeadBool)
        {
            DeadBool = true;
            Split();
        }
    }

    void Split()
    {
        for (int i = 0; i < SplitCount; i++)
        {
            Vector3 position = transform.position + new Vector3((i - (SplitCount - 1) / 2f) * 1.0f, 0f, 0f);
            GameObject game = Instantiate(SelfRelatedObj, position, Quaternion.identity);
            game.transform.parent = transform.parent;
        }

        //for (int i = 0; i < objectCount; i++)
        //{
        //    // �߽� ��ġ�� �������� ���ݿ� �°� ������Ʈ ����
        //    Vector3 position = centerPosition + new Vector3((i - (objectCount - 1) / 2f) * spacing, 0f, 0f);
        //    Instantiate(objectPrefab, position, Quaternion.identity);
        //}
    }
}
