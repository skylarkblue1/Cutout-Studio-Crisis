using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {
    [SerializeField] private GameObject line;
    private Coroutine _drawing;
    public bool LineDrawn { get; private set; } = false;

    public List<Vector3> Points { get; private set; } = new();

    private void Start() {
        if (PersistenceManager.Instance.cutoutMesh != null) LineDrawn = true;
    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0) && !LineDrawn) StartLine();
        if (Input.GetMouseButtonUp(0) && !LineDrawn) FinishLine();
    }

    private void StartLine() {
        if (_drawing != null) StopCoroutine(_drawing);
        if (Points.Any()) Points.Clear();
        _drawing = StartCoroutine(DrawLine());
    }

    private void FinishLine() {
        StopCoroutine(_drawing);
        LineDrawn = true;
    }

    private IEnumerator DrawLine() {
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        while (true) {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D targetObject = Physics2D.OverlapPoint(position);
            if (targetObject) {
                if (targetObject.gameObject.name == "Cardboard") {
                    position.z = 0;
                    Points.Add(position);
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
                };
            }
            yield return null;
        }
    }
}