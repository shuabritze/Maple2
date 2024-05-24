using System;
using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record DungeonMissionTable(IReadOnlyDictionary<int, DungeonMissionTable.Entry> Entries) : Table {

    public record Entry(
        int Id,
        string Type,
        float[] Value1,
        int Value2,
        int MaxScore,
        int ApplyCount,
        bool IsPenaltyType
    );
}
