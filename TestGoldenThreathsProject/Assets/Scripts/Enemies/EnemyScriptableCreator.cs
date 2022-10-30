using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableCreator : ScriptableObject
{
    public string enemyName;
    public EnemyType enemyType;
    public Vector2 HealthRange;
    public PossibleActions[] actions;
   
    
    [System.Serializable]
    public struct PossibleActions
    {
        public Vector2 damageAmount;
        public int armorAmount;
        public int buffAmount;

        public Debuff debuffType;
        public Buff buffType;
        public GameObject summonEntity;
        
        public Sprite intentIcon;
    }
    
    public enum EnemyType
    {
        Basic,
        Boss
    }
    
    public enum Debuff
    {
        None = 0,
        Shocked
    }

    public enum Buff
    {
        None = 0,
        Strength
    }
}
