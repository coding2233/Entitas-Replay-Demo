//-----------------------------------------------------------------------
// <copyright file="GameControlle.cs" company="Codingworks Game Development">
//     Copyright (c) codingworks. All rights reserved.
// </copyright>
// <author> codingworks </author>
// <time> #CREATETIME# </time>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start () {
        var contexts = Contexts.sharedInstance;
       
        _systems = CreateSystems(contexts);
        var logicSystems = CreateLogicSystems(contexts);
        _systems.Add(logicSystems);

        contexts.game.SetLogicSystem(logicSystems);

        _systems.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }

    Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Root System")
            .Add(new NotifyTickListenersSystem(contexts))
            .Add(new NotifyElixirListenersSystem(contexts))
            .Add(new NotifyPauseListenersSystem(contexts))
            .Add(new ReplaySystem(contexts))
            .Add(new CleanupConsumtionHistorySystem(contexts))
            ;
    }

    Systems CreateLogicSystems(Contexts contexts)
    {
        return new Feature("Logic System")
            .Add(new TickUpdateSystem(contexts))
            .Add(new ProduceElixirSystem(contexts))
            .Add(new ConsumeElixirSystem(contexts))
            .Add(new ConsumeElixirCleanupSystem(contexts))
            .Add(new ElixirConsumePersistSystem(contexts))
            ;
    }

}
