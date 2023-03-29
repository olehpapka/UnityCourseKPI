using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInitializer : MonoBehaviour
{
    [SerializeField] private PlayerEntity _platerEntity;
    [SerializeField] private GameUIInputView _gameUIInputView;

    private ExternalDevicesInputReader _externalDevicesInput;
    private PlayerSystem _playerSystem;
    private ProjectUpdater _projectUpdater;

    private List<IDisposable> _disposables;


    private void Awake()
    {
        _disposables = new List<IDisposable>();

        if (ProjectUpdater.Instance == null)
            _projectUpdater = new GameObject().AddComponent<ProjectUpdater>();
        else
            _projectUpdater = ProjectUpdater.Instance as ProjectUpdater;

        _externalDevicesInput = new ExternalDevicesInputReader();
        
        _disposables.Add(_externalDevicesInput);
        _disposables.Add(_platerEntity);
        _playerSystem = new PlayerSystem(_platerEntity, new List<IEntityInputSource>
        {
            _gameUIInputView,
            _externalDevicesInput
        });
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _projectUpdater.IsPaused = !_projectUpdater.IsPaused;
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
        ProjectUpdater.Instance = null;
    }




}
