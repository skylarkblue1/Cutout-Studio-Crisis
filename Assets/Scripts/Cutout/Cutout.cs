using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutout : MonoBehaviour {
    [SerializeField] private GameObject baseSprite;
    [SerializeField] private GameObject cardboard;
    [SerializeField] private ParticleSystem particles;
    
    private DrawWithMouse _drawing;
    private CreatePolygon _polygon;
    private CheckAccuracy _checkAccuracy;

    private bool _complete;
    
    private int _score;

    private void Start() {
        if (PersistenceManager.Instance.cutoutMesh != null) {
            _complete = true;
        }
        else {
            _drawing = GetComponent<DrawWithMouse>();
            _polygon = GetComponent<CreatePolygon>();
            _checkAccuracy = GetComponent<CheckAccuracy>();
        }
    }

    private void Update() {
        if (!_complete) {
            if (_drawing.LineDrawn) {
                _polygon.Build();
                _score = _checkAccuracy.CalculateScore();
                baseSprite.SetActive(false);
                cardboard.SetActive(false);
                _complete = true;
                // SceneManager.LoadScene("DressUpGame", LoadSceneMode.Single);
            }
        }
    }
}
