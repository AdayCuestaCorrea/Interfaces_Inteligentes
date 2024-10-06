using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Stats : MonoBehaviour {
  public Vector3 firstVector = new Vector3(1, 2, 3);
  public Vector3 secondVector = new Vector3(4, 5, 6);
  [SerializeField] private int firstVectorMagnitude;
  [SerializeField] private int secondVectorMagnitude;
  [SerializeField] private int angleBetweenVectors;
  [SerializeField] private int distanceBetweenVectors;
  [SerializeField] private string higherVector;
  void Start() {
    
  }
  // Update is called once per frame
  void Update() {
    firstVectorMagnitude = (int)firstVector.magnitude;
    secondVectorMagnitude = (int)secondVector.magnitude;
    angleBetweenVectors = (int)Vector3.Angle(firstVector, secondVector);
    distanceBetweenVectors = (int)Vector3.Distance(firstVector, secondVector);
    higherVector = firstVector[2] > secondVector[2] ? "First Vector is higher" : "Second Vector is higher";
  }
}
