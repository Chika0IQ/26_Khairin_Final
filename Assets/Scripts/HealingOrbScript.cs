using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrbScript : MonoBehaviour
{

    private float spinSpeed = 50f;

    public AnimationCurve myCurve;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed * Time.deltaTime, 0));
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}