using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponentInParent<EnnemiesBehaviour>().cursed = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
