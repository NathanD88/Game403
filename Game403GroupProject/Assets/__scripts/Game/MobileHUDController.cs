using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileHUDController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool pressed;
    private RVP.MobileInput mobileInput;
    private Car playerCar;

    [System.Serializable]
    public enum buttonType
    {
        Acceleration,
        Brake,
        Fire
    };

    public buttonType buttonControl;

	// Use this for initialization
	void Start ()
    {
        pressed = false;
        mobileInput = FindObjectOfType<RVP.MobileInput>();
        playerCar = FindObjectOfType<RVP.CameraControl>().target.gameObject.GetComponent<Car>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (pressed)
        {
            if (buttonControl == buttonType.Acceleration)
            {
                mobileInput.SetAccel(1.0f);
            }
            if (buttonControl == buttonType.Brake)
            {
                mobileInput.SetBrake(1.0f);
            }
            if (buttonControl == buttonType.Fire)
            {
                playerCar.checkFire();
            }
        }
        else
        {
            if (buttonControl == buttonType.Acceleration)
            {
                mobileInput.SetAccel(0.0f);
            }
            if (buttonControl == buttonType.Brake)
            {
                mobileInput.SetBrake(0.0f);
            }
        }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
