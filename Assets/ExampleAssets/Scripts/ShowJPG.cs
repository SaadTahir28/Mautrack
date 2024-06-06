using System;
using UnityEngine;
using UnityEngine.Events;

namespace PolySpatial.Template
{
    public class ShowJPG : MonoBehaviour
    {
        [SerializeField]
        GameObject objectToActivate;

        MeshRenderer m_MeshRenderer;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        void OnMouseDown()
        {
            ActivateObject();
        }

        public void ActivateObject()
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("Object activated!");
            }
        }

        public void SetObjectToActivate(GameObject obj)
        {
            objectToActivate = obj;
        }
    }
}
