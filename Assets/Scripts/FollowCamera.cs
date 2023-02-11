using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _verticalOffset;
    [SerializeField]
    private float _horizontalOffset;
    [SerializeField]
    private float _barrierOffset;
    #region references
    /// <summary>
    /// Reference to target's transform
    /// </summary>
    [SerializeField] private Transform _targetTransform;
    /// <summary>
    /// Reference to target's transform
    /// </summary>
    [SerializeField] private Transform _cameraTransform;
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;

    [SerializeField] private GameObject _screenBarrier;
    private Transform _barrierTransform;
    #endregion
    /// <summary>
    /// Initialiation of desired position and lookat point
    /// </summary>
    void Start()
    {
        Screen.SetResolution(1024, 768, true);
        _barrierTransform = _screenBarrier.transform;
        _myTransform = transform;
    }
    /// <summary>
    /// Updates camera position
    /// </summary>
    void LateUpdate()
    {
        if (_cameraTransform.position.x < _targetTransform.position.x + 0.001 )
        {
            Vector3 _desiredPosition = _targetTransform.position + new Vector3(_horizontalOffset, 0, -_distance);
            _desiredPosition.y = _verticalOffset;
            _myTransform.position = _desiredPosition;
            _barrierTransform.position = new Vector2(_desiredPosition.x + _barrierOffset, _desiredPosition.y);
        }
        

    }

    public void ResetCamera()
    {
        _myTransform.position = new Vector3(3.86999989f, 2.54999995f, -10f);
        _barrierTransform.position = new Vector2(-4.84f, 2.28f);
    }
}
