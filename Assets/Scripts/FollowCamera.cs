using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject mainCar;
    // Camera position initialization and follow the Car's position
    int cameraDisplacement = -10;

    void Update()
    {
        transform.position = mainCar.transform.position + new Vector3(0,0, cameraDisplacement);
    }
}
