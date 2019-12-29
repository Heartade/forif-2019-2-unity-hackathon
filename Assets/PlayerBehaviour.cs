using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
	int kcal;
	public int maxKcal;
	float deathTimeStamp = float.MinValue;
	public KcalNumberBehaviour[] kcalDigits = new KcalNumberBehaviour[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(deathTimeStamp != float.MinValue)
		{
			Debug.Log(deathTimeStamp);
			deathTimeStamp -= Time.deltaTime;
			if(deathTimeStamp < 0)
			{
				Time.timeScale = 1;
				SceneManager.LoadScene("GameOverScene");
			}
		}
	}

	public void AddKcal(int amount)
	{
		kcal += amount;
		kcalDigits[0].SetNumber(( kcal / 1000 ) % 10);
		kcalDigits[1].SetNumber(( kcal / 100 ) % 10);
		kcalDigits[2].SetNumber(( kcal / 10 ) % 10);
		kcalDigits[3].SetNumber(kcal % 10);
		if(kcal >= maxKcal && deathTimeStamp == float.MinValue)
		{
			Time.timeScale = 0.1f;
			deathTimeStamp = 0.2f;	
		}
	}
}
