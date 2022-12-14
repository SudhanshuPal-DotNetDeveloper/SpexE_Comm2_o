using Microsoft.AspNetCore.DataProtection;
using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SpexE_Comm.Service
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptionKey { get; set; }
        public static string saltString;

        #region Construction
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "7339EC33#2822#40FC#B9A8#021E26AC9A1D";

        public EncryptionService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
            EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            saltString = "MpdERm8TUNM=";
        }
        #endregion

        public string EncryptData(string password)
        {
            string encryptedPassword = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(password))
                {

                    byte[] encode = new byte[password.Length];
                    encode = Encoding.UTF8.GetBytes(password);
                    encryptedPassword = Convert.ToBase64String(encode);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return encryptedPassword;
        }

        public Membership UpdateMembershipModel(MembershipModel membershipModel, Membership membership)
        {
            membership.UserSalt = Convert.ToBase64String(GetRandomBytes());
            membership.Password = AESEncrypt(membershipModel.Password, membership.UserSalt);
            return membership;
        }

        public static byte[] GetRandomBytes()
        {
            int saltLength = GetSaltLength();
            byte[] ba = new byte[saltLength];
            RNGCryptoServiceProvider.Create().GetBytes(ba);
            return ba;
        }

        public static int GetSaltLength()
        {
            return 8;
        }

        public string AESEncrypt(string data, string userSalt = null)
        {
            using (AesManaged aes = new AesManaged())
            {
                byte[] baPwd = Encoding.UTF8.GetBytes("234567");

                // Hash the password with SHA256
                byte[] baPwdHash = SHA256Managed.Create().ComputeHash(baPwd);

                byte[] baText = Encoding.UTF8.GetBytes(data.Trim());

                //if (compressText)
                //    baText = Compressor.Compress(baText);
                if (!String.IsNullOrEmpty(userSalt))
                {
                    saltString = userSalt;
                }
                byte[] baSalt = System.Convert.FromBase64String(saltString);//GetRandomBytes();
                byte[] baEncrypted = new byte[baSalt.Length + baText.Length];

                // Combine Salt + Text
                for (int i = 0; i < baSalt.Length; i++)
                    baEncrypted[i] = baSalt[i];
                for (int i = 0; i < baText.Length; i++)
                    baEncrypted[i + baSalt.Length] = baText[i];
                // Encrypt string    
                byte[] encrypted = AES_Encrypt(baEncrypted, baPwdHash, baSalt);
                var encryptedstring = Convert.ToBase64String(encrypted).Replace("+", "onyc");
                encryptedstring = Convert.ToBase64String(encrypted).Replace("/", "toep");
                return encryptedstring;
            }
        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            //byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    ///====== added by atul baluni on 2 april 2020
                    AES.Padding = PaddingMode.ISO10126;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        /// <summary>
        /// This method is used to dencrypt an encrypted string
        /// </summary>
        /// <param name="encryptPassword"></param>
        /// <returns></returns>
        public string AESDecryptData(string encryptPassword, bool IsAuthentication = false, string userSalt = null)
        {
            string decryptPasswordd = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(encryptPassword))
                {
                    if (string.IsNullOrEmpty(userSalt))
                    {
                        if (IsAuthentication)
                        {
                            UTF8Encoding encodepwd = new UTF8Encoding();
                            Decoder Decode = encodepwd.GetDecoder();
                            byte[] todecode_byte = Convert.FromBase64String(encryptPassword);
                            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                            char[] decoded_char = new char[charCount];
                            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                            decryptPasswordd = new String(decoded_char);
                        }
                        else
                        {
                            decryptPasswordd = AESDecrypt(encryptPassword, userSalt);
                        }
                    }
                    else
                    {
                        decryptPasswordd = AESDecrypt(encryptPassword, userSalt);
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return decryptPasswordd;
        }


        public string AESDecrypt(string data, string userSalt = null)
        {
            using (AesManaged aes = new AesManaged())
            {
                data = data.Replace("onyc", "+");
                data = data.Replace("toep", "/");
                //string password = "1234";
                byte[] baPwd = Encoding.UTF8.GetBytes("234567");

                // Hash the password with SHA256
                byte[] baPwdHash = SHA256Managed.Create().ComputeHash(baPwd);

                byte[] baText = Convert.FromBase64String(data);
                //string base64Byte = "64UgFCq7oxE=";
                if (!String.IsNullOrEmpty(userSalt))
                {
                    saltString = userSalt;
                }
                byte[] saltBytes = System.Convert.FromBase64String(saltString);
                byte[] baDecrypted = AES_Decrypt(baText, baPwdHash, saltBytes);

                // Remove salt
                int saltLength = GetSaltLength();
                byte[] baResult = new byte[baDecrypted.Length - saltLength];
                for (int i = 0; i < baResult.Length; i++)
                    baResult[i] = baDecrypted[i + saltLength];

                //if (decompressText)
                //    baResult = Compressor.Decompress(baResult);

                string result = (Encoding.UTF8.GetString(baResult)).TrimEnd();

                return result;
            }
        }


        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            byte[] decryptedBytes = null;


            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;
                    ///====== added by atul baluni on 2 april 2020
                    AES.Padding = PaddingMode.ISO10126;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }



        /// <summary>
        /// This method is used to encrypt a string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string AESEncryptData(string password, bool IsAuthentication = false, string userSalt = null)
        {
            string encryptedPassword = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(password))
                {
                    if (string.IsNullOrEmpty(userSalt))
                    {
                        if (IsAuthentication)
                        {
                            byte[] encode = new byte[password.Length];
                            encode = Encoding.UTF8.GetBytes(password);
                            encryptedPassword = Convert.ToBase64String(encode);
                        }
                        else
                        {
                            encryptedPassword = AESEncrypt(password);
                        }
                    }
                    else
                    {
                        encryptedPassword = AESEncrypt(password, userSalt);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return encryptedPassword;
        }

        public string DecryptApiKey(string encryptPassword)
        {
            string decryptPasswordd = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(encryptPassword))
                {
                    UTF8Encoding encodepwd = new UTF8Encoding();
                    Decoder Decode = encodepwd.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(encryptPassword);
                    int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    decryptPasswordd = new String(decoded_char);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return decryptPasswordd;
        }

        /// <summary>
        /// This method is used to dencrypt an encrypted string
        /// </summary>
        /// <param name="encryptPassword"></param>
        /// <returns></returns>
        public string DecryptData(string encryptPassword)
        {
            string decryptPasswordd = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(encryptPassword))
                {
                    UTF8Encoding encodepwd = new UTF8Encoding();
                    Decoder Decode = encodepwd.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(encryptPassword);
                    int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    decryptPasswordd = new String(decoded_char);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return decryptPasswordd;
        }
    }
}
