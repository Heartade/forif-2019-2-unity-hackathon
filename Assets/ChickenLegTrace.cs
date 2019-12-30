using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLegTrace : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject par;
	public float timer;
	public float maxTimer = 0.2f;
    void Start()
    {
		transform.position = par.transform.position;
		transform.rotation = par.transform.rotation;
	}

    // Update is called once per frame
    void Update()
    {
		timer -= Time.deltaTime;
		Color col = GetComponent<SpriteRenderer>().color;
		col.a = timer / maxTimer;
		GetComponent<SpriteRenderer>().color = col;
		if ( timer < 0 )
		{
			transform.position = par.transform.position;
			transform.rotation = par.transform.rotation;
			timer = maxTimer;
		}
	}
}
