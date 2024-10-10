using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
  public Vector3 offset1 = new Vector3(0.1f, 0.2f, 0.3f);
  public Vector3 offset2 = new Vector3(0.4f, 0.5f, 0.6f);
  public Vector3 offset3 = new Vector3(0.7f, 0.8f, 0.9f); 
  private GameObject firstObject;
  private GameObject secondObject;
  private GameObject thirdObject;
  void Start() {
    firstObject = GameObject.Find("Cube_1");
    secondObject = GameObject.Find("Cube_2");
    thirdObject = GameObject.Find("Cube_3");
  }
  void Update() {
    if (Input.GetAxis("Jump") > 0) {
      firstObject.transform.position += offset1 * Time.deltaTime;
      secondObject.transform.position += offset2 * Time.deltaTime;
      thirdObject.transform.position += offset3 * Time.deltaTime;
    }
  }
}