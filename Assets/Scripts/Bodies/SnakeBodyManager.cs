using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyManager : MonoBehaviour
{
    static public SnakeBodyManager instance;
    public List<GameObject> bodiesGO;
    List<SnakeBody> bodies;
    public GameObject prefBody;
    public int bodyCount;
    public int maxBodyCount;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        bodies = new List<SnakeBody>();
    }
    private void Start()
    {
         Init();
        // AddBody(); //temp
    }
    private void Update()
    {
        UpdateBodiesPosition();


    }

    void UpdateBodiesPosition()
    {
        for(int i= 0;i<bodies.Count;i++)
        {
            bodies[i].Move(i);
            bodies[i].CheckOverMoved();
        }

    }


    public void AlertNewPH(SnakeHead.PosHistory newPH)
    {




        foreach (var body in bodies)
        {
            if(body.destination == null)
                body.destination = newPH;
        }
    }
    public void Init()
    {
        for(int i = 0; i < maxBodyCount; i++)
        {
            GameObject newGO;
            if (bodiesGO[i] == null)
            {
                newGO = Instantiate(prefBody, transform);
                if (i == 0)
                    newGO.transform.position = SnakeHead.instance.transform.position + Vector3.down;
                else
                    newGO.transform.position = bodiesGO[i - 1].transform.position + Vector3.down;
                bodiesGO.Add(newGO);
                bodies.Add(newGO.GetComponent<SnakeBody>());
                if (i < bodyCount)
                    bodies[i].Activate();
            }
            else
            {
                newGO = bodiesGO[i];
                if (i == 0)
                    newGO.transform.position = SnakeHead.instance.transform.position + Vector3.down;
                else
                    newGO.transform.position = bodiesGO[i - 1].transform.position + Vector3.down;
                bodies.Add(newGO.GetComponent<SnakeBody>());
                if (i < bodyCount)
                    bodies[i].Activate();
            }
        }
        
    }
    public void AddBody(SnakeBody newbody)
    {
        newbody.CopyValue(bodies[bodyCount]);

        bodies[bodyCount] = newbody;

        bodyCount++;

        //newbody.Activate();
        //bodies[bodyCount - 1].Activate();
    }
}
