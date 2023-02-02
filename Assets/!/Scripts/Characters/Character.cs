using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gladiator.Character
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Transform model;
        private CharacterMovement characterMovement;
        private CharacterController characterController;
        private CharacterStats characterStats;

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

        public CharacterController CharacterController
        {
            get
            {
                if (!characterController)
                {
                    characterController = GetComponent<CharacterController>();
                }
                return characterController;
            }
        }

        public CharacterStats CharacterStats
        {
            get
            {
                if (!characterStats)
                {
                    characterStats = GetComponent<CharacterStats>();
                }
                return characterStats;
            }
        }

        public void Init()
        {
            characterMovement = GetComponent<CharacterMovement>();
            characterController = GetComponent<CharacterController>();
            characterStats = GetComponent<CharacterStats>();
        }
    }
}
