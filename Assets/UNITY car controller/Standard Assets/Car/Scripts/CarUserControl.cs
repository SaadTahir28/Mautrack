using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        private float steerValue, gasValue, brakeValue;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void OnEnable()
        {
            VisionInputManager.OnSteeringWheelRotated += HandleSteeringWheel;
            VisionInputManager.OnBrakePressed += HandleBrake;
            VisionInputManager.OnGasPressed += HandleGas;
        }

        private void OnDisable()
        {
            VisionInputManager.OnSteeringWheelRotated -= HandleSteeringWheel;
            VisionInputManager.OnBrakePressed -= HandleBrake;
            VisionInputManager.OnGasPressed -= HandleGas;
        }

        void HandleSteeringWheel(float value)
        {
            steerValue = value;
        }

        void HandleGas(float value)
        {
            gasValue = value;
        }

        void HandleBrake(float value)
        {
            brakeValue = value;
        }

        private void FixedUpdate()
        {
            //            // pass the input to the car!
            //            float h = SimpleInput.GetAxis("Horizontal");
            //            float v = SimpleInput.GetAxis("Vertical");
            //#if !MOBILE_INPUT
            //            float handbrake = SimpleInput.GetAxis("Jump");
            //            m_Car.Move(h, v, v, handbrake);
            //#else
            //            m_Car.Move(h, 1f, v, 0f);
            //#endif
            m_Car.Move(steerValue, gasValue, brakeValue, 0f);
        }
    }
}
