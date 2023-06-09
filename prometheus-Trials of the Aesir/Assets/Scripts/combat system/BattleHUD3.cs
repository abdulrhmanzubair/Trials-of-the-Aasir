using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD3 : MonoBehaviour
{

	public Text nameText3;
	public Text levelText3;
	public Slider hpSlider3;

	
	public void SetHUD(Unit3 unit3)
	{
		nameText3.text = unit3.unitName;
		levelText3.text = "Lvl " + unit3.unitLevel;
		hpSlider3.maxValue = unit3.maxHP;
		hpSlider3.value = unit3.currentHP;
	}


	public void SetHP3(int hp)
	{
		hpSlider3.value = hp;
	}

}