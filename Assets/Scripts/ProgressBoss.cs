using UnityEngine;
using UnityEngine.UI;

public class ProgressBoss : MonoBehaviour
{
    public Slider slider;
    
    public int progressBossCount;

    public bool callBoss = false;
    void Start()
    {
        slider.maxValue = 5;
        slider.value = 0;
    }

    void Update()
    {
        if(progressBossCount == 5)
        {
            progressBossCount = 0;
            slider.value = 0;
            callBoss = true;
        }
        slider.value = progressBossCount;
    }
}
