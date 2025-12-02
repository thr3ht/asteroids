using UnityEngine;

namespace _Project.Scripts.Core
{
    public sealed class WorldBounds
    {
        private const float WRAP_OFFSET = 1f;
        
        private readonly Camera _camera;

        private Vector2 _min;
        private Vector2 _max;

        public Vector2 Min => _min;
        public Vector2 Max => _max;

        public WorldBounds()
        {
            _camera = Camera.main;
            CalculateBounds();
        }

        private void CalculateBounds()
        {
            float distance = Mathf.Abs(_camera.transform.position.z);

            Vector3 bottomLeft = _camera.ScreenToWorldPoint(new Vector3(0, 0, distance));
            Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));

            _min = new Vector2(bottomLeft.x, bottomLeft.y);
            _max = new Vector2(topRight.x, topRight.y);
        }

        public Vector2 GetWrappedPosition(Vector2 position)
        {
            Vector2 wrappedPosition = position;

            if (position.x > _max.x + WRAP_OFFSET)
            {
                wrappedPosition.x = _min.x - WRAP_OFFSET;
            }
            else if (position.x < _min.x - WRAP_OFFSET)
            {
                wrappedPosition.x = _max.x + WRAP_OFFSET;
            }

            if (position.y > _max.y + WRAP_OFFSET)
            {
                wrappedPosition.y = _min.y - WRAP_OFFSET;
            }
            else if (position.y < _min.y - WRAP_OFFSET)
            {
                wrappedPosition.y = _max.y + WRAP_OFFSET;
            }

            return wrappedPosition;
        }

        public bool IsOutOfBounds(Vector2 position)
        {
            return position.x > _max.x || position.x < _min.x || position.y > _max.y || position.y < _min.y;
        }
    }
}