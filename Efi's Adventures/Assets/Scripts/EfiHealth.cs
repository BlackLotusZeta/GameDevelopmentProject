using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EfiHealth : MonoBehaviour
{

    public delegate void UpdateHealthBar(int amount);
    public static event UpdateHealthBar UpdatePlayerHealth;

    [SerializeField]
    private int maxHealthPoints = 100;
    [SerializeField]
    private int invulnerabilityTime = 0;
    [SerializeField]
    private int cancelMovementTime = 0;

    private int currentHealthPoints;

    [HideInInspector]
    public bool hit;

    private void Damage(int amount)
    {
        if (!hit)
        {
            hit = true;
            currentHealthPoints -= amount;
            UpdatePlayerHealth(currentHealthPoints);

            if (currentHealthPoints <= 0)
            {
                SceneManager.LoadSceneAsync(0);
            }
        }
    }
}
