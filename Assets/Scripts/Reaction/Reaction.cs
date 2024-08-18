using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {
    [SerializeField] private Sprite bad;
    [SerializeField] private Sprite good;

    [SerializeField] private AudioSource stampSound;
    
    private SpriteRenderer _sr;

    private void Start() {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void React(int score) {
        _sr.sprite = score > 50 ? good : bad;
        // stampSound.Play(0);
    }
}
