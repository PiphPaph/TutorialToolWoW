using UnityEngine;

public class WhirlWindDamage : MonoBehaviour
{
    private WhirlWind _whirlWind;

    private void Start()
    {
        _whirlWind = FindObjectOfType<WhirlWind>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Dummy") && _whirlWind.isWhirlWinded)
        {
            Debug.Log("whirlwind damage"); 
        }
    }
}
