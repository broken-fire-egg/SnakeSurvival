using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator Anim;
    public enum TypeMucus
    {
        sticky,
        corrosion,
        every
    }
    public TypeMucus MucusType;
    public float MucusTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= MucusTime)
            Destroy(gameObject);
    }

    private void OnTriggerStay(Collider col)
    {
        if (MucusType != TypeMucus.sticky)
            col.GetComponent<SnakeHead>().HP--;
        else if (MucusType != TypeMucus.corrosion)
            col.GetComponent<SnakeHead>().speed = col.GetComponent<SnakeHead>().speed / 2f;
    }

}
