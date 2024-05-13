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
        //Vector3 targetPosition = _lookPose.transform.TransformPoint(new Vector3(0, distance, 0));

       // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        var lookAtPos = new Vector3(_lookPose.transform.position.x, transform.position.y, _lookPose.transform.position.z);
        transform.LookAt(lookAtPos);
    }
}
