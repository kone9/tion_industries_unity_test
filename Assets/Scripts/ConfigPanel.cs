using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConfigPanel : MonoBehaviour {

	public Slider sliderRate;
	public Slider sliderSpeed;
	public Text txtRate;
	public Text txtSpeed;
	public Text txtInfo;

	public int rate { get; private set; }
	public float speed { get; private set; }

	void Awake () {
		rate = Mathf.RoundToInt(sliderRate.value);
		txtRate.text = rate.ToString("0.");
		speed = sliderSpeed.value;
		txtSpeed.text = speed.ToString("0.");
	}
	
	void Update () {
       
    }

    /// <summary> Evento relacionado a cuando cambio el valor del slider</summary>
    public void on_change_sliderSpeed()
	{
        speed = sliderSpeed.value;
        txtSpeed.text = speed.ToString("0.");
    }

    /// <summary> Evento relacionado a cuando cambio el valor del slider</summary>
    public void on_change_sliderRate()
    {
        rate = Mathf.RoundToInt(sliderRate.value);
        txtRate.text = rate.ToString("0.");
    }

}
