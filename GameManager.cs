using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject Camera;
	public string mod;
	public GameObject ArrowBlue;
	public GameObject ArrowRed;
	public ParticleSystem MasicBlue;
	public ParticleSystem MasicRed;
	public GameObject UpgradeBW;
	public GameObject UpgradeBS;
	public GameObject UpgradeBA;
	public GameObject UpgradeBG;


	private int MaxCost = 10;
	public int BlueCost=0;
	public int RedCost=0;

	bool AbleGetCostBlue = true;
	bool AbleGetCostRed = true;

	float modNum;

	public int BlueHealth = 20;
	public int RedHealth = 20;

	public string GameOver;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		switch(mod)
		{
			case "Easy":
				modNum = 2f;
				break;
			case "Normal":
				modNum = 1.75f;
				break;
			case "Hard":
				modNum = 1.5f;
				break;
		}
	}

	private void Update()
	{
		if (AbleGetCostBlue)
			StartCoroutine(GetCostBlue());
		if(AbleGetCostRed)
			StartCoroutine(GetCostRed());
		CheckUpgrade();
	}

	IEnumerator GetCostBlue() // 2초에 1씩 cost회복
	{
		AbleGetCostBlue = false;
		if (MaxCost > BlueCost)
			BlueCost++;
		yield return new WaitForSeconds(2f);
		AbleGetCostBlue = true;
	}

	IEnumerator GetCostRed()
	{
		AbleGetCostRed = false;
		if (MaxCost > RedCost)
			RedCost++;
		yield return new WaitForSeconds(modNum);
		AbleGetCostRed = true;
	}

	void CheckUpgrade() //코스트가 10이 아니면 엑티브를 false로 설정
	{
		if (BlueCost == 10)
		{
			if (UpgradeBS != null)
				UpgradeBS.SetActive(true);
			if (UpgradeBA != null)
				UpgradeBA.SetActive(true);
			if (UpgradeBW != null)
				UpgradeBW.SetActive(true);
			if (UpgradeBG != null)
				UpgradeBG.SetActive(true);
		}
		if (BlueCost != 10)
		{
			if (UpgradeBS != null)
				UpgradeBS.SetActive(false);
			if (UpgradeBA != null)
				UpgradeBA.SetActive(false);
			if (UpgradeBW != null)
				UpgradeBW.SetActive(false);
			if (UpgradeBG != null)
				UpgradeBG.SetActive(false);
		}
	}
}
