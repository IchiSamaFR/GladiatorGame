namespace Gladiator.Character.Enemy
{
    public class HumanStats : EnemyStats
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

        private void Start()
        {
            OnDeath.AddListener(() => Destroy(gameObject));
        }
    }
}
