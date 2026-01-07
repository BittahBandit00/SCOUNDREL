using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Health
{
    private int HP = 20;
    private int MaxHealth = 0;

    public void SetMaxHealth(bool ExtraHealthRule)
    {
        MaxHealth = ExtraHealthRule ? 25 : 20;
        HP = MaxHealth;
    }

    public int GetHealth()
    {
        int HealthPoints = HP;
        return HealthPoints;
    }

    public void Heal(int x)
    {
        HP = HP+x;
        
        if(HP > MaxHealth)
        {
            HP = MaxHealth; 
        }
    }

    public void Damage(int x)
    {
        HP = HP - x;

        if (HP < 0)
        {
            HP = 0;
        }
    }
}