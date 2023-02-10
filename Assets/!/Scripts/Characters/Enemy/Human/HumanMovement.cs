namespace Gladiator.Character.Enemy
{
    public class HumanMovement : EnemyMovement
    {
        
        private Human human;

        public Human Human
        {
            get
            {
                if (!human)
                {
                    human = GetComponent<Human>();
                }
                return human;
            }
        }
        
        public void Start()
        {
            Human.AttackController.OnCharacterEnter += DetectPlayer;
        }

        public void DetectPlayer(CharacterStats player)
        {
            if (player.gameObject.CompareTag("Player"))
            {
                Human.AttackController.AttackEnemies("Player");
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void Movement()
        {
            //coucou je me déplace
        }
    }
}
