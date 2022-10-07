using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_cant_alien : MonoBehaviour
{
    public Director director;
   

    void Start()
    {
        director = GameObject.Find("Director").GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (director == null) return;
        director.actual_cant_hits += 1;

    }
}
