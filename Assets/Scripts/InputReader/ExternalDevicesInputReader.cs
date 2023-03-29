using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
{
    public float Direction => Input.GetAxisRaw("Horizontal");
    public bool Jump { get; private set; }

    public ExternalDevicesInputReader()
    {
        ProjectUpdater.Instance.UpdateCalled += OnUpdate;
    }

    public void ResetOneTimeActions()
    {
        Jump = false;
    }

    public void Dispose()
    {
        ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
    }

    private void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            Jump = true;
    }

    
    
}
