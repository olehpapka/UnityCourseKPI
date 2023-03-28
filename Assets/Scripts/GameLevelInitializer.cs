using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInitializer : MonoBehaviour
{
    [SerializeField] private PlayerEntity _platerEntity;
    [SerializeField] private GameUIInputView _gameUIInputView;

    private ExternalDevicesInputReader _externalDevicesInput;
    private PlayerBrain _playerBrain;

    private void Awake()
    {
        _externalDevicesInput= new ExternalDevicesInputReader();
        _playerBrain = new PlayerBrain(_platerEntity, new List<IEntityInputSource> 
        {
            _gameUIInputView,
            _externalDevicesInput
        });
    }

    private void Update()
    {
        _externalDevicesInput.OnUpdate();
    }

    private void FixedUpdate()
    {
        _playerBrain.OnFixedUpdate();
    }


}
