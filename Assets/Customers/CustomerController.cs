using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerController : MonoBehaviour
{
    // Add customer sprites here to enable and disable/play with in the queue
    // public List<GameObject> customerSprites = new List<GameObject>();
    public int customerNumber = 0;

    public GameObject custPrefab;

    public GameObject canvasOverall;

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
        // Spawn positions for customers. Change coords to final when scene is finished
        // Also here would be where to add the sound effect trigger

        if (customerNumber == 0)
        {
            var vektor = new Vector2(-713, 313);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
        }
        if (customerNumber == 1)
        {
            var vektor = new Vector2(-506, 112);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
        }
        if (customerNumber == 2)
        {
            var vektor = new Vector2(-184, 253);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
        }
        if (customerNumber == 3)
        {
            var vektor = new Vector2(155, 171);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
        }
        if (customerNumber == 4)
        {
            var vektor = new Vector2(559, 294);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
        }

        StartSpawningCustomers();
    }

    IEnumerator waiter()
    {
        int wait_time = Random.Range(1, 2);
        yield return new WaitForSeconds(wait_time);
        print("I waited for " + wait_time + "sec. Trying to spawn a customer");
        if (customerNumber <= 4)
        {
            SpawnCustomer();
            customerNumber++;
            //StartSpawningCustomers();
            }
        else
        {
            Debug.Log("Max amount of customers spawned, pausing spawning.");    
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
