using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        if (PersistenceManager.Instance.timer == 0 & PersistenceManager.Instance.ordersComplete == 0)
        {
            PersistenceManager.Instance.timer = startTime;
            Debug.Log("Timer set to start time");
        }
    }

    private void Update()
    {
        Debug.Log("Checking if timer is 0");
        if (PersistenceManager.Instance.timer > 0)
        {
            PersistenceManager.Instance.timer -= Time.deltaTime;
        }
    }
}
