using System.Security.Cryptography;
namespace Program{
    class HMAC{
        private string computerMove;
        private string HMACkey;
        private string HMACstring;
        public HMAC(string computerMove) {
            this.computerMove = computerMove;
            HMACkey = "";
            HMACstring = "";
        }

        public void createHMACs() {
            var rng = RandomNumberGenerator.Create();
            byte[] key = new byte[64];
            rng.GetBytes(key);
            foreach(byte bt in key) {
                HMACkey += $"{bt:X2}";
            }

            var sha = SHA3.Net.Sha3.Sha3256();
            key = sha.ComputeHash(key.Concat(System.Text.Encoding.Default.GetBytes(computerMove)).ToArray());
            foreach(byte bt in key){
                HMACstring += $"{bt:X2}";
            }
        }

        public string getKey(){return HMACkey;}
        public string getHMAC(){return HMACstring;}
    }
}