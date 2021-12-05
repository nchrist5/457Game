using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public FloatValue damageMax;
    public FloatValue shieldMax;
    public FloatValue healthMax;
    // Start is called before the first frame update
    public void restart()
    {
        PlayerController.lives = 3;
        damageMax.RuntimeValue = damageMax.initialValue;
        shieldMax.RuntimeValue = shieldMax.initialValue;
        healthMax.RuntimeValue = healthMax.initialValue;
        PlayerWeapon.shotgun = false;
        PlayerWeapon.railgun = false;
        PlayerWeapon.upgrade = false;
        PlayerWeapon.grenade = false;
        PlayerWeapon.defaultWeapon = true;
    }
}
