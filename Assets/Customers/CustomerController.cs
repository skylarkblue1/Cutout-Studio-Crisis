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

    public List<GameObject> allTheCustomers = new List<GameObject>();

    public AudioSource customerSpawnSound;

    // Start is called before the first frame update
    void Start()
    {
        if (PersistenceManager.Instance.customerList != null) {
            foreach (var customer in PersistenceManager.Instance.customerList) {
                customer.transform.SetParent(canvasOverall.transform);
                allTheCustomers.Add(customer.gameObject);
            }
        }
        StartSpawningCustomers();
    }

    void StartSpawningCustomers()
    {
        StartCoroutine(waiter());
    }

    void SpawnCustomer()
    {
        customerSpawnSound.Play(0);

        if (customerNumber == 0)
        {
            var vektor = new Vector2(271, -213);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
            
            allTheCustomers.Add(newCustomer);
        }
        if (customerNumber == 1)
        {
            var vektor = new Vector2(102, -172);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;

            allTheCustomers.Add(newCustomer);
        }
        if (customerNumber == 2)
        {
            var vektor = new Vector2(-67, -228);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;
            
            allTheCustomers.Add(newCustomer);
        }
        if (customerNumber == 3)
        {
            var vektor = new Vector2(-235, -187);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;

            allTheCustomers.Add(newCustomer);
        }
        if (customerNumber == 4)
        {
            var vektor = new Vector2(-372, -337);

            var newCustomer = Instantiate(custPrefab, vektor, Quaternion.identity);
            newCustomer.transform.SetParent(canvasOverall.transform);
            newCustomer.transform.localPosition = vektor;

            allTheCustomers.Add(newCustomer);
        }

        PersistenceManager.Instance.customerList = allTheCustomers;
        // likely can cut this down heavily by storing the co-ords in an array/list/etc and using the customer number to grab the right pair from the list? since the 3 lines to spawn and set the prefab are the exact same for each.

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
 * customer spawns in /
 * Multiple customers can spawn in at once - max of 5 /
 * grab a random celeb from the celeb list /
 * 
 * Can click on any customer in the queue / 
 * 
 * when a customer leaves, push the ones after that one ahead by 1, and put the one just removed on the end of the queue
 * 
 */
