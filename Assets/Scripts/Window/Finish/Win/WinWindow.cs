using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using Services.Levels;
using Services.SFX;
using Services.StaticData;
using Zenject;

namespace Window.Finish.Win
{
    public class WinWindow : FinishWindow
    {
        private IStateMachine<IGameState> _gameStateMachine;
        private ILevelService _levelService;
        private IStaticDataService _staticDataService;
        private ISoundService _soundService;
        
        [Inject]
        public void Constructor(
            ILevelService levelService,
            IStateMachine<IGameState> gameStateMachine,
            IStaticDataService staticDataService,
            ISoundService soundService)
        {
            _levelService = levelService;
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _soundService = soundService;
        }

        public void OnDestroy()
        {
            UnsubscribeEvents();
        }
        
        public void Initialize()
        {
            SubscribeEvents();
        }
        
        protected override void OnLoadLevelButtonClick()
        {
            _soundService.ButtonClick();
            _gameStateMachine.Enter<LoadLevelState, string>(_staticDataService.GameConfig.GameScene);
        }

        protected override void OnExitToMenuButtonClick()
        {
            _soundService.ButtonClick();
            _gameStateMachine.Enter<LoadMenuState, string>(_staticDataService.GameConfig.MenuScene);
        }
        
        protected override void OnRestartLevelButtonClick()
        {
            _soundService.ButtonClick();
            _gameStateMachine.Enter<LoadLevelState, string>(_staticDataService.GameConfig.GameScene);
        }
    }   
}