//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2c57fbae-0f01-450f-99dd-fe546ddb00f9"",
            ""actions"": [
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""e698d714-2425-419a-9092-4e3a7117612e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""f4774831-96e7-4b73-aec0-ce8295928cae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Clear"",
                    ""type"": ""Button"",
                    ""id"": ""d3a0c54a-60c7-4f2f-8e61-cc30c12bf68e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Backspace"",
                    ""type"": ""Button"",
                    ""id"": ""a3a8a6ec-e317-4ee0-814b-bcc841410f64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scramble"",
                    ""type"": ""Button"",
                    ""id"": ""bca9c9ea-1803-441d-a235-fa3d6550a0fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcbf0226-c3f6-4d34-b90a-e579618af87f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41f37329-abaf-49b2-96b4-45db7ff236b3"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e4df58a-cd67-48c0-a86a-c70bafa41df6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1bdb4cc-7a53-4273-8e24-10a84d046378"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backspace"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea676e64-0b79-4d85-9bad-8d1e0b6d3b41"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scramble"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Skip = m_Player.FindAction("Skip", throwIfNotFound: true);
        m_Player_Submit = m_Player.FindAction("Submit", throwIfNotFound: true);
        m_Player_Clear = m_Player.FindAction("Clear", throwIfNotFound: true);
        m_Player_Backspace = m_Player.FindAction("Backspace", throwIfNotFound: true);
        m_Player_Scramble = m_Player.FindAction("Scramble", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Skip;
    private readonly InputAction m_Player_Submit;
    private readonly InputAction m_Player_Clear;
    private readonly InputAction m_Player_Backspace;
    private readonly InputAction m_Player_Scramble;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skip => m_Wrapper.m_Player_Skip;
        public InputAction @Submit => m_Wrapper.m_Player_Submit;
        public InputAction @Clear => m_Wrapper.m_Player_Clear;
        public InputAction @Backspace => m_Wrapper.m_Player_Backspace;
        public InputAction @Scramble => m_Wrapper.m_Player_Scramble;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Skip.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkip;
                @Skip.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkip;
                @Skip.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkip;
                @Submit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSubmit;
                @Clear.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClear;
                @Clear.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClear;
                @Clear.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClear;
                @Backspace.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackspace;
                @Backspace.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackspace;
                @Backspace.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackspace;
                @Scramble.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScramble;
                @Scramble.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScramble;
                @Scramble.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnScramble;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skip.started += instance.OnSkip;
                @Skip.performed += instance.OnSkip;
                @Skip.canceled += instance.OnSkip;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Clear.started += instance.OnClear;
                @Clear.performed += instance.OnClear;
                @Clear.canceled += instance.OnClear;
                @Backspace.started += instance.OnBackspace;
                @Backspace.performed += instance.OnBackspace;
                @Backspace.canceled += instance.OnBackspace;
                @Scramble.started += instance.OnScramble;
                @Scramble.performed += instance.OnScramble;
                @Scramble.canceled += instance.OnScramble;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnSkip(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnClear(InputAction.CallbackContext context);
        void OnBackspace(InputAction.CallbackContext context);
        void OnScramble(InputAction.CallbackContext context);
    }
}
