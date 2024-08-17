using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public Mesh cutoutMesh;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
