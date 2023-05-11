using Assets._Scripts.Core.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IHealthBar
{
    [Header("Autoloads on Awake")]
    [Tooltip("Autoloads")]
    public Image healthBarImage;
    [Header("Just for debug. The value currently set on image")]
    public float debugDurrentHealth;

    private void Awake()
    {
        healthBarImage = GetComponent<Image>();
    }

    public void Set(float currentHealth, float maxHealth)
    {
        healthBarImage.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1f);

        debugDurrentHealth = currentHealth;
    }
}
