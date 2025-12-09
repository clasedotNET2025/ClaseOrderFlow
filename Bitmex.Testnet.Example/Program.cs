

// Poke api Http examples


using Bitmex.Testnet.Example;
using System.Text.Json;

Uri uri = new Uri("https://pokeapi.co/api/v2/");

HttpClient client = new HttpClient();

var result = await client.GetAsync(uri + "pokemon/charmander");

Console.WriteLine(result.Content);


Console.WriteLine(" ---------------------------------------------------");

var content = await result.Content.ReadAsStringAsync();


Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(content)!;

//Console.WriteLine($"Pokemon name: {pokemon.name}");

Console.WriteLine(JsonSerializer.Serialize(pokemon.name));