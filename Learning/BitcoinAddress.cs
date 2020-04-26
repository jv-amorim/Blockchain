using System;
using NBitcoin;

namespace Learning
{
    public class BitcoinAddress
    {
        public BitcoinAddress()
        {
            Key privateKey = new Key();
            PubKey publicKey = privateKey.PubKey;

            Console.WriteLine("Public Key: " + publicKey);
            Console.WriteLine();

            Console.WriteLine("Bitcoin Address (MainNet): " + 
                publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main));
            Console.WriteLine("Bitcoin Address (TestNet): " + 
                publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.TestNet));
            Console.WriteLine();

            var publicKeyHash = publicKey.Hash;

            Console.WriteLine("PubKey Hash: " + publicKeyHash);
            Console.WriteLine();

            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine("Bitcoin Addresses from PubKey Hash: ");
            Console.WriteLine("Bitcoin Address (MainNet): " + mainNetAddress);
            Console.WriteLine("Bitcoin Address (TestNet): " + testNetAddress);
        }
    }
}