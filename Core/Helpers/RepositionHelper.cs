using UnityEngine;

namespace Assets._Scripts.Core.Base.Helpers
{
    public class RepositionHelper : MonoBehaviour
    {
        public void TeleportTo(Transform newPosition)
        {
            this.transform.position = newPosition.position;
        }
    }
}
