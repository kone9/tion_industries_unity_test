using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.AI;

public class Alien : MonoBehaviour {
	public Canvas ui;
	public Text txtAlien;
	public Transform target;// DESDE SPAWNER obtengo el transform
	public float speed;
	private NavMeshAgent agent;

	private void Awake()
	{
        //MOVER AI CON NAVMESH
        agent = GetComponent<NavMeshAgent>();
	}


	void Start()
	{
        txtAlien = ui.GetComponentInChildren<Text>();
		txtAlien.text = "0";
		Reset();
    }


	public void Reset()
	{
		GetComponent<Animator>().Play("Grounded");
		GetComponent<Animator>().SetFloat("Forward", 1f);
	}


	void Update () {
		//No recuerdo si el charactercontroller puede evitar obstaculos, muevo directo con AI y componentes de AI
		//if(target != null)
		//{
		//	var delta = target.position - transform.position;
		//	delta.y = 0f;
		//	var deltaLen = delta.magnitude;
		//	var move = Mathf.Min(speed * Time.deltaTime, deltaLen);
		//	if(deltaLen <= 5f)
		//		target = null;
		//	else
		//	{
		//		var direction = delta / deltaLen;
		//		transform.forward = Vector3.Slerp(transform.forward, direction, 10f * Time.deltaTime);
		//		GetComponent<CharacterController>().Move(move * transform.forward + Vector3.down * 3f);
		//	}
		//}		

        move_ariel_AI(target.position);

        if (ui != null)
		{
			ui.transform.position = transform.position;
		}
	}


	//mueve el personaje com AI hacia un punto
	void move_ariel_AI(Vector3 new_target_position)
	{
        if (target == null) return;//sino es nula
        agent.destination = new_target_position;//muso hacia ese lugar con AI
    }



	private void OnTriggerEnter(Collider other)
	{
        
    }
}
