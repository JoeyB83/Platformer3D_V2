using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;
    public int maxHealth;

    public float invicibilityLength = 1f;
    private float invinCounter;

    public GameObject[] modelDisplay;
    private float flashCounter;
    public float flashTime = .1f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(invinCounter > 0)
        {
            invinCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                flashCounter = flashTime;

                foreach(GameObject piece in modelDisplay)
                {
                    piece.SetActive(!piece.activeSelf);
                }
            }

            if(invinCounter <= 0)
            {
                foreach (GameObject piece in modelDisplay)
                {
                    piece.SetActive(true);
                }
            }
        }
    }

    public void DamagePlayer()
    {
        if(invinCounter <= 0)
        {
            invinCounter = invicibilityLength;

            currentHealth--;

            if (currentHealth <= 0)
            {
                LevelManager.instance.Respawn();
            }
            else
            {
                AudioManager.instance.PlaySFX(12);
            }

            UIController.instance.UpdateHealthDisplay(currentHealth);
        }        
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;

        UIController.instance.UpdateHealthDisplay(currentHealth);
    }
}
