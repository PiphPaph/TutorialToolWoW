using System.Collections;
using UnityEngine;

public class BladeStorm : MonoBehaviour
{
    public bool isBladeStormed = false;
    private float _duration = 3f;
    private WhirlWind _whirlWind;

    private void Start()
    {
        _whirlWind = FindObjectOfType<WhirlWind>();
    }

    public void DoBladeStorm()
    {
        if (!isBladeStormed)
        {
            StartCoroutine(CastBladeStorm());
        }
    }

    private IEnumerator CastBladeStorm()
    {
        isBladeStormed = true;

        float elapsedTime = 0f;
        while (elapsedTime < _duration)
        {
            transform.Rotate(Vector3.up, _whirlWind.rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isBladeStormed = false;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
    }
}
