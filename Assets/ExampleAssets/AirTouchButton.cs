using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AirTouchButton : XRBaseInteractable
{
    public GameObject objectToActivate;

    protected override void Awake()
    {
        base.Awake();
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);  // Asegúrate de que el objeto esté desactivado al inicio
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún objeto para activar.");
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);  // Activa el objeto al tocar
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);  // Desactiva el objeto al dejar de tocar
        }
    }
}
