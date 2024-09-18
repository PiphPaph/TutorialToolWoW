using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectSelector : MonoBehaviour
{
   public Camera characterCamera;
   public GameObject selectedObject;
   void Update()
   {
      if (Input.GetMouseButton(0))
      {
         SelectObject();
      }

      void SelectObject()
      {
         var ray = characterCamera.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit))
         {
            if (selectedObject != null && selectedObject.name == "Dummy")
            {
               selectedObject.GetComponent<Renderer>().material.color = Color.white;  
            }

            selectedObject = hit.collider.gameObject;
            selectedObject.GetComponent<Renderer>().material.color = Color.green;
         }
      }
   }
}
