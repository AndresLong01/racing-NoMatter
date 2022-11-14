using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 250f;
  // try value number 27.5f and steer maybe 325f for higher speeds
  [SerializeField] float moveSpeed = 12.5f;

  void Start()
  {

  }

  void Update()
  {
    float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -steerAmount);
    transform.Translate(0, speedAmount, 0);
  }

  public IEnumerator speedBoost(int boostTimer)
  {
    moveSpeed = 25f;
    yield return new WaitForSeconds(boostTimer);
    moveSpeed = 12.5f;
  }
}