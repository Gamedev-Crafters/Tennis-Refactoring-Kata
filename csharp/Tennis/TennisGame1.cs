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
            if (_score1 == _score2)
            {
                return CheckEqualScoreValue();
            }

            if ((_score1 >= 4 || _score2 >= 4) && (_score1 - _score2 == -1 || _score1 - _score2 == 1))
            {
                return CheckAdvantageScoreValue();
            }

            if (_score1 >= 4 || _score2 >= 4)
            {
                return CheckWinningScoreValue();
            }

            return CheckRunningScoreValue();
        }

        private string CheckAdvantageScoreValue()
        {
            string[] scoreNames =
            {
                "Advantage " + _player1Name,
                "Advantage " + _player2Name
            };

            return _score1 - _score2 == 1 ? scoreNames[0] : scoreNames[1];
        }


        private string CheckRunningScoreValue()
        {
            string[] scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

            return scoreNames[_score1] + "-" + scoreNames[_score2];
        }
        
        private string CheckWinningScoreValue()
        {
            string[] scoreNames =
            {
                "Win for " + _player1Name,
                "Win for " + _player2Name
            };

            return _score1 - _score2 >= 2 ? scoreNames[0] : scoreNames[1];
        }

        private string CheckEqualScoreValue()
        {
            string[] scoreNames = { "Love-All", "Fifteen-All", "Thirty-All", "Deuce" };

            return _score1 <= 2 ? scoreNames[_score1] : scoreNames[^1];
        }
    }
}