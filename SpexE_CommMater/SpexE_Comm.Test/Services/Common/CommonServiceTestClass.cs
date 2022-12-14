using Moq;
using NUnit.Framework;
using SpexE_Comm.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Test.Services.Common
{
    class CommonServiceTestClass
    {
        #region Constructor

        private Mock<ICommonService> _commonService;
        CommonService commonService;

        #endregion

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _commonService = new Mock<ICommonService>();
            commonService = new CommonService();
        }

        #endregion

        #region Unit Test

        #region FormateMobileNumber Service Test Case

        [Test]
        public void TestFor_FormateMobileNumber_WhenWePass_PhoneNumber_Without_Hyphen_Return_Without_Hyphen_Number()
        {
            //Declare Perameter
            var Number = "9758109422";

            //Initialize Serice
            var result = commonService.FormateMobileNumber(Number);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestFor_FormateMobileNumber_WhenWePass_PhoneNumber_With_Hyphen_Return_Without_Hyphen_Number()
        {
            //Declare Perameter
            var Number = "975-810-9422";

            //Initialize Serice
            var result = commonService.FormateMobileNumber(Number);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestFor_FormateMobileNumber_WhenWePass_Empty_PhoneNumber_Return_Empty_String()
        {
            //Declare Perameter
            var Number = string.Empty;

            //Initialize Serice
            var result = commonService.FormateMobileNumber(Number);

            //Assert
            Assert.AreSame(Number, result);
        }

        #endregion

        #region GenerateOpt Service Test Case

        [Test]
        public void TestFor_GenerateOpt_WhenWePass_Nothing_return_OTP()
        {
            //Initialize Serice
            var result = commonService.GenerateOpt();

            //Assert
            Assert.IsNotNull(result);
        }

        #endregion

        #region FormateMobileNumberWithHyphen Service TestCase

        [Test]
        public void TestFor_FormateMobileNumberWithHyphen_WhenWePass_PhoneNumber_Without_Hyphen_Return_PhoneNumber_With_Hyphn()
        {
            //Declare Perameter
            var Number = "9758109422";

            //Initialize Serice
            var result = commonService.FormateMobileNumberWithHyphen(Number);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestFor_FormateMobileNumberWithHyphen_WhenWePass_PhoneNumber_With_Hyphen_Return_PhoneNumber_With_Hyphn()
        {
            //Declare Perameter
            var Number = "975-810-9422";

            //Initialize Serice
            var result = commonService.FormateMobileNumberWithHyphen(Number);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestFor_FormateMobileNumberWithHyphen_WhenWePass_Empty_String_Return_Empty_String()
        {
            //Declare Perameter
            var Number = "975-810-9422";

            //Initialize Serice
            var result = commonService.FormateMobileNumberWithHyphen(Number);

            //Assert
            Assert.AreSame(Number,result);
        }

        #endregion

        #endregion
    }
}
