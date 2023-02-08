using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
	public float damage;

	LayerMask enemy;
	Vector3 direction;
	RaycastHit2D hit;
	private float distance = 0.4f;

	private void Awake()
	{
		typeSet();
	}

	private void FixedUpdate()
	{
		hit = Physics2D.Raycast(transform.position, direction, distance, enemy); //���� Ž���ϴ� ������ 
		Debug.DrawRay(transform.position, direction, Color.green, 0f);
		if (hit)
		{
			if (hit.collider.GetComponent<Unit>())//���� ������Ʈ�� �ִٸ�
				hit.collider.GetComponent<Unit>().TakeDamage(damage); //������ �ֱ�, �������� ��� ȭ�쿡 ���� TakeDamage�� ȣ���ϱ� ������ �������ش�.
			else if (hit.collider.GetComponent<Base_Condition>())
				hit.collider.GetComponent<Base_Condition>().TakeDamage(damage);
			Destroy(gameObject);
		}

		if (transform.position.x > 10 || transform.position.x < -10) //�ʹ����� ������ �ı�
			Destroy(gameObject);

		transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, 0.3f, 0f);
	}

	void typeSet()
	{
		if (gameObject.layer == 8)
		{
			enemy = LayerMask.GetMask("Red");
			direction = Vector3.right * distance;
		}
		else if (gameObject.layer == 9)
		{
			enemy = LayerMask.GetMask("Blue");
			direction = Vector3.left * distance;
		}
	}

}
