namespace SpexE_Comm.Model
{
    public class Response
    {  /// <summary>
       /// ErrorId
       /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// additional
        /// </summary>
        public string Value { get; set; }

        public string RedirectUrl { get; set; }

        /// <summary>
        /// Default cons
        /// </summary>
        public Response()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="responseCode">Response Code</param>
        /// <param name="responseMessage">Response Message</param>
        public Response(int responseCode, string responseMessage, string redirectUrl)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            RedirectUrl = redirectUrl;
        }


    }

    public class BlockChainApiResponse
    {  /// <summary>
       /// ErrorId
       /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ResponseMessage { get; set; }


        /// <summary>
        /// Default cons
        /// </summary>
        public BlockChainApiResponse()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="responseCode">Response Code</param>
        /// <param name="responseMessage">Response Message</param>
        public BlockChainApiResponse(int responseCode, string responseMessage)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }


    }

    public class OtpModel
    {
        public int ResponseCode { get; set; }
        public string OTP { get; set; }
        public string HiddenOtp { get; set; }
        public string PhoneNumber { get; set; }
    }
}
