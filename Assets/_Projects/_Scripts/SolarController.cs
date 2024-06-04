using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarController : MonoBehaviour
{

    public event Action<Solar> OnSolarEventTriggered;
    public static SolarController instance;
    public SolarSystemData solarData;
    public Orbit[] orbits;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OnEventCall(Solar _Solor)
    {
        OnSolarEventTriggered?.Invoke(_Solor);
    }
    public float SetOrbitalSpeed(Solar body)
    {
        float speed = 0;
        switch (body)
        {
            case Solar.Mercury:
                speed = 47.4f;
                break;
            case Solar.Venus:
                speed = 35.0f;
                break;
            case Solar.Earth:
                speed = 29.8f;
                break;
            case Solar.Moon:
                speed = 1.0f;  // This speed can be adjusted if it's not representative of a typical value
                break;
            case Solar.Mars:
                speed = 24.1f;
                break;
            case Solar.Jupiter:
                speed = 13.1f;
                break;
            case Solar.Saturn:
                speed = 9.7f;
                break;
            case Solar.Uranus:
                speed = 6.8f;
                break;
            case Solar.Neptune:
                speed = 5.4f;
                break;
            case Solar.Pluto:
                speed = 4.7f;
                break;
            default:
                speed = 10.0f; // Default speed if none specified
                break;
        }
        Debug.Log("Retun Speed " + speed);
        return speed;
    }

}
public enum Solar
{
    Mercury,
    Venus,
    Earth,
    Moon,
    Mars,
    Jupiter,
    Saturn,
    Uranus,
    Neptune,
    Pluto,
    Sun,
    None
}



