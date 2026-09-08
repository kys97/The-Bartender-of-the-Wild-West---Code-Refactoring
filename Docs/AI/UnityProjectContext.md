# Unity Project Context

<!-- unity-onboarding:generated:start -->

## 프로젝트와 분석 기준
- 프로젝트: 황야의 무병자 리팩토링. 루트: `C:/Users/User/Documents/ChatGPT/황야의 무병자 리펙토링`.
- 분석일: 2026-09-07. 기준 커밋: `79e180c` 및 이번 로컬 리팩토링 변경.
- 저장소 파일과 대체 C# 컴파일로 확인한 내용이며, Unity Editor 실행 및 플레이어 빌드 검증은 수행하지 않았다.

## 환경 — 확인됨
- Unity `6000.0.23f1`, revision `1c4764c07fb4` (`ProjectSettings/ProjectVersion.txt`).
- Built-in Render Pipeline: GraphicsSettings 및 모든 QualitySettings의 커스텀 파이프라인 참조가 비어 있고 URP/HDRP 패키지가 없다.
- Legacy Input Manager: `ProjectSettings.asset`의 `activeInputHandler: 0`. UI는 EventSystems의 포인터 이벤트를 사용한다.
- 주요 패키지: 2D Feature 2.0.1, uGUI 2.0.0, Test Framework 1.4.5, Timeline 1.8.7, Visual Scripting 1.9.4. manifest 및 lock에 registry/builtin 패키지가 있고 Git/local 의존성은 없다.
- Multiplayer Center 패키지는 있지만, 확인한 게임 코드에서 네트워크 플레이 구현은 발견하지 못했다.
- 실제 배포 대상은 미확인. UIEventHandler에는 모바일, 데스크톱, WebGL 조건부 코드가 있다.

## 구조와 어셈블리
- `Assets/0. Scenes`: Main, Level, Game, Result 씬.
- `Assets/2. Scripts`: 자체 C# 스크립트 19개. 루트의 매니저와 `0. UI`, `1. Game`으로 분류.
- `Assets/1. Sprites`: 이미지 에셋. `Assets/Resources`: 런타임 오디오 및 스프라이트 로딩 경로.
- `Assets/TextMesh Pro`: 가져온 TMP 리소스.
- 자체 asmdef/asmref가 없어 게임 스크립트는 기본 Assembly-CSharp에 속하는 구조다. 별도 테스트/에디터 어셈블리는 발견하지 못했다.
- README 외 별도 프로젝트 지침이나 기존 아키텍처 문서는 발견하지 못했다.

## 시작 흐름과 아키텍처 — 코드에서 확인됨
- 빌드 씬 순서: Main → Level → Game → Result, 모두 활성화됨 (`EditorBuildSettings.asset`). 첫 빌드 씬은 Main.
- GameStartBtn이 Level을 열고, 난이도 버튼이 정적 GameLevel을 설정한 뒤 Game을 연다. Result로 넘어가는 흐름은 이번 표본 검사에서 확인되지 않았다.
- GameManager는 Singleton MonoBehaviour이며 DontDestroyOnLoad로 유지된다. ResourceManager와 AudioManager를 AddComponent로 만들고 초기화한다.
- GameManager의 sceneLoaded 콜백이 BGM과 게임 초기화를 담당한다. Start에서도 현재 씬 초기화 함수를 호출한다.
- 게임 상태, 금액, 난이도는 public static 필드다. 수배자/좌석 배열은 GameManager 인스턴스에 있고 외부 코드가 직접 접근한다.
- 정적 OnUIInit 이벤트에 Timer, Money, Plate, Wanted가 OnEnable에서 구독하고 OnDisable에서 해제한다.
- ResourceManager는 Resources.LoadAll로 이미지를, AudioManager는 오디오를 로드한다. 오디오 이름은 문자열 사전으로 조회한다.
- UIEventHandler 상속으로 버튼 포인터 처리를 공유한다. LevelButton이 난이도 선택/사운드/씬 전환을 공유하고 기존 4개 난이도 컴포넌트는 레벨 값만 제공한다. 기존 클래스와 .meta GUID는 보존했다.

