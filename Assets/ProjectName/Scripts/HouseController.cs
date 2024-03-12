using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public Renderer roofRenderer;

    public void DisableRoof()
    {
        roofRenderer.enabled = false;
    }

    public void EnableRoof()
    {
        roofRenderer.enabled = true;
    }

    public void SwitchRoofState(){
        if(roofRenderer.enabled == true){
            DisableRoof();
        } else {
            EnableRoof();
        }
    }
}
