using System.Collections;
using TMPro;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthIndicator;

    private int _health;

    void Start()
    {
        _health = 100;
        healthIndicator.text = _health.ToString() + " HP";
        healthIndicator.color = Color.green;
    }

    void Update()
    {
        switch (_health)
        {
            case int n when (n > 70):
                healthIndicator.color = Color.green;
                break;
            case int n when (n > 30):
                healthIndicator.color = Color.yellow;
                break;
            default:
                healthIndicator.color = Color.red;
                break;
        }
    }

    public void IncreaseHealth(int damage)
    {
        _health += damage;
        if (_health > 100)
        {
            _health = 100;
        }
        healthIndicator.text = _health.ToString() + " HP";
    }
    public void DecreaseHealth(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
        healthIndicator.text = _health.ToString() + " HP";
    }
}
