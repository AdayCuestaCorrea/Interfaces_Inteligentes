using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPosition : MonoBehaviour {
  // Reference to the TextMeshProUGUI component
  [SerializeField] private TMP_Text positionText;

  // Start is called before the first frame update
  void Start() {
    if (positionText == null) {
      Debug.LogError("Position Text is not assigned.");
    }
  }

  // Update is called once per frame
  void Update() {
    if (positionText != null) {
      Vector3 parentPosition = transform.parent.position;
      positionText.text = transform.parent.name + " Position: " + parentPosition.ToString();
    }
  }
}