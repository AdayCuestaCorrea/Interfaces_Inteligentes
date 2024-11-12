using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointingEgg : MonoBehaviour
{
    public delegate void pointingAtEgg(GameObject egg);
    public static event pointingAtEgg onPointingEgg;

    public float activationDistance = 1.5f; // Set the distance within which the event can be triggered
    private GameObject player;
    private bool isPointing = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= activationDistance && isPointing) {
            isPointing = true;
            onPointingEgg?.Invoke(this.gameObject);
        }
    }

    public void OnPointerEnter() {
      isPointing = true;
    }

    public void OnPointerExit() {
      isPointing = false;
    }
}