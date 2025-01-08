using MetaExcel2CodeForFeiShu.Models;
using MetaExcel2CodeForFeiShu.Tools;
using MetaExcel2CodeProgram.ExcelPipeLine;

namespace MetaExcel2CodeForFeiShu.ExcelPipeLine;

public static class SheetParser
{
    public static SheetFullStruct Parse(CloudExcelSheetData sheet)
    {
        // 工作表名称
        string sheetName = sheet.name;

        int totalRows = sheet.values.Count;
        int totalColumns = sheet.values[0].Count;

        TypeStruct[] typeStructs = new TypeStruct[totalColumns];

        // 字段
        List<string> fields = [];

        // 类型
        List<string> types = [];

        // 注释
        List<string?> annotations = [];

        // KEY列
        List<string> keyCols = [];

        List<Dictionary<string, object?>> sheetData = [];

        for (int col = 0; col < totalColumns; col++)
        {
            string? colName = sheet.values[0][col];
            if (string.IsNullOrWhiteSpace(colName))
            {
                // 判断后一个单元格是不是也是空，如果是空，那就代表这是空置的单元格，不解析，结束
                if (string.IsNullOrWhiteSpace(sheet.values[0][Math.Min(col + 1, totalColumns - 1)]))
                {
                    break;
                }

                throw new Exception($"[sheet表 {sheetName}] [1行, {ExcelTools.NumberToLetters(col + 1)}列] -- 字段不能为空");
            }

            // 如果是 `//` 代表是注释 跳过
            if (colName == "//") continue;

            fields.Add(colName);

            string? annotation = sheet.values[1][col];
            annotations.Add(annotation);

            string? colValue = sheet.values[2][col];
            if (string.IsNullOrWhiteSpace(colValue))
            {
                throw new Exception($"[{sheetName} 表] [2行, {ExcelTools.NumberToLetters(col + 1)}列] -- 类型不能为空");
            }

            TypeStruct type;
            try
            {
                type = TypeParser.Parse(colValue);
                typeStructs[col] = type;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{sheetName} 表] [{3}行, {ExcelTools.NumberToLetters(col + 1)}列] -- {ex.Message}");
            }

            // 如果是 `id` 代表本列是主键，添加到主键列表
            if (type.constraint is "id")
            {
                keyCols.Add(colName);
            }

            types.Add(type.constraint is null ? colValue : type.type);
        }

        for (int row = 3; row < totalRows; row++)
        {
            // 如果本行第一列是 `//` 代表本行是注释，跳过
            if (sheet.values[row][0] == "//") continue;

            // 如果本行第一列是空，并且本行最后一列是空，代表本行为空
            if (sheet.values[row][0] == null && sheet.values[row][totalColumns - 1] == null)
            {
                // 如果下一行同上，代表剩下数据都是空的，停止解析
                if (sheet.values[Math.Min(row + 1, totalRows - 1)][0] == null &&
                    sheet.values[Math.Min(row + 1, totalRows - 1)][totalColumns - 1] == null)
                {
                    break;
                }
            }

            // 行数据
            Dictionary<string, object?> rowData = [];

            for (int col = 0; col < totalColumns; col++)
            {
                // 如果是 `//` 代表本列是注释，跳过
                if (sheet.values[0][col] == "//") continue;

                // 如果本单元格是空，并且第一行单元格是空(这么做是防止是string类型和自定义类型可以为空，导致跳过解析)，并且后面一个单元格也是空，那就停止解析当前行剩下的单元格
                if (string.IsNullOrWhiteSpace(sheet.values[row][col]) &&
                    string.IsNullOrWhiteSpace(sheet.values[0][col]) &&
                    string.IsNullOrWhiteSpace(sheet.values[row][Math.Min(col + 1, totalColumns - 1)]))
                {
                    break;
                }

                // 读取实际值（公式值/文本）
                string? cellValue = sheet.values[row][col];

                if (cellValue == null)
                {
                    if (typeStructs[col].type == "string")
                    {
                        cellValue = "";
                    }
                    // 自定义类型允许为空
                    else if (Program.IsCustomType(typeStructs[col].type))
                    {
                    }
                    else
                    {
                        throw new Exception(
                            $"[{sheetName} 表] [{row + 1}行, {ExcelTools.NumberToLetters(col + 1)}列] -- 值不能为空");
                    }
                }

                try
                {
                    object? parseValue = CellParser.Parse(typeStructs[col], cellValue);
                    rowData.Add(sheet.values[0][col]!, parseValue);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        $"[{sheetName} 表] [{row + 1}行, {ExcelTools.NumberToLetters(col + 1)}列] -- {ex.Message}");
                }
            }

            sheetData.Add(rowData);
        }

        if (keyCols.Count == 0)
        {
            keyCols.Add(fields[0]);
        }

        return new SheetFullStruct(
            fields,
            types,
            annotations,
            new SheetStruct
            {
                sheetKeys = keyCols,
                sheetData = sheetData
            }
        );
    }
}