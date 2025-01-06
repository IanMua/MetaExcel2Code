using OfficeOpenXml;

namespace MetaExcel2CodeProgram.ExcelPipeLine;

public static class SheetParser
{
    public static SheetStruct Parse(ExcelWorksheet sheet)
    {
        // 工作表名称
        string sheetName = sheet.Name;

        int totalRows = sheet.Dimension.End.Row;
        int totalColumns = sheet.Dimension.End.Column;

        TypeStruct[] typeStructs = new TypeStruct[totalColumns];

        // KEY列
        List<string> keyCols = [];

        List<Dictionary<string, object>> sheetData = [];

        for (int col = 1; col <= totalColumns; col++)
        {
            string colName = sheet.Cells[1, col].Text;
            if (string.IsNullOrWhiteSpace(colName))
            {
                throw new Exception($"[{sheetName} 表] [{1}行, {col}列] -- 字段不能为空");
            }
            
            string colValue = sheet.Cells[2, col].Text;

            TypeStruct type;
            try
            {
                type = TypeParser.Parse(colValue);
                typeStructs[col - 1] = type;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{sheetName} 表] [{2}行, {col}列] -- {ex.Message}");
            }

            // 如果是 `id` 代表本列是主键，添加到主键列表
            if (type.constraint is "id")
            {
                keyCols.Add(colName);
            }
        }

        for (int row = 3; row <= totalRows; row++)
        {
            // 如果本行第一列字体是斜体，代表本行是注释，跳过
            if (sheet.Cells[row, 1].Style.Font.Italic) continue;

            // 行数据
            Dictionary<string, object> rowData = [];

            for (int col = 1; col <= totalColumns; col++)
            {
                // 如果是 `//` 代表本列是注释，跳过
                if (sheet.Cells[1, col].Text == "//") continue;

                // 读取实际值（公式值/文本）
                string? cellValue = sheet.Cells[row, col].Value.ToString();

                if (cellValue == null)
                {
                    if (typeStructs[col - 1].type == "string")
                    {
                        cellValue = "";
                    }
                    else
                    {
                        throw new Exception($"[{sheetName} 表] [{row}行, {col}列] -- 值不能为空");
                    }
                }

                try
                {
                    object parseValue = CellParser.Parse(typeStructs[col - 1], cellValue);
                    rowData.Add(sheet.Cells[1, col].Text, parseValue);
                }
                catch (Exception ex)
                {
                    throw new Exception($"[{sheetName} 表] [{row}行, {col}列] -- {ex.Message}");
                }
            }
            
            sheetData.Add(rowData);
        }

        return new SheetStruct
        {
            sheetKeys = keyCols.ToArray(),
            sheetData = sheetData
        };
    }
}