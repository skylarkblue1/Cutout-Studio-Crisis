using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    private Rigidbody2D  _selectedObject;
    private Vector3 _mousePosition;
    private Vector3 _offset;
    
    private bool _isDragging;
    private void Update() {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0) && !_isDragging) {
            Collider2D targetObject = Physics2D.OverlapPoint(_mousePosition);

            if (targetObject)
            {
                _selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
            }
            
            _isDragging = true;
        }
        
        if (Input.GetMouseButtonUp(0) && _selectedObject)
        {
            _selectedObject = null;
            _isDragging = false;
        }
    }

    private void FixedUpdate() {
        if (_selectedObject) {
            _offset = _selectedObject.transform.position - _mousePosition;
            _selectedObject.MovePosition(new Vector2(_mousePosition.x, _mousePosition.y));
        }
    }
}