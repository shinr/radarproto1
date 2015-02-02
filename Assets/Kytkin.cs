using UnityEngine;
using System.Collections;

public class Kytkin : MonoBehaviour {

	public bool isalive;
	public int sources;
	public float hp;
	public bool isturnedon;

	public GameObject[] connectedobjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		turnedoncheck ();
		if (sources == 0) {   //testailua siitä onko sähköt päällä
						gameObject.renderer.material.color = Color.red;
				} else if (sources == 1) {
						gameObject.renderer.material.color = Color.green;
				} else {
			gameObject.renderer.material.color = Color.yellow;
				}
	
	}

	public void setpowers(int i) //asettaa powereita
	{

		sources = sources + i;
	}

	public void alivecheck()
	{

	}

	public void turnedoncheck()
	{
		if ((isturnedon && sources < 1) || (!isturnedon && sources > 0))
		    {
			isturnedon = !isturnedon;
			if (isturnedon) //meni päälle
			{
				for (int i = 0; i < connectedobjects.Length; i++)
				{
					connectedobjects[i].SendMessage("setpowers", 1); //lähetä viesti lisäämään powereja
					
				}
			}
			else
			{
				for (int i = 0; i < connectedobjects.Length; i++)
				{
					connectedobjects[i].SendMessage("setpowers", -1); //lähetä viesti vähentää powereja
					
				}
			}


		}
	}




}
