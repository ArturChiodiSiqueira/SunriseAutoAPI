using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Utils
    {
        public static bool CPFIsValid(string unformattedCpf)
        {
            string cpfString = unformattedCpf;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];

            if (unformattedCpf.Length != 11) return false;

            if (!long.TryParse(cpfString, out long cpfLong)) return false;

            digVerificador = (int)(cpfLong % 100);
            cpfLong /= 100;
            for (int i = 0; i < 9; i++)
            {
                aux = (int)(cpfLong % 10);
                digitosCPF[i] = aux;
                cpfLong /= 10;
            }
            for (int i = 0; i < digitosCPF.Length; i++)
            {
                if (i == digitosCPF.Length - 1) return false;
                if (digitosCPF[i] != digitosCPF[i + 1]) break;
            }
            v1 = v2 = 0;
            for (int i = 0; i < 9; i++)
            {
                v1 += digitosCPF[i] * (9 - i);
                v2 += digitosCPF[i] * (8 - i);
            }
            v1 = (v1 % 11) % 10;
            v2 += v1 * 9;
            v2 = (v2 % 11) % 10;
            if (v1 * 10 + v2 == digVerificador) return true;
            else return false;
        }

        public static string FormatCPF(string unformattedCpf)
            => $"{unformattedCpf.Substring(0, 3)}." +
            $"{unformattedCpf.Substring(3, 3)}." +
            $"{unformattedCpf.Substring(6, 3)}-" +
            $"{unformattedCpf.Substring(9, 2)}";

        public static bool MailIsValid(string mail)
        {
            string domain = "@admin.com";
            bool validator = mail.Contains(domain);

            if (validator)
                return true;
            else
                return false;
        }
    }
}
