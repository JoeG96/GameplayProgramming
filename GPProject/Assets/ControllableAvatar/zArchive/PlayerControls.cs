// GENERATED AUTOMATICALLY FROM 'Assets/ControllableAvatar/zArchive/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""5b539116-4d5a-420b-bc32-dbc249a2d80b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""950ed2bc-41b2-4f69-9e83-09618a5d0407"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""92a87c89-0fd0-44b8-9020-ec5d97742b7d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bbbbc588-61b9-43b4-87a9-bb4340329f55"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4cd672cf-a09c-431e-a02d-7d285dbc6579"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""32f8a801-8958-48a4-9118-a8ee108ab7fa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""486dcb63-3fbf-4144-b248-410e3b574885"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""48d6cb4b-3292-4a61-be93-585d9d68d7ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""a9664771-caf3-4ced-9dfe-a4b135703a7f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ee416aa3-a462-4ea5-8177-60ed90e05ca7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9aa1361c-e532-4705-98b8-2f65488e6e10"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f2e8fe0f-5937-464e-84c1-3b85d308f049"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18a1e5a6-85e0-419b-981d-ad9a82b8df2b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""384781ac-d4d2-4ef8-9926-cf2a1bc85bd6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Stick"",
                    ""id"": ""7837372f-970e-41e7-b614-2521cda0222c"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0fad24f-4b80-4a47-80c8-03ba84e02d5b"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe5e1d4e-ea05-4f30-8fc8-a8945fbfb961"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ff961e1-3a44-4598-b5fc-ad681dfdd177"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c24a68da-2343-4af6-b5ed-b2f7f0df6e59"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""903cda06-2009-4456-8956-436af00453d2"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""6a18f070-e95a-440c-97c7-6f877f87333c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""888f3412-4557-4b87-810b-5f1f18ab9e20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""ba6fdc3d-695f-40ea-855f-9e8b7db94730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""ec6e6325-b643-4000-88d1-0f536f08400a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""d0d0b8ed-b926-475f-9999-62361edf91d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""fb3efb37-69b9-4562-8d8d-5d33e1eb4921"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""fae95dd6-3fe6-4451-b9d5-ab43ab2cfba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""3c4452a8-aa48-4cc3-9457-b3e9765d1b9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""fc1690e6-e389-4ecc-901c-84e77efdd259"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""DpadDown"",
                    ""type"": ""Button"",
                    ""id"": ""015202a3-c6a1-45c7-b853-8dbe68e3e806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DpadUp"",
                    ""type"": ""Button"",
                    ""id"": ""3cf32442-e465-4c33-8c47-8924f61b0ba8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DpadLeft"",
                    ""type"": ""Button"",
                    ""id"": ""32bc5068-6361-48a0-a281-5da7028000ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DpadRight"",
                    ""type"": ""Button"",
                    ""id"": ""d6897ac5-90dc-4ce8-be8a-465285727480"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""5080f951-a432-46d4-a8a7-ce44f7b567e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80565e32-6da1-4cdd-acaf-6171c5b12649"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d28440a8-7fb9-49b9-af51-c5c94d3eb8d2"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a61e4a01-230d-4b2f-819e-c20ee73cd93e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""987c7362-e27d-4eb5-a667-564ea6eea959"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccfe5d4f-ee37-46db-be46-7a3be018d7da"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16bf73a1-9fc4-4b5c-abbc-2e1d51be6f48"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de477f33-0bcd-4465-bcb1-cffa618c7a27"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b632784-4009-4069-8f29-9a76aa3f0f75"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb13b902-bcc8-4a42-ad7a-a0cac04961e2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5311f32-e7c5-44f9-8efa-b11406b7639c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""190201d2-b891-48ac-a9c3-5892cb18d05c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad665359-eec4-40f2-8ec2-d1cb75593d70"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92d27d67-ae11-4848-9d24-bbe378339fd1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af6df2b9-917e-4c32-821d-02265273a5d6"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d60620de-6e6c-4314-8104-44b5bf795e1b"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d2fdbf4-62d0-454d-bd75-49abb3c8d44f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac056921-8191-4d1c-b1cf-235dc8f25f2c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8990fc75-23f3-4b81-8cee-05c8e88495fc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_A = m_PlayerActions.FindAction("A", throwIfNotFound: true);
        m_PlayerActions_Y = m_PlayerActions.FindAction("Y", throwIfNotFound: true);
        m_PlayerActions_B = m_PlayerActions.FindAction("B", throwIfNotFound: true);
        m_PlayerActions_X = m_PlayerActions.FindAction("X", throwIfNotFound: true);
        m_PlayerActions_Start = m_PlayerActions.FindAction("Start", throwIfNotFound: true);
        m_PlayerActions_RB = m_PlayerActions.FindAction("RB", throwIfNotFound: true);
        m_PlayerActions_RT = m_PlayerActions.FindAction("RT", throwIfNotFound: true);
        m_PlayerActions_LB = m_PlayerActions.FindAction("LB", throwIfNotFound: true);
        m_PlayerActions_LT = m_PlayerActions.FindAction("LT", throwIfNotFound: true);
        m_PlayerActions_DpadDown = m_PlayerActions.FindAction("DpadDown", throwIfNotFound: true);
        m_PlayerActions_DpadUp = m_PlayerActions.FindAction("DpadUp", throwIfNotFound: true);
        m_PlayerActions_DpadLeft = m_PlayerActions.FindAction("DpadLeft", throwIfNotFound: true);
        m_PlayerActions_DpadRight = m_PlayerActions.FindAction("DpadRight", throwIfNotFound: true);
        m_PlayerActions_Use = m_PlayerActions.FindAction("Use", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_Camera;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_A;
    private readonly InputAction m_PlayerActions_Y;
    private readonly InputAction m_PlayerActions_B;
    private readonly InputAction m_PlayerActions_X;
    private readonly InputAction m_PlayerActions_Start;
    private readonly InputAction m_PlayerActions_RB;
    private readonly InputAction m_PlayerActions_RT;
    private readonly InputAction m_PlayerActions_LB;
    private readonly InputAction m_PlayerActions_LT;
    private readonly InputAction m_PlayerActions_DpadDown;
    private readonly InputAction m_PlayerActions_DpadUp;
    private readonly InputAction m_PlayerActions_DpadLeft;
    private readonly InputAction m_PlayerActions_DpadRight;
    private readonly InputAction m_PlayerActions_Use;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_PlayerActions_A;
        public InputAction @Y => m_Wrapper.m_PlayerActions_Y;
        public InputAction @B => m_Wrapper.m_PlayerActions_B;
        public InputAction @X => m_Wrapper.m_PlayerActions_X;
        public InputAction @Start => m_Wrapper.m_PlayerActions_Start;
        public InputAction @RB => m_Wrapper.m_PlayerActions_RB;
        public InputAction @RT => m_Wrapper.m_PlayerActions_RT;
        public InputAction @LB => m_Wrapper.m_PlayerActions_LB;
        public InputAction @LT => m_Wrapper.m_PlayerActions_LT;
        public InputAction @DpadDown => m_Wrapper.m_PlayerActions_DpadDown;
        public InputAction @DpadUp => m_Wrapper.m_PlayerActions_DpadUp;
        public InputAction @DpadLeft => m_Wrapper.m_PlayerActions_DpadLeft;
        public InputAction @DpadRight => m_Wrapper.m_PlayerActions_DpadRight;
        public InputAction @Use => m_Wrapper.m_PlayerActions_Use;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnA;
                @Y.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnY;
                @B.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnB;
                @X.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnX;
                @Start.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnStart;
                @RB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @LB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLB;
                @LT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLT;
                @DpadDown.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadDown;
                @DpadDown.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadDown;
                @DpadDown.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadDown;
                @DpadUp.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadUp;
                @DpadUp.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadUp;
                @DpadUp.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadUp;
                @DpadLeft.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadLeft;
                @DpadLeft.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadLeft;
                @DpadLeft.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadLeft;
                @DpadRight.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadRight;
                @DpadRight.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadRight;
                @DpadRight.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDpadRight;
                @Use.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @DpadDown.started += instance.OnDpadDown;
                @DpadDown.performed += instance.OnDpadDown;
                @DpadDown.canceled += instance.OnDpadDown;
                @DpadUp.started += instance.OnDpadUp;
                @DpadUp.performed += instance.OnDpadUp;
                @DpadUp.canceled += instance.OnDpadUp;
                @DpadLeft.started += instance.OnDpadLeft;
                @DpadLeft.performed += instance.OnDpadLeft;
                @DpadLeft.canceled += instance.OnDpadLeft;
                @DpadRight.started += instance.OnDpadRight;
                @DpadRight.performed += instance.OnDpadRight;
                @DpadRight.canceled += instance.OnDpadRight;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnDpadDown(InputAction.CallbackContext context);
        void OnDpadUp(InputAction.CallbackContext context);
        void OnDpadLeft(InputAction.CallbackContext context);
        void OnDpadRight(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
}
