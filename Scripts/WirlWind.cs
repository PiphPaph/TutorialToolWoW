using System.Collections;
using UnityEngine;

public class WirlWind : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public bool isWirlWinded = false;
    private float _rotationSpeed = 2100f;
    private float _totalRotation = 0f;

    public void DoWirlWind()
    {
        if (!isWirlWinded)
        {
            StartCoroutine(CastWirlWind());
        }
    } 
    
    private IEnumerator CastWirlWind()
    {
        isWirlWinded = true;

        while (_totalRotation < 360)
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
            _totalRotation += _rotationSpeed * Time.deltaTime;
            Debug.Log(_totalRotation);
            yield return null;
        }

        isWirlWinded = false;
        _totalRotation = 0f;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
    }
    
}
