using PayzeeCaseStudy.Business.Models.Transaction;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PayzeeCaseStudy.Business
{
    public static class HashOperations
    {
        public static string CreateHash3D(Vpos3DRequest request)
        {
            var apiKey = "kU8@iP3@"; 
            var hashString = $"{apiKey}{request.userCode}{request.rnd}{request.txnType}{request.totalAmount}{ request.customerId}{ request.orderId}{ request.okUrl}{ request.failUrl}";
            
            SHA512 s512 = SHA512.Create();

            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = BitConverter.ToString(bytes).Replace("-", "");

            return hash;

        }
        public static string CreateHashNoneSecure(VposNoneSecureRequest request)
        {
            var apiKey = "kU8@iP3@"; 
            var hashString = $"{apiKey}{request.userCode}{request.rnd}{request.txnType}{request.totalAmount}{ request.customerId}{ request.orderId}";

            SHA512 s512 = SHA512.Create();
            
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = BitConverter.ToString(bytes).Replace("-", "");

            return hash;
        }
    }
}
