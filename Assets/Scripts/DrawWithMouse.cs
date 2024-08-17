using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {
    [SerializeField] private GameObject line;
    private Coroutine _drawing;

    public List<Vector2> Points { get; private set; } = new();

    private void Start() {
        Points.Add(new Vector2(0, 0));
    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) StartLine();
        if (Input.GetMouseButtonUp(0)) FinishLine();
    }

    private void StartLine() {
        if (_drawing != null) StopCoroutine(_drawing);
        if (Points.Any()) Points.Clear();
        _drawing = StartCoroutine(DrawLine());
    }

    private void FinishLine() {
        StopCoroutine(_drawing);
    }

    private IEnumerator DrawLine() {
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        while (true) {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Points.Add(new Vector2(position.x, position.y));
            position.z = 0;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
            yield return null;
        }
    }
}