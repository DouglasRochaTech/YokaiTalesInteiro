using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeeee : MonoBehaviour
{
    //Por que infernos eu fiz esse script???

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime, Space.Self);
    }
}
