using Newtonsoft.Json;

namespace DummyFind.Clients.Models;

public record AddressDto(
    [property: JsonProperty("address")] string Address,
    [property: JsonProperty("city")] string City,
    [property: JsonProperty("coordinates")] Coordinates Coordinates,
    [property: JsonProperty("postalCode")] string PostalCode,
    [property: JsonProperty("state")] string State
);

public record Bank(
    [property: JsonProperty("cardExpire")] string CardExpire,
    [property: JsonProperty("cardNumber")] string CardNumber,
    [property: JsonProperty("cardType")] string CardType,
    [property: JsonProperty("currency")] string Currency,
    [property: JsonProperty("iban")] string Iban
);

public record Company(
    [property: JsonProperty("address")] AddressDto Address,
    [property: JsonProperty("department")] string Department,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("title")] string Title
);

public record Coordinates(
    [property: JsonProperty("lat")] double? Lat,
    [property: JsonProperty("lng")] double? Lng
);

public record Hair(
    [property: JsonProperty("color")] string Color,
    [property: JsonProperty("type")] string Type
);

public record UsersResponse(
    [property: JsonProperty("users")] IEnumerable<User> Users,
    [property: JsonProperty("total")] int? Total,
    [property: JsonProperty("skip")] int? Skip,
    [property: JsonProperty("limit")] int? Limit
);

public record User(
    [property: JsonProperty("id")] int? Id,
    [property: JsonProperty("firstName")] string FirstName,
    [property: JsonProperty("lastName")] string LastName,
    [property: JsonProperty("maidenName")] string MaidenName,
    [property: JsonProperty("age")] int? Age,
    [property: JsonProperty("gender")] string Gender,
    [property: JsonProperty("email")] string Email,
    [property: JsonProperty("phone")] string Phone,
    [property: JsonProperty("username")] string Username,
    [property: JsonProperty("password")] string Password,
    [property: JsonProperty("birthDate")] string BirthDate,
    [property: JsonProperty("image")] string Image,
    [property: JsonProperty("bloodGroup")] string BloodGroup,
    [property: JsonProperty("height")] int? Height,
    [property: JsonProperty("weight")] double? Weight,
    [property: JsonProperty("eyeColor")] string EyeColor,
    [property: JsonProperty("hair")] Hair Hair,
    [property: JsonProperty("domain")] string Domain,
    [property: JsonProperty("ip")] string Ip,
    [property: JsonProperty("address")] AddressDto Address,
    [property: JsonProperty("macAddress")] string MacAddress,
    [property: JsonProperty("university")] string University,
    [property: JsonProperty("bank")] Bank Bank,
    [property: JsonProperty("company")] Company Company,
    [property: JsonProperty("ein")] string Ein,
    [property: JsonProperty("ssn")] string Ssn,
    [property: JsonProperty("userAgent")] string UserAgent
);

