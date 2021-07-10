using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BatterPower : MonoBehaviour
{

    [SerializeField] Image batteryUI;
    [SerializeField] float drainTime=15.0f;

    [SerializeField] float power;
    
    void Update()
    {
        if(SaveScript.flashLightOn || SaveScript.NVOn)
        {
            batteryUI.fillAmount-=1.0f /drainTime *Time.deltaTime;
            power=batteryUI.fillAmount;
            SaveScript.batteryPower=power;
        }
    }
}
