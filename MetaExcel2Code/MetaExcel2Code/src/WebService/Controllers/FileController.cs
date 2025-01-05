using MetaExcel2Code.Excel;
using MetaExcel2Code.model;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace MetaExcel2Code.Controllers;

[ApiController]
[Route("api/file")]
public class FileController : ControllerBase
{
    [HttpGet("directory")]
    public IActionResult GetFileDirectory()
    {
        string path = @"F:\Project\Work\MGF\SlimeAssemble\Game_SlimeAssemble\SlimeAssemble\ExcelExporter";

        string?[] directories = Directory.GetDirectories(path).Select(Path.GetFileName).ToArray();

        Console.WriteLine("Directories:" + directories.Length);

        return Ok(directories);
    }

    [HttpGet("getAllWorkSpace")]
    public IActionResult GetAllWorkSpace()
    {
        string path = @"F:\Project\Work\MGF\SlimeAssemble\Game_SlimeAssemble\SlimeAssemble\ExcelExporter";

        List<WorkSpace> workSpaceList = [];

        string[] workSpace = Directory.GetDirectories(path);

        workSpace.ToList().ForEach((item) =>
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return;
            }

            ExcelInfo[] excels = Directory.GetFiles(item, "*.xlsx")
                .Select(excelPath => new ExcelInfo(Path.GetFileNameWithoutExtension(excelPath), excelPath))
                .ToArray();

            workSpaceList.Add(new WorkSpace(Path.GetFileName(item), item, excels));
        });

        return Ok(workSpaceList);
    }

    [HttpGet("parseExcel")]
    public IActionResult ParseExcel()
    {
        string path = @"F:\Project\Work\MGF\SlimeAssemble\Game_SlimeAssemble\SlimeAssemble\ExcelExporter\lzy\测试2.xlsx";

        using (var package = new ExcelPackage(new FileInfo(path)))
        {
            var worksheet = package.Workbook.Worksheets[0];

            int row = 1;
            int column = worksheet.Dimension.End.Column;

            for (int col = 1; col <= column; col++)
            {
                var cellValue = worksheet.Cells[row, col].Text;
                Console.WriteLine("cell: " + cellValue);
                var type = TypeParser.Parse(cellValue);
                Console.WriteLine(type);
            }
        }

        return Ok(1);
    }
}