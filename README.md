# The-BOX

作成手順  
1. Build SettingsでプラットフォームをAndroid用に切り替える   
Game→ Free Aspect→ WXGA Portrait(800*1280)を選択すると,画面サイズが800*1280になる  
2.Assets以下に/
  Resouces  
  Scenes  
  Scripts  
のフォルダを作成  
3.TitleSceneを作成    
シーンとは  
GameObjectを任意の座標に配置したり、コンポーネントをアタッチしたオブジェクトを配置したりするもの  
TitleSceneを作成して保存  
まずはUIとしてCanvasを配置し、そのCanvasに様々なUIを配置していく　　
Canvasは始めはゲーム画面に対してあまりに大きいので、SortOrderをScreen Space Cameraに設定してカメラの範囲に収まるようにする　　r CamearaRendee
Render CameraをMain Cameraに設定して、 Main　Cameraで写せるようにする
  StartボタンからGameSceneへ遷移  
4.パネルを設定　親1枚,子４枚用意  
5.左右ボタンを設定し、パネル移動を実装  
6.テキストボタン、メモボタンを配置  
