using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCollection : MonoBehaviour
{
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void PhysicSimulate()
    {
        Physics2D.simulationMode = SimulationMode2D.Script;
        Physics2D.Simulate(0.001f);
        Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
    }
}
