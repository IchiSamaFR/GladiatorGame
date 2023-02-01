using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Character
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        public void MoveDirection(Vector3 direction, float speed)
        {
            transform.position += direction * speed * Time.fixedDeltaTime;
        }
    }
}
