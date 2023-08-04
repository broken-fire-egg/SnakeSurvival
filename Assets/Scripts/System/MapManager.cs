using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapTile
{
    public Vector2 position;
}

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public MapInfo mapInfo;

    GameObject bgGroup;
    GameObject hero;
    Vector2 heroPos;

    private void Awake()
    {
        instance = this;
        MapInfoSetting();
        heroPos = Vector2.zero;
    }
    private void Start()
    {
        bgGroup = GameObject.Find("BackGround");
        hero = SnakeHead.instance.gameObject;

    }
    private void Update()
    {
        bgGroup.transform.position = new Vector3((int)(hero.transform.position.x / 10) * 10, (int)(hero.transform.position.y / 10) * 10);
        
        
    }

    public void MapInfoSetting()
    {
        for (int i = 0; i < mapInfo.mapSize.y; i++)
        {
            string line = mapInfo.csv.text.Split('\n')[i];
            for (int j = 0; j < mapInfo.mapSize.x; j++)
            {
                var info = line.Split(',')[j];

                if(info == "3")
                {


                }
            }
        }
    }

}
