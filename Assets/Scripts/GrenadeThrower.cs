using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject GrenadePref;
    public GameObject FirePoint;
    public float throwForce = 300;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ThrowGrenade()
    {
        
        GameObject grenadeObject = Instantiate(GrenadePref, FirePoint.transform.position, FirePoint.transform.rotation);
        Rigidbody grenadeRigidbody = grenadeObject.GetComponent<Rigidbody>();
        grenadeRigidbody.AddRelativeForce(FirePoint.transform.forward * throwForce, ForceMode.Impulse);
        
    }
}
