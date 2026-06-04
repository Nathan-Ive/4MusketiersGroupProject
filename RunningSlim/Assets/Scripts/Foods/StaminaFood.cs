using UnityEngine;

public class StaminaFood : MonoBehaviour
{
    private StatsV1 _getStamina = new StatsV1();
    void Start()
    {
        _getStamina = FindAnyObjectByType<StatsV1>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
