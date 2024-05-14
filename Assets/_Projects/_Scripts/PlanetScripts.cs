using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlanetScripts : MonoBehaviour
{
    [SerializeField] private Solar _solar;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private Transform targetObject;

    private void Awake()
    {
        targetObject = transform.parent;
        transform.parent.gameObject.name = this._solar.ToString();
        if (_title != null) _title.text = this._solar.ToString();
    }


}
