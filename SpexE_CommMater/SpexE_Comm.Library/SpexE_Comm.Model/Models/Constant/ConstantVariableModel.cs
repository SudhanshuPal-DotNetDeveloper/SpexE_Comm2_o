using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Model
{
    public static class ConstantVariableModel
    {
        public const string USER_NAME = "SpexE_CommUserName";
        public const string Key = "SpexE_Comm";
        public const string DISPLAY_NAME = "{0} {1}";

        public static class SpexE_commRole
        {
            public const string ADMIN = "Admin";
            public const string CUSTOMER = "Customer";
        }
        public static class Email
        {
            public const string USER_REGISTER_EMAIL = "Hi {0},<br>Thank you for registering with SpexE_Comm.<br> You are register as a customer with us.<br>Please click  on the link given below to confirm your registration <br>  <a title=\"SpexE_Comm - Everything Shop\" href=\"https://www.google.com\">Confirm</a> and complete your profile.<br><br>Thank You<br>SpexE_Comm Admin";
            public const string AGENT_REGISTER_EMAIL = "Hi {0},<br>Thank you for registering with SpexE_Comm.<br> You are register as a agent with us.<br>Please click  on the link given below to confirm your registration <br>  <a title=\"SpexE_Comm - Everything Shop\" href=\"https://www.google.com\">Confirm</a> <br>Please Note: Your account will be activated as soon as the SpexE_Comm Admin approve it.<br><br>Thank You<br>SpexE_Comm Admin";
            public const string REGISTER_SUBJECT = "SpexE_Comm : Registration Email";
        }
        public enum Session_TIME
        {
            TIME_OUT = 1
        }
        public static class ResponseCode
        {
            public const string SUCCESS = "200";
            public const string FAIL = "404";
            public const string REQUIRED_FIELDS_EMPTY = "400";
            public const string TWO_STEP_OTP_SENT = "100";
        }
        public static class SMS
        {
            public static class RecordMessage
            {
                public const string OTP_MESSAGE_REGISTER = "{0}<br>Use this code for your verification.<br><br>Thank you<br>SpexE_Comm Support<br>9758109422";
                public const string INVALID_OTP = "Otp Invalid Please Enter a valid OTP !!!";
            }
        }
        public static class MobileExtention
        {
            public const string INDIA = "+91";
        }
        public static class TwilioCredentials
        {
            public const string TWILIO_NUMBER = "+13464881953";
            public const string CONTENT_BODY = "{1}";
            public const string FORMATED_MOBILE_NUMBER = "+91{0}";
        }
        public static class ErrorMessage
        {
            public const string INVALID_USER = "Invalid user name/password.";
            public const string ERROR_MESSAGE = "Incorrect Email Or Password. Please try again.";
            public const string ACCOUNT_ALREADY_EXIST = "Your Account is already exist.";
        }

        public enum SpexE_CommApiKeys
        {
            TWILIO_ACCOUNT_SID = 1,
            TWILIO_AUTH_TOKEN = 2,
            SENDGRIT_API_KEY = 3,
            RAPBOOSTER_API_KEY = 4,
            SMTP_EMAIL = 5,
            SMTP_PASSWORD = 6,
            SMTP_PORT = 7,
            WHATSAPP_API_TOKEN = 8,
            WHATSAPP_API_PHONEID = 9
        }
        public static class HtmlTags
        {
            public const string BREAK = "<br>";
            public const string PARAGRAPH_OPEN = "<p>";
            public const string PARAGRAPH_CLOSE = "</p>";
        }

    }
}
