using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls _playerControls;
    private ChargeToTarget _chargeToTarget;
    private WirlWind _wirlWind;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }
    
    void Start()
    {
        _chargeToTarget = FindObjectOfType<ChargeToTarget>();
        _wirlWind = FindObjectOfType<WirlWind>();
        _playerControls.Player.Dash.performed += ctx => OnDash();
        _playerControls.Player.Wirlwind.performed += ctx => WirlWind();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    void OnDash()
    {
        _chargeToTarget.Charge();
    }

    void WirlWind()
    {
        Debug.Log("E");
        _wirlWind.DoWirlWind();
    }
}
