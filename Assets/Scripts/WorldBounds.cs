using UnityEngine;

namespace Assets.Scripts
{
    public static class WorldBounds
    {
        public static Vector3 min;
        public static Vector3 max;

        public static void Initialize(Bounds bounds)
        {
            min = bounds.min;
            max = bounds.max;
        }

        public static bool HasLeftGameWorld(GameObject target)
        {
            return target.transform.position.x < min.x 
                || target.transform.position.x > WorldBounds.max.x 
                || target.transform.position.z < WorldBounds.min.z 
                || target.transform.position.z > WorldBounds.max.z;
        }
    }
}
