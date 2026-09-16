using UnityEngine;
using UnityEngine.InputSystem;

namespace MidtermTuringTest


{
    [DefaultExecutionOrder(-100)]
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput instance { get; set; }//Singleton pattern
        public float horizontalInput { get; private set; }
        public float verticalInput { get; private set; }
        public float mouseX { get; private set; }
        public float mouseY { get; private set; }

        public bool sprintHeld { get; private set; }
        public bool jumpPressed { get; private set; }
        public bool activatePressed { get; private set; }
        public bool primaryShootPressed { get; private set; }
        public bool secondaryShootPressed { get; private set; }
        public bool alpha1Pressed { get; private set; }
        public bool alpha2Pressed { get; private set; }
        public bool commandPressed { get; private set; }

        public bool pausePressed { get; private set; }



        [Header("References")]
        [SerializeField] InputActionReference moveAction;
        [SerializeField] InputActionReference lookAction;
        [SerializeField] InputActionReference sprintAction;
        [SerializeField] InputActionReference jumpAction;
        [SerializeField] InputActionReference activateAction;
        [SerializeField] InputActionReference primaryShootAction;

        [SerializeField] InputActionReference secondaryShootAction;

        //Strategy Pattern--changing guns
        [SerializeField] InputActionReference alpha1Action;
        [SerializeField] InputActionReference alpha2Action;

        //Command Pattern
        [SerializeField] InputActionReference commandAction;
        [SerializeField] InputActionReference pauseAction;

        private bool clear;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != null)
            {
                Destroy(gameObject);
            }

        }

        /// <summary>
        /// When player presses button on the keyboard/controller/etc. the game is listening for that input
        /// </summary>
        private void OnEnable()
        {
            moveAction.action.Enable();
            lookAction.action.Enable();

            sprintAction.action.Enable();
            jumpAction.action.Enable();
            activateAction.action.Enable();

            primaryShootAction.action.Enable();
            secondaryShootAction.action.Enable();

            //enable shoot strategy
            alpha1Action.action.Enable();
            alpha2Action.action.Enable();

            //command strategy
            commandAction.action.Enable();

            //pause game
            pauseAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            lookAction.action.Disable();

            sprintAction.action.Disable();
            jumpAction.action.Disable();
            activateAction.action.Disable();

            primaryShootAction.action.Disable();
            secondaryShootAction.action.Disable();

            //disable shoot strategy
            alpha1Action.action.Disable();
            alpha2Action.action.Disable();

            //command strategy
            commandAction.action.Disable();

            //Pause game
            pauseAction.action.Disable();
        }

        private void Update()
        {
            ClearInputs();
            ProcessInputs();

        }

        //clearing inputs at the end of the frame
        private void LateUpdate()
        {
            clear = true;
        }

        private void ProcessInputs()
        {
            //pause game
            pausePressed |= pauseAction.action.WasPressedThisFrame();

            if (GameManager.instance.currentGameState != GameManager.GameState.GamePlaying)
                return;

            Vector2 move = moveAction.action.ReadValue<Vector2>();
            Vector2 look = lookAction.action.ReadValue<Vector2>();

            horizontalInput = move.x;
            verticalInput = move.y;

            mouseX = look.x;
            mouseY = look.y;

            sprintHeld = sprintAction.action.IsPressed();
            jumpPressed |= jumpAction.action.WasPressedThisFrame(); // | is "Or" operator
            activatePressed |= activateAction.action.WasPressedThisFrame();

            primaryShootPressed |= primaryShootAction.action.WasPressedThisFrame();
            secondaryShootPressed |= secondaryShootAction.action.WasPressedThisFrame();

            //Strategy pattern. Checks if Alpha1 or Alpha2 were pressed
            alpha1Pressed |= alpha1Action.action.WasPressedThisFrame();
            alpha2Pressed |= alpha2Action.action.WasPressedThisFrame();

            //Command Pattern
            commandPressed |= commandAction.action.WasPressedThisFrame();
            

        }


        private void ClearInputs()
        {
            if (!clear)
            {
                return;
            }
            horizontalInput = 0;
            verticalInput = 0;
            mouseX = 0;
            mouseY = 0;

            sprintHeld = false;
            jumpPressed = false;
            activatePressed = false;

            primaryShootPressed = false;
            secondaryShootPressed = false;

            //strategy pattern
            alpha1Pressed = false;
            alpha2Pressed = false;

            //command pattern
            commandPressed = false;
            //pause game
            pausePressed = false;

            clear = false;
        }


    }
}
