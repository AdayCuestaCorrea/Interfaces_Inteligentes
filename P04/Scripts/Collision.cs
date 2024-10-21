using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject newPrefab; // Referencia al nuevo prefab

    void OnCollisionEnter(UnityEngine.Collision collision) {
      // Instanciar el nuevo prefab en la misma posición y rotación
      GameObject newObject = Instantiate(newPrefab, collision.transform.position, collision.transform.rotation);
      // Destruir el objeto colisionado
      Destroy(collision.gameObject);
    }
}
