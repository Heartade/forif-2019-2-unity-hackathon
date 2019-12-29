using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutBehaviour : MonoBehaviour
{
	float patternInvokeTimeStamp = 0;
	float currentTime = 0;
	public GameObject bulletObject;
	public float health;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
		if(currentTime >= patternInvokeTimeStamp)
		{
			patternInvokeTimeStamp += 0.4f;
			PatternRadialBurst(12, (currentTime % 360) * 45);
		}
    }

	void PatternRadialBurst(int num, float angleAdjustment)
	{
		for(int i = 0; i < num; ++i)
		{
			GameObject tempbullet = (GameObject) Instantiate(bulletObject);
			tempbullet.transform.position = transform.position + Vector3.forward*0.1f;
			BulletBehaviour bullet = tempbullet.GetComponent<BulletBehaviour>();
			bullet.speed = 0.08f;
			bullet.angle = (360f / num) * i + angleAdjustment;
			bullet.angleCompensation = 90;
			bullet.power = 25;
			bullet.lifespan = 2f;
			bullet.preliminaryMovement = new Vector2(0, 1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();

		if(player!=null)
		{
			player.AddKcal(1000);
		}
	}
}
