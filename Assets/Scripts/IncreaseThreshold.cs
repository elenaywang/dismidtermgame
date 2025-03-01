//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.U2D.Aseprite;
// using System.Diagnostics;

public class IncreaseThreshold : MonoBehaviour
{
    public static int thresholdCount;
    public GameObject displayThreshold;
    public int internalCount;
    public int section = 0;
    public Canvas clickCanvas;
    public Canvas platform1;
    //public Canvas platform2;
    //public Canvas platform3;
    public int[] maxThreshold;

    
    void Update()
    {
        internalCount = thresholdCount;
        displayThreshold.GetComponent<TMPro.TextMeshProUGUI>().text = "Threshold: " + internalCount;
        switchLayers();
    }

    private void switchLayers(){
        maxThreshold[0] = 20;
        maxThreshold[1] = 40;
        maxThreshold[2]= 60;

        if (internalCount >= maxThreshold[section]) {
            clickCanvas.enabled = false;
            platform1.enabled = true;
            // Debug.Log("step:" + section);
            if (section < 2) {
                section++;
            }
        }
        
    }

    public void switchToClicker() {
        clickCanvas.enabled = true;
        platform1.enabled = false;
    }
    

}
