using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float turnSpeed = 0.1f;

    void FixedUpdate()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    [SerializeField] Transform target;

    void MoveThePlayer()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y = 0;
        Vector3 movement = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
        transform.position = movement;
    }

    void TurnThePlayer()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
    }

}
