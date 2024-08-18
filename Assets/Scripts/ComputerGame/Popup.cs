using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Popup : MonoBehaviour {
    [SerializeField] List<Sprite> sprites;


    private void Awake() {
        this.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Count)];
    }
    public void Die() {
        Destroy(this.gameObject);
    }
}