using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveWeapon : MonoBehaviour
{
    public FloatValue damageMax;

    public void IncreaseDamage()
    {
        damageMax.RuntimeValue = damageMax.RuntimeValue += 10;
    }
}
