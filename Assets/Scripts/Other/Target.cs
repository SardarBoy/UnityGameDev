// Cleaned version below
using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 50f;

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
	}

	public void Die()
	{
		score.scoreValue++;
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}
}
