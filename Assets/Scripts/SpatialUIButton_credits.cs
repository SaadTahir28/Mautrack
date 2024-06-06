using System;
using System.Collections;
using UnityEngine;

namespace PolySpatial.Template
{
    public class SpatialUIButton_credits : SpatialUI
    {
        [SerializeField]
        string m_ButtonText;

        [SerializeField]
        int m_ButtonIndex;

        [SerializeField]
        GameObject objectToDeactivate; // Objeto a desactivar

        MeshRenderer m_MeshRenderer;

        // Variables para la animación del botón
        Vector3 originalPosition;
        bool isAnimating;

        // Velocidad de la animación
        [SerializeField]
        float animationSpeed = 0.2f; // Ajusta la velocidad de movimiento

        public string ButtonText => m_ButtonText;
        public MeshRenderer MeshRenderer => m_MeshRenderer;
        public event Action<string, MeshRenderer, int> WasPressed;

        void OnEnable()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            originalPosition = transform.position;
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

            if (!isAnimating)
                StartCoroutine(MoveButtonAnimation());

            // Desactivar el objeto si está asignado
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }
        }

        // Corrutina para la animación de movimiento
        IEnumerator MoveButtonAnimation()
        {
            isAnimating = true;
            float elapsedTime = 0f;
            float animationDuration = 0.5f; // Duración de la animación en segundos
            Vector3 targetPosition = originalPosition + new Vector3(-0.2f, 0f, 0f); // Mover el botón -0.2 en el eje X

            // Movimiento hacia adelante (más rápido)
            while (elapsedTime < animationDuration)
            {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / (animationDuration * animationSpeed)); // Multiplicado por animationSpeed para ajustar la velocidad
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(0.2f); // Esperar un breve momento

            elapsedTime = 0f;
            // Movimiento de regreso (más lento)
            while (elapsedTime < animationDuration)
            {
                transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / (animationDuration * 0.5f)); // La velocidad de retorno es la mitad de la velocidad de avance
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = originalPosition;
            isAnimating = false;
        }
    }
}
