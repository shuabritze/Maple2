using System;
using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record DungeonConfigTable(IReadOnlyList<DungeonConfigTable.Entry> Entries) : Table {

    public record Entry(
        IList<MissionRank> Ranks
    );

    public record MissionRank(
        int Id,
        string Desc,
        int MaxScore,
        List<MissionRankGroupEntry> Entries
    );

    public record MissionRankGroupEntry(
        int Score
    );
}

public record ReverseRaidConfigTable(IReadOnlyList<ReverseRaidConfigTable.Entry> Entries) : Table {

    public record Entry(
        DateTime StartDate,
        int PeriodDays,
        IList<ReverseRaidConfigDungeonEntry> Dungeons
    );

    public record ReverseRaidConfigDungeonEntry(
        int DungeonId
    );
}

public record UnitedWeeklyRewardTable(IReadOnlyList<UnitedWeeklyRewardTable.Entry> Entries) : Table {

    public record Entry(
        int RewardCount,
        int RewardId
    );
}
