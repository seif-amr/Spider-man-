using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
	public int health = 6;
	public int lives = 3;

	private float flickertime = 0f;
	public float flickerDuration = 0.1f;

	private SpriteRenderer spriteRenderer;

	public bool isImmune = false;
	private float immunityTime = 0f;
	public float immunityDuration = 1.5f;

	public int WIN_collected = 0;

	public Slider healthUI;

	public void CollectCoins(int coinValue)
	{
		this.WIN_collected = this.WIN_collected + coinValue;

	}

	void Start()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}


	void Update()
	{
		healthUI.value = health;
		if (this.isImmune == true)
		{
			SpriteFlicker();
			immunityTime = immunityTime + Time.deltaTime;
			if (immunityTime >= immunityDuration)
			{
				this.isImmune = false;
				this.spriteRenderer.enabled = true;

			}
		}
		if (this.WIN_collected == 10)
		{
			(new NavigationContoller()).GoToVictoryScene();
		}
	}

	void SpriteFlicker()
	{
		if (this.flickertime < this.flickerDuration)
		{
			this.flickertime = this.flickertime + Time.deltaTime;
		}
		else if (this.flickertime >= this.flickerDuration)
		{
			spriteRenderer.enabled = !(spriteRenderer.enabled);
			this.flickertime = 0;
		}
	}

	public void TakeDamage(int damage)
	{
		if (this.isImmune == false)
		{
			this.health = this.health - damage;
			if (this.health < 0)
				this.health = 0;
			if (this.lives > 0 && this.health == 0)
			{
				FindObjectOfType<LevelManeger>().RespawnPlayer();
				this.health = 6;
				this.lives--;
			}
			else if (this.lives == 0 && this.health == 0)
			{

				(new NavigationContoller()).GoToGameOverScene();
				Destroy(this.gameObject);
			}
			Debug.Log("Player Health:" + this.health.ToString());
			Debug.Log("Player Lives:" + this.lives.ToString());
		}
		PlayHitReaction();
	}
	void PlayHitReaction()
	{
		this.isImmune = true;
		this.immunityTime = 0f;
	}
}
