using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
public class InfoPanel : MonoBehaviour
{
    public PlanetScripts _targetPlanet;
    public Transform _iteamPosition;
    private void OnTriggerEnter(Collider other)
    {
        // is there is already a planet attached to realese it and attached new as child
       var _temp = other.GetComponentInParent<PlanetScripts>();
        if(_temp !=null)
        {
            if (_targetPlanet != null && !_targetPlanet.isGrabe && _targetPlanet.isStay)
            {
                // ReleasePlanet(_targetPlanet); // First Relase last planet
                _targetPlanet.MoveToTargetPosition(_targetPlanet.targetObject.transform);
                if (_targetPlanet._title != null) _targetPlanet._title.transform.parent.gameObject.SetActive(true);
            }
             SelectedPlanet(_temp);
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        PlanetScripts temp = other.GetComponentInParent<PlanetScripts>();
        if (temp != null)
        {
            ReleasePlanet(temp);
        }
    }

    // To Dipalay the Planet New Position and Attached it's child component 
    private void SelectedPlanet(PlanetScripts newPlanet)
    {
        if (newPlanet != null)
        {
            Debug.Log("Hand Enter ======= " + _targetPlanet);
            _targetPlanet = newPlanet;
            _targetPlanet._infoPanel = GetComponent<InfoPanel>();
            _targetPlanet.isStay = true;
            if (_targetPlanet._solar == Solar.Sun)
            {
                _iteamPosition.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (_targetPlanet._solar == Solar.Jupiter)
            {
                _iteamPosition.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            }
            else
            if (_targetPlanet._solar == Solar.Pluto || _targetPlanet._solar == Solar.Mercury)
            {
                _iteamPosition.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else
            {
                _iteamPosition.localScale = Vector3.one;
            }
        }
    }
    // Ungroup and  send the planet to it's start orbit position
    private void ReleasePlanet(PlanetScripts lastPlanet)
    {
        if (lastPlanet == null) return;
        Solar _solar = Solar.None;
        SolarController.instance.OnEventCall(_solar);
        lastPlanet.isStay = false;
        lastPlanet._infoPanel = null;
        lastPlanet = null;
    }
}
