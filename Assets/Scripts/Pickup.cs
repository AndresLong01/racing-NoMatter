using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
  //Car state variables
  [SerializeField] string item;
  [SerializeField] bool canTakeItem = true;

  //settings related to item usage timers
  [SerializeField] int boostTimer = 2;

  //imported Component for changing the Car's speed
  Driver importedCarSettings;

  private void Start()
  {
    importedCarSettings = GetComponent<Driver>();
  }

  private void Update()
  {
    if (Input.GetKeyDown("space") && !canTakeItem)
    {
      //TODO: add Oil spill functionality
      if (item == "Broccoli")
      {
        StartCoroutine(importedCarSettings.speedBoost(boostTimer));
        item = "";
        canTakeItem = true;
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Parcel")
    {
      float randomItemId = Random.Range(0, 2);

      //TODO: currently softlocked due to Oil not being fully implemented
      if (randomItemId == 0 && canTakeItem)
      {
        item = "Broccoli";
      }
      else if (canTakeItem)
      {
        item = "Oil";
      }

      canTakeItem = false;
      StartCoroutine(RespawnTimer(other.gameObject));
    }
  }

  IEnumerator RespawnTimer(GameObject itemRandomizer)
  {
    itemRandomizer.SetActive(false);

    yield return new WaitForSeconds(5);
    itemRandomizer.SetActive(true);
  }
}
