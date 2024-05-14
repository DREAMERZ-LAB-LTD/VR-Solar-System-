using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private RotateAround _OrbitRoted;
    [SerializeField] private PlanetScripts _planet;

    private void Awake()
    {
        _OrbitRoted = GetComponent<RotateAround>();
        _planet = transform.GetChild(0).GetComponent<PlanetScripts>();
    }
}
