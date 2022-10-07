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
	public ConfigPanel configPanel;

	public float time_a_spawnar = 1.0f;//cada cuanto tiempo instancio


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

	void Start ()
	{

		spawn_rate_aliens(configPanel.rate);
        
		StartCoroutine("spawnear_cada_cierto_tiempo");//spawneo cada cierto tiempo
	}


    /// <summary>Spawnea el alien </summary>
    void spawn_alien()
	{
        var alien = CreateAlien();
        alien.target = finish.transform;
        alien.speed = config.speed;
    }

    /// <summary>Spawnea una cierta cantidad de aliens</summary>
	/// /// <param>@ref int cantidad de aliens </param>
    void spawn_rate_aliens(int cant_aliens)
	{
        for (int i = 0; i < cant_aliens; i++)//dependiendo cantidad en rate UI es la cantidad que isntancio por segundo
        {
            spawn_alien();
			director.aliensAlive += 1;
        }
    }


    /// <summary>Cada cierto tiempo spawneo cierta cantidad de aliens</summary>
    IEnumerator spawnear_cada_cierto_tiempo()
	{
        while (true)
        {
			yield return new WaitForSeconds(time_a_spawnar);
			spawn_rate_aliens(configPanel.rate);

        }
    }





}
