namespace BurgerApi.Burgers.Dto;

public record ComboRequestDto(string nome, double preco, List<Guid> burgerIds);