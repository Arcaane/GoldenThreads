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
        enemyManager.SpawnEnemies(enemyManager.numberOfEnemiesToSpawn);
        playerManager.UpdateUI();
    }

    void StartBehavior()
    {
        // Cartes joueur
        deckContainer.StartTurn();
        
        // UI Player
        // Enemis Behavior à la fin du tour
        // Enemis UI
        // --> Passer au tour du joueur (1)
        state = BattleStates.PLAYERTURN;
    }

    void PlayerTurnBehavior()
    {
        // Quand le joueur n'as plus de mana -> Passer au tour enemis
        state = BattleStates.ENEMYTURN;
    }

    void EnemyTurnBehavior()
    {
        // Quand les ennemis ont joués leurs tour --> Passer au Start
        state = BattleStates.START;
    }

    void OnWin()
    {
        // Recompense + Effect de fin de combat
    }

    void OnLose()
    {
        // Mort + Stats 
    }
}
