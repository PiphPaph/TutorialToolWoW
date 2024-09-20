using System.Collections;
using UnityEngine;

public class Rampage : MonoBehaviour
{
    private ObjectSelector _objectSelector;
    public bool isRampaged = false;
    private RampageDamage _rampageDamage;

    private void Start()
    {
        _objectSelector = FindObjectOfType<ObjectSelector>();
        _rampageDamage = FindObjectOfType<RampageDamage>();
    }

    public void DoRampage()
    {
        if (!isRampaged)
        {
            StartCoroutine(RampageCoroutine());
        }
    }

    private IEnumerator RampageCoroutine()
    {
        
        if (_objectSelector.selectedObject.name == "Dummy")
        {
            isRampaged = true;
            Debug.Log("Rampaged!");
            _rampageDamage.Damage();
            yield return null;
        }
        isRampaged = false;
    }
}
