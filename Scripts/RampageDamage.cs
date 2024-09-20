using UnityEngine;

public class RampageDamage : MonoBehaviour
{
    private Rampage _rampage;

    private void Start()
    {
        _rampage = FindObjectOfType<Rampage>();
    }

    public void Damage()
    {
        if (_rampage.isRampaged)
        {
            Debug.Log("Rampage damage"); 
        }
    }
}
