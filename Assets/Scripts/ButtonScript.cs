using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject textBox;

    public void clickTheButton(){
        IncreaseThreshold.thresholdCount += 1;
    }
}
