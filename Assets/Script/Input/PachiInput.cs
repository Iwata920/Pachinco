// GENERATED AUTOMATICALLY FROM 'Assets/Script/Input/PachiInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PachiInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PachiInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PachiInput"",
    ""maps"": [
        {
            ""name"": ""inGame"",
            ""id"": ""d3fb6569-7702-4ef1-9ffc-707bf638eea9"",
            ""actions"": [
                {
                    ""name"": ""power"",
                    ""type"": ""Value"",
                    ""id"": ""d0ad1347-ce41-41eb-9c4c-a2d2ba117b8e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""test"",
                    ""type"": ""Value"",
                    ""id"": ""d8a2fd9a-b0a5-40f7-a2c9-4416906261c9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""efa1c6c4-01a4-4b3f-bf2f-7133a955b7b2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""power"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a026391e-e118-406b-9b5d-438b2404bbac"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // inGame
        m_inGame = asset.FindActionMap("inGame", throwIfNotFound: true);
        m_inGame_power = m_inGame.FindAction("power", throwIfNotFound: true);
        m_inGame_test = m_inGame.FindAction("test", throwIfNotFound: true);
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

    // inGame
    private readonly InputActionMap m_inGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_inGame_power;
    private readonly InputAction m_inGame_test;
    public struct InGameActions
    {
        private @PachiInput m_Wrapper;
        public InGameActions(@PachiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @power => m_Wrapper.m_inGame_power;
        public InputAction @test => m_Wrapper.m_inGame_test;
        public InputActionMap Get() { return m_Wrapper.m_inGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @power.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnPower;
                @power.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnPower;
                @power.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnPower;
                @test.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnTest;
                @test.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnTest;
                @test.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @power.started += instance.OnPower;
                @power.performed += instance.OnPower;
                @power.canceled += instance.OnPower;
                @test.started += instance.OnTest;
                @test.performed += instance.OnTest;
                @test.canceled += instance.OnTest;
            }
        }
    }
    public InGameActions @inGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnPower(InputAction.CallbackContext context);
        void OnTest(InputAction.CallbackContext context);
    }
}
