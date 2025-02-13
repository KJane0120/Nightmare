using System.ComponentModel;
using System.Reflection;

namespace Nightmare
{
    internal class UtilityManager
    {
        static public string GetDescription(Enum e)
        {
            FieldInfo field = e.GetType().GetField(e.ToString());

            if (field != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return e.ToString();
        }

        /// <summary>
        /// 주어진 범위내의 숫자를 입력 로직 함수
        /// </summary>
        /// <param name="min">최솟값</param>
        /// <param name="max">최댓값</param>
        /// <param name="success">범위내 숫자였을때 불리는 함수</param>
        /// <param name="failure">범위밖 숫자였을때 불리는 함수</param>
        /// <param name="nextActionText">다음 행동 텍스트</param>
        /// <param name="waitTime">failure처리를 부르기까지 기다리는 시간</param>
        static public void InputNumberInRange(int min, int max, Action<int> success, Action failure, string nextActionText, int waitTime = 800)
        {
            while (true)
            {
                Console.Write($"\n{nextActionText}\n>> ");
                if (int.TryParse(Console.ReadLine(), out int number) && min <= number && number <= max)
                {
                    success?.Invoke(number);
                }
                else
                {
                    PrintErrorMessage();
                    failure?.Invoke();
                }

                Thread.Sleep(waitTime);
            }
        }

        static public void PrintErrorMessage()
        {
            ColorWriteLine("잘못된 입력입니다!", ConsoleColor.Red);
        }

        /// <summary>
        /// 지정 텍스트의 색깔을 변환하는 함수 WriteLine 버전
        /// </summary>
        /// <param name="text">색깔 바꿀 텍스트</param>
        /// <param name="color">색깔</param>
        static public void ColorWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //Write버전
        static public void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
