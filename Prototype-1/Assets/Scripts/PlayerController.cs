using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30.0f;
    public float yawRate = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var forwardInput = Input.GetAxis("Vertical");
        var steeringInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, steeringInput * yawRate * Time.deltaTime);
    }
}
