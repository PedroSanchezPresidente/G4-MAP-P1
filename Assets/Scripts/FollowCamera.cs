using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private MovementComponent _movementComponent;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _verticalOffset;
    [SerializeField]
    private float _horizontalOffset;
    
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
    #endregion
    /// <summary>
    /// Initialiation of desired position and lookat point
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _movementComponent = FindObjectOfType<MovementComponent>();
        
    }
    /// <summary>
    /// Updates camera position
    /// </summary>
    void LateUpdate()
    {
        if (_movementComponent.MoveCamera && _cameraTransform.position.x < _targetTransform.position.x + 0.001 )
        {
            Vector3 _desiredPosition = _targetTransform.position + new Vector3(_horizontalOffset, 0, -_distance);
            _desiredPosition.y = _verticalOffset;
            _myTransform.position = _desiredPosition;
        }
        

    }
}
