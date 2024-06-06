using System;
using UnityEngine;

namespace PolySpatial.Template
{
    public class SpatialUIButton_ACTIVE : SpatialUI
    {
        [SerializeField]
        string m_ButtonText;
        [SerializeField]
        int m_ButtonIndex;
        [SerializeField] GameObject objectToActivate;
        [SerializeField] GameObject gameobject_1;
        [SerializeField] GameObject gameobject_stay1;
        [SerializeField] GameObject gameobject_stay2;
        [SerializeField] GameObject gameobject_stay3;
        [SerializeField] GameObject gameobject_stay4;
        [SerializeField] GameObject gameobject_stay5;

        MeshRenderer m_MeshRenderer;

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;
        public event Action<string, MeshRenderer, int> WasPressed;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
        }

        public override void PressStart()
        {
            m_PressStart.Invoke();
            base.PressStart();
        }
        public override void PressEnd()
        {
            m_PressEnd.Invoke();
            base.PressEnd();
            WasPressed?.Invoke(m_ButtonText, m_MeshRenderer, m_ButtonIndex);
            Invoke("ActivateObjectsStayDelayed", 0.3f);
        }

        void ActivateObjectsStayDelayed()
        {
            Debug.Log("Objetos 'stay' activados.");
            ActivateRecursively(gameobject_stay1);
            ActivateRecursively(gameobject_stay2);
            ActivateRecursively(gameobject_stay3);
            ActivateRecursively(gameobject_stay4);
            ActivateRecursively(gameobject_stay5);
        }

        void ActivateRecursively(GameObject gameObject)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(true);
                foreach (Transform child in gameObject.transform)
                {
                    ActivateRecursively(child.gameObject);
                }
            }
        }
    }
}
