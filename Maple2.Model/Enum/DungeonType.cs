namespace Maple2.Model.Enum;

public enum DungeonPlayType : byte {
    none = 0,
    limitReward = 1,
    limitEnter = 2,
}

public enum DungeonGroupType : byte {
    none = 0,
    normal = 1,
    raid = 2,
    chaosRaid = 3,
    reverseRaid = 4,
    lapenta = 5,
    guildRaid = 6,
    darkStream = 7,
    worldBossDungeon = 8,
    item = 9,
    vip = 10,
    @event = 11,
    fameChallenge = 12,
    colosseum = 13,
    turka = 14,
}

public enum DungeonCooldownType : byte {
    none = 0,
    dayOfWeeks = 1,
    nextDay = 2,
}

public enum DungeonTimerType : byte {
    none = 0,
    clock = 1,
    gauge = 2,
}

public enum DungeonBossRankingType : byte {
    None = 0,
    Kill = 1,
    Damage = 2,
    KillRumble = 3,
    MultiKill = 4,
    Colosseum = 5,
}

public enum DungeonRequireRole : byte {
    None = 0,
    Support = 1,
    Tank = 2,
}
