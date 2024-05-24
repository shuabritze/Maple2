using System;
using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record DungeonRoundGroupTable(IReadOnlyDictionary<int, DungeonRoundGroupTable.Entry> Entries) : Table {

    public record Entry(
        int Id,
        IList<DungeonRoundGroup> Groups
    );

    public record DungeonRoundGroup(
        int RewardId,
        int GearScore
    );
}
