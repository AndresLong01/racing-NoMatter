using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
  //Car state variables
  [SerializeField] public string item;
  [SerializeField] bool canTakeItem = true;

  //settings related to item usage timers
  [SerializeField] int boostTimer = 2;

  //UI related information
  [SerializeField] Sprite emptyImage;
  [SerializeField] Sprite broccoliImage;
  [SerializeField] Sprite oilImage;

  //imported Components
  Driver importedCarSettings;
  GameObject importedUI;
  Image imageContainer;

  private void Start()
  {
    importedUI = GameObject.FindGameObjectWithTag("Image");
    importedCarSettings = GetComponent<Driver>();
    imageContainer = importedUI.GetComponent<Image>();
  }

  private void Update()
  {
    if (Input.GetKeyDown("space") && !canTakeItem)
    {
      //TODO: add Oil spill functionality
      if (item == "Broccoli")
      {
        StartCoroutine(importedCarSettings.speedBoost(boostTimer));
      }

      item = "";
      canTakeItem = true;
      imageContainer.sprite = emptyImage;
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
        imageContainer.sprite = broccoliImage;
      }
      else if (canTakeItem)
      {
        item = "Oil";
        imageContainer.sprite = oilImage;
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
