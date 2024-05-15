using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public PlanetScripts _tragetPlanet;
    public Transform _iteamPosition;
    private void OnTriggerEnter(Collider other)
    {
       if(_tragetPlanet !=null) return;
        _tragetPlanet = other.GetComponentInParent<PlanetScripts>();
        if (_tragetPlanet != null)
        {
            Debug.Log("Hand Enter ======= " + _tragetPlanet);
            _tragetPlanet._infoPanel = GetComponent<InfoPanel>();
            _tragetPlanet.isStay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlanetScripts temp = other.GetComponentInParent<PlanetScripts>();
        if (temp != null)
        {
            if (_tragetPlanet == null) return;
            Debug.Log("Hand Exit ======= " + _tragetPlanet);
            Solar _solar = Solar.None;
            SolarController.instance.OnEventCall(_solar);
           
            _tragetPlanet.isStay = false;
            _tragetPlanet._infoPanel = null;
            _tragetPlanet = null;

        }
    }

    private void Update()
    {
       
       
    }
}
