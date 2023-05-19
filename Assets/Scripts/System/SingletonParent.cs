using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonParent<T> : MonoBehaviour where T  : MonoBehaviour
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if(instance == null)
                {
                    GameObject Go = new GameObject(instance.GetType().Name);
                    instance = Go.AddComponent<T>();
                }
            }
            return instance;
           
        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this as T;
    }
}
