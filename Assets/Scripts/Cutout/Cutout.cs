using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutout : MonoBehaviour {
    private DrawWithMouse _drawing;
    private CreatePolygon _polygon;
    private CheckAccuracy _checkAccuracy;

    private bool _complete;
    
    private int _score;

    private void Start() {
        if (PersistenceManager.Instance.cutoutMesh != null) {
            _complete = true;
        }
        _drawing = GetComponent<DrawWithMouse>();
        _polygon = GetComponent<CreatePolygon>();
        _checkAccuracy = GetComponent<CheckAccuracy>();
        
        
    }

    private void Update() {
        if (_drawing.LineDrawn && !_complete) {
            _polygon.Build();
            _score = _checkAccuracy.CalculateScore();
            _complete = true;
            SceneManager.LoadScene("DressUpGame", LoadSceneMode.Single);
        }
    }
}
