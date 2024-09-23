using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyboardVisualizer : MonoBehaviour
{
    public InputActionAsset InputActionAsset;
    private InputAction dashAction;
    private InputAction whirlwindAction;
    private InputAction rampageAction;
    private InputAction bladestormAction;

    public Image keyCharge;
    public Image keyWhirlWind;
    public Image keyRampage;
    public Image keyBladestorm;

    private Dictionary<string, Image> keyMap;

    private void Awake()
    {
        dashAction = InputActionAsset.FindAction("Dash");
        whirlwindAction = InputActionAsset.FindAction("WhirlWind");
        rampageAction= InputActionAsset.FindAction("Rampage");
        bladestormAction = InputActionAsset.FindAction("Bladestorm");

        keyMap = new Dictionary<string, Image>
        {
            { "6", keyCharge },
            { "E", keyWhirlWind },
            { "Q", keyRampage },
            { "4", keyBladestorm }
            
        };
    }

    private void OnEnable()
    {
        dashAction.Enable();
        dashAction.performed += OnKeyPressed;
        
        whirlwindAction.Enable();
        whirlwindAction.performed += OnKeyPressed;
        
        rampageAction.Enable();
        rampageAction.performed += OnKeyPressed;
        
        bladestormAction.Enable();
        bladestormAction.performed += OnKeyPressed;
    }

    private void OnDisable()
    {
        dashAction.performed -= OnKeyPressed;
        dashAction.Disable();
        
        whirlwindAction.performed -= OnKeyPressed;
        whirlwindAction.Disable();
        
        rampageAction.performed -= OnKeyPressed;
        rampageAction.Disable();
        
        bladestormAction.performed -= OnKeyPressed;
        bladestormAction.Disable();
    }

    private void OnKeyPressed(InputAction.CallbackContext context)
    {
        var key = context.control.displayName;
        if (keyMap.TryGetValue(key, out Image keyImage))
        {
            HighlightKey(keyImage);
        }
    }

    private void HighlightKey(Image keyImage)
    {
        StartCoroutine(ChangeColor(keyImage));
    }

    private IEnumerator ChangeColor(Image keyImage)
    {
        keyImage.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        keyImage.color = Color.white;
    }
}
