using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class CreatePolygon : MonoBehaviour
{
    [SerializeField] private DrawWithMouse drawing;
    [SerializeField] private Material material;
    [SerializeField] private GameObject polygon;

    private PolygonCollider2D polygonCollider;
    private Mesh _mesh;

    private void Start() {
        polygonCollider = polygon.GetComponent<PolygonCollider2D>();
    }
    
    void Update() {
        if (Input.GetMouseButtonUp(0) && drawing.Points.Any()) {
            var simplifiedPoints = new List<Vector3>();
            LineUtility.Simplify(drawing.Points, 0.1f, simplifiedPoints);
            
            Vector2[] points = simplifiedPoints.Select(p => new Vector2(p.x, p.y)).ToArray();

            polygonCollider.points = points;

            if (_mesh) _mesh.Clear();
            
            _mesh = polygonCollider.CreateMesh(false, false);
            
            GetComponent<MeshFilter>().mesh = _mesh;
            
            drawing.Points.Clear();
        }
    }
}
