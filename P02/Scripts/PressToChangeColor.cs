using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToChangeColor : MonoBehaviour {
    // Key to press to change color
    public KeyCode key = KeyCode.C;

    // Update is called once per frame
    void Update() {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(key)) {
            // Change the color of the object to a random color
            ChangeColor();
        }
    }

    // Method to change the color of the object to a random color
    void ChangeColor() {
        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Apply the random color to the object's material
        GetComponent<Renderer>().material.color = randomColor;
    }
}