﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  //Colliding with objects
  [SerializeField] float slowDownTimer = 1.5f;

  //Lap Logic
  [SerializeField] int gateCount = 0;
  [SerializeField] int lapCount = 1;
  GameObject[] gates;

  Driver importedCar;

  void Start()
  {
    importedCar = GetComponent<Driver>();
    gates = GameObject.FindGameObjectsWithTag("Gate");
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    importedCar.slowDown();
  }

  void OnCollisionExit2D(Collision2D other) {
    StartCoroutine(importedCar.collisionRecovery(slowDownTimer));
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Finish")
    {
      if (gateCount >= 17)
      {
        gateCount = 0;
        lapCount++;
        foreach (GameObject gate in gates)
        {
          gate.SetActive(true);
        }
      }
    }

    if (other.tag == "Gate")
    {
      other.gameObject.SetActive(false);
      gateCount++;
    }
  }
}
