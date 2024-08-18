using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutout : MonoBehaviour {
    private static readonly int CutoutComplete = Animator.StringToHash("CutoutComplete");
    [SerializeField] private GameObject baseSprite;
    
    [SerializeField] private Animator popUpAnimator;
    [SerializeField] private Animator cardAnimator;
    
    [SerializeField] private Reaction reaction;

    [SerializeField] private Timer timer;
    
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
            if (_drawing.LineDrawn || timer.timeRemaining < 0.1f) {
                _polygon.Build();
                _score = _checkAccuracy.CalculateScore();
                reaction.React(_score);
                baseSprite.SetActive(false);
                _complete = true;
                PersistenceManager.Instance.score += _score;
                StartCoroutine(ExitScene());
            }
        }
    }

    private IEnumerator ExitScene() {
        cardAnimator.SetTrigger(CutoutComplete);
        yield return new WaitForSeconds(0.75f);
        popUpAnimator.SetTrigger(CutoutComplete);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DressUpGame", LoadSceneMode.Single);
    }
}
