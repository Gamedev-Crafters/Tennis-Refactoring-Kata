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
            var score = "";
            if (_score1 == _score2)
            {
                score = CheckEqualScoreValue();
                return score;
            }

            if (_score1 >= 4 || _score2 >= 4)
            {
                score = CheckWinningScoreValue();
                return score;
            }

            score = CheckRunningScoreValue();
            return score;
        }

        private string CheckRunningScoreValue()
        {
            string[] scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

            return scoreNames[_score1] + "-" + scoreNames[_score2];
        }

        private string CheckWinningScoreValue()
        {
            string score;
            var minusResult = _score1 - _score2;
            if (minusResult == 1) score = $"Advantage {_player1Name}";
            else if (minusResult == -1) score = $"Advantage {_player2Name}";
            else if (minusResult >= 2) score = $"Win for {_player1Name}";
            else score = $"Win for {_player2Name}";
            return score;
        }

        private string CheckEqualScoreValue()
        {
            string[] scoreNames = { "Love-All", "Fifteen-All", "Thirty-All", "Deuce" };
            
            return _score1 <= 2 ? scoreNames[_score1] : scoreNames[^1];
        }
    }
}