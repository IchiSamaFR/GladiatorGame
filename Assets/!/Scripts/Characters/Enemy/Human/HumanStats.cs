using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Character.Enemy.Human
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
