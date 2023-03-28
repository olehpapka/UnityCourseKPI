using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBrain
{
    private readonly PlayerEntity _playerEntity;
    private readonly List<IEntityInputSource> _inputSources;
    public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
    {
        _playerEntity = playerEntity;
        _inputSources = inputSources;
    }

    public void OnFixedUpdate()
    {
        _playerEntity.MoveHorizontally(GetHorizontalDirection());
        if (IsJumping)
            _playerEntity.Jump();

        foreach (var inputSources in _inputSources)
            inputSources.ResetOneTimeActions();

        
    }

    private float GetHorizontalDirection()
    {
        foreach (var inputSource in _inputSources)
        {
            if (inputSource.Direction == 0)
                continue;
            return inputSource.Direction;
        }
        return 0;
    }

    private bool IsJumping => _inputSources.Any(source => source.Jump);
}
