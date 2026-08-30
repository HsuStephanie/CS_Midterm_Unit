using UnityEngine;

namespace MidtermTuringTest
{
    public class PlayerTurnBehavior : MonoBehaviour
    {
        [SerializeField] PlayerInput _input;

        [Header("Player Turn")]
        [SerializeField] float _turnSpeed;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {
           RotatePlayer();
        }
        void RotatePlayer ()
        {
            transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * _input.mouseX);
        }
    }
}
