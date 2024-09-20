using System.Collections;
using UnityEngine;



public class WhirlWind : MonoBehaviour
{
    public bool isWhirlWinded = false;
    public float rotationSpeed = 2100f;
    private float _totalRotation = 0f;

    public void DoWhirlWind()
    {
        if (!isWhirlWinded)
        {
            StartCoroutine(CastWhirlWind());
        }
    } 
    
    private IEnumerator CastWhirlWind()
    {
        isWhirlWinded = true;

        while (_totalRotation < 360)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            _totalRotation += rotationSpeed * Time.deltaTime;
            yield return null;
        }

        isWhirlWinded = false;
        _totalRotation = 0f;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
    }
    
}
