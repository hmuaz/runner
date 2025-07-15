using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateUI;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateUI;
    }

    private void UpdateUI(int currentHealth)
    {
        GetComponent<TextMeshProUGUI>().text = $"Health: {currentHealth}";
    }
}
