using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAndPosRandom : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    color = new Color(Random.value, Random.value, Random.value);
    GetComponent<Renderer>().material.color = color;
  }
  // Update is called once per frame
  void Update() {
    frameCounter++;
    if (frameCounter >= framesToWait) {
      // Resetear el contador de frames
      frameCounter = 0;
      // Cambiar el valor de una posición aleatoria
      int randomIndex = Random.Range(0, 3);
      switch (randomIndex) {
        case 0:
          color.r = Random.value;
          break;
        case 1:
          color.g = Random.value;
          break;
        case 2:
          color.b = Random.value;
          break;
      }
      // Asignar el nuevo color
      GetComponent<Renderer>().material.color = color;
    }
  }
  public int framesToWait = 120;
  private int frameCounter = 0;
  private Color color;
}
