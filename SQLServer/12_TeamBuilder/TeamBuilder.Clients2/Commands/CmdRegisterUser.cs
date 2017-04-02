namespace TeamBuilder.Clients2.Commands
{
    using Models;
    using System;
    using System.Linq;
    using TeamBuilder.Clients2.Utilities;

    public class CmdRegisterUser
    {
        public string Executer(string[] cmdParam)
        {
            //0. <username> 
            //1. <password> 
            //2. <repeat-password> 
            //3. <firstName> 
            //4. <lastName> 
            //5. <age> 
            //6. <gender>

            Check.CheckLength(7, cmdParam);
            var username = cmdParam[0];
            if (username.Length < Constans.MinLength_Username ||
                username.Length < Constans.MaxLength_Username)
            {
                throw new ArgumentException(string.Format(
                    Constans.ErrorMessages.UsernameNotValid,
                    username
                    ));
            }

            //password.Any(c => char.IsDigit(c))
            //password.Any(char.IsDigit)

            var password = cmdParam[1];
            if (!password.Any(char.IsDigit) ||
                !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(
                    Constans.ErrorMessages.PasswordNotValid,
                    password
                    ));
            }

            var repPassword = cmdParam[2];
            if (password != repPassword)
            {
                throw new ArgumentException(string.Format(
                    Constans.ErrorMessages.PasswordDoesNotMatch,
                    password
                    ));
            }

            var firstname = cmdParam[3];
            var lastname = cmdParam[4];

            int age;
            var isNumber = int.TryParse(cmdParam[5], out age);
            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(string.Format(
                    Constans.ErrorMessages.AgeNotValid,
                    password
                    ));
            }

            Gender gender;
            var isGender = Enum.TryParse(cmdParam[6], out gender);
            return "";
        }
    }
}
