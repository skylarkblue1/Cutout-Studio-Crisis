using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Rigidbody2D>(out _rb)) {
            _rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (other.gameObject.name == "Eyes") {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Rigidbody2D>(out _rb)) {
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
