namespace MyMauiApp;

public partial class DigitsPage : ContentPage // 기본 페이지 유형인 ContentPage 상속
{
	public DigitsPage() // 생성자 : 컴포넌트 초기화
	{
		InitializeComponent(); // XAML 파일의 구성요소 초기화
	}

    string translatedNumber; // 번역된 번호 저장 필드

    // TranslateButton 클릭 이벤트 핸들러
    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text; // 입력된 전화 단어 가져오기
        translatedNumber = MyMauiApp.PhonewordTranslator.ToNumber(enteredNumber); // 숫자로 변환

        if (!string.IsNullOrEmpty(translatedNumber)) // 변역된 번호가 비어있지 않다면
        {
            CallButton.IsEnabled = true; // 버튼 활성화
            CallButton.Text = "Call " + translatedNumber; // 텍스트 업데이트
        }
        else // 변환된 번호가 비어있다면
        {
            CallButton.IsEnabled = false; // 버튼 비활성화
            CallButton.Text = "Call"; 
        }
    }
    
    // CallButton 클릭 이벤트 핸들러
    async void OnCall(object sender, System.EventArgs e)
    {
        if (await this.DisplayAlert( // DisplayAlert : 알림 대화 상자 표시
        "Dial a Number",
        "Would you like to call " + translatedNumber + "?",
        "Yes",
        "No"))
        {
            // 전화 번호로 전화 걸기
            try
            {
                if (PhoneDialer.Default.IsSupported) 
                    // PhoneDialer 클래스 : 전화 걸기 기능(및 기타)의 추상화를 제공
                    PhoneDialer.Default.Open(translatedNumber); // Open() : 제공된 번호를 호출하려고 시도
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                // Other error has occurred.
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }
}