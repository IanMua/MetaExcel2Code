using MetaExcel2Code.Config;
using OfficeOpenXml;

namespace MetaExcel2Code.Excel;

public static class SheetParser
{
    public static void Parse(ExcelWorksheet sheet)
    {
        // 工作表名称
        string sheetName = sheet.Name;

        int totalRows = sheet.Dimension.End.Row;
        int totalColumns = sheet.Dimension.End.Column;

        // 是否读取类型
        Boolean isReadType = false;
        // 是否读取字段
        Boolean isReadFiled = false;

        string[] filed = new string[totalColumns];

        for (int row = 1; row <= totalRows; row++)
        {
            
            // 如果本行第一列字体是斜体，代表本行是注释，跳过
            if (sheet.Cells[row, 1].Style.Font.Italic) continue;
            
            // KEY
            string key = "";

            for (int col = 1; col <= totalColumns; col++)
            {
                // 如果是 `//` 代表本列是注释，跳过
                if (sheet.Cells[1, col].Text == "//") continue;

                // 读取实际值（公式值/文本）
                string? cellValue = sheet.Cells[row, col].Value.ToString();

                if (cellValue == null)
                {
                    if (!isReadType)
                        throw new BusinessException(ErrorEnum.SHEET_NULL_TYPE, $"{sheetName} 第{row}行，第{col}列的类型为空");
                    if (!isReadFiled)
                        throw new BusinessException(ErrorEnum.SHEET_NULL_FILED, $"{sheetName} 第{row}行，第{col}列的字段为空");

                    cellValue = "";
                }

                if (!isReadType)
                {
                    try
                    {
                        TypeStruct type = TypeParser.Parse(cellValue);
                    }
                    catch (BusinessException exception)
                    {
                        if (exception.Code == ErrorEnum.SHEET_NULL_TYPE)
                            throw new BusinessException(ErrorEnum.SHEET_NULL_TYPE, $"{sheetName} 第{row}行，第{col}列的类型为空");
                        if (exception.Code == ErrorEnum.SHEET_TYPE_NOT_FORMATTED)
                            throw new BusinessException(ErrorEnum.SHEET_TYPE_NOT_FORMATTED,
                                $"{sheetName} 第{row}行，第{col}列的类型格式不正确");
                    }
                }
            }
        }
    }
}