using Domain;
using Xunit.Sdk;

namespace TestOldPhone
{
    public class OldPhoneTest
    {
        Boolean result;

        [Fact]
        public void OldPhonePad_ExampleCases_True()
        {
            // Examples from the prompt,problem
            result = (OldPhone.OldPhonePad("33#") == "E") ? true : throw new Exception();
            result = (OldPhone.OldPhonePad("227*#") == "B") ? true : throw new Exception();
            result = (OldPhone.OldPhonePad("4433555 555666#") == "HELLO") ? true : throw new Exception();
            result = (OldPhone.OldPhonePad("8 88777444666*664#") == "TURING") ? true : throw new Exception();
        }
        
        [Fact]
        public void OldPhonePad_InvalidInputCases_True()
        {
            // input not end with #
            result = (OldPhone.OldPhonePad("12345") == "you input is not valid") ? true : throw new Exception();
            // input with non number string
            result = (OldPhone.OldPhonePad("dsadasd#") == "you input is not valid") ? true : throw new Exception();

        }

        [Fact]
        public void OldPhonePad_OnlySharpSignCase_True()
        {
            // input only #
            result = (OldPhone.OldPhonePad("#") == "") ? true : throw new Exception();
        }

        [Fact]
        public void OldPhonePad_PressSameButtonFourTimes_True()
        {
            // when press '2' button 4 times
            result = (OldPhone.OldPhonePad("2222#") == "A") ? true : throw new Exception();
        }
        [Fact]
        public void OldPhonePad_OnlySpaceWord_True()
        {
            // when the word only have 0, output = " "
            result = (OldPhone.OldPhonePad("000#") == "   ") ? true : throw new Exception();
        }
        [Fact]
        public void OldPhonePad_DeleteMoreThanWord_True()
        {
            // when you have delete till you have no more word to delete
            result = (OldPhone.OldPhonePad("12345*******#") == "") ? true : throw new Exception();

        }
        [Fact]
        public void OldPhonePad_TestSevenAndNine_True()
        {
            // test wheter 7, 9 work properly
            result = (OldPhone.OldPhonePad("7 77 777 7777 9 99 999 9999#") == "PQRSWXYZ") ? true : throw new Exception();

        }

    }
}