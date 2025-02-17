using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseThreshold : MonoBehaviour
{
    public static int thresholdCount;
    public GameObject displayThreshold;
    public int internalCount;
    void Update()
    {
        internalCount = thresholdCount;
        displayThreshold.GetComponent<Text>().text = "Threshold: " + internalCount;
    }
}
