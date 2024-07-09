using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMauiApp
{
    public partial class OmokGamePage : ContentPage
    {
        private OmokRule _omokLogic;
        private OmokGameDrawable _drawable;
        private HttpClient _httpClient;
        private string _headerGameToken;
        private long _headerUserId;

        public OmokGamePage()
        {
            InitializeComponent();
            _omokLogic = new OmokRule();
            _drawable = new OmokGameDrawable(_omokLogic);
            gameCanvas.Drawable = _drawable;
            _httpClient = new HttpClient();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = userIDEntry.Text;
            string password = userPWEntry.Text;
            var loginResponse = await LoginAsync(email, password);

            if (loginResponse != null && loginResponse.result == 0)
            {
                dataUserId.Text = "UserID: " + email;
                _headerUserId = loginResponse.userNum;
                _headerGameToken = loginResponse.hiveToken;
                AddLog("Login Successful");
            }
            else
            {
                dataUserId.Text = "Login Failed";
                AddLog("Login Failed");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = userIDEntry.Text;
            string password = userPWEntry.Text;
            var registerResponse = await RegisterAsync(email, password);

            if (registerResponse != null && registerResponse.result == 0)
            {
                dataUserId.Text = "Register Successful";
                AddLog("Register Successful");
            }
            else
            {
                dataUserId.Text = "Register Failed";
                AddLog("Register Failed");
            }
        }

        private void OnConnectClicked(object sender, EventArgs e)
        {
            // TODO : ADD connection logic
            Console.WriteLine("Connect button clicked");
            AddLog("Connect button clicked");
        }

        private void OnDisconnectClicked(object sender, EventArgs e)
        {
            // TODO : ADD disconnection logic
            Console.WriteLine("Disconnect button clicked");
            AddLog("Disconnect button clicked");
        }

        private void OnNewGameClicked(object sender, EventArgs e)
        {
            _omokLogic.StartGame();
            gameCanvas.Invalidate();
            AddLog("New Game Started");
        }

        private void OnUndoClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Undo button clicked");
            AddLog("Undo button clicked");
        }

        private void OnEndGameClicked(object sender, EventArgs e)
        {
            _omokLogic.EndGame();
            gameCanvas.Invalidate();
            AddLog("Game Ended");
        }

        private void OnRoomEnterClicked(object sender, EventArgs e)
        {
            // TODO : ADD room enter logic
            Console.WriteLine("Room Enter button clicked");
            AddLog("Room Enter button clicked");
        }

        private void OnRoomLeaveClicked(object sender, EventArgs e)
        {
            // TODO : ADD room leave logic 
            Console.WriteLine("Room Leave button clicked");
            AddLog("Room Leave button clicked");
        }

        private void OnRoomChatClicked(object sender, EventArgs e)
        {
            // TODO : ADD room chat logic 
            Console.WriteLine("Room Chat button clicked");
            AddLog("Room Chat button clicked");
        }

        private void OnMatchingClicked(object sender, EventArgs e)
        {
            // TODO : ADD matching logic 
            Console.WriteLine("Matching button clicked");
            AddLog("Matching button clicked");
        }

        private void OnCancelMatchingClicked(object sender, EventArgs e)
        {
            // TODO : ADD cancel matching logic 
            Console.WriteLine("Cancel Matching button clicked");
            AddLog("Cancel Matching button clicked");
        }

        private void OnGameReadyClicked(object sender, EventArgs e)
        {
            // TODO : ADD game ready logic
            Console.WriteLine("Game Ready button clicked");
            AddLog("Game Ready button clicked");
        }

        private async Task<LoginResponse> LoginAsync(string email, string password)
        {
            // login test code
            await Task.Delay(100);

            if (email == "test1" && password == "1111")
            {
                return new LoginResponse { result = 0, userNum = 1, hiveToken = "mockToken" };
            }

            return new LoginResponse { result = -1 };
        }

        private async Task<RegisterResponse> RegisterAsync(string email, string password)
        {
            // register test code
            await Task.Delay(100); 

            if (email == "test1" && password == "1111")
            {
                return new RegisterResponse { result = 0 };
            }

            return new RegisterResponse { result = -1 };
        }

        private void OnCanvasTapped(object sender, TappedEventArgs e)
        {
            if (_omokLogic.IsGameOver || !_omokLogic.IsBlackTurn())
            {
                return;
            }

            Point? touchPoint = e.GetPosition(gameCanvas);
            if (touchPoint == null) return;
            Point touch = touchPoint.Value;

            int x = (int)((touch.X - 30 + 10) / 30);
            int y = (int)((touch.Y - 30 + 10) / 30);

            if (x < 0 || x >= 19 || y < 0 || y >= 19)
            {
                return;
            }

            if (_omokLogic.GetStone(x, y) == (int)OmokRule.StoneType.None && !_omokLogic.IsGameOver)
            {
                _omokLogic.PlaceStone(x, y);
                _omokLogic.CheckForOmok(x, y);
                gameCanvas.Invalidate();
                AddLog($"Stone placed at ({x}, {y})");
            }
        }

        private void AddLog(string message)
        {
            logLabel.Text += $"{DateTime.Now}: {message}\n";
        }
    }

    public class LoginResponse
    {
        public int result { get; set; }
        public long userNum { get; set; }
        public string hiveToken { get; set; }
    }

    public class RegisterResponse
    {
        public int result { get; set; }
    }
}