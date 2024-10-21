using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {
  private GameObject egg;
  private Vector3 eggPosition;
  public float speed = 1.0f;
  private Rigidbody rb;
  private AnimationsController animationsController;
  void Start() {
    egg = null;
    rb = GetComponent<Rigidbody>();
    animationsController = GetComponent<AnimationsController>();
    // Desactivar el control de rotación del script de animación
    if (animationsController != null) {
      animationsController.controlRotation = false;
    }
  }

  void OnEnable() {
    MovingTo.OnMovingToEggType1 += HandleMovingToEggType1;
  }

  void OnDisable() {
    MovingTo.OnMovingToEggType1 -= HandleMovingToEggType1;
  }

  void FixedUpdate() {
    if (egg != null) {
      eggPosition = egg.transform.position;
      Vector3 direction = (eggPosition - transform.position);
      direction.y = 0; // Mantener la componente Y en cero para rotar solo en el plano horizontal
      Quaternion rotation = Quaternion.LookRotation(direction);
      rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotation, speed * Time.deltaTime));
    }
  }
  void OnDestroy() {
    // Restaurar el control de rotación del script de animación
    if (animationsController != null) {
      animationsController.controlRotation = true;
    }
  }

  void HandleMovingToEggType1() {
    egg = GameObject.FindGameObjectWithTag("Egg_Type2");
  }
}
