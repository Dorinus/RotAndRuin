using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crossHairScript : MonoBehaviour
{
    private Image crosshair;

    void Start() {
        // Find the crosshair image in the scene by tag
        crosshair = GameObject.FindGameObjectWithTag("crosshair").GetComponent<Image>();
    }

    void Update () {
        if (Input.GetButton("Fire2")) {
            crosshair.enabled = true;
        } else {
            //crosshair.enabled = false;
        }
    }
}
