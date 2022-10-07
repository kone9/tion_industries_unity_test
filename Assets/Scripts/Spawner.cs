using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Spawner : MonoBehaviour {
	public Transform start;
	public Transform finish;
	public Alien prefabAlien;
	public Canvas prefabAlienUI;
	public ConfigPanel config;
	public Director director;

	void ResetAlien(Alien alien)
	{
		alien.speed = config.speed;
		alien.ui.transform.position = alien.transform.position = start.transform.position;
		alien.transform.rotation = start.transform.rotation;

		alien.Reset();
	}

	Alien CreateAlien()
	{
		var alien = Instantiate(prefabAlien, this.transform);
		alien.ui = Instantiate(prefabAlienUI, this.transform);
		ResetAlien(alien);

		return alien;
	}

	void Start () {
		//Demo
		var alien = CreateAlien();
		alien.target = finish.transform;
		alien.speed = config.speed;

	}


}
