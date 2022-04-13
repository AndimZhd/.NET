namespace Program{
    class Rules{
        private string[] args;
        public Rules(string[] args) {
            this.args = args;
        }
        public int detectTheWinner(int computer, int user) {
            int difference = user-computer>=0 ? user-computer : args.Length+user-computer;
            return difference==0 ? 3 : (difference<=args.Length/2 ? 1 : 2);
        }

        public (string, int) getComputerMove() {
            int index = System.Security.Cryptography.RandomNumberGenerator.GetInt32(args.Length);
            return (args[index], index+1);
        }
    }
}