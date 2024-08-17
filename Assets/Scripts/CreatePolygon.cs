using System;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class CreatePolygon : MonoBehaviour
{
    [SerializeField] private DrawWithMouse drawing;
    [SerializeField] private SpriteShapeController sprite;
    [SerializeField] private Material material;
    // private PolygonCollider2D _polygon;
    
    private void Start() {
        // _polygon = GetComponent<PolygonCollider2D>();
        // _polygon.points = Array.Empty<Vector2>();
        print(sprite.spline);
        print(sprite.spriteShape);
    }

    void Update() {
        if (Input.GetMouseButtonUp(0) && drawing.Points.Any()) {
            // _polygon.points = drawing.Points.ToArray();
            // Mesh mesh = _polygon.CreateMesh(false, false);
            drawing.Points.Clear();
        }
    }
}
