using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MapInfo",menuName = "ScriptableObjects/new MapInfo")]
public class MapInfo : ScriptableObject
{
    public Vector2 mapSize;
    public List<GameObject> MapObjects;
    public TextAsset csv;
}
