// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""f683cf79-9633-4112-a76a-0838a1d9e81e"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""111f5e76-4c1a-415d-9e7e-0f91c327b4a6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerator"",
                    ""type"": ""Value"",
                    ""id"": ""d7a6e693-9c69-4574-b252-1514cfc01b2b"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""7118af0b-3873-456d-9075-5d30d35023fd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""976b0bed-6ddd-4f90-a6ac-8cc211e53476"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""cf3e55eb-0fa0-42ba-8aab-7e83d0c1e81e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""19494f41-38a0-4cee-89a2-f7d88be8c1f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c11bc436-8620-41fd-878a-0fc40811d584"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a21f574-b617-415c-ac3c-fbc05c34aa2d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""486b2d94-9488-4cb1-a205-a070d33c90f9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cca1ae7-2170-4d93-954d-1508ac644f6c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29f2c9bf-c34e-4aac-9dff-de4d0c2e3406"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc6f0808-321c-410e-ae1d-8a2ac744cb64"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8aac2e7-7ddc-4191-9c39-b387caa8c5b6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""136f56f1-9fdd-4b28-8fc8-05fed44d037a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e614064-1b1b-48b6-85ab-03d5924e0e82"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""90328458-3d5f-40f9-8c0e-cfb11e884087"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""fbe1ceeb-2bac-473a-a377-6eb30b4c2c42"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8f5063c9-6306-40c6-967e-5edb682d7202"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard AD"",
                    ""id"": ""2c2d2499-fe3c-473a-84ce-5e2a49945763"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""26ec41a0-7896-4475-8867-c943a5ff4584"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d4e27e54-793a-49af-85f1-458162cd65a4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Arrows"",
                    ""id"": ""58e57d11-4f7b-4b33-bed1-4e00bb971010"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""77992f65-9bba-4325-988e-e4f13cc64fd1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1c53d21c-e533-415d-bdb3-ab52ec454c29"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6a35471c-6f99-4619-ad80-d3422e56456f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05937b99-fc1f-4792-9d61-217824873bfb"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf5c69da-a90e-4af0-89da-7860922a1a2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f2b9e55-69cb-4c35-bf81-c9fc86e63c88"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Look = m_Car.FindAction("Look", throwIfNotFound: true);
        m_Car_Accelerator = m_Car.FindAction("Accelerator", throwIfNotFound: true);
        m_Car_Steering = m_Car.FindAction("Steering", throwIfNotFound: true);
        m_Car_Brake = m_Car.FindAction("Brake", throwIfNotFound: true);
        m_Car_Reset = m_Car.FindAction("Reset", throwIfNotFound: true);
        m_Car_Menu = m_Car.FindAction("Menu", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Look;
    private readonly InputAction m_Car_Accelerator;
    private readonly InputAction m_Car_Steering;
    private readonly InputAction m_Car_Brake;
    private readonly InputAction m_Car_Reset;
    private readonly InputAction m_Car_Menu;
    public struct CarActions
    {
        private @Controls m_Wrapper;
        public CarActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_Car_Look;
        public InputAction @Accelerator => m_Wrapper.m_Car_Accelerator;
        public InputAction @Steering => m_Wrapper.m_Car_Steering;
        public InputAction @Brake => m_Wrapper.m_Car_Brake;
        public InputAction @Reset => m_Wrapper.m_Car_Reset;
        public InputAction @Menu => m_Wrapper.m_Car_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_CarActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnLook;
                @Accelerator.started -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerator;
                @Accelerator.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerator;
                @Accelerator.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerator;
                @Steering.started -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Brake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Reset.started -= m_Wrapper.m_CarActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnReset;
                @Menu.started -= m_Wrapper.m_CarActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Accelerator.started += instance.OnAccelerator;
                @Accelerator.performed += instance.OnAccelerator;
                @Accelerator.canceled += instance.OnAccelerator;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    public interface ICarActions
    {
        void OnLook(InputAction.CallbackContext context);
        void OnAccelerator(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
}
