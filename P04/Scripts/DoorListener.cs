using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : MonoBehaviour {
  public delegate void DoorOpenedHandler();
  public static event DoorOpenedHandler OnDoorOpened;
  public static void DoorOpened() {
    OnDoorOpened?.Invoke();
  }
}
