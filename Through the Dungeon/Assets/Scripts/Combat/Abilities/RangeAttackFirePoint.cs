using UnityEngine;

namespace Combat.Abilities
{
    public class RangeAttackFirePoint : MonoBehaviour
    {
        private void Update()
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
        }
    }
}