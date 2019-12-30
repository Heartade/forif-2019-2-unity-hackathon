
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenController : MonoBehaviour
{
    public float speed = 2;

    public int direction = 0;
    public float directionChangeTimer = 0;
    public float chickTimer = 0;
    public int check1 = 0;
	float patternInvokeTimeStamp = 0;
	float currentTime = 0;
	public GameObject bulletObject;
	public GameObject player;
	private float Init_health = 150;
	public float Current_Health;
	public string nextScene;

	public GameObject boss_HealthBar;
	GameObject boss_Mass;

	private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
		if ( currentTime >= patternInvokeTimeStamp )
		{
			patternInvokeTimeStamp += 0.3f;
			PatternRadialBurst(10, ( currentTime % 360 ) * 45);
			PatternRadialBurst(10, - ( currentTime % 360 ) * 45);
		}
		directionChangeTimer -= Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            directionChangeTimer = Random.Range(0.5f, 1.0f);
            direction = Random.Range(0, 2);
        }

        Vector2 position = rigidbody2d.position;

        chickTimer += Time.deltaTime;
       
        if (rigidbody2d.position.x < -2.2)
        {
            position.x += Time.deltaTime * speed;
        }
        else if (rigidbody2d.position.x > 2.3)
            position.x -= Time.deltaTime * speed * 2;

        switch (direction)
        {
            case 0:
                position.x += Time.deltaTime * speed;
                break;
            case 1:
                position.x -= Time.deltaTime * speed;
                break;
        }
        if ((chickTimer > 10)&&(check1==0))
        {
            position.y = 7.5f;
            check1 = 1;
        }
        if ((chickTimer > 13)&& (check1==1) )
        {
            position.x = 0;
            position.y = 1;
            check1 = 2;
        }

        if ((chickTimer > 20) && (check1 == 2))
        {
            position.y = 7.5f;
            check1 = 3;
        }
        if ((chickTimer > 23) && (check1 == 3))
        {
            position.x = -1;
            position.y = -2;
            check1 = 4;
        }

        if ((chickTimer > 30) && (check1 == 4))
        {
            position.y = 7.5f;
            check1 = 5;
        }
        if ((chickTimer > 33) && (check1 == 5)){
            position.x = 2;

            position.y = 2;
            check1 = 6;
        }

        if ((chickTimer > 50) && (check1 == 6))
        {
            position.y = 7.5f;
            check1 = 7;
        }
        if ((chickTimer > 53) && (check1 == 7))
        {
            position.x = 0;
            position.y = 0;
            check1 = 8;
        }

        if ((chickTimer > 70) && (check1 == 8))
        {
            position.y = 7.5f;
            check1 = 9;
        }
        if ((chickTimer > 73) && (check1 == 9))
        {
            position.x = -1;
            position.y = -3;
            check1 = 10;
        }

        rigidbody2d.MovePosition(position);
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
		for ( int i = 0; i < num; ++i )
		{
			GameObject tempbullet = (GameObject)Instantiate(bulletObject);
			tempbullet.transform.position = transform.position + Vector3.forward * 0.1f;
			BulletBehaviour bullet = tempbullet.GetComponent<BulletBehaviour>();
			bullet.speed = 0.07f;
			bullet.angle = ( 360f / num ) * i + angleAdjustment;
			bullet.angleCompensation = 90;
			bullet.power = 20;
			bullet.lifespan = 2f;
			bullet.preliminaryMovement = new Vector2(0, 1f);
		}
	}
	void PatternStraight()
	{
		Debug.Log("building");
		for ( int i = 0; i <= 0; i++ )
		{
			GameObject tempbullet = (GameObject)Instantiate(bulletObject);
			tempbullet.transform.position = transform.position + Vector3.forward * 0.1f;
			BulletBehaviour bullet = tempbullet.GetComponent<BulletBehaviour>();
			bullet.speed = 0.1f;
			bullet.angle = Mathf.Atan2(-transform.position.x + player.transform.position.x, transform.position.y - player.transform.position.y) * Mathf.Rad2Deg - 90;
			Debug.Log(bullet.angle);
			bullet.angleCompensation = 0;
			bullet.power = 25;
			bullet.lifespan = 2f;
			bullet.preliminaryMovement = new Vector2(0, 1f * i);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
		if ( player != null )
		{
			player.AddKcal(1000);
		}
	}
}