using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class ComputerGame : MonoBehaviour {
    [SerializeField] private GameObject popup;
    [SerializeField] private Image customerImage;
    [SerializeField] private Timer timer;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Button done;

    [SerializeField] private TMPro.TMP_Dropdown firstName;
    [SerializeField] private TMPro.TMP_Dropdown lastName;

    [SerializeField] private TMP_Text request;

    private CustomerData _customer;

    private Coroutine _showPopup;

    [SerializeField] AudioSource popupOpen;

    private bool _done;

    private int _score;

    private float xmin = 5.047315f;
    private float xmax = 668f;
    private float ymin = 207f;
    private float ymax = -108f;

    private void Start() {
        if (PersistenceManager.Instance.cutoutMesh) {
            PersistenceManager.Instance.cutoutMesh = null;
        }
        
        foreach (GameObject cust in PersistenceManager.Instance.customerList) {
            if (cust.GetComponent<CustomerData>().custNum == PersistenceManager.Instance.customerNumber) {
                _customer = cust.GetComponent<CustomerData>();
            }
        }

        customerImage.sprite = _customer.GetComponent<Image>().sprite;
        request.text = $"I would like a cutout of {_customer.firstName} {_customer.lastName}";

        _showPopup = StartCoroutine(ShowPopup());
    }

    private void Update() {
        done.onClick.AddListener(() => {
            StopCoroutine(_showPopup);
            _done = true;
        });
        if (timer.timeRemaining < 0.1f) {
            StopCoroutine(_showPopup);
            _done = true;
        }

        if (_done) {
            if (firstName.options[firstName.value].text == _customer.firstName)
                _score += 50;
            
            if (lastName.options[lastName.value].text == _customer.lastName)
                _score += 50;
            
            PersistenceManager.Instance.score += _score;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator ShowPopup() {
        while (true) {
            float delay = Random.Range(0.5f * 1 / (PersistenceManager.Instance.ordersComplete + 1),
                3.0f * 1 / (PersistenceManager.Instance.ordersComplete + 1));

            Vector2 position = new Vector2(Random.Range(xmin, xmax), Random.Range(ymin, ymax));

            yield return new WaitForSeconds(delay);
            Instantiate(popup, canvas.transform, false);
            popup.transform.localPosition = position;

            popupOpen.Play(0);
        }
    }
}