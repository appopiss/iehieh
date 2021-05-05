using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;

public class LegendaryEffect : BASE {

    public static double StatsBonus()
    {
        long HSnum = main.S.RP;
        if (HSnum == 0)
            return 1.0;

        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (0.2 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].level * 0.05);
            case ALLY.Job.Wizard:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWizard].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (0.2 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWizard].level * 0.05);
            case ALLY.Job.Angel:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendAngel].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (0.2 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendAngel].level * 0.05);
            default:
                return 1.0;
        }
    }

    public static double SkillEfficiencyBonus()
    {
        long HSnum = main.S.RP;
        if (HSnum == 0)
            return 1.0;

        switch (main.ally.job)
        {
            case ALLY.Job.Warrior:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (1.0 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].level);
            case ALLY.Job.Wizard:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWizard].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (1.0 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].level);
            case ALLY.Job.Angel:
                if (!main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendAngel].isEquipped) { return 1.0; }
                return 1.0 + HSnum * (1.0 + main.NewArtifacts[(int)ARTIFACT.ArtifactName.LegendWarrior].level);
            default:
                return 1.0;
        }
    }
}
