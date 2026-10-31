using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Unit per seconds")] private float _moveSpeed = 5f;

    private InputAction _moveAction;
    // Start when you wait to other object to awake,Awake it's important to configure before the object really start
    private void Awake()
    {
        _moveAction = new InputAction("Move", InputActionType.Value);
        // Binding to composite normalizes a diagonal step, and bind multiple control to one value
        // In this setting, opposite not canceling each other
        _moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        _moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");

        // In this setting every opposite direction cancel each other when pressed at the same time, not adding if in the same direction
        //_moveAction.AddCompositeBinding("2DVector")
        //    .With("Up", "<Keyboard>/w")
        //    .With("Down", "<Keyboard>/s")
        //    .With("Left", "<Keyboard>/a")
        //    .With("Right", "<Keyboard>/d")
        //    .With("Up", "<Keyboard>/upArrow")
        //    .With("Down", "<Keyboard>/downArrow")
        //    .With("Left", "<Keyboard>/leftArrow")
        //    .With("Right", "<Keyboard>/rightArrow");
    }

    private void OnEnable()
    {
        _moveAction.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
    }
    private void OnDestroy()
    {
        _moveAction.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        //Debug.Log(input);
        /*
            V3 cast not required, transform.position is always V3 (because unity's world is 3d).
            in 2D transform position will take only x,y

            error if "transform.position = Vector2.Movetowards() ---> z becomes 0, so if the vector in other z it will move to z=0;
         */
        transform.position += (Vector3)(_moveSpeed * Time.deltaTime * input);
    }
}
