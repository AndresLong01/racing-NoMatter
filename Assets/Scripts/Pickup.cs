using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
  //Car state variables
  [SerializeField] string item;
  [SerializeField] bool canTakeItem = true;
  [SerializeField] int gateCount = 0;

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
    if (Input.GetKeyDown("space"))
    {
      //&& car canHasItem;
      if (item == "Brocolli")
      {
        StartCoroutine(importedCarSettings.speedBoost(boostTimer));
        item = "";
        canTakeItem = true;
      }
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("Dang");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Parcel")
    {
      float randomItemId = Random.Range(0, 2);
      Debug.Log(randomItemId);

      if (randomItemId == 0 && canTakeItem)
      {
        item = "Brocolli";
      }
      else if (canTakeItem)
      {
        item = "Oil";
      }

      canTakeItem = false;
      StartCoroutine(RespawnTimer(other.gameObject));

    }
    else if (other.tag == "Finish")
    {
      if (gateCount >= 10)
      {
        gateCount = 0;
        Debug.Log("This is the finish line");
      }
      else
      {
        Debug.Log("You are not prepared");
      }
    }
  }

  IEnumerator RespawnTimer(GameObject itemRandomizer)
  {
    itemRandomizer.SetActive(false);

    yield return new WaitForSeconds(5);
    itemRandomizer.SetActive(true);
  }
}
