using System;
using System.Collections.Generic;
using NBitcoin;
using QBitNinja.Client;
using QBitNinja.Client.Models; 

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO-DO: To write in README how to use this project, and how to get data of transactions to use as examples.
            
            QBitNinjaClient client = new QBitNinjaClient(Network.Main);

            var transactionId = uint256.Parse("f13dc48fb035bbf0a6e989a26b3ecb57b84f85e0836e777d6edf60d87a4a2d94");
            GetTransactionResponse transactionResponse = client.GetTransaction(transactionId).Result;
            NBitcoin.Transaction transaction = transactionResponse.Transaction;

            Console.WriteLine("Getting the transaction ID from GetTransactionResponse: " + transactionResponse.TransactionId);
            Console.WriteLine("Getting the transaction ID from Transaction: " + transaction.GetHash());
            Console.WriteLine();

            Console.WriteLine("Getting received coins info:");
            
            List<ICoin> receivedCoins = transactionResponse.ReceivedCoins;
            foreach (var coin in receivedCoins)
            {
                Money amount = (Money) coin.Amount;
                Console.WriteLine("Amount: " + amount.ToDecimal(MoneyUnit.BTC));

                var paymentScript = coin.TxOut.ScriptPubKey;
                Console.WriteLine("ScriptPubKey: " + paymentScript);

                var address = paymentScript.GetDestinationAddress(Network.Main);
                Console.WriteLine("BitcointAddress: " + address);
            }

            Console.WriteLine();
            Console.WriteLine("Getting spent coins info:");

            decimal totalSpent = 0;
            List<ICoin> spentCoins = transactionResponse.SpentCoins;
            foreach (var coin in spentCoins)
            {
                Money amount = (Money) coin.Amount;
                totalSpent += amount.ToDecimal(MoneyUnit.BTC);
                Console.WriteLine("Amount: " + amount.ToDecimal(MoneyUnit.BTC));

                var paymentScript = coin.TxOut.ScriptPubKey;
                Console.WriteLine("ScriptPubKey: " + paymentScript);

                var address = paymentScript.GetDestinationAddress(Network.Main);
                Console.WriteLine("BitcointAddress: " + address);
            }

            Console.WriteLine();
            Console.WriteLine("Total Spent: " + totalSpent);
        }
    }
}