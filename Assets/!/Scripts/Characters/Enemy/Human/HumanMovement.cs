namespace Gladiator.Character.Enemy.Human
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
