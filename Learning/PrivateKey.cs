using System;
using NBitcoin;

namespace Learning
{
    public class PrivateKey
    {
        public PrivateKey()
        {
            Key privateKey = new Key();
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main);
            BitcoinSecret testNetPrivateKey = privateKey.GetBitcoinSecret(Network.TestNet);

            Console.WriteLine("Private Key from MainNet: " + mainNetPrivateKey);
            Console.WriteLine("Private Key from TestNet: " + testNetPrivateKey);
            Console.WriteLine();

            bool WifIsBitcoinSecret = mainNetPrivateKey == privateKey.GetWif(Network.Main);

            Console.WriteLine("Is WIF (Wallet Import Format) equal to BitcoinSecret?");
            Console.WriteLine(WifIsBitcoinSecret);
        }
    }
}