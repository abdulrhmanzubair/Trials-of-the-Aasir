using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public int unitLevel = 0;

	public int damage;

	public int maxHP;
	public int currentHP;

	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)

			return true;
		else
			return false;
	}

	public void LVL(int amount)
    {
		
      

	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;

	}

}
