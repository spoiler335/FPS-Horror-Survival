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

    private bool isFlashLightOn=false;
    void Start()
    {
        myVolume.profile = Standard;
        nightVisisonOverlay.SetActive(false);
        spotLight.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            if (myVolume.profile == Standard)
            {
                myVolume.profile = nightVision;
                nightVisisonOverlay.SetActive(true);
            }

            else if(myVolume.profile==nightVision)
            {
                myVolume.profile = Standard;
                nightVisisonOverlay.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isFlashLightOn)
            {
                spotLight.SetActive(false);
                isFlashLightOn = false;
            }

            else
            {
                spotLight.SetActive(true);
                isFlashLightOn = true;
            }
        }
    }
}
