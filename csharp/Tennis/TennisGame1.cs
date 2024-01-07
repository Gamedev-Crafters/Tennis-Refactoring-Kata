namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly string _player1Name;
        private readonly string _player2Name;
        private int _score1;
        private int _score2;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _score1 = 0;
            _score2 = 0;
        }

        public void WonPoint(string playerName)
        {
            if (HasPlayer1WonThePoint(playerName))
            {
                AddPointToPlayer1();
                return;
            }
            
            AddPointToPlayer2();
        }

        private bool HasPlayer1WonThePoint(string playerName) => playerName == _player1Name;

        private void AddPointToPlayer2() => _score2 += 1;

        private void AddPointToPlayer1() => _score1 += 1;

        
        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (_score1 == _score2)
            {
                switch (_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (_score1 >= 4 || _score2 >= 4)
            {
                var minusResult = _score1 - _score2;
                if (minusResult == 1) score = $"Advantage {_player1Name}";
                else if (minusResult == -1) score = $"Advantage {_player2Name}";
                else if (minusResult >= 2) score = $"Win for {_player1Name}";
                else score = $"Win for {_player2Name}";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = _score1;
                    else { score += "-"; tempScore = _score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

