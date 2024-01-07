using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _winningScoreNames;
        private readonly string[] _advantageScoreNames;
        private readonly string[] _runningScoreNames = 
            { "Love", "Fifteen", "Thirty", "Forty" };
        private readonly string[] _equalScoreNames = 
            { "Love-All", "Fifteen-All", "Thirty-All", "Deuce" };
        
        private int _score1;
        private int _score2;
        
        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            
            _score1 = 0;
            _score2 = 0;
            
            _advantageScoreNames = new[]
            {
                "Advantage " + _player1Name,
                "Advantage " + _player2Name
            };
            _winningScoreNames = new []
            {
                "Win for " + _player1Name,
                "Win for " + _player2Name
            };
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

        private bool HasPlayer1WonThePoint(string playerName) 
            => playerName == _player1Name;

        private void AddPointToPlayer2() 
            => _score2 += 1;

        private void AddPointToPlayer1() 
            => _score1 += 1;


        public string GetScore()
        {
            if (_score1 == _score2)
            {
                return CheckEqualScoreValue();
            }

            if (_score1 < 4 && _score2 < 4) return CheckRunningScoreValue();
            
            return Math.Abs(_score1 - _score2) == 1 
                ? CheckAdvantageScoreValue() : CheckWinningScoreValue();
        }

        private string CheckAdvantageScoreValue() 
            => _score1 - _score2 == 1 ? _advantageScoreNames[0] : _advantageScoreNames[1];

        private string CheckRunningScoreValue() 
            => _runningScoreNames[_score1] + "-" + _runningScoreNames[_score2];

        private string CheckWinningScoreValue() 
            => _score1 - _score2 >= 2 ? _winningScoreNames[0] : _winningScoreNames[1];

        private string CheckEqualScoreValue() 
            => _score1 <= 2 ? _equalScoreNames[_score1] : _equalScoreNames[^1];
    }
}