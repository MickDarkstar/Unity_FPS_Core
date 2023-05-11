using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Scripts.Core.Camera
{
    public class CameraShake : MonoBehaviour
        //: Singleton<CameraShake>
    {
        public Transform mainCamera = default;
        private Vector3 _startingPosition = default;
        public float shakeFrequency = default;

        void Start()
        {
            _startingPosition = mainCamera.position;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.H))
            {
                Shake();
            }
            else if (Input.GetKeyUp(KeyCode.H))
            {
                StopShake();
            } 
            else
            {
                _startingPosition = mainCamera.position;
            }
        }

        private void StopShake()
        {
            //mainCamera.position = _startingPosition;
        }

        private void Shake()
        {
            mainCamera.position = _startingPosition + Random.insideUnitSphere * shakeFrequency;
        }
    }
}