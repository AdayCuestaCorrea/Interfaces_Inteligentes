using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeightOfFurthestObject : MonoBehaviour {
  public string objectTag = "SphereGroup2";
  public float increase = 0.1f;
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

    // Update is called once per frame
  void Update() {
    furthestObject.transform.position = new Vector3(furthestObject.transform.position.x, furthestObject.transform.position.y + increase * Time.deltaTime, furthestObject.transform.position.z);
  }
}
