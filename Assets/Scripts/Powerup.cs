using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player")) pickup(other);
    }

    void pickup(Collider player) {
        FPSInput controls = player.GetComponent<FPSInput>();
        controls.jetpack = true;
        Destroy(gameObject);
    }
}
