using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
   public Camera characterCamera;
   public GameObject selectedObject;
   private GameObject _dummy;

   private void Start()
   {
      _dummy = GameObject.FindWithTag("Dummy");
   }

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
               selectedObject.GetComponent<Renderer>().material.color = Color.green;
            }

            if (selectedObject != null && selectedObject.name != "Dummy")
            {
               _dummy.GetComponent<Renderer>().material.color = Color.red;
            }
            selectedObject = hit.collider.gameObject;
         }
      }
   }
}
