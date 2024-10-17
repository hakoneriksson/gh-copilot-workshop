public class UrbsSeeder
{
    public static List<Urb> SeedUrbs()
    {
        // Generate 10 urbs (urbs are the same as herbs) using real herbs names using json format
        var urbsJson = """
                [
                    { "Id": 1, "Name": "Basil" },
                    { "Id": 2, "Name": "Rosemary" },
                    { "Id": 3, "Name": "Thyme" },
                    { "Id": 4, "Name": "Sage" },
                    { "Id": 5, "Name": "Mint" },
                    { "Id": 6, "Name": "Parsley" },
                    { "Id": 7, "Name": "Cilantro" },
                    { "Id": 8, "Name": "Dill" },
                    { "Id": 9, "Name": "Oregano" },
                    { "Id": 10, "Name": "Chives" }
                ]
                """;

        return System.Text.Json.JsonSerializer.Deserialize<List<Urb>>(urbsJson);
    }
}
