using UnityEngine;
using System.Collections;

public class Torcia : MonoBehaviour {

	public float maxIntensity = 100.0f; // Intensità della luce
	public float batteryLife = 100; // Valore di carica della batteria
	public float step = 2.0f; // intervallo di tempo tra un add o remove di batteryLife 
	public float time = 0.0f; 
	private bool onCharge = false;
	private bool status = true; // true per on, false per off
	private float i;


	Light lt;
	public Color cl = Color.red; // Per settare colore diverso per personaggio

	// Metodo Start
	void Start () {
		lt = GetComponent<Light>();
	}
	
	// Metodo Update chiamato per ogni frame
	void Update () {
		BatteryFlow();
		if(Input.GetKeyDown("space")){
			Toggle();
		}

		if(Input.GetKeyDown("b")){
			onCharge = !onCharge;
		}
	}

	// Il flusso della batteria
	void BatteryFlow(){
		
		if(onCharge){
			i = 2.5f;
		}else if(status == false){
			return;
		}else{
			i = -2.5f;
		}

		time += Time.deltaTime;
		
		if(time >= step){
			batteryLife += i;
			if(batteryLife > 100.0f){
				batteryLife = 100.0f;
			}

			time = 0.0f;
		}

		ChangeIntensity();
	}

	// Toggle: se viene premuto un pulsante cambia lo stato e in base a questo si chiama changeIntensity: con parametro true si spegne
	void Toggle(){
			status = !status;

			if (status){
				ChangeIntensity();
			}else{
				ChangeIntensity(true);
			}
	}

	// Serve per cambiare intensità: automatico in base la carica della batteria oppure a 0 se viene spenta.
	void ChangeIntensity(bool toZero = false){
		if(!toZero){
			lt.intensity = (batteryLife / 100) * 8.0f;
		}else{
			lt.intensity = 0.0f;
		}
	}
}