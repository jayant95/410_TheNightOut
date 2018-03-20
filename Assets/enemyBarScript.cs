using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBarScript : MonoBehaviour {

	public Image hpBar;

	public Enemy enemyScript;

	public float fillAmount;

	private Image content;

	public float MaxValue { get; set;}




	// Use this for initialization
	void Start()
	{
		fillAmount = 1;
	}

	// Update is called once per frame
	void Update()
	{

		HandleBar();

	}

	private void HandleBar()
	{

//			content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime * lerpSpeed);
		fillAmount = Map(enemyScript.curHealth, 0, 100, 0, 1);
		hpBar.fillAmount = fillAmount;
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{

		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;


	}

	public float Value
	{
		set
		{
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}



}