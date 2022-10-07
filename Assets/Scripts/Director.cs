using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Director : MonoBehaviour {
	
	public Spawner spawner;
	public ConfigPanel config;

    public int aliensAlive = 0;
    public int hitsPerSecond = 0;
    public float avgAngle = 0f;

    void Start () {

	}


	void Update () {
		
		//Update stats
		config.txtInfo.text =
			$"{aliensAlive} aliens alive"
			+ $"\n{hitsPerSecond} cocoons hits p/sec"
			+ $"\n{avgAngle:F2}° average angle"
			;

	}
}
