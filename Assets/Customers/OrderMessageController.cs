using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderMessageController : MonoBehaviour
{
    public GameObject messageObj;
    public TMP_Text messageText;

    public string orderMessage;

    public void UpdateOrderMessage(string orderMessage)
    {
        messageText.text = orderMessage;
        messageObj.SetActive(true);
    }
}
