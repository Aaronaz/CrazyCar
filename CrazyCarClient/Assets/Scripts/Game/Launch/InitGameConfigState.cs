using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class InitGameConfigState : AbstractState<LaunchStates, Launch>, IController {
    public InitGameConfigState(FSM<LaunchStates> fsm, Launch target) : base(fsm, target) {
    }

    public override void OnEnter() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        InitSettingsInfo();
        
        if (this.GetUtility<IPlayerPrefsStorage>().LoadInt(PrefKeys.isSuperuser) == 1) {
            this.SendCommand(new ShowPageCommand(UIPageType.GameHelper, UILevelType.Debug));
        }
        ChangeState();
    }
    
    private void ChangeState() {
        
    }

    private void InitSettingsInfo() {
        this.SendCommand<SavaSettingsCommand>();
    }

    public IArchitecture GetArchitecture() {
        return CrazyCar.Interface;
    }
}
