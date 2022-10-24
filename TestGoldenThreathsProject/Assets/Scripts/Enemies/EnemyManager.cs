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
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }
    
    public void SpawnEnemies(int x)
    {
        if (typeOfEnemyICanUse.Length == 0)
        {
            Debug.Log("Veuillez inserer des enemis dans la variables prévu à cet effet"); return;
        }
        
        for (int i = 0; i < x; i++)
        {
            if (enemiesOnBoard < 3)
            {
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
}
