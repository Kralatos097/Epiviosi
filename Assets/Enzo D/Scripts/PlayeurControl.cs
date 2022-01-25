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
                    ""name"": ""Mouvement"",
                    ""type"": ""Value"",
                    ""id"": ""50082c2a-72f9-41f2-9803-7f7c764aacc5"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttaqueALaLance"",
                    ""type"": ""Button"",
                    ""id"": ""fd25891e-a5f8-4eab-801b-50ba79185b50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttaqueSpeciale"",
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
                    ""id"": ""12448ad3-a992-488e-a230-4f77c312fb55"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ce0e2b8-ae50-43ad-8238-9e5a5b16f27c"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
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
                    ""action"": ""AttaqueALaLance"",
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
                    ""action"": ""AttaqueSpeciale"",
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
        m_Arène_Mouvement = m_Arène.FindAction("Mouvement", throwIfNotFound: true);
        m_Arène_AttaqueALaLance = m_Arène.FindAction("AttaqueALaLance", throwIfNotFound: true);
        m_Arène_AttaqueSpeciale = m_Arène.FindAction("AttaqueSpeciale", throwIfNotFound: true);
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
    private readonly InputAction m_Arène_Mouvement;
    private readonly InputAction m_Arène_AttaqueALaLance;
    private readonly InputAction m_Arène_AttaqueSpeciale;
    private readonly InputAction m_Arène_Pause;
    public struct ArèneActions
    {
        private @PlayeurControl m_Wrapper;
        public ArèneActions(@PlayeurControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvement => m_Wrapper.m_Arène_Mouvement;
        public InputAction @AttaqueALaLance => m_Wrapper.m_Arène_AttaqueALaLance;
        public InputAction @AttaqueSpeciale => m_Wrapper.m_Arène_AttaqueSpeciale;
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
                @Mouvement.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMouvement;
                @Mouvement.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMouvement;
                @Mouvement.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnMouvement;
                @AttaqueALaLance.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueALaLance;
                @AttaqueALaLance.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueALaLance;
                @AttaqueALaLance.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueALaLance;
                @AttaqueSpeciale.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueSpeciale;
                @AttaqueSpeciale.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueSpeciale;
                @AttaqueSpeciale.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnAttaqueSpeciale;
                @Pause.started -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ArèneActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ArèneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouvement.started += instance.OnMouvement;
                @Mouvement.performed += instance.OnMouvement;
                @Mouvement.canceled += instance.OnMouvement;
                @AttaqueALaLance.started += instance.OnAttaqueALaLance;
                @AttaqueALaLance.performed += instance.OnAttaqueALaLance;
                @AttaqueALaLance.canceled += instance.OnAttaqueALaLance;
                @AttaqueSpeciale.started += instance.OnAttaqueSpeciale;
                @AttaqueSpeciale.performed += instance.OnAttaqueSpeciale;
                @AttaqueSpeciale.canceled += instance.OnAttaqueSpeciale;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ArèneActions @Arène => new ArèneActions(this);
    public interface IArèneActions
    {
        void OnMouvement(InputAction.CallbackContext context);
        void OnAttaqueALaLance(InputAction.CallbackContext context);
        void OnAttaqueSpeciale(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
