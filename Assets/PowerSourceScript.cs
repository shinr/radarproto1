using UnityEngine;
using System.Collections;




public class PowerSourceScript : MonoBehaviour {

	public GameObject[] connectedpowers;
	public float hp;
	public bool isalive;
	public bool isturnedon;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		alivecheck ();
		if (isalive) {

				}
	
	}

	void alivecheck()
	{
		if (hp <= 0 && isalive)
		{
			isalive = false;
			if (isturnedon)
			{
			for (int i = 1; i < connectedpowers.Length; i++) //ilmoita kaikille kytkimille kun kuolen :(
			{
				Kytkin kytkin = connectedpowers[i].GetComponent<Kytkin>();
				kytkin.setpowers(-1);

			}
			}
		}
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			isturnedon = !isturnedon;
			if (isturnedon) // jos poweri käynnistyy ilmoita kaikille kytkimille
			{
				for (int i = 0; i < connectedpowers.Length; i++)
				{

					Kytkin kytkin = connectedpowers[i].GetComponent<Kytkin>();
					kytkin.setpowers(1);
					
				}

			}
			if (!isturnedon) // jos poweri menee pois päälle ilmoita kaikille kytkimille
			{
				for (int i = 0; i < connectedpowers.Length; i++)
				{
					Kytkin kytkin = connectedpowers[i].GetComponent<Kytkin>();
					kytkin.setpowers(-1);
					
				}
				
			}

		}

	}
}
