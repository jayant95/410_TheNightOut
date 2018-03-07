using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject currentPlayer;
    private GameObject playerObject;

    public GameObject hallucinationEnemy1;
    public GameObject hallucinationEnemy2;
    public GameObject hallucinationEnemy3;

	private Stat intoxicationLevel;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        playerObject = currentPlayer.GetComponent<PlayerSwitch>().currentPlayer;
		intoxicationLevel = playerObject.GetComponent<Player> ().intoxication;

		if (intoxicationLevel.CurrentVal > 25.0f)
        {
            hallucinationEnemy1.SetActive(true);
        }

		if (intoxicationLevel.CurrentVal > 50.0f)
        {
            hallucinationEnemy2.SetActive(true);
        }

		if (intoxicationLevel.CurrentVal > 75.0f)
        {
            hallucinationEnemy3.SetActive(true);
        }
    }
}
