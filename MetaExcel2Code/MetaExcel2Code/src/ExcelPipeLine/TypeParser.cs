﻿using System.Text.RegularExpressions;
using MetaExcel2Code.Config;

namespace MetaExcel2Code.Excel;

/** 类型解析器 */
public static class TypeParser
{
    // 正则表达式解析类型结构
    // 这个正则做了三部分捕获：
    // 1)  (?<type>[A-Za-z_]\w*)       基础类型
    // 2)  (?:<(?<generic> ... )>)?    可选泛型(多层嵌套) - 用平衡组匹配
    // 3)  (?:\((?<constraint>[^)]+)\))?  可选的小括号约束
    //
    // 注意：用平衡组(DEPTH)来匹配泛型内部任意多层 <...<...>...>
    private static readonly Regex TypeRegex = new Regex(
        // 基础类型 (字母或下划线开始、允许后续若干字母、数字、下划线等)
        @"^(?<type>[A-Za-z_]\w*)"
        + @"(?:<(?<generic>(?>[^<>]|<(?<DEPTH>)|>(?<-DEPTH>))+(?(DEPTH)(?!)))>)?"
        + @"(?:\((?<constraint>[^)]+)\))?"
        + @"$",
        RegexOptions.Compiled
    );

    /** 解析类型结构 */
    public static TypeStruct Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) throw new BusinessException(ErrorEnum.SHEET_NULL_TYPE, input);

        var match = TypeRegex.Match(input);
        if (!match.Success)
        {
            throw new BusinessException(ErrorEnum.SHEET_TYPE_NOT_FORMATTED, input);
        }

        return new TypeStruct(
            match.Groups["type"].Value,
            match.Groups["generic"].Success ? match.Groups["generic"].Value : null,
            match.Groups["constraint"].Success ? match.Groups["constraint"].Value : null
        );
    }
}