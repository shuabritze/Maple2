using IronPython.Runtime;
using Maple2.Model.Error;
using Maple2.Model.Metadata;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Core.PacketHandlers;
using Maple2.Server.Game.Packets;
using Maple2.Server.Game.Session;

namespace Maple2.Server.Game.PacketHandlers;

public class DungeonRoomHandler : PacketHandler<GameSession> {
    public override RecvOp OpCode => RecvOp.RoomDungeon;

    private enum Command : byte {
        Reset = 1,
        Enter = 2,
        Unknown1 = 3,
        Unknown2 = 4,
        Unknown3 = 8,
        Unknown4 = 9,
        GotoField = 10,
        Unknown6 = 13,
        Unknown7 = 14,
        Unknown8 = 15,
        FindHelp = 16,
        Unknown10 = 17,
        Unknown11 = 18,
        Unknown12 = 22,
        Unknown13 = 25,
    }

    public override void Handle(GameSession session, IByteReader packet) {
        var command = packet.Read<Command>();
        switch (command) {
            case Command.Reset:
                HandleReset(session);
                return;
            case Command.Enter:
                HandleEnter(session, packet);
                return;
            case Command.GotoField:
                HandleGotoField(session);
                return;
        }
    }

    private void HandleReset(GameSession session) {
        // TODO: Reset dungeon room
        Logger.Debug("Resetting dungeon room");
    }

    // Enters dungeon from UI select list
    private void HandleEnter(GameSession session, IByteReader packet) {
        int dungeonRoomId = packet.ReadInt();
        bool withParty = packet.ReadBool();
        int unk1 = packet.ReadInt();
        byte unk2 = packet.ReadByte();

        Logger.Debug("Entering dungeon room {DungeonRoomId} {WithParty} {Unk1} {Unk2}", dungeonRoomId, withParty, unk1, unk2);

        // TryGet dungeon manager instance
        // Create dungeon room instance if it doesn't exist
        // Send dungeon room data
        if (!session.TableMetadata.DungeonRoomTable.Entries.TryGetValue(dungeonRoomId, out DungeonRoomTable.Entry? entry)) {
            // dungeon not found
            return;
        }

        // Get lobby field
        session.Send(session.PrepareField(entry.LobbyFieldId)
            ? FieldEnterPacket.Request(session.Player)
    :         FieldEnterPacket.Error(MigrationError.s_move_err_default));

        session.Field.UserValues["dungeonRoomId"] = dungeonRoomId;
        session.Field.UserValues["dungeonFieldId"] = entry.FieldIds[0];
    }

    private void HandleGotoField(GameSession session) {
        // Get the sessions current dungeonmanager instance
        int dungeonFieldId = session.Field.UserValues["dungeonFieldId"];

        session.Send(session.PrepareField(dungeonFieldId)
            ? FieldEnterPacket.Request(session.Player)
:           FieldEnterPacket.Error(MigrationError.s_move_err_default));
    }
}
