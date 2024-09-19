using UnityEngine;

public class AbilitysManager : MonoBehaviour
{
    private ObjectSelector _objectSelector;
    private ChargeToTarget _chargeToTarget;
    void Start()
    {
        _objectSelector = FindObjectOfType<ObjectSelector>();
        _chargeToTarget = FindObjectOfType<ChargeToTarget>();
    }
    
    // void Update()
    // {
    //     if (_objectSelector.selectedObject.name == "Dummy")
    //     {
    //             _chargeToTarget.Charge();
    //     }
    // }
}
