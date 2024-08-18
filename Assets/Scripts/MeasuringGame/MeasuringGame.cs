using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeasuringGame : MonoBehaviour
{
    private static readonly int CutoutComplete = Animator.StringToHash("CutoutComplete");
    [SerializeField] private GameObject ruler;
    [SerializeField] private GameObject marker;
    
    [SerializeField] private Timer timer;
    
    [SerializeField] private Reaction reaction;
    
    private Vector3 _markerPosition;
    private float _markerWidth;
    private float _rulerWidth;
    private float _counter;

    private bool _complete;
    
    private CustomerData _customer;

    private void Start()
    {
        foreach (GameObject cust in PersistenceManager.Instance.customerList) {
            if (cust.GetComponent<CustomerData>().custNum == PersistenceManager.Instance.customerNumber) {
                _customer = cust.GetComponent<CustomerData>();
            }
        }
        
        _markerWidth = marker.GetComponent<RectTransform>().rect.width;
        _rulerWidth = ruler.GetComponent<RectTransform>().rect.width;
        
        // float height = Random.Range(100f, 250f);
        float oldRange = (250 - 100);
        float newRange = (850 - -730);
        float newValue = (((_customer.height - 100) * newRange) / oldRange) + -730;

        _markerPosition = marker.transform.localPosition;
        _markerPosition.x = newValue;
        marker.transform.localPosition = _markerPosition;
    }

    private void Update() {
        if (!_complete) {
            var transformPosition = ruler.transform.localPosition;
            transformPosition.x += 360 * (PersistenceManager.Instance.ordersComplete + 1) * Time.deltaTime;
            ruler.transform.localPosition = transformPosition;
        
            _counter = transformPosition.x + (_rulerWidth / 2);
        }
        
        if (Input.GetMouseButtonDown(0)) {
            int score;
            if (_counter < (_markerPosition.x + (_markerWidth / 2)) && _counter > (_markerPosition.x - (_markerWidth / 2))) {
                score = 100;
            }
            else {
                score = 0;
                
            }
            reaction.React(score);
            _complete = true;
            reaction.GetComponent<Animator>().SetTrigger(CutoutComplete);
            PersistenceManager.Instance.score += score;
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Cutout", LoadSceneMode.Single);
    }
}
