using System;
using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record DungeonRankRewardTable(IReadOnlyDictionary<int, DungeonRankRewardTable.Entry> Entries) : Table {

    public record Entry(
        int Id,
        IList<DungeonRankReward> Rewards
    );

    public record DungeonRankReward(
        int Rank,
        int ItemId,
        int SystemMailId
    );
}
