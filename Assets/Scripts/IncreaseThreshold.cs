using UnityEditor.PackageManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreaseThreshold : MonoBehaviour
{
    public static int thresholdCount;
    public GameObject displayThreshold;
    public int internalCount;
    void Update()
    {
        internalCount = thresholdCount;
        displayThreshold.GetComponent<TMPro.TextMeshProUGUI>().text = "Threshold: " + internalCount;
    }
}
