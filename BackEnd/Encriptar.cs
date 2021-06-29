using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace LI4BackEnd
{
    // Clase Encriptar age como uma classe wraper da classe de criptografia "built-in" RijndaelManaged.
    class Encriptar
    {
        // Esta constante é usada para determinar o tamanho da chave do algoritmo de encriptação (em bits).
        // Divide-se por 8 de modo a obter o equivalente número em bytes.
        private const int tamanhoChave = 256;

        // Esta constante determina o número de iterações para a geração de bytes da chave.
        private const int iteracoes = 1000;

        public static string Encriptacao(string textoOriginal, string fraseChave)
        {
            // Sal e IV são gerados aleatoriamente de cada vez, mas está à cabeça do texto encriptado
            // de modo a que os mesmos valores sejam usados para a desencriptação. 
            var bytesStringSal = Gerador256BytesDeEntropia();
            var bytesStringIV = Gerador256BytesDeEntropia();
            var bytesTexto = Encoding.UTF8.GetBytes(textoOriginal);
            using (var password = new Rfc2898DeriveBytes(fraseChave, bytesStringSal, iteracoes))
            {
                var bytesChave = password.GetBytes(tamanhoChave / 8);
                using (var chaveSimetrica = new RijndaelManaged())
                {
                    chaveSimetrica.BlockSize = 256;
                    chaveSimetrica.Mode = CipherMode.CBC;
                    chaveSimetrica.Padding = PaddingMode.PKCS7;
                    using (var encriptador = chaveSimetrica.CreateEncryptor(bytesChave, bytesStringIV))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encriptador, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(bytesTexto, 0, bytesTexto.Length);
                                cryptoStream.FlushFinalBlock();
                                // Criar os bytes finais como uma concatenação dos bytes do sal, IV e string encriptada, gerados aleatóreamente.
                                var cipherTextBytes = bytesStringSal;
                                cipherTextBytes = cipherTextBytes.Concat(bytesStringIV).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Desencriptacao(string textoEncriptado, string fraseChave)
        {
            // Obtém a stream de bytes equivalentes a:
            // [32 bytes do Sal] + [32 bytes do IV] + [n bytes do texto encriptado].
            var bytesTextoEncriptadoSalIV = Convert.FromBase64String(textoEncriptado);
            // Obtém os bytes do sal extraindo os primeiros 32 bytes do texto Encriptado que lhe é fornecido (em bytes).
            var bytesStringSal = bytesTextoEncriptadoSalIV.Take(tamanhoChave / 8).ToArray();
            // Obtém os bytes do IV extraindo os próximos 32 bytes do texto encriptado que lhe é fornecido.
            var ivStringBytes = bytesTextoEncriptadoSalIV.Skip(tamanhoChave / 8).Take(tamanhoChave / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the textoEncriptado string.
            // Obtém o texto encriptado própriamente dito removendo os restantes 64 bytes do texto encriptado recebido.
            var cipherTextBytes = bytesTextoEncriptadoSalIV.Skip((tamanhoChave / 8) * 2).Take(bytesTextoEncriptadoSalIV.Length - ((tamanhoChave / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(fraseChave, bytesStringSal, iteracoes))
            {
                var bytesChave = password.GetBytes(tamanhoChave / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var desencriptador = symmetricKey.CreateDecryptor(bytesChave, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, desencriptador, CryptoStreamMode.Read))
                            {
                                var bytesTextoOriginal = new byte[cipherTextBytes.Length];
                                var contagemBytesDesencriptados = cryptoStream.Read(bytesTextoOriginal, 0, bytesTextoOriginal.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(bytesTextoOriginal, 0, contagemBytesDesencriptados);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Gerador256BytesDeEntropia()
        {
            var randomBytes = new byte[32]; // 32 bytes equivalem a 256 bits
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // preencher o array com bytes gerados aleatóreamene de modo a que sejam seguros.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
