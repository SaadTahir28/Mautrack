using System;
using UnityEngine;

namespace PolySpatial.Template
{
    public class SpatialUIButton_objects : SpatialUI
    {

        [SerializeField] GameObject objectToActivate;
        [SerializeField] GameObject additionalObjectToActivate;

        bool isPressed = false;



        void OnEnable()
        {

        }

        public override void PressStart()
        {

            base.PressStart();
            ActivateObjects();
            isPressed = true;
        }

        public override void PressEnd()
        {

            base.PressEnd();
            DeactivateObjects();
            isPressed = false;

        }

        void ActivateObjects()
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            if (additionalObjectToActivate != null)
            {
                additionalObjectToActivate.SetActive(true);
            }
        }

        void DeactivateObjects()
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
            if (additionalObjectToActivate != null)
            {
                additionalObjectToActivate.SetActive(false);
            }
        }
    }
}
