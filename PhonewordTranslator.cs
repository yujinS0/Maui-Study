using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp
{
    internal static class PhonewordTranslator
    {
        // [문자열을 입력받아 변환된 숫자 문자열을 반환하는 메서드]
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) // 입력 문자열이 비어 있거나 공백만 있는 경우, null을 반환
                return null;

            raw = raw.ToUpperInvariant(); // 입력 문자열을 대문자로 변환하여 일관된 처리를 보장

            var newNumber = new StringBuilder(); // 변환된 숫자를 저장할 StringBuilder 객체를 초기화
            foreach (var c in raw) // 입력 문자열의 각 문자를 순회
            {
                if (" -0123456789".Contains(c)) // 문자 c가 공백, 하이픈 또는 숫자인 경우, 그대로 추가
                    newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c); // 문자를 숫자로 변환
                    if (result != null)
                        newNumber.Append(result);
                    // Bad character?
                    else // 변환할 수 없는 문자가 포함된 경우, null을 반환
                        return null;
                }
            }
            return newNumber.ToString(); // 변환된 숫자 문자열을 반환
        }

        // [문자열에서 특정 문자의 존재 여부를 확인하는 확장 메서드]
        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0; // IndexOf를 사용하여 문자가 문자열에 포함되어 있는지 확인
        }

        // [키패드의 알파벳 그룹을 나타내는 digits 배열]
        static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        // [문자를 숫자로 변환하는 메서드]
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++) // 각 알파벳 그룹을 순회
            {
                if (digits[i].Contains(c)) // 문자가 해당 알파벳 그룹에 포함되면 대응하는 숫자를 반환
                    return 2 + i;
            }
            return null; // 어떤 알파벳 그룹에도 포함되지 않는 경우 null을 반환
        }
    }
}
