using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class changeScene : MonoBehaviour {


    public int num;

	
	// Update is called once per frame
	void Update () {

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(num);
            Debug.Log("Scene changed to" + num);

        }

        }
}
