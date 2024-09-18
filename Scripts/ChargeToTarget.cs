using System.Collections;
using System.Collections.Generic;
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
         if (!isDashing)
         {
             StartCoroutine(ChargeTarget());
         }
    }

     private IEnumerator ChargeTarget()
     {
         isDashing = true;
         float startTime = Time.time;
         // Vector3 startPosition = transform.position;
         // Vector3 targetPosition = startPosition + transform.position * dashDistance;

         while (Time.time < startTime + dashSpeed && isDashing)
         {
             transform.position = Vector3.MoveTowards(transform.position, _objectSelector.selectedObject.transform.position, dashSpeed * Time.deltaTime);
             yield return null;
         }
         //isDashing = false;
     }
     private void OnCollisionEnter(Collision collision)
     {
         if (isDashing && collision.gameObject.CompareTag("Dummy"))
         {
             isDashing = false; // Остановить рывок при столкновении
         }
     }
}
