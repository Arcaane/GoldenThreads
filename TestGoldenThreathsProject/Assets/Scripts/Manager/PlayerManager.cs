using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int healthMax = 100;
    [SerializeField] private int health;
    [SerializeField] private int manaMax;
    [SerializeField] private int mana;
    public int currentArmor;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        mana = manaMax;
    }
}
