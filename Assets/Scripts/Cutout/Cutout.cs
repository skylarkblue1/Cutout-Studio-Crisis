using UnityEngine;

public class Cutout : MonoBehaviour {
    private DrawWithMouse _drawing;
    private CreatePolygon _polygon;
    private CheckAccuracy _checkAccuracy;

    private bool _complete;
    
    private int _score;

    private void Start() {
        _drawing = GetComponent<DrawWithMouse>();
        _polygon = GetComponent<CreatePolygon>();
        _checkAccuracy = GetComponent<CheckAccuracy>();
    }

    private void Update() {
        if (_drawing.LineDrawn && !_complete) {
            _polygon.Build();
            _score = _checkAccuracy.CalculateScore();
            _complete = true;
        }
    }
}
