using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveShield : MonoBehaviour
{
    public FloatValue shieldMax;

    public void IncreaseSheild()
    {
        shieldMax.RuntimeValue = shieldMax.RuntimeValue += 0.5f;
    }
}
