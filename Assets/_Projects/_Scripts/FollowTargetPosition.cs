using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPosition : MonoBehaviour
{
    [SerializeField] Transform _targetPosition;
    private void Update()
    {
        if (_targetPosition != null)
        { 
            transform.position = _targetPosition.position;
        }
    }
}
