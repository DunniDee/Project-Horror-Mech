// GENERATED AUTOMATICALLY FROM 'Assets/Mech/Mech Controlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MechControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MechControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Mech Controlls"",
    ""maps"": [
        {
            ""name"": ""GroundMevment"",
            ""id"": ""cea69962-0f04-43cc-9a16-e01766561d2c"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5861beed-786b-41ad-a93a-a0f2bd03eb73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""041414f2-795a-464c-a0b1-bfe7fc2b823e"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""132dd503-92ab-4f8c-804b-c2a074aca5ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f835ec1d-743b-4e95-bd72-7d650f3bddf1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47305531-db9f-4e4b-b32e-405e503d2abd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""89444170-92f7-45b6-bfe7-8a76221082a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lock"",
                    ""type"": ""Button"",
                    ""id"": ""4bc389fb-c7b0-4fbd-b0bb-e408d901fefa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""4d776dc1-b909-49d3-be1d-820dc786a617"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""63cba90e-e98c-4002-b8f1-fd6cc92ce47e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ed145cda-c918-4fec-9b21-90048e08a649"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""762f3aad-57df-419b-bb4e-918c34acda95"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""561ea2a6-c79c-4b6c-8334-56250a329afe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""04dbf7af-41a3-454e-8a8b-df244a4339d7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a36ce805-869e-4fe1-9e26-55cc7add7c15"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80f6ece6-4fa8-4865-b868-bc2605835396"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4404232-7dbc-4608-9dda-99f4116994fd"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f26a9305-0982-453a-906e-ba631a0b6b9a"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4872e17-1a58-4521-92bc-a81a6e0ab24b"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""4086a810-6067-4488-867a-4f85db843c38"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4b33302-3cc4-4c46-ae7d-8bb2c4049f04"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bf76cbbb-dca1-4b7b-9ac8-dd8278f17dac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3285cb4d-22a3-48f8-8219-d8a8243ed5b2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GroundMevment
        m_GroundMevment = asset.FindActionMap("GroundMevment", throwIfNotFound: true);
        m_GroundMevment_HorizontalMovement = m_GroundMevment.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_GroundMevment_Rotation = m_GroundMevment.FindAction("Rotation", throwIfNotFound: true);
        m_GroundMevment_Jump = m_GroundMevment.FindAction("Jump", throwIfNotFound: true);
        m_GroundMevment_MouseX = m_GroundMevment.FindAction("MouseX", throwIfNotFound: true);
        m_GroundMevment_MouseY = m_GroundMevment.FindAction("MouseY", throwIfNotFound: true);
        m_GroundMevment_Dash = m_GroundMevment.FindAction("Dash", throwIfNotFound: true);
        m_GroundMevment_Lock = m_GroundMevment.FindAction("Lock", throwIfNotFound: true);
        m_GroundMevment_MouseClick = m_GroundMevment.FindAction("MouseClick", throwIfNotFound: true);
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

    // GroundMevment
    private readonly InputActionMap m_GroundMevment;
    private IGroundMevmentActions m_GroundMevmentActionsCallbackInterface;
    private readonly InputAction m_GroundMevment_HorizontalMovement;
    private readonly InputAction m_GroundMevment_Rotation;
    private readonly InputAction m_GroundMevment_Jump;
    private readonly InputAction m_GroundMevment_MouseX;
    private readonly InputAction m_GroundMevment_MouseY;
    private readonly InputAction m_GroundMevment_Dash;
    private readonly InputAction m_GroundMevment_Lock;
    private readonly InputAction m_GroundMevment_MouseClick;
    public struct GroundMevmentActions
    {
        private @MechControlls m_Wrapper;
        public GroundMevmentActions(@MechControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_GroundMevment_HorizontalMovement;
        public InputAction @Rotation => m_Wrapper.m_GroundMevment_Rotation;
        public InputAction @Jump => m_Wrapper.m_GroundMevment_Jump;
        public InputAction @MouseX => m_Wrapper.m_GroundMevment_MouseX;
        public InputAction @MouseY => m_Wrapper.m_GroundMevment_MouseY;
        public InputAction @Dash => m_Wrapper.m_GroundMevment_Dash;
        public InputAction @Lock => m_Wrapper.m_GroundMevment_Lock;
        public InputAction @MouseClick => m_Wrapper.m_GroundMevment_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_GroundMevment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundMevmentActions set) { return set.Get(); }
        public void SetCallbacks(IGroundMevmentActions instance)
        {
            if (m_Wrapper.m_GroundMevmentActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnHorizontalMovement;
                @Rotation.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnRotation;
                @Jump.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnJump;
                @MouseX.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseY;
                @Dash.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnDash;
                @Lock.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnLock;
                @Lock.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnLock;
                @Lock.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnLock;
                @MouseClick.started -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_GroundMevmentActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_GroundMevmentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Lock.started += instance.OnLock;
                @Lock.performed += instance.OnLock;
                @Lock.canceled += instance.OnLock;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public GroundMevmentActions @GroundMevment => new GroundMevmentActions(this);
    public interface IGroundMevmentActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnLock(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
