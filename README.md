# TweenManager
프로젝트 기간 : 24.04.18 ~

프로젝트 인원 : 위규연

# 설명
- DOTween을 토대로 재구성한 스크립트입니다.
- UI 및 Object에 효과를 줄 때 재사용하기 위해 제작하게 되었습니다.
- 계속해서 필요한 기능을 업데이트 할 예정입니다.

- ### Sequence 및 Parallel Tweens (순차 및 병렬 애니메이션):
  - Sequence Tween: 여러 개의 Tween을 순차적으로 실행할 수 있습니다. 현재 Tween이 완료되면 다음 Tween이 실행됩니다.

  - Parallel Tween: 여러 개의 Tween을 동시에 실행할 수 있습니다. 모든 Tween이 동시에 시작되며, 각각 개별 적용이 가능합니다.

- ### Loop 및 Delay 기능:
  - Loop: 애니메이션을 반복해서 실행할 수 있습니다. 특정 횟수 또는 무한 반복이 가능합니다.
  - Delay: 애니메이션 시작 전에 일정 시간을 대기하거나, 애니메이션 도중 특정 시간을 기다릴 수 있습니다.

- ### 콜백 기능:
  - 콜백: 애니메이션 종료 시점에서 사용자 지정 콜백 함수를 호출할 수 있습니다.

- ### 트윈의 일시 정지 및 재개 기능:
  - 애니메이션을 일시 정지하고 다시 재개할 수 있는 기능을 제공합니다.


# 시연영상
## Relative
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/e53a101b-2772-49e7-a4fc-ac98416633cb"/>

- 두 오브젝트 모두 x좌표 –10의 위치에서 시작
- Vector3(10,0,0)값을 줬을 때
- isRelative를 true로 설정시 기존 오브젝트의 위치에서 +10만큼 이동
- isRelative를 false로 설정시 기존 오브젝트가 10의 위치로 이동

## MoteTotarget
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/79d368a6-6461-4a59-b415-837d473a756a"/>

- 이징함수 별 Move 변경함수
- 오브젝트의 움직임에 Tween애니메이션 적용

## RotateToTarget
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/bb616428-58c0-4d1a-963e-6cfc7f104f7a"/>

- 이징함수 별 Rotate 변경함수
- 오브젝트의 회전에 Tween애니메이션 적용

## ScaleToTarget
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/4d745a2e-a368-4d91-8551-ca7bd3a4ff35"/>

- 이징함수 별 Scale 변경함수
- 오브젝트의 크기 변화 Tween애니메이션 적용

## ColorToTarget
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/a4581559-9f1e-4728-96d7-19901e8b50ca"/>

- 이징함수 별 Color 변경함수
- 오브젝트의 색상 변화 Tween애니메이션 적용
  
## AlphaToTarget
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/52b06295-2b0c-4285-b6a9-3b100663f322"/>

- 이징함수 별 Alpha 변경함수
- 오브젝트의 투명도 변화 Tween애니메이션 적용

## SequenceTween
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/0d4e5b4a-4ac2-400e-b4a2-939dda491c76"/>

- Tween 순차 실행
  
## Resume,Pause
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/26393610-4f3f-4e12-82cc-b6251b5edaba"/>

- 일시정지 및 재개
  
## Loop
<img width="100%" src="https://github.com/noey-uyg/Tween_Func/assets/105009308/801beaff-9e44-4bc0-b948-b5d244a1c10e"/>

- LoopType 별 반복
