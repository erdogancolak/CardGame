using UnityEngine;

public class TimeTest : MonoBehaviour
{
    [Range(0f,1f)] public float timeFloat;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeFloat;  
    }
}
