using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcular_angulo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(gameObject.transform.rotation.eulerAngles.y);
    }
}
