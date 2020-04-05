using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Floating : MonoBehaviour
{
    public float waterLevel = 0.0f;
    public float floatTreshhold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 1.0f;
    public float floatingForce = 0.001f;
    float forceFactor;
    Vector3 floatForce;


    private void FixedUpdate()
    {
        forceFactor = 1.0f - (transform.position.y - waterLevel) / floatTreshhold;

        downForce = Mathf.Abs(2* Mathf.Sin(Time.time *2));


        if (forceFactor > 0.0f)
        {
            var rigidbody = GetComponent<Rigidbody>();
            floatForce = -Physics.gravity * rigidbody.mass * (forceFactor - rigidbody.velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce * rigidbody.mass, 0.0f);
            rigidbody.AddForceAtPosition(floatForce, transform.position);
        }
    }
}
