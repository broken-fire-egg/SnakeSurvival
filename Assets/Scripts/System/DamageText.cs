using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    Vector3 position;
    
    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }
    private void Update()
    {
        transform.position = position;
    }
}
