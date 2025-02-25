using UnityEngine;

public class IncreaseThreshold : MonoBehaviour
{
    public static int thresholdCount;
    public GameObject displayThreshold;
    public int internalCount;
    public Canvas clickCanvas;
    public Canvas platform1;
    public Canvas platform2;
    public Canvas platform3;
    public int[] maxThreshold;

    void Update()
    {
        internalCount = thresholdCount;
        displayThreshold.GetComponent<TMPro.TextMeshProUGUI>().text = "Threshold: " + internalCount;
        switchLayers();
    }

    private void switchLayers()
    {
        maxThreshold[0] = 20;
        maxThreshold[1] = 40;
        maxThreshold[2] = 60;



        for (int i = 0; i < 3; i++)
        {
            if (internalCount >= maxThreshold[i])
            {
                clickCanvas.enabled = false;
                platform1.enabled = true;
                thresholdCount = maxThreshold[i];
            }

            /* }
             else if (internalCount == maxThreshold[1]){
                 clickCanvas.enabled = false;
                 platform2.enabled = true;
             }
             else if (internalCount == maxThreshold[2]){
                 clickCanvas.enabled = false;
                 platform3.enabled = true; */
        }
    }

}
