using UnityEngine;

namespace _Project
{
    public class PlayerMove : MonoBehaviour
    {
        private GameInput _game;

        private void Awake()
        {
            _game = new GameInput();
            _game.Enable();
        }

        private void Update()
        {
            var move = _game.Map.Move.ReadValue<Vector2>();
            transform.Translate(move * (Time.deltaTime * 2f));
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}