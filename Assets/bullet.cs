using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerBehaviour>() == null && collision.gameObject.GetComponent<bullet>() == null && collision.gameObject.GetComponent<BulletBehaviour>() == null) Destroy(gameObject);

        if (collision.gameObject.GetComponent<DonutBehaviour>() != null)
        {
            DonutBehaviour donutBehaviour = collision.GetComponent<DonutBehaviour>();
            donutBehaviour.changeHealth(-1);
        }

		if ( collision.gameObject.GetComponent<PorkNeckBehaviour>() != null )
		{
			PorkNeckBehaviour donutBehaviour = collision.GetComponent<PorkNeckBehaviour>();
			donutBehaviour.changeHealth(-1);
		}

		if ( collision.gameObject.GetComponent<ChickenController>() != null )
		{
			ChickenController donutBehaviour = collision.GetComponent<ChickenController>();
			donutBehaviour.changeHealth(-1);
		}
	}
}
