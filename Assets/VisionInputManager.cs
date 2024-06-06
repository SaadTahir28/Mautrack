using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;
using System;

public class VisionInputManager : MonoBehaviour
{
    public static event Action<float> OnSteeringWheelRotated;
    public static event Action<float> OnGasPressed;
    public static event Action<float> OnBrakePressed;
    public float steeringSensitivity = 0.1f;

    private bool isSteering = false;
    private bool isGas = false;
    private bool isBrake = false;
    private float pedalPressAngle = -30f;
    private GameObject selectedObject;
    private Vector2 lastTouchPosition;
    private bool isTouching;
    private float currentRotation;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        HandleTouch();
    }

    private void HandleTouch()
    {
        for (int i = 0; i < Touch.activeTouches.Count; i++)
        {
            Touch touch = Touch.activeTouches[i];
            SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);

            if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (touchData.targetObject.CompareTag("SteeringWheel"))
                    {
                        selectedObject = touchData.targetObject;
                        lastTouchPosition = touchData.interactionPosition;
                        isTouching = true;
                        isSteering = true;
                    }
                    else if (touchData.targetObject.CompareTag("Gas"))
                    {
                        selectedObject = touchData.targetObject;
                        OnGasPressed?.Invoke(1);
                        HandlePedalPress(1);
                        isGas = true;
                    }
                    else if (touchData.targetObject.CompareTag("Brake"))
                    {
                        selectedObject = touchData.targetObject;
                        OnBrakePressed?.Invoke(-1);
                        HandlePedalPress(1);
                        isBrake = true;
                    }
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (selectedObject != null && isTouching)
                    {
                        Vector2 currentTouchPosition = touchData.interactionPosition;
                        float angleDelta = CalculateRotationAngle(lastTouchPosition, currentTouchPosition, selectedObject.transform.position);
                        var angle = angleDelta * steeringSensitivity;
                        currentRotation += angle;
                        currentRotation = Mathf.Clamp(currentRotation, -90f, 90f);
                        float normalizedValue = currentRotation / 90f;

                        OnSteeringWheelRotated?.Invoke(-normalizedValue);
                        RotateSteeringWheel(angle);
                        lastTouchPosition = currentTouchPosition;

                        //Vector2 currentTouchPosition = touchData.interactionPosition;
                        //var deltaPosition = currentTouchPosition - lastTouchPosition;
                        //float rotationAmount = deltaPosition.x * rotationSpeed; // Adjust the multiplier as needed

                        //// Smoothly adjust the currentSteerValue
                        //currentSteerValue = Mathf.Clamp(currentSteerValue + rotationAmount, -1f, 1f);

                        //Debug.Log(currentSteerValue);
                        ////Debug.Log(rotationAmount);
                        //RotateSteeringWheel(rotationAmount);
                        ////OnSteeringWheelRotated?.Invoke(rotationAmount);
                        //OnSteeringWheelRotated?.Invoke(currentSteerValue);
                        //lastTouchPosition = currentTouchPosition;

                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    if (touchData.targetObject.CompareTag("SteeringWheel"))
                    {
                        //OnSteeringWheelRotated?.Invoke(0);
                        //ResetSteeringWheel();
                        //currentRotation = 0f;
                        isTouching = false;
                        selectedObject = null;
                        isSteering = false;
                    }
                    else if (touchData.targetObject.CompareTag("Gas"))
                    {
                        OnGasPressed?.Invoke(0);
                        HandlePedalPress(0);
                        isGas = false;
                        selectedObject = null;
                    }
                    else if (touchData.targetObject.CompareTag("Brake"))
                    {
                        OnBrakePressed?.Invoke(0);
                        HandlePedalPress(0);
                        isBrake = false;
                        selectedObject = null;
                    }
                }
            }
        }
    }

    private float CalculateRotationAngle(Vector2 initialPos, Vector2 currentPos, Vector3 pivot)
    {
        Vector2 initialDirection = initialPos - (Vector2)pivot;
        Vector2 currentDirection = currentPos - (Vector2)pivot;
        float angle = Vector2.SignedAngle(initialDirection, currentDirection);
        return angle;
    }

    private void HandlePedalPress(float value)
    {
        if (selectedObject != null)
        {
            switch (value)
            {
                case 0:
                    selectedObject.transform.Rotate(Vector3.right, pedalPressAngle);
                    break;
                case 1:
                    selectedObject.transform.Rotate(Vector3.right, -pedalPressAngle);
                    break;
                default:
                    break;
            }
        }
    }

    private void RotateSteeringWheel(float angle)
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(-Vector3.up, angle);
        }
    }
}