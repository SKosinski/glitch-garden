using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] int health = 5;
    TextMeshProUGUI healthText;

    // Start is called before the first frame update

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
    
    /*
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    */

    public void TakeALife()
    {
        if (health >= 1)
        { 
            health--;
            UpdateDisplay();
        }

        if (health <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    public bool HaveEnoughHealth(int amount)
    {
        return health >= amount;
    }
}
