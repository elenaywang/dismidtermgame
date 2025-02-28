using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


// add this script to the Platformer Player game object

public class ObjectManager : MonoBehaviour
{

    GameObject obj1;
    GameObject obj2;
    GameObject obj3;

    public GameObject thresholdDisplay;


	void OnTriggerEnter2D(Collider2D other) {
	    if(other.CompareTag("Obj1") && obj1 == null) {
	        obj1 = other.gameObject;
	        Debug.Log("you collected obj1!");
	        obj1.GetComponent<Object>().doorToUnlock.Unlock();                          // open door to section 2
	        GetComponent<PlayerPlatformerController>().section = 2;
	        thresholdDisplay.GetComponent<IncreaseThreshold>().switchToClicker();       // switch to clicker game
	    } 
            else if(other.CompareTag("Obj2") && obj2 == null) {
                obj2 = other.gameObject;
                Debug.Log("you collected obj2!");
                obj2.GetComponent<Object>().doorToUnlock.Unlock();                          // open door to section 3
                GetComponent<PlayerPlatformerController>().section = 3;
                thresholdDisplay.GetComponent<IncreaseThreshold>().switchToClicker();       // switch to clicker game
	    } 
            else if(other.CompareTag("Obj3") && obj3 == null) {
                 obj3 = other.gameObject;
                 Debug.Log("you collected obj3!");
                 obj3.GetComponent<Object>().doorToUnlock.Unlock();                          // open last door
                 GetComponent<PlayerPlatformerController>().section = 4;
                 thresholdDisplay.GetComponent<IncreaseThreshold>().switchToClicker();       // switch to clicker game
	    } 
            else if (other.CompareTag("Trap")) {
                 GetComponent<PlayerPlatformerController>().hp -= 5;                         // decrement health points
                 Debug.Log(String.Format("you fell into a trap :( \t hp = {0}", GetComponent<PlayerPlatformerController>().hp));
            }
	}
}
