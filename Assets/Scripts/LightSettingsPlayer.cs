using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume myVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile nightVision;
    [SerializeField] GameObject nightVisisonOverlay;
    [SerializeField] GameObject spotLight;
    [SerializeField] GameObject enemyFlashLight;


    private bool isFlashLightOn=false;
    void Start()
    {
        myVolume.profile = Standard;
        nightVisisonOverlay.SetActive(false);
        spotLight.SetActive(false);
        enemyFlashLight.SetActive(false);
    }

    void Update()
    {
        if(SaveScript.batteryPower>0.0f)
        {
        if(Input.GetKeyDown(KeyCode.N))
        {
            if (myVolume.profile == Standard)
            {
                myVolume.profile = nightVision;
                nightVisisonOverlay.SetActive(true);
                SaveScript.NVOn=true;
            }

            else if(myVolume.profile==nightVision)
            {
                myVolume.profile = Standard;
                nightVisisonOverlay.SetActive(false);
                SaveScript.NVOn=false;
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isFlashLightOn)
            {
                spotLight.SetActive(false);
                enemyFlashLight .SetActive(false);
                isFlashLightOn = false;
                SaveScript.flashLightOn=false;
            }

            else
            {
                spotLight.SetActive(true);
                enemyFlashLight.SetActive(true);
                isFlashLightOn = true;
                SaveScript.flashLightOn=true;
            }
        }
    }
    else
    {
        myVolume.profile = Standard;
        nightVisisonOverlay.SetActive(false);
        SaveScript.NVOn=false;
        

        isFlashLightOn=false;
        spotLight.SetActive(false);
        enemyFlashLight.SetActive(false);
        isFlashLightOn = false;
        SaveScript.flashLightOn=false;

    }
    }
}
