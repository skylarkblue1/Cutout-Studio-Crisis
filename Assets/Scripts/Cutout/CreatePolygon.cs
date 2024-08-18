using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class CreatePolygon : MonoBehaviour {
    [SerializeField] private DrawWithMouse drawing;
    [SerializeField] private GameObject polygon;

    private PolygonCollider2D _polygonCollider;
    private Mesh _mesh;

    private void Start() {
        _polygonCollider = polygon.GetComponent<PolygonCollider2D>();
        if (PersistenceManager.Instance.cutoutMesh != null)
        {
            _mesh = PersistenceManager.Instance.cutoutMesh;
            GetComponent<MeshFilter>().mesh = _mesh;
            
            _polygonCollider.points = _mesh.vertices.Select(p => new Vector2(p.x, p.y)).ToArray();
        }
    }

    public void Build() {
        var simplifiedPoints = new List<Vector3>();
        LineUtility.Simplify(drawing.Points, 0.1f, simplifiedPoints);

        Vector2[] points = simplifiedPoints.Select(p => new Vector2(p.x, p.y)).ToArray();

        _polygonCollider.points = points;
        
        PersistenceManager.Instance.polygonPoints = points;

        if (_mesh) _mesh.Clear();

        _mesh = _polygonCollider.CreateMesh(false, false);

        GetComponent<MeshFilter>().mesh = _mesh;

        PersistenceManager.Instance.cutoutMesh = _mesh;
        
        drawing.Points.Clear();
    }
}