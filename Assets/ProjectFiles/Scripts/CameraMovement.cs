using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform targetCam;

    public void GoMove()
    {
        transform.DOMove(targetCam.position, 1);
        transform.DORotate(targetCam.eulerAngles, 1, RotateMode.Fast);
    }

}
