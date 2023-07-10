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
        //    // 중심 위치를 기준으로 간격에 맞게 오브젝트 생성
        //    Vector3 position = centerPosition + new Vector3((i - (objectCount - 1) / 2f) * spacing, 0f, 0f);
        //    Instantiate(objectPrefab, position, Quaternion.identity);
        //}
    }
}
