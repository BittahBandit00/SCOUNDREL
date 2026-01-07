using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OptionalRules
{
    public bool ShowCardRemaining { get; set; }
    public bool DoubleSkip { get; set; }
    public bool ExtraHealth { get; set; }


    public void ResetToDefaults()
    {
        DoubleSkip = false;
        ShowCardRemaining = false;
        ExtraHealth = false;
    }
}
