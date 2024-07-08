namespace MyMauiApp
{
    public partial class App : Application
    {
        public App() // 생성자는 애플리케이션 시작 시 호출
        {
            InitializeComponent();

            MainPage = new AppShell(); // MainPage 속성을 새로운 AppShell 인스턴스로 설정
                    // AppShell은 애플리케이션의 기본 UI를 정의하는 클래스
        }

        // 이벤트 처리기 추가
        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
    }
}
