using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static SolarSystemData;

public class DialogUI : MonoBehaviour
{
    public TextMeshProUGUI _Title;
    public TextMeshProUGUI _Description;


    private void Start()
    {
        SolarController.instance.OnSolarEventTriggered += DisplayInfo;
    }
    private void OnDisable()
    {
        SolarController.instance.OnSolarEventTriggered -= DisplayInfo;
    }
    private void DisplayInfo(Solar _solar)
    {
        PlanetInfo _planetInfo = null;

        foreach(var info in SolarController.instance.solarData.planets)
        {
            if(info.solar == _solar)
            {
                _planetInfo = info;
               //break;
            }
        }

        if (_planetInfo != null)
        {

            _Title.text = _planetInfo.solar.ToString();
            _Description.text = _planetInfo.description;
            // Do something with _planetInfo
            Debug.Log("Found planet: " + _planetInfo.solar.ToString());
        }
        else
        {
            Debug.Log("Planet not found.");
            _Title.text ="";
            _Description.text = "";
           
        }
    }


}
