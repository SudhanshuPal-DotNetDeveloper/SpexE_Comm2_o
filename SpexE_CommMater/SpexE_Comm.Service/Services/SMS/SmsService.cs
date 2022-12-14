using SpexE_Comm.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static SpexE_Comm.Model.ConstantVariableModel;

namespace SpexE_Comm.Service
{
    public class SmsService : ISmService
    {
        #region Constructor

        private readonly ICommonService _commonService;
        public readonly IEncryptionService _encryptionService;

        public SmsService(ICommonService commonService,
            IEncryptionService encryptionService)
        {
            this._commonService = commonService;
            this._encryptionService = encryptionService;
        }

        #endregion

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="messageContent"></param>
        /// <param name="senderName"></param>
        /// <returns></returns>
        public bool SendSms(string mobileNumber, string messageContent, string senderName)
        {
            bool isSuccess = false;
            try
            {
                if (!string.IsNullOrEmpty(mobileNumber))
                {
                    //var isSent = SendWhatsAppMessage(mobileNumber, messageContent, senderName);

                    var index = mobileNumber.IndexOf(MobileExtention.INDIA);
                    if (index < 0)
                    {
                        mobileNumber = string.Format(TwilioCredentials.FORMATED_MOBILE_NUMBER, mobileNumber);
                    }
                    mobileNumber = _commonService.FormateMobileNumber(mobileNumber);

                    string accountSid = this.GetApiKeys((int)SpexE_CommApiKeys.TWILIO_ACCOUNT_SID);
                    string authToken = this.GetApiKeys((int)SpexE_CommApiKeys.TWILIO_AUTH_TOKEN);

                    TwilioClient.Init(accountSid, authToken);
                    var to = new PhoneNumber(mobileNumber);
                    var message = MessageResource.Create(
                        to,
                        from: new PhoneNumber(TwilioCredentials.TWILIO_NUMBER), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
                        body: messageContent);
                    var status = message.Status.ToString();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetApiKeys(int keyCode)
        {
            string apiKey = string.Empty;
            using (var spexE_Comm = new SpexE_CommContext())
            {
                var apiDetail = spexE_Comm.SpexCommKeys.Where(x => x.ApiCode == keyCode && x.IsActive == true).FirstOrDefault();
                if (apiDetail != null)
                {
                    apiKey = _encryptionService.DecryptApiKey(apiDetail.ApiKey);
                }
            }
            return apiKey;
        }
    }
}
