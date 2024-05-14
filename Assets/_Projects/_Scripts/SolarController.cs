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
        if(instance == null )
            instance = this;
    }

    public void OnEventCall(Solar _Solor)
    {
        OnSolarEventTriggered?.Invoke( _Solor );
    }
}
public enum Solar
{
    Mercury,
    Vnus,
    Earth,
    Mars,
    Jumpiter,
    Saturn,
    Urenus,
    Neptune,
    Pluto,
    None
}

