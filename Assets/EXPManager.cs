using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EXPManager : MonoBehaviour
{
    static public EXPManager instance;
    public class ExpOP : ObjectPooling<Item>
    {
        public void Init(GameObject go,int defaultCap_ = 10)
        {
            defaultCap = defaultCap_;
            origin = go;
            base.Start();
        }
    }

    public ExpOP itemOP;
    public GameObject origin;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        itemOP = transform.AddComponent<ExpOP>();
        itemOP.Init(origin, 40);
    }



}
