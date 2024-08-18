using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerData : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public float height;
    public string eyes;
    public string hair;

    public GameObject celebDatabaseObj;
    public CelebDatabase database;

    public Button customerButt;

    public TMP_Text messageText;
    public string orderMessage;

    public GameObject customerControllerObj;
    public CustomerController controller;

    public int custNum;

    void Awake()
    {
        // Grab text
        database = GameObject.Find("CelebDatabase").GetComponent<CelebDatabase>();
        messageText = GameObject.Find("OrderMessage").GetComponent<TMP_Text>();

        // Get it's own button
        customerButt = GetComponentInParent<Button>();

        // Get order data
        int index = Random.Range(0, 2);
        firstName = database.items[index].firstName;
        lastName = database.items[index].lastName;
        height = database.items[index].height;
        eyes = database.items[index].eyes;
        hair = database.items[index].hair;

        // Get number for array
        controller = GameObject.Find("CustomerController").GetComponent<CustomerController>();
        custNum = controller.customerNumber;
        Debug.Log(custNum);

        orderMessage = "Hello, I would like to order a cutout of " + firstName + " " + lastName;
    }

    void Update()
    {
        customerButt.onClick.AddListener(CustomerClicked);
    }

    void CustomerClicked()
    {
        Debug.Log("Clicked customer");

        messageText.text = orderMessage;

        PersistenceManager.Instance.customerNumber = custNum;
    }
}
