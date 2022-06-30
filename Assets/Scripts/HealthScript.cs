using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;
    [SerializeField] GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
        HealthText.text=SaveScript.playerHealth + "%";  
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.healthChanged)
        {
            SaveScript.healthChanged=false;
            HealthText.text=SaveScript.playerHealth + "%";
        }

        if(SaveScript.playerHealth <= 0)
        {
            SaveScript.playerHealth = 0;
            deathPanel.SetActive(true);
        }
    }
}
