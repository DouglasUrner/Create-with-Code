using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Default speed, tune in Inspector.
  public float speed = 5.0f;

  private Rigidbody playerRb;
  private GameObject focalPoint;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    focalPoint = GameObject.Find("Focal Point");
  }

  // Update is called once per frame
  void Update()
  {
    var forwardInput = Input.GetAxis("Vertical");
    playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
  }
}
