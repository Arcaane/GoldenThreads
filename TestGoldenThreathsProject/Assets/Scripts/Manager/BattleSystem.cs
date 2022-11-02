using System;
using UnityEngine;

public enum BattleStates { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public BattleStates state;
    public DeckContainer deckContainer;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;

    void Start()
    {
        state = BattleStates.START;
        enemyManager = GetComponent<EnemyManager>();
        SetupBattle();
        StartBehavior();
    }

    private void SetupBattle()
    {
        playerManager.UpdateUI();
        enemyManager.SpawnEnemies(enemyManager.numberOfEnemiesToSpawn);
    }

    void StartBehavior()
    {
        deckContainer.StartTurn(); // Cartes joueur
        playerManager.UpdateUI(); // UI Player
        enemyManager.ProvideAllEffects(); // Enemis Behavior à la fin du tour
        
        state = BattleStates.PLAYERTURN;
        PlayerTurnBehavior();  // --> Passer au tour du joueur (1)
    }

    void PlayerTurnBehavior()
    {
        // Quand le joueur n'as plus de mana -> Passer au tour enemis
    }

    void EnemyTurnBehavior()
    {
        enemyManager.ApplyAllEffects();

        if (playerManager.isDead)
        {
            state = BattleStates.LOST;
            EndBattle();
        }
        else
        {
            state = BattleStates.PLAYERTURN;
            PlayerTurnBehavior();
        }
    }

    void EndBattle()
    {
        if (state == BattleStates.LOST)
        {
            // Mort + Stats 
            playerManager.PlayerDeath();
        }
        else
        {
            // Récompense + Effect de fin de combat
            playerManager.PlayerWin();
        }
    }

    public void OnEndTurnButton()
    {
        if (state != BattleStates.PLAYERTURN) return;

        state = BattleStates.ENEMYTURN;
        EnemyTurnBehavior();
    }
}
