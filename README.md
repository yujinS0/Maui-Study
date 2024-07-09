# .NET MAUI
C#과 XAML을 사용하여 네이티브 모바일 및 데스크톱 앱을 만들기 위한 플랫폼 간 프레임워크
​
단일 공유 코드 베이스에서 여러 플랫폼 (Android, iOS, macOS, windows)에서 실행할 수 있는 앱(네이티브 애플리케이션)을 개발할 수 있음
​
-   "네이티브 앱 패키지"
    -   각 플랫폼에서 실행될 수 있도록 패키징된 네이티브 애플리케이션을 의미
    -   즉, .NET MAUI를 사용하여 개발된 애플리케이션은 각각의 플랫폼(Android, iOS, Windows, macOS)에서 요구하는 형태로 패키징되어 실행
    -   이를 통해 사용자는 각 플랫폼의 네이티브 성능과 사용자 경험을 누릴 수 있음
-   각 플랫폼에서 네이티브 앱 패키징
    -   **Android**: .NET MAUI 앱은 Android용으로 패키징될 때 .apk 또는 .aab 파일로 컴파일됩니다. 이는 Android 장치에서 설치되고 실행될 수 있는 네이티브 Android 애플리케이션입니다.
    -   **iOS**: .NET MAUI 앱은 iOS용으로 패키징될 때 .ipa 파일로 컴파일됩니다. 이는 iOS 장치(예: iPhone, iPad)에서 설치되고 실행될 수 있는 네이티브 iOS 애플리케이션입니다.
    -   **Windows**: .NET MAUI 앱은 Windows용으로 패키징될 때 .msix 또는 .exe 파일로 컴파일됩니다. 이는 Windows 운영체제에서 실행될 수 있는 네이티브 Windows 애플리케이션입니다.
    -   **macOS**: .NET MAUI 앱은 macOS용으로 패키징될 때 .app 파일로 컴파일됩니다. 이는 macOS 장치에서 설치되고 실행될 수 있는 네이티브 macOS 애플리케이션입니다.

    ![image](https://github.com/yujinS0/MyMauiApp/assets/87336788/6820df1f-d001-47dd-b2b0-540447dcd3f6)


.NET MAUI는 오픈 소스로, 성능 및 확장성을 위해 처음부터 다시 빌드된 UI 컨트롤을 사용하여 모바일에서 데스크톱 시나리오로 확장된 Xamarin.Forms의 진화라고도 볼 수 있음
​
.NET MAUI의 주목표는 **단일 코드베이스**에서 **최대한 많은 애플리케이션 논리**와 **UI 레이아웃**을 **구현**할 수 있도록 하는 것
​
# 학습 및 실습 내용 정리
- [.NET MAUI 란?](https://cojelly.tistory.com/entry/NET-MAUI-%EB%9E%80)
- [.NET MAUI 프로젝트 만들기 및 구조 설명](https://cojelly.tistory.com/entry/NET-MAUI-%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%EB%A7%8C%EB%93%A4%EA%B8%B0-%EB%B0%8F-%EA%B5%AC%EC%A1%B0-%EC%84%A4%EB%AA%85)
- [.NET MAUI 앱에 시각적 개체 컨트롤 추가](https://cojelly.tistory.com/entry/NET-MAUI-%EC%95%B1%EC%97%90-%EC%8B%9C%EA%B0%81%EC%A0%81-%EA%B0%9C%EC%B2%B4-%EC%BB%A8%ED%8A%B8%EB%A1%A4-%EC%B6%94%EA%B0%80)
- [실습: 전화 번호 변환기 앱 만들기](https://cojelly.tistory.com/entry/%EC%8B%A4%EC%8A%B5-%EC%A0%84%ED%99%94-%EB%B2%88%ED%98%B8-%EB%B3%80%ED%99%98%EA%B8%B0-%EC%95%B1-%EB%A7%8C%EB%93%A4%EA%B8%B0)

# 오목 게임 클라이언트 제작
- [WinForm으로 제작한 클라이언트](https://github.com/yujinS0/GameServer/tree/main/SocketServer/OmokClient) 기반
- 주요 클래스
  + `OmokGamePage` : 사용자와의 상호작용
  + `OmokGameDrawable` : 게임 보드 그리는 로직
  + `OmokRule` : 게임의 규칙과 상태 관리

## Omok 게임 구현 요약
### 1. OmokGamePage
`OmokGamePage`는 전체 Omok 게임 UI를 관리하는 메인 페이지입니다. 이 페이지는 다양한 UI 요소들을 포함하며, 사용자와의 상호작용을 처리합니다.
#### 주요 기능:
- **서버 설정 및 연결**: 서버 주소와 포트 번호를 입력하고 서버에 연결할 수 있습니다.
- **사용자 인증**: 회원가입 및 로그인 기능을 제공합니다.
- **게임 설정**: 새로운 게임 시작, 게임 종료, 룸 입장 및 퇴장, 매칭 등의 기능을 포함합니다.
- **로그**: 각종 이벤트 및 작업에 대한 로그를 기록하여 사용자에게 표시합니다.
- **Omok 보드**: Omok 보드의 그래픽을 표시하고, 사용자가 보드에 돌을 놓을 수 있도록 합니다.

#### 코드 구조:
- UI 요소들은 XAML 파일에 정의되며, C# 코드 비하인드 파일(`OmokGamePage.xaml.cs`)에서 각 UI 요소와 상호작용을 처리합니다.
- `OmokGamePage` 클래스는 `OmokRule`과 `OmokGameDrawable`을 사용하여 게임 로직을 처리하고 보드를 그립니다.

### 2. OmokGameDrawable
`OmokGameDrawable`는 게임 보드의 그래픽을 그리는 클래스입니다. 이 클래스는 `IDrawable` 인터페이스를 구현하여 `GraphicsView`에 그리기 작업을 수행합니다.

#### 주요 기능:
- **보드 그리기**: Omok 보드를 그립니다.
- **돌 그리기**: 보드 위에 놓인 돌을 그립니다.
- **보드 갱신**: 게임 상태에 따라 보드를 갱신하여 다시 그립니다.
#### 코드 구조:
- `OmokGameDrawable` 클래스는 `Draw` 메서드를 통해 보드와 돌을 그립니다.
- `OmokRule` 객체를 통해 현재 게임 상태를 받아와 적절하게 그립니다.

### 3. OmokRule
`OmokRule` 클래스는 Omok 게임의 규칙과 상태를 관리합니다. 이 클래스는 게임 로직을 처리하고 게임 상태를 유지합니다.

#### 주요 기능:
- **게임 시작 및 종료**: 게임을 시작하고 종료하는 기능을 제공합니다.
- **돌 놓기**: 사용자가 돌을 놓을 때의 처리를 담당합니다.
- **게임 상태 검사**: 승리 조건, 삼삼금지 규칙 등을 검사합니다.
- **턴 관리**: 현재 턴을 관리하고, 턴을 전환합니다.

#### 코드 구조:
- `OmokRule` 클래스는 게임 상태를 저장하는 2차원 배열과 게임 관련 메서드들을 포함합니다.
- `PlaceStone`, `CheckForOmok` 등의 메서드를 통해 게임 규칙을 구현합니다.


# 실행 화면
### 1. Home
![image](https://github.com/yujinS0/MyMauiApp/assets/87336788/790d450c-10cd-4246-a252-468f59e207ad)

### 2. OmokGamePage
![image](https://github.com/yujinS0/MyMauiApp/assets/87336788/51647b00-31a1-4f17-ac5a-db038ed41d98)

### 3. DigitsPage
![image](https://github.com/yujinS0/MyMauiApp/assets/87336788/32c54981-a21b-4925-9819-162bb48755a3)
