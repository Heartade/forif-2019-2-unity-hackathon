using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashScreen : MonoBehaviour
{
	public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if ( Input.GetKeyDown(KeyCode.Space) )
		{
			Debug.Log("???");
			SceneManager.LoadScene(sceneName);
		}
	}

}
