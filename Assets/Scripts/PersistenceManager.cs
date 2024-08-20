using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public Mesh cutoutMesh;
    public Vector2[] polygonPoints;

    public List<GameObject> customerList;

    public int customerNumber;
    public int score;
    public int ordersComplete;
    public float timer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Time.timeScale = 1;

        Debug.Log("Persistance Manager Awake");
    }
}
