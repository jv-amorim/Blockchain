using System;
using NBitcoin;

namespace Learning
{
    public class ScriptPubKey
    {
        public ScriptPubKey()
        {
            var publicKeyHash = new KeyId("14836dbe7f38c5ac3d49e8d790af808a4ee9edcf");

            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);

            Console.WriteLine("ScriptPubKey (MainNet): " + mainNetAddress.ScriptPubKey);
            Console.WriteLine("ScriptPubKey (TestNet): " + testNetAddress.ScriptPubKey);
            Console.WriteLine();

            var paymentScript = publicKeyHash.ScriptPubKey;
            var sameMainNetAddress = paymentScript.GetDestinationAddress(Network.Main);

            Console.WriteLine("Is it possible to get BitcoinAddress from ScriptPubKey?");
            Console.WriteLine(mainNetAddress == sameMainNetAddress);
            Console.WriteLine();

            var samePublicKeyHash = (KeyId) paymentScript.GetDestination();

            Console.WriteLine("Is it possible to get PublicKeyHash from ScriptPubKey?");
            Console.WriteLine(publicKeyHash == samePublicKeyHash);
        }
    }
}