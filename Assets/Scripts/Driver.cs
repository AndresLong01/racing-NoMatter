using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 300f;
  // try value number 27.5f and steer maybe 325f for higher speeds
  // initial value is 17.5f tentatitve
  [SerializeField] public float moveSpeed = 17.5f;

  void Update()
  {
    float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -steerAmount);
    transform.Translate(0, speedAmount, 0);
  }

  public void slowDown() {
    moveSpeed = 7.5f;
  }

  public IEnumerator speedBoost(int boostTimer)
  {
    moveSpeed = 25f;
    yield return new WaitForSeconds(boostTimer);
    moveSpeed = 17.5f;
  }

  public IEnumerator collisionRecovery(float slowDownTimer)
  {
    yield return new WaitForSeconds(slowDownTimer);
    moveSpeed = 17.5f;
  }
}