using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Health
{
    private int HP = 20;

    public int GetHealth()
    {
        int HealthPoints = HP;
        return HealthPoints;
    }

    public void Heal(int x)
    {
        HP = HP+x;
        
        if(HP > 20)
        {
            HP = 20; 
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