## 코드 관례
- 네임스페이스 없이 Allman 중괄호 사용. 필드 명명은 camelCase, PascalCase, snake_case가 혼재한다.
- 표본 코드는 public 필드와 런타임 GetComponent/계층 탐색을 사용한다.
- GameManager에는 region 구획이 있다. 비동기/DI/이벤트 버스 프레임워크 사용은 표본에서 발견되지 않았다.

## 검증 및 도구
- Test Framework 의존성은 있으나 자체 테스트 코드, 테스트 어셈블리, CI 검증 설정은 발견하지 못했다.
- Unity MCP 패키지/설정 및 연결 가능한 Unity 전용 도구는 발견하지 못했다. 설치된 Editor는 6000.4.1f1과 6000.5.8f1이며 프로젝트 지정 버전과 다르다. Editor 연결 상태는 미확인.
- 6000.4.1f1의 Roslyn, Unity 참조 DLL 및 번들 2D 템플릿의 UI/TMP DLL로 전체 자체 코드를 대체 컴파일했다. 변경 전 Windows/Android는 통과, WebGL은 CS0103 두 건으로 실패했다. 변경 후 세 조건 모두 오류 없이 통과했다. 프로젝트 지정 버전/실제 패키지 조합의 Editor 컴파일과 동등한 검증은 아니다.
- 기존 미사용 이벤트 3개 및 Customer.PlateNumber 경고가 남아 있다. Play Mode, 실제 씬 연결, 오디오 재생 및 화면 동작은 미검증이다.
- 임시 컴파일 도구와 로그: `Temp/RefactorValidation/` (Git 제외). 변경 파일 diff 및 공백 오류 검사를 수행했고 씬/기존 .meta/직렬화 필드는 변경하지 않았다.

## 리팩토링 후보와 확인할 동작
- 사용자는 지저분하고 비효율적인 코드 개선을 요청했다. 난이도 버튼 중복 제거, 오디오 로딩/재생 공통화, 리스트 초기화 단순화, 불필요한 using 및 빈 생명주기 함수 제거를 완료했다. 측정된 실행 성능 향상을 주장하지 않는다.
- GameInit은 WantedCriminals를 0으로 초기화하지만 Wanted의 추첨 루프는 -1일 때만 실행된다. 코드상 조건 불일치가 확인되며 의도한 초기 상태와 화면 결과는 별도로 검증해야 한다.
- GameManager.Start의 `if(true)`와 사용되지 않는 isFirstLoad를 제거했다. sceneLoaded와 Start의 초기화 중복 가능성은 실행으로 확인해야 한다. 호출 순서는 보존했다.
- UIEventHandler의 WebGL hover 메서드 선언 누락을 수정해 등록 조건과 일치시켰다. 기존 컴파일 오류 수정이며 게임 규칙 변경은 아니다.
- ResourceManager의 미사용 NUnit using 및 EnumManager의 미사용 Burst using을 제거했다.
- 씬/프리팹의 스크립트 GUID, 직렬화 필드, 인스펙터 이벤트 연결을 보존하는 방식으로 변경해야 한다. 기존 버그 수정은 동작 보존 리팩토링과 구분한다.

## 주요 근거
- `README.md`, `Packages/manifest.json`, `Packages/packages-lock.json`.
- `ProjectSettings/ProjectVersion.txt`, `EditorBuildSettings.asset`, `GraphicsSettings.asset`, `QualitySettings.asset`, `ProjectSettings.asset`.
- `Assets/2. Scripts`의 GameManager, ResourceManager, AudioManager, EnumManager, UIEventHandler, EasyLevelBtn, NormalLevelBtn, GameStartBtn, TutorialPanel, Timer, Wanted, Customer를 읽고 나머지 코드의 씬 전환/이벤트 구독 패턴을 검색했다.

<!-- unity-onboarding:generated:end -->
