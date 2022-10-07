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

	public int actual_cant_hits = 0;

    void Start () {
        StartCoroutine("verificar_cada_un_segundo");//verifica algunas cosas cada 1 segundo
    }


	void Update () {
		
		//Update stats
		config.txtInfo.text =
			$"{aliensAlive} aliens alive"
			+ $"\n{hitsPerSecond} cocoons hits p/sec"
			+ $"\n{avgAngle:F2}° average angle"
			;

	}

    /// <summary>Cada un segundo verifico algunas cosas</summary>
    IEnumerator verificar_cada_un_segundo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
			hitsPerSecond = actual_cant_hits;
			actual_cant_hits = 0;
        }
    }
}
