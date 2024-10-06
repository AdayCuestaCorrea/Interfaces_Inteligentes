using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOfFurthestObject : MonoBehaviour {
  public KeyCode key = KeyCode.Space;
  public string objectTag = "SphereGroup1";
  private GameObject referenceObject;
  private GameObject furthestObject;
  void Start() {
    referenceObject = gameObject;
    furthestObject = GameObject.FindGameObjectsWithTag(objectTag)[0];
    foreach (GameObject obj in GameObject.FindGameObjectsWithTag(objectTag)) {
      if (Vector3.Distance(referenceObject.transform.position, obj.transform.position) > Vector3.Distance(referenceObject.transform.position, furthestObject.transform.position)) {
        furthestObject = obj;
      }
    }
  }

  void Update() {
    // Check if the specified key is pressed
    if (Input.GetKeyDown(key)) {
      // Change the color of the object to a random color
      ChangeColor();
    }
  }

  // Method to change the color of the object to a random color
  void ChangeColor() {
    // Generate a random color
    Color randomColor = new Color(Random.value, Random.value, Random.value);
    // Apply the random color to the object's material
    furthestObject.GetComponent<Renderer>().material.color = randomColor;
  }
}
