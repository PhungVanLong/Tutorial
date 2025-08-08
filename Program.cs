using System.Text.RegularExpressions;

var pattern_1 = @"(0|\+84)(3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])[0-9]{7}";
// var pattern_2= @"(?<!\d)(0|\+84)(3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])[0-9]{7}(?!\d)";
var phoneNumber = File.ReadAllText("fake_vn_phones.txt");
MatchCollection matches = Regex.Matches(phoneNumber, pattern_1);
Console.WriteLine($"Found {matches.Count} phone numbers");
foreach (Match match in matches)
{
    Console.WriteLine(match.Value);
}
