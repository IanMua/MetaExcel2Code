using System.Text;
using MetaExcel2CodeProgram.ExcelPipeLine;

namespace MetaExcel2CodeForFeiShu.ExcelPipeLine;

public static class CodeGenerate
{
    /// <summary>
    /// 生成 TypeScript 接口代码
    /// </summary>
    /// <param name="allSheets">数据: 表名 -> SheetStruct</param>
    /// <returns>TS 接口定义字符串</returns>
    public static string GenerateTsCode(Dictionary<string, SheetFullStruct> allSheets)
    {
        var sb = new StringBuilder();

        // 给最终的输出加一个开头注释可选
        sb.AppendLine("/** 静态数据库 */");
        sb.AppendLine("export class DBManager {");

        // 存储
        sb.AppendLine("    private static dbMap: Map<number | string, Map<number | string, any>> = new Map();");
        sb.AppendLine();

        sb.AppendLine("    // 获取数据库");
        sb.AppendLine(
            "    public static getDB(dbName: string): Map<number | string, any> | undefined {");
        sb.AppendLine("        return this.dbMap.get(dbName);");
        sb.AppendLine("    }");
        sb.AppendLine();

        sb.AppendLine("    // 获取数据库");
        sb.AppendLine(
            "    public static getDb(dbName: string): Map<number | string, any> | undefined {");
        sb.AppendLine("        return this.dbMap.get(dbName);");
        sb.AppendLine("    }");
        sb.AppendLine();

        sb.AppendLine("// ==================== 数据库GET方法 ====================");
        sb.AppendLine();

        foreach (var (sheetName, sheetFullStruct) in allSheets)
        {
            List<string> paramTypes = [];
            foreach (var sheetKey in sheetFullStruct.sheetStruct.sheetKeys)
            {
                int index = sheetFullStruct.fields.IndexOf(sheetKey);
                if (index == -1) throw new Exception($"{sheetName} 表中没有发现 {sheetKey}");
                string type = sheetFullStruct.types[index];
                paramTypes.Add($"{sheetKey}: {type}");
            }

            sb.AppendLine(
                $"    public static get{sheetName}({string.Join(", ", paramTypes)}): {sheetName} | undefined {{");
            sb.AppendLine($"    const db: Map<number | string, any> = this.dbMap.get(\"{sheetName}\");");
            if (sheetFullStruct.sheetStruct.sheetKeys.Count == 1)
            {
                sb.AppendLine(
                    $"    return db ? db.get({sheetFullStruct.sheetStruct.sheetKeys[0]}) : undefined;");
            }
            else
                sb.AppendLine(
                    $"    return db ? db.get({string.Join(" + \"_\" + ", sheetFullStruct.sheetStruct.sheetKeys)}) : undefined;");

            sb.AppendLine("    }");
            sb.AppendLine();
        }

        sb.AppendLine("    /** 初始化数据库 */");
        sb.AppendLine("    private static _initDatabase(_json: any, jsonKey: string): boolean {");
        sb.AppendLine("        interface IExportDB {");
        sb.AppendLine("            //数据库KEY");
        sb.AppendLine("            sheetKeys: string[],");
        sb.AppendLine("            //数据库数据");
        sb.AppendLine("            sheetData: object[],");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        const db: IExportDB = _json[jsonKey];");
        sb.AppendLine("        if (!db) {");
        sb.AppendLine("            console.error('db is null ! ', jsonKey);");
        sb.AppendLine("            return false;");
        sb.AppendLine("        }");
        sb.AppendLine();
        sb.AppendLine("        const dbData: Map<number | string, any> = new Map();");
        sb.AppendLine("        for (const data of db.sheetData) {");
        sb.AppendLine("            let keys: string[] = [];");
        sb.AppendLine("            Object.entries(data).forEach(([key, value]: [string, any]) => {");
        sb.AppendLine("                if (db.sheetKeys.includes(key)) keys.push(value);");
        sb.AppendLine("            });");
        sb.AppendLine("            dbData.set(keys.length === 1 ? keys[0] : keys.join(\"_\"), data);");
        sb.AppendLine("        }");
        sb.AppendLine("        this.dbMap.set(jsonKey, dbData);");
        sb.AppendLine("        return true;");
        sb.AppendLine("    }");
        sb.AppendLine();

        sb.AppendLine("    /** 初始化数据库 */");
        sb.AppendLine("    public static initDbWithIgnore(_json: any): boolean {");
        sb.AppendLine("        const arrJsonKeys: string[] = Object.keys(_json);");
        sb.AppendLine("        for (const jsonKey of arrJsonKeys) {");
        sb.AppendLine("            if (!DBManager._initDatabase(_json, jsonKey)) {");
        sb.AppendLine("                return false;");
        sb.AppendLine("            }");
        sb.AppendLine("        }");
        sb.AppendLine("        return true;");
        sb.AppendLine("    }");

        // DBManager类结束
        sb.AppendLine("}");
        sb.AppendLine();


        sb.AppendLine("// ==================== 自定义接口 ====================");
        sb.AppendLine();

        // 生成自定义类型接口
        Program.AppConfigs.typeList!.ForEach(typeConfig =>
        {
            sb.AppendLine($"export interface {typeConfig.name} {{");

            typeConfig.types.ForEach(type =>
            {
                TypeStruct typeStruct = TypeParser.Parse(type.type);
                sb.AppendLine($"    // {type.ann}");
                if (typeStruct.constraint is null) sb.AppendLine($"    {type.name}: {type.type}");
                else sb.AppendLine($"    {type.name}: {typeStruct.type}");
            });

            sb.AppendLine("}");
            sb.AppendLine();
        });

        sb.AppendLine("// ==================== 数据表接口 ====================");
        sb.AppendLine();

        // 生成表的接口
        foreach (var (sheetName, sheetFullStruct) in allSheets)
        {
            sb.AppendLine($"export interface {sheetName} {{");

            for (var i = 0; i < sheetFullStruct.fields.Count; i++)
            {
                sb.AppendLine($"    // {sheetFullStruct.annotations[i]}");
                sb.AppendLine($"    {sheetFullStruct.fields[i]}: {sheetFullStruct.types[i]};");
            }

            sb.AppendLine("}");
            sb.AppendLine();
        }
        
        sb.AppendLine("// ==================== 数据表字面量枚举 ====================");
        sb.AppendLine();

        sb.AppendLine("export const enum DBManagerEnum {");
        foreach (var (sheetName, _) in allSheets)
        {
            sb.AppendLine($"    {sheetName} = \"{sheetName}\",");
        }
        sb.AppendLine("}");

        return sb.ToString();
    }
}