using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using Core.StateMachine;

public class GameManager : Singleton<GameManager> {
    public enum GameStates {
        INTRO,
        GAMEPLAY,
        WIN,
        LOSS,
        PAUSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start() {
        Init();
    }

    public void Init() {
        stateMachine = new StateMachine<GameStates>();

        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisterStates(GameStates.WIN, new StateBase());
        stateMachine.RegisterStates(GameStates.LOSS, new StateBase());
        stateMachine.RegisterStates(GameStates.PAUSE, new StateBase());

        stateMachine.SwitchState(GameStates.INTRO);
    }



}
