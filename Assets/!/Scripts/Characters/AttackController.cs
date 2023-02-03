using Gladiator.Character.Enemy;
using UnityEngine;
using Gladiator.Tools;

namespace Gladiator.Character
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class AttackController : MonoBehaviour
    {
        private CircleCollider2D circleCollider;

        public CircleCollider2D CircleCollider
        {
            get
            {
                if (!circleCollider)
                {
                    circleCollider = GetComponent<CircleCollider2D>();
                }
                return circleCollider;
            }
        }

        void Update()
        {
            GetEnemiesInRange();
        }

        public void GetEnemiesInRange()
        {
            float forward = transform.rotation.eulerAngles.z;
            forward = (forward < 0) ? forward + 360 : forward;
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, CircleCollider.radius);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.gameObject.GetComponent<Enemy.Enemy>())
                {
                    float enemyAngle = Geometry.AngleBetweenVector2(transform.position, enemy.transform.position);
                    enemyAngle = (enemyAngle < 0) ? enemyAngle + 360 : enemyAngle;
                    print(enemyAngle);
                }
            }

        }
    }
}
