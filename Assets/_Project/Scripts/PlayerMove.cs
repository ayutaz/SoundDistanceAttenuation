using UnityEngine;

namespace _Project
{
    public class PlayerMove : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.Enable();
        }

        private void Update()
        {
            var move = _game.Map.Move.ReadValue<Vector2>();
            transform.Translate(move * (Time.deltaTime * 2f));
        }
    }
}