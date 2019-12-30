using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLegBehaviour : MonoBehaviour
{
	public GameObject go;
	public GameObject trace;
    // Start is called before the first frame update
    void Start()
    {
		//transform.LookAt(go.transform);
        for(int i = 0; i < 5; i++)
		{
			ChickenLegTrace clt = Instantiate(trace).GetComponent<ChickenLegTrace>();
			clt.par = gameObject;
			clt.timer = 0.04f * i;
		}
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.up * Time.deltaTime);
    }
}
