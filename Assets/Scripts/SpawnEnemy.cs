using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject currentPlayer;
    private GameObject playerObject;

    public GameObject hallucinationEnemy1;
    public GameObject hallucinationEnemy2;
    public GameObject hallucinationEnemy3;

    private float playerIntoxication;

    // Use this for initialization
    void Start () {
        playerIntoxication = 0;
    }
	
	// Update is called once per frame
	void Update () {
        playerObject = currentPlayer.GetComponent<PlayerSwitch>().currentPlayer;
        playerIntoxication = playerObject.GetComponent<Player>().intoxicationLevel;

        if (playerIntoxication > 25.0f)
        {
            hallucinationEnemy1.SetActive(true);
        }

        if (playerIntoxication > 50.0f)
        {
            hallucinationEnemy2.SetActive(true);
        }

        if (playerIntoxication > 75.0f)
        {
            hallucinationEnemy3.SetActive(true);
        }
    }
}
