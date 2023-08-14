using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverPatternManager : MonoBehaviour
{
    public delegate void VoidDelegate();
    public delegate void FloatDelegate();


    public FloatDelegate OnHeal;


}
