using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public void upgradeAquired()
    {
        PlayerWeapon.defaultWeapon = false;
        PlayerWeapon.upgrade = true;
    }
    
    public void railgunAquired()
    {
        PlayerWeapon.defaultWeapon = false;
        PlayerWeapon.railgun = true;
    }
    public void shotgunAquired()
    {
        PlayerWeapon.defaultWeapon = false;
        PlayerWeapon.shotgun = true;
    }
    public void grenadeAquired()
    {
        PlayerWeapon.defaultWeapon = false;
        PlayerWeapon.grenade = true;
    }
}
