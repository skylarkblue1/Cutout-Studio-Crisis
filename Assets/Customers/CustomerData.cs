using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerData : MonoBehaviour
{
    private string firstName;
    private string lastName;
    private string height;
    private string eyes;
    private string hair;

    public GameObject celebDatabaseObj;
    public CelebDatabase database;

    public Button customerButt;

    public TMP_Text messageText;
    private string orderMessage; 

    public bool clickedOnCustomer;

    void Awake()
    {
        // grab a random celeb from CelebReader database
        // Copy it's data to this prefab
        database = GameObject.Find("CelebDatabase").GetComponent<CelebDatabase>();
        messageText = GameObject.Find("OrderMessage").GetComponent<TMP_Text>();

        customerButt = GetComponentInParent<Button>();

        int index = Random.Range(0, 2);
        firstName = database.items[index].firstName;
        lastName = database.items[index].lastName;
        height = database.items[index].height;
        eyes = database.items[index].eyes;
        hair = database.items[index].hair;

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
    }
}
