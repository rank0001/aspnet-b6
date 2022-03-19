// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
codes = codesRepo.SearchFor(predicate)
    .Select(c => new { c.Id, c.Flag })
    .AsEnumerable()
    .Select(c => new Tuple<string, byte>(c.Id, c.Flag))
    .ToList();