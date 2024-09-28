/** Universidad de La Laguna
  * Escuela Superior de Ingeniería y Tecnología
  * Grado en Ingeniería Informática
  * Asignatura: Interfaces Inteligentes
  * Curso: 4º
  * Práctica 1: Introducción a Unity
  * Autor: Aday Cuesta Correa
  * Correo: alu0101483887@ull.edu.es
  * Fecha: 28/09/2024
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintPosition : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    Debug.Log("Object called " + gameObject.name + " Position: " + transform.position);
  }

  // Update is called once per frame
  void Update() {
    Debug.Log("Object called " + gameObject.name + " Position: " + transform.position);
  }
}
