using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutout : MonoBehaviour {
    private static readonly int CutoutComplete = Animator.StringToHash("CutoutComplete");
    [SerializeField] private GameObject baseSprite;
    
    [SerializeField] private Animator popUpAnimator;
    [SerializeField] private Animator cardAnimator;
    
    [SerializeField] private Reaction reaction;
    
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
                reaction.React(_score);
                baseSprite.SetActive(false);
                _complete = true;
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
