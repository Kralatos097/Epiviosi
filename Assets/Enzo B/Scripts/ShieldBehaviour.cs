using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponentInParent<PlayerScript>().ShieldActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        transform.GetComponentInParent<PlayerScript>().ShieldActive = false;
    }
}
