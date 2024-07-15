namespace BurgerApi.Burgers;

public class Burger {
    public Guid Id { get; init; }
    public String Nome { get; private set; }
    public bool Ativo { get; private set; }

    public Burger(String nome) {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;
    }
}