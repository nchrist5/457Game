using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    private Vector3 target;
    public static float shipRot;

    // Update is called once per frame
    void FixedUpdate()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);


        Vector3 difference = target - player.transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90;
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        shipRot = rotationZ;
    }
}
