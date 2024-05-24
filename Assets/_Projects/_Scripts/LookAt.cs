using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    [SerializeField] private Transform _lookPose;
    [SerializeField] private float distance  = 2.0f;
    [SerializeField] private float smoothTime;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        _lookPose = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var lookAtPos = new Vector3(_lookPose.transform.position.x, transform.position.y, _lookPose.transform.position.z);
        transform.LookAt(lookAtPos);
    }
}
