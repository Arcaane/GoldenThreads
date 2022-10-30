using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
    private int enemiesOnBoard = 0;
    public int numberOfEnemiesToSpawn;
    [SerializeField] private GameObject[] typeOfEnemyICanUse;
    [SerializeField] private GameObject[] enemiesSpawnPoints;
    [SerializeField] public List<RectTransform> enemiesRect;

    public int maxEnemiesOnBoard = 4;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }
    
    public void SpawnEnemies(int x, GameObject enemyPrefab = null)
    {
        if (typeOfEnemyICanUse.Length == 0)
        {
            Debug.Log("Veuillez inserer des enemis dans la variables prévu à cet effet"); return;
        }
        
        for (int i = 0; i < x; i++)
        {
            if (enemiesOnBoard < maxEnemiesOnBoard)
            {
                if (enemyPrefab)
                {
                    RectTransform rE = Instantiate(enemyPrefab, enemiesSpawnPoints[enemiesOnBoard].transform).GetComponent<RectTransform>();
                    enemiesRect.Add(rE);
                    enemiesOnBoard++;
                    return;
                }
                
                if (typeOfEnemyICanUse.Length == 1)
                {
                    RectTransform rE = Instantiate(typeOfEnemyICanUse[0], enemiesSpawnPoints[enemiesOnBoard].transform).GetComponent<RectTransform>();
                    enemiesRect.Add(rE);
                }
                else
                {
                    int enemyTemp = Random.Range(0, typeOfEnemyICanUse.Length + 1);
                    RectTransform rE = Instantiate(typeOfEnemyICanUse[enemyTemp], enemiesSpawnPoints[enemiesOnBoard].transform).GetComponent<RectTransform>();
                    enemiesRect.Add(rE);
                }

                enemiesOnBoard++;
            }
            else
            {
                Debug.Log("No more enemy slot avalable");
            }
        }
    }

    public void ProvideAllEffects()
    {
        if (enemiesOnBoard == 0) return;

        for (int i = 0; i < enemiesRect.Count; i++)
        {
            enemiesRect[i].GetComponent<Unit>()
            
        }
    }
}
