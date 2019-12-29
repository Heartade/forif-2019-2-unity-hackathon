using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KcalNumberBehaviour : MonoBehaviour
{
	public Sprite[] sprites = new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetNumber(int num)
	{
		GetComponent<SpriteRenderer>().sprite = sprites[num];
	}
}
