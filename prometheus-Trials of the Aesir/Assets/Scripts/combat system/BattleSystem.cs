using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;
	public Transform enemyBattleStation2;
	public GameObject EnemyBattleStationOBJ;
	Unit playerUnit;
	Unit enemyUnit;
	Unit2 enemyUnit2;
	Unit enemyUnit3;

	public Text dialogueText;
	public Text dialogueText2;
	public Text dialogueTextMAIN;
	public GameObject playerHUDobj;
	public BattleHUD playerHUD;
	public GameObject EnemyHUDobj;
	public  BattleHUD enemyHUD;
	public GameObject EnemyHUDobj2;
	public BattleHUD2 enemyHUD2;
	public GameObject EnemyHUDobj3;
	public BattleHUD enemyHUD3;
	private static bool BSExists;

	public BattleState state;

	// Start is called before the first frame update
	void Start()
	{
		

		
		state = BattleState.START;
		Coroutine coroutine = StartCoroutine(SetupBattle());
	}



	public IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();


		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		GameObject enemyGO2 = Instantiate(enemyPrefab2, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();
		enemyUnit2 = enemyGO2.GetComponent<Unit2>();

		dialogueTextMAIN.text = "GOD'S TRIALS AHEAD!";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);
		enemyHUD2.SetHUD(enemyUnit2);

		yield return new WaitForSeconds(0f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();

		
	}

	public IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		bool isDead2 = enemyUnit2.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		enemyHUD2.SetHP2(enemyUnit2.currentHP);
		dialogueTextMAIN.text = "The attack is successful!";

		yield return new WaitForSeconds(0f);
		/////////////////////////enemy 1
		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
			enemyPrefab.SetActive(false);

			EnemyHUDobj.SetActive(false);
			EnemyBattleStationOBJ.SetActive(false);
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
			EnemyHUDobj.SetActive(true);
			enemyPrefab.SetActive(true);
		}
		/////////////////////////////enemy 2
		if (isDead2)
		{
			state = BattleState.WON;
			EndBattle();
			enemyPrefab2.SetActive(false);
			
			EnemyHUDobj2.SetActive(false);
			EnemyBattleStationOBJ.SetActive(false);
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
			EnemyHUDobj2.SetActive(true);
			enemyPrefab2.SetActive(true);
		}
	}

	public IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";
		dialogueText2.text = enemyUnit2.unitName + " attacks!";


		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		bool isDead2 = playerUnit.TakeDamage(enemyUnit2.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);
		if(state == BattleState.ENEMYTURN)
        {
			EnemyHUDobj2.SetActive(true);
			enemyPrefab2.SetActive(true);
		}

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
			
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
		

	}

	public void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueTextMAIN.text = "You won the battle!";
			state = BattleState.PLAYERTURN;
			EnemyBattleStationOBJ.SetActive(false);

		}
		else if (state == BattleState.LOST)
		{
			dialogueTextMAIN.text = "You were defeated.";
			SceneManager.LoadScene("MainMenu");
			playerUnit.Heal(100);
			state = BattleState.START;
			
		}
	}

	public void PlayerTurn()
	{
		dialogueTextMAIN.text = "Choose an action:";

	}

	public IEnumerator PlayerHeal()
	{
		playerUnit.Heal(17);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueTextMAIN.text = "GOD's BLESSINGS!";

		yield return new WaitForSeconds(0f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());


	}

    

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;


		StartCoroutine(PlayerAttack());




	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}