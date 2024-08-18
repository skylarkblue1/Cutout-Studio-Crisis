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

    public CelebDatabase database;

    public Button customerButt;

    public string orderMessage;

    public CustomerController controller;

    public OrderMessageController messageController;

    public SpriteManager spriteManager;

    public int custNum;

    public Sprite currentSprite;

    void Awake()
    {
        // Grab database
        database = GameObject.Find("CelebDatabase").GetComponent<CelebDatabase>();

        // Get it's own button
        customerButt = GetComponentInParent<Button>();

        // Get order data
        int index = Random.Range(0, 4);
        firstName = database.items[index].firstName;
        lastName = database.items[index].lastName;
        height = database.items[index].height;
        eyes = database.items[index].eyes;
        hair = database.items[index].hair;

        // Get number for array
        controller = GameObject.Find("CustomerController").GetComponent<CustomerController>();
        custNum = controller.customerNumber;
        Debug.Log(custNum);

        // Get OrderMessageController to display the correct order messages properly
        messageController = GameObject.Find("MessageController").GetComponent<OrderMessageController>();

        // Grab sprite array from SpriteManager and pull a random sprite and set it as this object's current sprite
        // make default sprite blank so there's no flashing
        spriteManager = GameObject.Find("SpriteManager").GetComponent<SpriteManager>();

        int spriteNum = Random.Range(0, 4);
        currentSprite = spriteManager.customerSprites[spriteNum];
        GetComponent<Image>().sprite = currentSprite;

       // Construct the order message that'll be shown
        orderMessage = "Hello, I would like to order a cutout of " + firstName + " " + lastName;
    }

    void FixedUpdate()
    {
        customerButt.onClick.AddListener(CustomerClicked);
    }

    void CustomerClicked()
    {
        Debug.Log("Clicked customer");

        messageController.UpdateOrderMessage(orderMessage);

        PersistenceManager.Instance.customerNumber = custNum;
    }
}
