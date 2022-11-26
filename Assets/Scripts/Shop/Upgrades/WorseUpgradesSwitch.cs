using System;
using System.Collections.Generic;
using System.Linq;

public sealed class WorseUpgradesSwitch : IWorseUpgradesSwitch
{
    private readonly IEnumerable<IUpgradeView> _upgradeViews;

    public WorseUpgradesSwitch(IEnumerable<IUpgradeView> upgradeViews)
    {
        _upgradeViews = upgradeViews ?? throw new ArgumentNullException(nameof(upgradeViews));
    }

    public void Off()
    {
        _upgradeViews.ToList().ForEach(view => view.Use());
    }
}