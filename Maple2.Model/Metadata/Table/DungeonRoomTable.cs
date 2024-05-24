﻿using System;
using System.Collections.Generic;
using Maple2.Model.Enum;

namespace Maple2.Model.Metadata;

public record DungeonRoomTable(IReadOnlyDictionary<int, DungeonRoomTable.Entry> Entries) : Table {

    public record Entry(
        int Id,
        short DungeonLevel,
        DungeonPlayType PlayType,
        DungeonGroupType GroupType,
        int ClearValue,
        DungeonCooldownType CooldownType,
        int CooldownValue,
        int SortOrder,
        int RewardCount,
        int SubRewardCount,
        bool IsAccountReward,
        int UnionRewardId,
        int RoundId,
        long RewardExp,
        float RewardExpRate,
        long RewardMeso,
        int ScoreBonusId,
        int[] RewardLimitedDropBoxIds,
        int[] RewardUnlimitedDropBoxIds,
        int SeasonRankRewardId,
        int LobbyFieldId,
        int[] FieldIds,
        int DurationTick,
        bool IsExpireTimeOut,
        DungeonTimerType TimerType,
        int MinUserCount,
        int MaxUserCount,
        int GearScore,
        int LimitAchieveId,
        short LimitPlayerLevel,
        bool LimitVip,
        MapleDayOfWeek[] LimitDayOfWeeks,
        bool LimitMesoRevival,
        bool LimitMeratRevival,
        int[] LimitClearDungeon,
        int[] LimitAdditionalEffects,
        bool LimitRecommendWeapon,
        string DungeonBanner,
        string BossIcon,
        bool IsUseBossIcon,
        DungeonBossRankingType BossRankingType,
        string OpenPeriodTag,
        bool IsPartyOnly,
        bool IsChangeMaxUser,
        int PlayerCountFactorID,
        short CustomMonsterLevel,
        bool ChaosDamageMeter,
        bool IsMoveOutToBackupField,
        int DefaultRevivalLimitCount,
        int DungeonHelperRequireClearCount,
        bool IsUseRandomMatch,
        bool IsLeaveAfterCloseReward,
        int[] PartyMissions,
        int[] UserMissions,
        int RankTableID,
        int RepresentID,
        string ClearType,
        int BossRanking,
        DateTime OpenPeriodDate,
        bool IsDisableFindHelper,
        int ExtraRewardTicketBaseCount,
        int ExtraRewardTicketTableID,
        bool IsLimitTime,
        bool IsTimeUp,
        bool IsRandomField,
        bool DungeonHelperManualChange,
        bool IsUseFindMember,
        int[] FindHelperRewardDropBoxIds,
        int[] FindHelperExtraRewardDropBoxIds,
        bool IsDisableRandomMatch,
        DungeonRequireRole RequireRole
    );
}
