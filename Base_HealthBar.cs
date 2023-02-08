using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Base_HealthBar : MonoBehaviour
{
	public string baseType;

	private void Update() // 각 진영의 체력바
	{
		if (baseType == "Blue")
		{
			transform.GetComponent<RectTransform>().sizeDelta = new Vector2((float)GameManager.instance.BlueHealth / 20 * 60, 14f);
			transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.instance.BlueHealth.ToString();
			transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = GameManager.instance.BlueHealth.ToString();
		}
		if (baseType == "Red")
		{
			transform.GetComponent<RectTransform>().sizeDelta = new Vector2((float)GameManager.instance.RedHealth / 20 * 60, 14f);
			transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.instance.RedHealth.ToString();
			transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = GameManager.instance.RedHealth.ToString();
		}
	}
}
