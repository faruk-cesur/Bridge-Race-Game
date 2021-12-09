using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StairClimb : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private GameObject _raycastDown;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        StepClimb();
    }

    private void StepClimb()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(_raycastDown.transform.position, transform.TransformDirection(Vector3.down), out raycastHit, 1f))
        {
            var position = _rigidBody.position;
            position = new Vector3(position.x, raycastHit.point.y, position.z);
            _rigidBody.position = position;
        }
    }
}