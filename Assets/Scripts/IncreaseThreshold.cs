using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseThreshold : MonoBehaviour
{
    public static int thresholdCount;
    public GameObject displayThreshold;
    public int internalCount;
    public Canvas clickCanvas;
    public Canvas platformCanvas;
    void Update()
    {
        internalCount = thresholdCount;
        displayThreshold.GetComponent<TMPro.TextMeshProUGUI>().text = "Threshold: " + internalCount;
    }

    private void switchLayers(){
        if (internalCount == 20){
            clickCanvas.enabled = false;
            platformCanvas.enabled = true;
        }
    }
}
