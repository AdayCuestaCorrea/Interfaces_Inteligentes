using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstObjectName = "Red_Cube";
    public string secondObjectName = "Green_Cylinder";
    private GameObject firstObject;
    private GameObject secondObject;
    void Start() {
      firstObject = GameObject.Find(firstObjectName);
      secondObject = GameObject.Find(secondObjectName);
      Debug.Log("Distance between " + gameObject.name + " and " + firstObjectName + ": " + Vector3.Distance(transform.position, firstObject.transform.position));
      Debug.Log("Distance between " + gameObject.name + " and " + secondObjectName + ": " + Vector3.Distance(transform.position, secondObject.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
