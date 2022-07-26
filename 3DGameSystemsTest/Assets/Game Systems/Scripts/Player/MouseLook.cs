using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Systems/Player/Mouse Look")]

public class MouseLook : MonoBehaviour
{
    #region RotationalAxis
    public enum RotationalAxis
    {
        MouseX, MouseY
    }

    #endregion
    #region Variables
    [Header("Rotation")]
    public RotationalAxis axis = RotationalAxis.MouseX;

    [Header("Sensitivity")]
    public Vector2 sensitivity = new Vector2(10,10);
    [Range(-100, 100)]
    
    public float minY = -60f, maxY = 60f;
    public bool invert;

    float _rotY;

    #endregion
    #region Start
    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (GetComponent<Camera>())
        {
            axis = RotationalAxis.MouseY;
        }
    }
    #endregion
    #region Update
    private void Update()
    {
        //if in game state, mouse look is normal
        if (GameManager.GameManagerInstance.gameState == GameStates.GameState)
        {
            #region Mouse X
            if (axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity.x, 0);
            }

            #endregion
            #region Mouse Y
            else
            {
                _rotY += Input.GetAxis("Mouse Y") * sensitivity.y;
                _rotY = Mathf.Clamp(_rotY, minY, maxY);

                if (!invert)
                {
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(_rotY, 0, 0);
                }
            }
            #endregion
        }
    }
    #endregion
}
