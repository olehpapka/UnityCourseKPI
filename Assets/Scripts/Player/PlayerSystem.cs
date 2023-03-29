using System;
using System.Collections.Generic;
public class PlayerSystem
{
    private readonly PlayerEntity _playerEntity;
    private readonly PlayerBrain _playerBrain;

    public PlayerSystem(PlayerEntity playerEntity, List<IEntityInputSource> inputSource)
    {
        _playerEntity = playerEntity;
        _playerBrain = new PlayerBrain(_playerEntity, inputSource);
    }
}
