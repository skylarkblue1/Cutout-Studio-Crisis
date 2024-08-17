using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{
    // Add customer sprites here to enable and disable/play with in the queue
    public List<GameObject> customerSprites = new List<GameObject>();
    public int customerNumber = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCustomers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartSpawningCustomers()
    {
        StartCoroutine(waiter());
    }

    void SpawnCustomer()
    {

    }

    IEnumerator waiter()
    {
        int wait_time = Random.Range(3, 9);
        yield return new WaitForSeconds(wait_time);
        print("I waited for " + wait_time + "sec. Trying to spawn a customer");
        if (customerNumber <= 4)
        {
            customerSprites[customerNumber].SetActive(true);
            customerNumber++;
            StartSpawningCustomers();
            }
        else
        {
            Debug.Log("Max amount of customers spawned, pausing spawning.");
            // pause spawning
        }
    }
}

/*
 * customer spawns in 
 * Multiple customers can spawn in at once - max of 5 /
 * 1 order at a time
 * grab a random celeb from the celeb list
 * Player hands over cutout and triggers evaluation screen
 * 
 * Can click on any customer in the queue
 * 
 * when a customer leaves, push the ones after that one ahead by 1, and put the one just removed on the end of the queue
 */
