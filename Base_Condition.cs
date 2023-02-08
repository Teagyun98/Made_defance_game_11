using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Condition : MonoBehaviour
{
	BoxCollider2D col;
	int Hp;

	public ParticleSystem destroyPar;
	public string baseType;
	public Sprite HitImg;
	public Sprite norImg;
	public Sprite GameOverImg;

	private void Awake()
	{
		col = GetComponent<BoxCollider2D>();
	}

	public void TakeDamage(float Attack) //각 진영의 데미지 함수
	{
		if (baseType == "Blue")
		{
			GameManager.instance.BlueHealth -= (int)Attack;
			StartCoroutine(ChangeHitImage());
			if(GameManager.instance.BlueHealth <= 0)
			{
				transform.GetComponent<SpriteRenderer>().sprite = GameOverImg;
				GameManager.instance.GameOver = "BlueDie";
			}
		}
		else if (baseType == "Red")
		{
			GameManager.instance.RedHealth -= (int)Attack;
			StartCoroutine(ChangeHitImage());
			if (GameManager.instance.RedHealth <= 0)
			{
				transform.GetComponent<SpriteRenderer>().sprite = GameOverImg;
				GameManager.instance.GameOver = "RedDie";
			}
		}
	}

	IEnumerator ChangeHitImage()
	{
		transform.GetComponent<SpriteRenderer>().sprite = HitImg;
		yield return new WaitForSeconds(0.1f);
		transform.GetComponent<SpriteRenderer>().sprite = norImg;
	}
}
