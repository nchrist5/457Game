using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveHealth : MonoBehaviour
{
    public FloatValue healthMax;

    // Update is called once per frame
    public void IncreaseHealth()
    {
        healthMax.RuntimeValue += 10;
    }
}
