using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using EllipticCurve;

namespace ColeCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateKey key1 = new PrivateKey();
            PublicKey wallet1 = key1.publicKey();

            PrivateKey key2 = new PrivateKey();
            PublicKey wallet2 = key2.publicKey();

            Blockchain colecoin = new Blockchain(2,100);

            Console.WriteLine("Start Miner");
            colecoin.MinePendingTransactions(wallet1);
            Console.WriteLine("\nBlance of wallet1 is $" + colecoin.GetBalanceOfWallet(wallet1).ToString());


            Transaction tx1 = new Transaction(wallet1, wallet2, 10);
            tx1.SignTransaction(key1);
            colecoin.addPendingTransaction(tx1);
            Console.WriteLine("Start Miner");
            colecoin.MinePendingTransactions(wallet2);
            Console.WriteLine("\nBlance of wallet1 is $" + colecoin.GetBalanceOfWallet(wallet1).ToString());
            Console.WriteLine("\nBlance of wallet2 is $" + colecoin.GetBalanceOfWallet(wallet2).ToString());

            string blockJSON = JsonConvert.SerializeObject(colecoin, Formatting.Indented);
            Console.WriteLine(blockJSON);

            if (colecoin.IsChainvalid())
            {
                Console.WriteLine("BlockChain is Valid!!!");

            }
            else
            {
                Console.WriteLine("BlockChain is NO GOOD");
            }
        }
    }



}
