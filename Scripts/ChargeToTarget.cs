using System.Collections;
using UnityEngine;

public class ChargeToTarget : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDistance = 2f;
    private ObjectSelector _objectSelector;
    public bool isDashing = false;

    void Start()
    {
        _objectSelector = FindObjectOfType<ObjectSelector>();
    }
    
     public void Charge()
     {
         if (!isDashing && _objectSelector.selectedObject.name == "Dummy")
         {
             StartCoroutine(ChargeTarget());
         }
    }

     private IEnumerator ChargeTarget()
     {
         isDashing = true;
         float startTime = Time.time;

         while (Time.time < startTime + dashSpeed && isDashing)
         {
             transform.position = Vector3.MoveTowards(transform.position, _objectSelector.selectedObject.transform.position, dashSpeed * Time.deltaTime);
             yield return null;
         }
     }
     private void OnTriggerEnter(Collider other)
     {
         if (isDashing && other.gameObject.CompareTag("Dummy"))
         {
             isDashing = false;
         }
     }
}
