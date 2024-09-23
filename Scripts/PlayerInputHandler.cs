using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls _playerControls;
    private ChargeToTarget _chargeToTarget;
    private WhirlWind _whirlWind;
    private BladeStorm _bladeStorm;
    private Rampage _rampage;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }
    
    void Start()
    {
        _chargeToTarget = FindObjectOfType<ChargeToTarget>();
        _whirlWind = FindObjectOfType<WhirlWind>();
        _bladeStorm = FindObjectOfType<BladeStorm>();
        _rampage = FindObjectOfType<Rampage>();
        
        
        _playerControls.Player.Dash.performed += ctx => OnDash();
        _playerControls.Player.Whirlwind.performed += ctx => WhirlWind();
        _playerControls.Player.BladeStorm.performed += ctx => BladeStorm();
        _playerControls.Player.Rampage.performed += ctx => Rampage();
        
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

    void WhirlWind()
    {
        _whirlWind.DoWhirlWind();
    }

    void BladeStorm()
    {
        _bladeStorm.DoBladeStorm();
    }

    void Rampage()
    {
        _rampage.DoRampage();
    }
}
