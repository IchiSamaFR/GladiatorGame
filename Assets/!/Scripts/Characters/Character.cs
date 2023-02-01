using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gladiator.Character
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Transform model;
        private CharacterMovement characterMovement;

        public Transform Model
        {
            get
            {
                if (!model)
                {
                    Debug.LogError("Model is not instantiate.");
                }
                return model;
            }
        }
        public CharacterMovement CharacterMovement
        {
            get
            {
                if (!characterMovement)
                {
                    characterMovement = GetComponent<CharacterMovement>();
                }
                return characterMovement;
            }
        }
    }
}
