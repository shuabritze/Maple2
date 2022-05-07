﻿using Maple2.Database.Storage;
using Maple2.Model.Metadata;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Core.PacketHandlers;
using Maple2.Server.Core.Packets;
using Maple2.Server.Game.Packets;
using Maple2.Server.Game.Session;
using Microsoft.Extensions.Logging;
using static Maple2.Model.Error.MigrationError;

namespace Maple2.Server.Game.PacketHandlers;

public class TaxiHandler : PacketHandler<GameSession> {
    public override ushort OpCode => RecvOp.REQUEST_TAXI;

    private enum Command : byte {
        Taxi = 1,
        RotorsAir = 2,
        MesoAir = 3,
        MeretAir = 4,
        Discover = 5,
    }

    #region Autofac Autowired
    // ReSharper disable MemberCanBePrivate.Global
    public MapMetadataStorage MapMetadata { get; init; } = null!;
    public MapEntityStorage EntityMetadata { get; init; } = null!;
    // ReSharper restore All
    #endregion

    public TaxiHandler(ILogger<TaxiHandler> logger) : base(logger) { }

    public override void Handle(GameSession session, IByteReader packet) {
        var command = packet.Read<Command>();

        switch (command) {
            case Command.Taxi:
                HandleTaxi(session, packet);
                return;
            case Command.RotorsAir:
                HandleRotorsAirTaxi(session, packet);
                return;
            case Command.MesoAir:
                HandleMesoAirTaxi(session, packet);
                return;
            case Command.MeretAir:
                HandleMeretAirTaxi(session, packet);
                return;
            case Command.Discover:
                HandleDiscoverTaxi(session);
                return;
        }
    }

    private void HandleTaxi(GameSession session, IByteReader packet) {
        int mapId = packet.ReadInt();
        if (!session.Player.Value.Unlock.Taxis.Contains(mapId)) {
            return;
        }
        if (!MapMetadata.TryGet(mapId, out MapMetadata? map)) {
            return;
        }
        MapEntityMetadata? entities = EntityMetadata.Get(map.XBlock);
        if (entities?.Taxi == null) {
            return;
        }

        session.Send(session.PrepareField(mapId, position: entities.Taxi.Position, rotation: entities.Taxi.Rotation)
            ? FieldEnterPacket.Request(session.Player)
            : FieldEnterPacket.Error(s_move_err_default));
    }

    private static void HandleRotorsAirTaxi(GameSession session, IByteReader packet) {
        int mapId = packet.ReadInt();
        session.Send(session.PrepareField(mapId)
            ? FieldEnterPacket.Request(session.Player)
            : FieldEnterPacket.Error(s_move_err_default));
    }

    private static void HandleMesoAirTaxi(GameSession session, IByteReader packet) {
        int mapId = packet.ReadInt();
        session.Send(session.PrepareField(mapId)
            ? FieldEnterPacket.Request(session.Player)
            : FieldEnterPacket.Error(s_move_err_default));
    }

    private static void HandleMeretAirTaxi(GameSession session, IByteReader packet) {
        int mapId = packet.ReadInt();
        session.Send(session.PrepareField(mapId)
            ? FieldEnterPacket.Request(session.Player)
            : FieldEnterPacket.Error(s_move_err_default));
    }

    private static void HandleDiscoverTaxi(GameSession session) {
        int mapId = session.Player.Value.Character.MapId;
        session.Player.Value.Unlock.Taxis.Add(mapId);

        session.Send(RevealTaxi(mapId));
    }

    private static ByteWriter RevealTaxi(params int[] taxis) {
        var pWriter = Packet.Of(SendOp.TAXI);
        pWriter.WriteInt(taxis.Length);
        foreach (int taxi in taxis) {
            pWriter.WriteInt(taxi);
        }
        pWriter.WriteBool(true); // s_reveal_taxi_station

        return pWriter;
    }
}
