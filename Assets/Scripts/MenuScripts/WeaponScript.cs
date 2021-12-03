using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public void upgradeAquired()
    {
        PlayerWeapon.upgrade = true;
    }
    
    public void railgunAquired()
    {
        PlayerWeapon.railgun = true;
    }
    public void shotgunAquired()
    {
        PlayerWeapon.shotgun = true;
    }
    public void grenadeAquired()
    {
        PlayerWeapon.grenade = true;
    }
}
