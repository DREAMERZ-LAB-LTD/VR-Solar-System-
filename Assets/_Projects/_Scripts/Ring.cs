using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private void Awake()
    {
        Vector3 currentAng = transform.localEulerAngles;
        float angleY = Random.Range(90, 360.0f);
        currentAng.y = angleY;
        transform.localEulerAngles = currentAng;
    }
}
