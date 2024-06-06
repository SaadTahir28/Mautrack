using System;
using UnityEngine;

namespace PolySpatial.Template
{
    public class SpatialUIButton_shape : SpatialUI
    {
        [SerializeField] string m_ButtonText;
        [SerializeField] int m_ButtonIndex;
        [SerializeField] GameObject objectToActivate;
        [SerializeField] GameObject gameobject_1;
        [SerializeField] GameObject gameobject_stay1;
        [SerializeField] GameObject gameobject_stay2;
        [SerializeField] GameObject gameobject_stay3;
        [SerializeField] GameObject gameobject_stay4;
        [SerializeField] GameObject gameobject_stay5;
        [SerializeField] GameObject gameobject_stay6;
        [SerializeField] GameObject gameobject_stay7;
        [SerializeField] GameObject gameobject_stay8;
        //-
        [SerializeField] GameObject gameobject_gone1;
        [SerializeField] GameObject gameobject_gone2;
        [SerializeField] GameObject gameobject_gone3;
        [SerializeField] GameObject gameobject_gone4;
        [SerializeField] GameObject gameobject_gone5;

        MeshRenderer m_MeshRenderer;
        Vector3 originalLocalPosition;
        Quaternion originalRotation;
        bool isPressed = false;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;
        public event Action<string, MeshRenderer, int> WasPressed;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            originalLocalPosition = transform.localPosition;
            originalRotation = transform.rotation;
        }

        public override void PressStart()
        {
            m_PressStart.Invoke();
            base.PressStart();
            Vector3 moveDirection = -transform.forward;
            Vector3 targetLocalPosition = originalLocalPosition + moveDirection * 0.005f;
            transform.localPosition = targetLocalPosition;
            ActivateObjects();
            isPressed = true;
            Invoke("ActivateGameobjectsStay2To8", 0.4f); // Activar los gameobjects stay2 a stay8 medio segundo después
        }

        public override void PressEnd()
        {
            m_PressEnd.Invoke();
            base.PressEnd();
            DeactivateObjects();
            ActivateObjects_gone();
            DeactivateObjectsWithTag_1();
            DeactivateObjectsWithTag_2();
            isPressed = false;
            transform.localPosition = originalLocalPosition;
        }

        void ActivateObjects()
        {
            GameObject[] objetosABorrar = GameObject.FindGameObjectsWithTag("green_on");
            foreach (GameObject objeto in objetosABorrar)
            {
                objeto.SetActive(false);
            }
        }

        void DeactivateObjects()
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
            if (gameobject_1 != null)
            {
                gameobject_1.SetActive(false);
            }
        }



        void ActivateObjects_gone()
        {
            if (gameobject_gone1 != null) gameobject_gone1.SetActive(false);
            if (gameobject_gone2 != null) gameobject_gone2.SetActive(false);
            if (gameobject_gone3 != null) gameobject_gone3.SetActive(false);
            if (gameobject_gone4 != null) gameobject_gone4.SetActive(false);
            if (gameobject_gone5 != null) gameobject_gone5.SetActive(false);
        }

        void ActivateGameobjectsStay2To8()
        {
            if (gameobject_stay1 != null) gameobject_stay1.SetActive(true);
            if (gameobject_stay2 != null) gameobject_stay2.SetActive(true);
            if (gameobject_stay3 != null) gameobject_stay3.SetActive(true);
            if (gameobject_stay4 != null) gameobject_stay4.SetActive(true);
            if (gameobject_stay5 != null) gameobject_stay5.SetActive(true);
            if (gameobject_stay6 != null) gameobject_stay6.SetActive(true);
            if (gameobject_stay7 != null) gameobject_stay7.SetActive(true);
            if (gameobject_stay8 != null) gameobject_stay8.SetActive(true);
        }

        void DeactivateObjectsWithTag_1()
        {
            GameObject[] objectsWithTagHideme88q = GameObject.FindGameObjectsWithTag("Hideme88q");
            foreach (GameObject obj in objectsWithTagHideme88q)
            {
                DeactivateObjectsWithTag(obj);
            }
        }

        void DeactivateObjectsWithTag_2()
        {
            GameObject[] objectsWithTagPartesPines = GameObject.FindGameObjectsWithTag("partesypines");
            foreach (GameObject obj in objectsWithTagPartesPines)
            {
                DeactivateObjectsWithTag(obj);
            }
        }

        void DeactivateObjectsWithTag(GameObject obj)
        {
            if (obj.CompareTag("Hideme88q") || obj.CompareTag("partesypines"))
            {
                obj.SetActive(false);
            }

            foreach (Transform child in obj.transform)
            {
                DeactivateObjectsWithTag(child.gameObject);
            }
        }
    }
}
