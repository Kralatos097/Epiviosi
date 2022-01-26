// GENERATED AUTOMATICALLY FROM 'Assets/Enzo D/Scripts/PlayeurControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayeurControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayeurControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayeurControl"",
    ""maps"": [
        {
            ""name"": ""Arène"",
            ""id"": ""fee5a664-4690-4880-a0e4-529ddbcddf20"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""50082c2a-72f9-41f2-9803-7f7c764aacc5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""fd25891e-a5f8-4eab-801b-50ba79185b50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""697b42b2-283c-426a-82c2-0575dd026837"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cd7f68d1-e5a8-4c33-ab8f-a6349f7e294e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5371cf13-f8b5-4ff5-9855-fba8f4b49fc4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72afacb5-ee4a-416c-a1e7-af94b1f14922"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3388b72-206c-454d-8802-1a73a778a99a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d86a7da2-8152-404e-9295-854f3a441741"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Arène
        m_Arène = asset.FindActionMap("Arène", throwIfNotFound: true);
        m_Arène_Movement = m_Arène.FindAction("Movement", throwIfNotFound: true);
        m_Arène_Attack = m_Arène.FindAction("Attack", throwIfNotFound: true);
        m_Arène_Special = m_Arène.FindAction("Special", throwIfNotFound: true);
        m_Arène_Pause = m_Arène.FindAction("Pause", throwIfNotFound: true);
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

    // Arène
    private readonly InputActionMap m_Arène;
    private IArèneActions m_ArèneActionsCallbackInterface;
    private readonly InputAction m_Arène_Movement;
    private readonly InputAction m_Arène_Attack;
    private readonly InputAction m_Arène_Special;
    private readonly InputAction m_Arène_Pause;
    public struct ArèneActions
    {
        private @PlayeurControl m_Wrapper;
        public ArèneActions(@PlayeurControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Arène_Movement;
        public InputAction @Attack => m_Wrapper.m_Arène_Attack;
        public InputAction @Special => m_Wrapper.m_Arène_Special;
        public InputAction @Pause => m_Wrapper.m_Arène_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Arène; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArèneActions set) { return set.Get(); }
        public void SetCallbacks(IArèneActions instance)
        {
            if (m_Wrapper.m_ArèneActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttack;
                @Special.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnSpecial;
                @Pause.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ArèneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ArèneActions @Arène => new ArèneActions(this);
    public interface IArèneActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
