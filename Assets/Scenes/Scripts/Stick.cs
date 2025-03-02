using Unity.VisualScripting;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public static bool stickCollected = false;
    public Transform stick;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0);
    } 

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Debug.Log("Collision Occurs");
           CheckStickCollected();
           //stickCollected = false;
           StickRemoved();
           InventoryManager.numOfSticks++;
           Debug.Log("you have" + InventoryManager.numOfSticks);
           

        }
    }

    public static bool CheckStickCollected()
    {
        stickCollected = true;
         Debug.Log("Stick Was Collected");
        return stickCollected;
       
        
    }

     void StickRemoved()
    {
        if (CheckStickCollected() == true)
        {
            Destroy(gameObject);
        }
    }
}