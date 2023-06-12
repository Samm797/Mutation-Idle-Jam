using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float CurrentHealth => _currentHealth;

    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        // If a mutation causes the max health to drop below the current health, the current health to match
        if (_maxHealth < _currentHealth)
        {
            _currentHealth = _maxHealth;
        }

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Death");
    }

    private void TakeDamage(int amount)
    {
        _currentHealth -= amount;
    }

    private void Heal(int amount)
    {
        _currentHealth += amount;
    }
}
