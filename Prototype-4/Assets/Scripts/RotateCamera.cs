using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
  // Degrees/sec -- default, tune in Inspector.
  public float rotationSpeed = 45;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      var rotationInput = Input.GetAxis("Horizontal");
      transform.Rotate(Vector3.up,
        rotationInput * rotationSpeed * Time.deltaTime);
  }
}
