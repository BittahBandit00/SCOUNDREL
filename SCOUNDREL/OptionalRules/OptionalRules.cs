using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OptionalRules
{

    // make things easier
    public bool ShowEncountersLeft { get; set; }
    public bool DoubleSkip { get; set; }
    public bool ExtraHealth { get; set; }
    public bool AlteredWeaponCanMatch { get; set; }
    public bool LowAces { get; set; }
    public bool InfiniteHeals { get; set; }

    // lucky 7's -> all 7's heal +1

    // CHALLENGE MODE

    // no heals
    // strongest weapon is 5
    // Death Timer: 1 Minute
    // Double Encounters
    // Jokers shuffle encounters into deck and reset the deck

    public void ResetToDefaults()
    {
        ShowEncountersLeft = false;
        DoubleSkip = false;
        ExtraHealth = false;
        AlteredWeaponCanMatch = false;
        LowAces = false;
        InfiniteHeals = false;
    }
}

