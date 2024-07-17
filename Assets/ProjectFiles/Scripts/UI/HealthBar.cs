using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] Vector3 offset;

    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the screen position of the player
        Vector3 screenPosition = mainCam.WorldToScreenPoint(followTarget.position + offset);

        transform.position = screenPosition;
    }
}
