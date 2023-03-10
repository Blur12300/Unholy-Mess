using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public GameObject player;
    public GameObject Empty;
    public GameObject gunParent;
    public GameObject gunPrefab;
    public GameObject pickUpText;

    public Gun gunscript;
    bool isNear = false;

    private void Start()
    {
        gunscript.enabled = false;
    }
    private void Update()
    {
        if (isNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUpText.SetActive(false);
                Instantiate(gunPrefab).transform.SetParent(gunParent.transform, false);
                gunscript.enabled = true;
                Destroy(Empty);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            pickUpText.SetActive(true);
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            pickUpText.SetActive(false);
            isNear = false;
        }
    }
}
