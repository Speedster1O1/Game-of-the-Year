using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryManager : MonoBehaviour
{
    public static int numOfSticks = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfSticks == 3)
        {
            SceneManager.LoadScene("endscene", LoadSceneMode.Single); 
        }
    }

    
}
