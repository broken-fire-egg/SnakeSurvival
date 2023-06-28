using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> : MonoBehaviour
{
    public class PoolObject
    {
        public T component;
        public GameObject gameObject;
        public SpriteRenderer spriteRenderer;
        public PoolObject(T component, GameObject gameObject)
        {
            this.gameObject = gameObject;
            this.component = component;
            this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void SetPositionAndActive(Vector3 pos)
        {
            gameObject.transform.position = pos;
            gameObject.SetActive(true);
        }

    }
    public int defaultCap;
    public GameObject origin;
    public List<PoolObject> poolObjects;
    private bool alreadyInit;
    public bool isUI;
    public bool hasPivot;
    public RectTransform UICanvas;
    public void Start()
    {
        if (alreadyInit)
            return;
        alreadyInit = true;
        poolObjects = new List<PoolObject>();
        for (int i = 0; i < defaultCap; i++)
        {
            GameObject newgo;
            if (isUI)
                newgo = Instantiate(origin, UICanvas);
            else
                newgo = Instantiate(origin, gameObject.transform);


            if (hasPivot)
                poolObjects.Add(new PoolObject(newgo.transform.GetChild(0).GetComponent<T>(), newgo.gameObject));
            else
                poolObjects.Add(new PoolObject(newgo.GetComponent<T>(), newgo.gameObject));
        }
    }
    public void SetValue(int defaultCap, GameObject origin)
    {
        this.defaultCap = defaultCap;
        this.origin = origin;
    }
    public void SetLayerOrder(int n)
    {
        if (poolObjects[0].spriteRenderer)
            foreach (var po in poolObjects)
            {
                po.spriteRenderer.sortingOrder = n;
            }
    }
    /// <summary>
    /// 오브젝트 풀에서 쉬는놈 가져옴
    /// </summary>
    /// <returns>쉬는놈,
    /// <para>없으면 null</para></returns>
    public PoolObject GetRestingPoolObject()
    {
        foreach (var po in poolObjects)
        {
            if (!po.gameObject.activeInHierarchy)
                return po;
        }
        return null;

    }

}
