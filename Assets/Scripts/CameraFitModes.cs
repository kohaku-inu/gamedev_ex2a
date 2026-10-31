using UnityEngine;

// Each mode as a single variable constant, ONLY ONE shouldn't be a comment!
[RequireComponent(typeof(Camera))]
public class CameraFitModes : MonoBehaviour
{
    //[SerializeField, Tooltip("Option 1: world units visible from bottom to top")]
    //private float _visibleHeight = 10f;

    //[SerializeField, Tooltip("Option 2: world units visible from left to right")]
    //private float _visibleWidth = 16f;

    [SerializeField, Tooltip("Option 3: visible width x visible height, in square units")]
    private float _visibleArea = 144f;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // OPTION 1: fixed height (what Unity does by default).
        // Objects get bigger in portrait. The visible width changes.
        //_camera.orthographicSize = _visibleHeight / 2f;

        // OPTION 2: fixed width.
        // Objects get smaller in portrait. The visible height changes.
        //_camera.orthographicSize = _visibleWidth / (2f * _camera.aspect);

        // OPTION 3: fixed area (width x height).
        // Objects keep the same pixel size when you rotate. The visible shape changes.
        _camera.orthographicSize = 0.5f * Mathf.Sqrt(_visibleArea / _camera.aspect);
    }
}