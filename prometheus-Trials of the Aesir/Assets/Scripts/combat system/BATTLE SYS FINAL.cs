using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleStateFNL { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystemFINAL : MonoBehaviour
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
	Unit3 enemyUnit3;

	public Text dialogueText;
	public Text dialogueText2;
	public Text dialogueText3;
	public Text dialogueTextMAIN;
	public GameObject playerHUDobj;
	public BattleHUD playerHUD;
	public GameObject EnemyHUDobj;
	public BattleHUD enemyHUD;
	public GameObject EnemyHUDobj2;
	public BattleHUD2 enemyHUD2;
	public GameObject EnemyHUDobj3;
	public BattleHUD enemyHUD3;
	private static bool BSExists;

	public BattleState state;

	// Start is called before the first frame update
	void Start()
	{
		enemyPrefab.SetActive(true);
		enemyPrefab2.SetActive(true);
		enemyPrefab3.SetActive(true);
		EnemyBattleStationOBJ.SetActive(true);
		state = BattleState.START;
		Coroutine coroutine = StartCoroutine(SetupBattle());
	}

	private void Update()
	{


		if (state == BattleState.WON)
		{

			enemyPrefab.SetActive(false);
			enemyPrefab2.SetActive(false);
			enemyPrefab3.SetActive(true);
		}
	}



	public IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();


		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		GameObject enemyGO2 = Instantiate(enemyPrefab2, enemyBattleStation);
		GameObject enemyGO3 = Instantiate(enemyPrefab3, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();
		enemyUnit2 = enemyGO2.GetComponent<Unit2>();
		enemyUnit3 = enemyGO3.GetComponent<Unit3>();

		dialogueTextMAIN.text = "GOD'S TRIALS AHEAD!";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);
		enemyHUD2.SetHUD(enemyUnit2);
		enemyHUD3.SetHUD(enemyUnit3);
		

		yield return new WaitForSeconds(0f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();


		Debug.Log("enemy spawned");
	}

	public IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		bool isDead2 = enemyUnit2.TakeDamage(playerUnit.damage);
		bool isDead3 = enemyUnit3.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		enemyHUD2.SetHP2(enemyUnit2.currentHP);
		enemyHUD3.SetHP(enemyUnit3.currentHP);
		dialogueTextMAIN.text = "The attack is successful!";

		yield return new WaitForSeconds(0f);
		/////////////////////////enemy 1
		if (isDead)
		{
			EnemyBattleStationOBJ.SetActive(false);
			state = BattleState.WON;
			EndBattle();
			enemyPrefab.SetActive(false);
			Debug.Log("knight died");
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());

		}
		/////////////////////////////enemy 2
		if (isDead2)
		{
			state = BattleState.WON;
			EndBattle();
			enemyPrefab2.SetActive(false);

			Debug.Log("dog died");
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());

		}
		/////////////////////// enemy 3
		///
		if (isDead3)
		{
			state = BattleState.WON;
			EndBattle();
			

			Debug.Log("dog died");
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());

		}
	}

	public IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";
		dialogueText2.text = enemyUnit2.unitName + " attacks!";
		dialogueText3.text = enemyUnit3.unitName + " attacks!";


		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		bool isDead2 = playerUnit.TakeDamage(enemyUnit2.damage);
		bool isDead3 = playerUnit.TakeDamage(enemyUnit3.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);
		if (state == BattleState.ENEMYTURN)
		{

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

		if (isDead2)
		{
			state = BattleState.LOST;
			EndBattle();

		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

		if (isDead3)
		{
			state = BattleState.LOST;
			EndBattle();

		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

		Debug.Log("Enemy turn");
	}

	public void EndBattle()
	{
		if (state == BattleState.WON)
		{

			dialogueTextMAIN.text = "You won the battle!";



			Debug.Log("battle won");

		}
		else if (state == BattleState.LOST)
		{
			dialogueTextMAIN.text = "You were defeated.";
			SceneManager.LoadScene("Map");
			playerUnit.Heal(60);
			state = BattleState.START;
			Debug.Log("battle lost");
		}
	}

	public void PlayerTurn()
	{
		dialogueTextMAIN.text = "Choose an action:";
		Debug.Log("player turn");
	}

	public IEnumerator PlayerHeal()
	{
		playerUnit.Heal(20);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueTextMAIN.text = "GOD's BLESSINGS!";

		yield return new WaitForSeconds(0f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
		Debug.Log("heal");

	}



	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;


		StartCoroutine(PlayerAttack());


		Debug.Log("attack");

	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}