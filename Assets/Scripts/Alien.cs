using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Alien : MonoBehaviour {
	public Canvas ui;
	public Text txtAlien;
	public Transform target;// DESDE SPAWNER obtengo el transform
	public float speed;
	private NavMeshAgent agent;
	public float gravity = 9.8f;
	public ConfigPanel config;//ref a objetos de panel
	public Director director;
    private bool puedo_iniciar_nav_mesh = false;

	private void Awake()
	{
		
	}


	void Start()
	{
        txtAlien = ui.GetComponentInChildren<Text>();
		txtAlien.text = "0";
		Reset();
		
		config = GameObject.Find("ConfigPanel").GetComponent<ConfigPanel>();
        director = GameObject.Find("Director").GetComponent<Director>();

        Invoke("fixear_navmesh_init", 0.1f);//fixeado el navmesh agent solo funciona despues de 0.1f segundos, sino hay problemas porque se instancian
    }


	public void Reset()
	{
		GetComponent<Animator>().Play("Grounded");
		GetComponent<Animator>().SetFloat("Forward", 1f);
	}


	void Update () {
		/////////////////////////////////////////////////////////////////////////////////////////////////////
		//El personaje sigue derecho hasta chocar contra la pared, tendria que fixear con raycast, pero prefiero usar navmesh agent
		
		//if (target != null)
		//{
		//	var delta = target.position - transform.position;
		//	delta.y = 0f;
		//	var deltaLen = delta.magnitude;
		//	var move = Mathf.Min(speed * Time.deltaTime, deltaLen);
		//	if (deltaLen <= 5f)
		//		target = null;
		//	else
		//	{
		//		var direction = delta / deltaLen;
		//		transform.forward = Vector3.Slerp(transform.forward, direction, 10f * Time.deltaTime);
		//		GetComponent<CharacterController>().Move(move * transform.forward + Vector3.down * 3f);
		//	}
		//}
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		move_ariel_AI(ref target); //fixeado el navmesh agent solo funciona despues de 0.1f segundos
		
	}



	//FIXEO POSIICON DE UI con RAYCAST AUNQUE LE FALTA BASTANTE TRABAJo
    void FixedUpdate()
    {
        // LAYER 9 TERRENO
        int layerMask = 1 << 9;

        // This would cast rays only against colliders in layer 9.
        // But instead we want to collide against everything except layer 9. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

			//FIXEO CON RAYCAST POSICION DE TEXTO, pero le falta más trabajo
            if (ui != null)
            {
                Vector3 newUiposition = transform.position;
				//aca tendria que fixear posicion de UI
				newUiposition.y = hit.transform.position.y;
                ui.transform.position = newUiposition;

            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            //FIXEO CON RAYCAST POSICION DE TEXTO
            if (ui != null)
            {
                Vector3 newUiposition = transform.position;
				newUiposition.y = newUiposition.y + 1;
                ui.transform.position = newUiposition;

            }
        }
    }



    /// <summary> mueve el personaje con AI hacia un punto, uso referecia para no duplicar tantas la variable en el parametro </summary>
    /// <summary> fixeado el navmesh agent solo funciona despues de 0.1f segundos </summary>
    /// <param>@ref Transform new_target_position </param>
    void move_ariel_AI(ref Transform new_target)
	{
		if (target == null) return;//sino es nula
		if (puedo_iniciar_nav_mesh == false) return;//sino es nula

		Vector3	new_position = new Vector3(new_target.position.x,0, new_target.position.z);
		agent.destination = new_position;//muso hacia ese lugar con AI
		agent.speed = config.speed;//agregado speed desde UI
		agent.acceleration = config.speed;//agregado speed desde UI
    }

    /// <summary>Esperar un un poco antes de iniciar navMesh, sino hay un bug por inicializacíon de objetos </summary>
    void fixear_navmesh_init()
    {
        puedo_iniciar_nav_mesh = true;
        //GET AI CON NAVMESH
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }


    //para determinar cantidad de colisiones con bichos, tengo problemas con los canales de colisiones en Unity, no recuerdo como usarlos y como es un detalle pequeño dejo el comentario aqui
    private void OnTriggerEnter(Collider other)
	{
		if (director == null) return;
		director.actual_cant_hits +=1;
		txtAlien.text = director.actual_cant_hits.ToString();

    }




	/// <summary> agrega gravedad en el eje Y, osea hacia el suelo </summary>
	void add_gravity()
    {
        transform.position = new Vector3(
            this.transform.position.x,
             -gravity * Time.deltaTime,
            this.transform.position.z);
    }

}
