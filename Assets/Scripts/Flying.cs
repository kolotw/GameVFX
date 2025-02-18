using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public SkinnedMeshRenderer skr;
    float dispear = 0f;

    void Start()
    {
        //this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50f);
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        if (dispear < 1)
        {
            dispear += 0.25f * Time.deltaTime;
            skr.material.SetFloat("_dispear", dispear);
        }
        else
        {
            dispear = 0f;
        }
    }
}