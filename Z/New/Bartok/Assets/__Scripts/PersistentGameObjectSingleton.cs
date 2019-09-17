
using UnityEngine;

public class PersistentGameObjectSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private readonly object instanceLock = new object();
    public static T Instance { get; private set; }

    void Awake()
    {
        lock (instanceLock)
        {
            // If no Instance yet exists, assign and preserve across scenes.
            if (!Instance)
            {
                Instance = (T)(object)this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("created singleton instance of type " + name);
            }
            // Otherwise, if an Instance already exists, destroy the new instance.
            else if (Instance != this)
            {
                Debug.Log("destroying new instance of " + name + " singleton");
                DestroyImmediate(gameObject);
            }
        }
    }
}
