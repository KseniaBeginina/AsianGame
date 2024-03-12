using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public HouseController houseController;


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseController.SwitchRoofState();            
        }
    }

}
