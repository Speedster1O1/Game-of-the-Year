using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    
    public void Revive()
    {
        SceneManager.LoadScene("Testing Scene", LoadSceneMode.Single); 

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
