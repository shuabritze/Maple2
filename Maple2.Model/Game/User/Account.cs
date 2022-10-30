﻿using System;

namespace Maple2.Model.Game;

public class Account {
    #region Immutable
    public DateTime LastModified { get; init; }
    public long Id { get; init; }

    public string Username { get; init; }
    public Guid MachineId { get; set; }
    #endregion

    public int MaxCharacters { get; set; }
    public int PrestigeLevel { get; set; }
    public long PrestigeExp { get; set; }
    public Trophy Trophy { get; set; }
    public long PremiumTime { get; set; }
    public int MesoMarketListed { get; set; }
    public int MesoMarketPurchased { get; set; }
}
