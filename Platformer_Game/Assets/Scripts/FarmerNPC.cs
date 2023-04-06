using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerNPC : MonoBehaviour
{
    public GameObject Canvas;
    void Start()
    {
        Canvas.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Canvas.SetActive(true);
        }
    }
}
