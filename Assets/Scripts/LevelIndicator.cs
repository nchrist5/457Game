using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndicator : MonoBehaviour
{
    public Text indicator;
    public Text mainIndicator;
    private float showIndicator = 2.5f;
    private float endIndicator;

    // Start is called before the first frame update
    void Start()
    {
        mainIndicator.enabled = false;
        indicator.enabled = true;
        endIndicator = Time.time + showIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        if (indicator.enabled & Time.time > endIndicator)
        {
            indicator.enabled = false;
            mainIndicator.enabled = true;
        }
    }
}
