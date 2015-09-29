動作確認Unity: ver 5.1.1~

# PhaseStateController

## これなに

* ゲームの状態をゲーム開始処理,ゲームプレイ中,ゲーム終了処理みたいに状態ごとに管理しやすくするtips的な物
* 小さなゲームとか短期間で作るゲームとかで、不穏なバグを生み出したくない場合は有効なはず

## How to

* PhaseBase
 * フェーズ名、フェーズに入った時の処理、フェーズを終了するときの処理を書く
 * フェーズに入った時に初期化処理→ループルーチンみたいな感じに繋ぐことが多い

* PhaseStateMachine
 * フェーズを管理するやつ
 * 現状はPhaseBaseと同じゲームオブジェクトにAddComponentしてあるという想定で作っていますが、必要に応じて変更することを推奨します
 * フェーズの遷移はGotoメソッドを使っておこないます

* SamplePhaseController
 * PhaseStateMachineまでで完結してるけど、作者はこういう感じで使ってるよというサンプル
 * こいつをMainGameManagerという名称にしたり、PlayerControllerという名前にしたりしてる
