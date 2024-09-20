using UnityEngine;

public class BladeStormDamage : MonoBehaviour
{
    private BladeStorm _bladeStorm;

    private void Start()
    {
        _bladeStorm = FindObjectOfType<BladeStorm>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Dummy") && _bladeStorm.isBladeStormed)
        {
            Debug.Log("BS damage"); 
        }
    }
}
