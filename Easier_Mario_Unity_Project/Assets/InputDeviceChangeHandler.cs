using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

// add this into built-in button you can create from menu: UI/Button
public class InputDeviceChangeHandler : MonoBehaviour
{
    // refs to Button's components
    public Image buttonImage;

    // refs to your sprites
    public Sprite ProControllerImage;
    public Sprite PS4ControllerImage;
    public Sprite keyboardImage;

    void Awake()
    {
        PlayerInput input = FindObjectOfType<PlayerInput>();
        updateButtonImage(input.currentControlScheme);
    }

    void OnEnable()
    {
        InputUser.onChange += onInputDeviceChange;
    }

    void OnDisable()
    {
        InputUser.onChange -= onInputDeviceChange;
    }

    void onInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            updateButtonImage(user.controlScheme.Value.name);
        }
    }

    void updateButtonImage(string schemeName)
    {
        // assuming you have only 2 schemes: keyboard and gamepad
        if (schemeName.Equals("ProController"))
        {
            buttonImage.sprite = ProControllerImage;
        }
        else if (schemeName.Equals("M+K"))
        {
            buttonImage.sprite = keyboardImage;
        }
        else if(schemeName.Equals("PS4Controller"))
        {
            buttonImage.sprite = PS4ControllerImage;
        }
    }
}
