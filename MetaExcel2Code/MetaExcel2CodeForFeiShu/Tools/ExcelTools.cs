namespace MetaExcel2CodeForFeiShu.Tools;

public class ExcelTools
{
    public static string NumberToLetters(int number)
    {
        string result = string.Empty;
        while (number > 0)
        {
            int remainder = (number - 1) % 26;
            result = (char)('A' + remainder) + result;
            number = (number - 1) / 26;
        }
        return result;
    }
}