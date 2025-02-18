using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class clickEvent : MonoBehaviour
{
    public VisualEffect vfx;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            vfx.SendEvent("OnClick");
            Invoke("stopVFX", 3f);
        }
    }
    void stopVFX()
    {
        vfx.SendEvent("OnStop");
    }
}