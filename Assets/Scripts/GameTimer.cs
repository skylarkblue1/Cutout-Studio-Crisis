using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    public float startTime = 300;

    // Start is called before the first frame update
    void Start()
    {
        PersistenceManager.Instance.timer = startTime;
    }

    private void Update()
    {
        if (PersistenceManager.Instance.timer > 0)
        {
            PersistenceManager.Instance.timer -= Time.deltaTime;
        }
    }
}
