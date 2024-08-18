using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ComputerGame : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private Image customerImage;
    [SerializeField] private Timer timer;
    
    [SerializeField] private Canvas canvas;
    
    [SerializeField] private Text request;
    
    private CustomerData _customer;

    private float xmin = 5.047315f;
    private float xmax = 668f;
    private float ymin = 207f;
    private float ymax = -108f;

    private void Start() {
        foreach (GameObject cust in PersistenceManager.Instance.customerList) {
            if (cust.GetComponent<CustomerData>().custNum == PersistenceManager.Instance.customerNumber) {
                _customer = cust.GetComponent<CustomerData>();
            }
        }
        
        customerImage.sprite = _customer.GetComponent<Image>().sprite;
        request.GetComponent<Text>().text = $"I would like a cutout of {_customer.firstName} {_customer.lastName}";
        StartCoroutine(ShowPopup());
    }

    private void Update() {
        
    }

    private IEnumerator ShowPopup() {
        while (true) {
            float delay = Random.Range(0.5f * 1 / (PersistenceManager.Instance.ordersComplete + 1), 3.0f * 1 / (PersistenceManager.Instance.ordersComplete + 1));
        
            Vector2 position = new Vector2(Random.Range(xmin, xmax), Random.Range(ymin, ymax));
            
            yield return new WaitForSeconds(delay);
            Instantiate(popup, canvas.transform, false);
            popup.transform.localPosition = position;
        }
    }

}
