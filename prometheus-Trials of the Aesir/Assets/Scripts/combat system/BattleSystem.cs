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

	Unit playerUnit;
	Unit enemyUnit;
	Unit2 enemyUnit2;
	Unit enemyUnit3;

	public Text dialogueText;
	public Text dialogueText2;
	public Text dialogueTextMAIN;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;
	public BattleHUD2 enemyHUD2;
	public BattleHUD enemyHUD3;
	private static bool BSExists;

	public BattleState state;

	// Start is called before the first frame update
	void Start()
	{
		if (!BSExists)
		{
			BSExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}


		state = BattleState.START;
        Coroutine coroutine = StartCoroutine(SetupBattle());
	}
	
	IEnumerator SetupBattle()
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

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		bool isDead2 = enemyUnit2.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		enemyHUD2.SetHP2(enemyUnit2.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(0f);

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
			Destroy(GameObject.FindWithTag("Enemy"));
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
			playerPrefab.SetActive(false);
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";
		dialogueText2.text = enemyUnit2.unitName + " attacks!";


		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		bool isDead2 = playerUnit.TakeDamage(enemyUnit2.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

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

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			

		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			SceneManager.LoadScene("Map");
		}
	}

	void PlayerTurn()
	{
		dialogueTextMAIN.text = "Choose an action:";
		
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(10);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "GOD's BLESSINGS!";

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