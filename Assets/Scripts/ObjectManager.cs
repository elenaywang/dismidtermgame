using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// add this script to the Platformer Player game object

public class ObjectManager : MonoBehaviour
{

    GameObject obj1;
    GameObject obj2;
    GameObject obj3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Obj1") && obj1 == null) {
            obj1 = other.gameObject;
            Debug.Log("you collected obj1!");
            obj1.GetComponent<Object>().doorToUnlock.Unlock();      // open door to section 2
		} else if(other.CompareTag("Obj2") && obj2 == null) {
            obj2 = other.gameObject;
            Debug.Log("you collected obj2!");
            obj2.GetComponent<Object>().doorToUnlock.Unlock();      // open door to section 3
		} else if(other.CompareTag("Obj3") && obj3 == null) {
            obj3 = other.gameObject;
            Debug.Log("you collected obj3!");
            obj3.GetComponent<Object>().doorToUnlock.Unlock();      // open last door
		} else if (other.CompareTag("Trap")) {
            // restart maze section. maybe set player's position to the maze section's start position? also reset the section's object?
            Debug.Log("you fell into a trap :(");
        }
	}
}