using System.Text.RegularExpressions;
using ClosedXML.Excel;


var phoneNumberPattern = @"\b(0|\+84)(3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])[0-9]{7}\b";
// var pattern_2= @"(?<!\d)(0|\+84)(3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])[0-9]{7}(?!\d)";
var emailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}\b";
var codeIDPattern = @"\b(0[0-9]{2}|1[0-9]{2})\d{9}\b";
var birthDayPattern = @"\b\d{1,2}[\/\-\.]\d{1,2}[\/\-\.]\d{2,4}\b";
var namePattern = @"\b([A-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯẠ-ỹ][a-zàáâãèéêìíòóôõùúăđĩũơưạ-ỹ]+(?:\s+[A-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠƯẠ-ỹ][a-zàáâãèéêìíòóôõùúăđĩũơưạ-ỹ]+)+)\b";
var bankPattern = @"\b\d{8,16}\b";





var phoneNumber = File.ReadAllText("fake_vn_phones.txt");
MatchCollection matches = Regex.Matches(phoneNumber, phoneNumberPattern);
Console.WriteLine($"Found {matches.Count} phone numbers / 30 " );

if(Regex.IsMatch(phoneNumber, phoneNumberPattern))
{
    foreach (Match match in matches)
    {
        Console.WriteLine($"Matched phone number: {match.Value}");
    }
}
else
{
    Console.WriteLine("Phone number pattern not matched.");
}

Console.WriteLine("========================================");

var workbook = new XLWorkbook();
var filepath = "fake_data_20_rows.xlsx";
using (var xlWorkbook = new XLWorkbook(filepath))
{
    var worksheet = xlWorkbook.Worksheet(1); // Sheet đầu tiên
    var range = worksheet.RangeUsed(); // Lấy toàn bộ vùng có dữ liệu
    Console.WriteLine($"Used Range: {worksheet}");
    var rowcount = range.RowCount();
    var colcount = range.ColumnCount();
    Console.WriteLine($"Row count: {rowcount}, Column count: {colcount}");
    // Mảng chứa các pattern
    Console.WriteLine("========================================");
    for (int row = 1; row <= rowcount; row++)
    {
        for (int col = 1; col <= colcount; col++)
        {
            var cellValue = worksheet.Cell(row, col).GetString();

            if (Regex.IsMatch(cellValue, emailPattern))
            {
                Console.WriteLine($" {cellValue}");
            }
            if (Regex.IsMatch(cellValue, codeIDPattern))
            {
                Console.WriteLine($" {cellValue}");
            }
            if (Regex.IsMatch(cellValue, birthDayPattern))
            {
                Console.WriteLine($" {cellValue}");
            }
            if (Regex.IsMatch(cellValue, namePattern))
            {
                Console.WriteLine($" {cellValue}");
            }
            if (Regex.IsMatch(cellValue, bankPattern))
            {
                Console.WriteLine($" {cellValue}");
            }
        }
        Console.WriteLine("========================================");

    }
}

