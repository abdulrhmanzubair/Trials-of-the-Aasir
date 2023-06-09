using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD2 : MonoBehaviour
{

	public Text nameText2;
	public Text levelText2;
	public Slider hpSlider2;

	
	public void SetHUD(Unit2 unit2)
	{
		nameText2.text = unit2.unitName;
		levelText2.text = "Lvl " + unit2.unitLevel;
		hpSlider2.maxValue = unit2.maxHP;
		hpSlider2.value = unit2.currentHP;
	}


	public void SetHP2(int hp)
	{
		hpSlider2.value = hp;
	}

}