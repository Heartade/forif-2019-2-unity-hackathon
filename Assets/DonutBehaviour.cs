using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonutBehaviour : MonoBehaviour
{
	float patternInvokeTimeStamp = 0;
	float currentTime = 0;
	public GameObject bulletObject;
	private float Init_health = 100;
	public float Current_Health;
	public string nextScene;

	public GameObject boss_HealthBar;
	GameObject boss_Mass;

	// Start is called before the first frame update
	void Start()
    {
		boss_Mass = gameObject;
		Current_Health = Init_health;

		Vector3 DonutMass = boss_Mass.transform.localScale;
		DonutMass.x = 0.3f;
		DonutMass.y = 0.3f;
		boss_Mass.transform.localScale = DonutMass;

		Vector3 scale = boss_HealthBar.transform.localScale;
		scale.x = 4.7f;
		boss_HealthBar.transform.localScale = scale;
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
	public void changeHealth(int amount)
	{
		Current_Health = Mathf.Clamp(Current_Health + amount, 0, Current_Health);

		Vector3 scale = boss_HealthBar.transform.localScale;
		scale.x = 4.7f * ( Current_Health / Init_health );
		boss_HealthBar.transform.localScale = scale;

		Vector3 DonutMass = boss_Mass.transform.localScale;

		if ( Current_Health <= 50 )
		{
			DonutMass.x = 0.2f;
			DonutMass.y = 0.2f;
			boss_Mass.transform.localScale = DonutMass;
		}
		if ( Current_Health <= 0 )
		{
			SceneManager.LoadScene(nextScene);
		}
		Debug.Log(Current_Health + "/" + Init_health);

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
			bullet.power = 10;
			bullet.lifespan = 2f;
			bullet.preliminaryMovement = new Vector2(0, 1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();

		if(player!=null)
		{
			player.AddKcal(500);
		}
	}
}
