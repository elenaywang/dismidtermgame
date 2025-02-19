using UnityEngine;


// add this script to the door game objects in the platformer

public class Door : MonoBehaviour
{

    bool locked = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void Unlock() {
        locked = false;
        Debug.Log("door is unlocked");
        Destroy(gameObject);
    }
}
